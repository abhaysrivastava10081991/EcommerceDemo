
using Ecommerce.DataAccess.Repository.IRepository;
using Ecommerce.DataModels.Models;
using EcommerceDemo.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ecommerce.DataAccess.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CartRepository(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }
        public async Task<int> AddItem(int productId,int unitPrice, int qty)
        {
            string userId = getUserId();
            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                if (string.IsNullOrEmpty(userId))
                {
                    throw new Exception("Invalid userid");
                }
                var cart = await getCart(userId);
                if (cart == null)
                {
                    cart = new ShoppingCart
                    {
                        UserId = userId,
                        CreatedBy = userId,
                        CreatedDate = DateTime.Now
                    };
                    _dbContext.ShoppingCart.Add(cart);
                }
                _dbContext.SaveChanges();

                //cart detail section

                var cartItem = await _dbContext.CartDetails
                    .FirstOrDefaultAsync(c => c.ProductId == productId && c.ShoppingCartId == cart.ID);

                if (cartItem is not null)
                {
                    // If the item already exists in the cart, update the quantity
                    cartItem.Quantity += qty;
                }
                else
                {
                    // If the item does not exist, create a new cart detail entry
                    cartItem = new CartDetails
                    {
                        ShoppingCartId = cart.ID,
                        ProductId = productId,
                        Quantity = qty,
                        UnitPrice= unitPrice,
                        CreateBy = userId
                    };
                    _dbContext.CartDetails.Add(cartItem);
                }
                await _dbContext.SaveChangesAsync();
                transaction.Commit();
            }
            catch (Exception ex)
            {
            }
            var totoalItems = await getCartItemCount(userId);
            return totoalItems; // Item added successfully
        }
        public async Task<ShoppingCart> GetUserCart()
        {
            var userId=getUserId();
            if(userId == null)
            {
                throw new Exception("Invalid userid");
            }

            var ShoppingCarts = await _dbContext.ShoppingCart
                .Where(c => c.UserId == userId && !c.Archived)
                .Include(c => c.CartDetails)
                .ThenInclude(cd => cd.Product)
                .ThenInclude(cat => cat.Category).FirstOrDefaultAsync();

            return ShoppingCarts;
        }
        public async Task<int> RemoveItem(int productId)
        {
            string userId = getUserId();
            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                if (string.IsNullOrEmpty(userId))
                {
                    throw new Exception("Invalid userid");
                }
                var cart = await getCart(userId);
                if (cart is null)
                {
                    throw new Exception("cart is empty"); // No cart found for the user
                }
                    //cart detail section
                    var cartItem = await _dbContext.CartDetails
                        .FirstOrDefaultAsync(c => c.ProductId == productId && c.ShoppingCartId == cart.ID);
                if (cartItem is null)
                {
                    throw new Exception("no items in cart");
                }
                else if(cartItem.Quantity==1)
                {
                    _dbContext.CartDetails.Remove(cartItem);
                }
                else
                {
                    cartItem.Quantity= cartItem.Quantity-1;
                }
                await _dbContext.SaveChangesAsync();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                throw new Exception("Invalid userid");
            }
            var totalItems = await getCartItemCount(userId);
            return totalItems; // Item removed successfully
        }
        public async Task<ShoppingCart> getCart(string userId)
        {
            var cart = await _dbContext.ShoppingCart.FirstOrDefaultAsync(c => c.UserId == userId && !c.Archived);
            return cart;
        }

        public async Task<int> getCartItemCount(string userId="")
        {
            if(string.IsNullOrEmpty(userId))
            {
                userId = getUserId();
            }
            var data = await (from cart in _dbContext.ShoppingCart
                        join cartdet in _dbContext.CartDetails on cart.ID equals cartdet.ShoppingCartId
                        where cart.UserId == userId
                              select new
                        {
                            cartdet.ID
                        }).ToListAsync();

            return data.Count;

        }
        private string getUserId()
        {
            var principal = _httpContextAccessor.HttpContext?.User;
            var UserId = _userManager.GetUserId(principal);
            return UserId ?? string.Empty;
        }

        public async Task<bool> DoCheckOut()
        {
            using var transaction = _dbContext.Database.BeginTransaction();
            try
            {
                string userId = getUserId();
                if(string.IsNullOrEmpty(userId))
                {
                    throw new Exception("not loged in");
                }
                var cart = await getCart(userId);
                if(cart is null)
                {
                    throw new Exception("Invalid Cart");
                }
                var cartDetails = await _dbContext.CartDetails.Where(a => a.ShoppingCartId == cart.ID).ToListAsync(); 
                if (cartDetails.Count==0 )
                {
                    throw new Exception("Cart is empty");
                }
                var order = new Order
                {
                    UserId = userId,
                    OrderDate = DateTime.Now,
                    CreatedDate = DateTime.Now,
                    CreatedBy = userId,
                    OrderStatusId = 2,
                };
                _dbContext.Orders.Add(order);
                _dbContext.SaveChanges();

                foreach(var item in cartDetails)
                {
                    var orderDet = new OrderDetails
                    {
                        ProductId = Convert.ToInt32(item.ProductId),
                        OrderId = order.ID,
                        Quantity = Convert.ToInt32(item.Quantity),
                        UnitPrice = item.UnitPrice,
                        CreatedBy = userId,
                    };
                    _dbContext.OrderDetails.Add(orderDet);
                    _dbContext.SaveChanges();
                }

                // Removing the Cart Details

                _dbContext.CartDetails.RemoveRange(cartDetails);
                _dbContext.SaveChanges();
                transaction.Commit();
                return true;

            }
            catch(Exception ex)
            {
                return false;
                throw;
            }
        }
    }
}
