using Ecommerce.DataAccess.Repository;
using Ecommerce.DataAccess.Repository.IRepository;
using EcommerceDemo.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace EcommerceDemo.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ICartRepository _cartRepository;
        public CartController(ApplicationDbContext dbContext, ICartRepository cartRepository)
        {
            _dbContext = dbContext;
            _cartRepository = cartRepository;
        }
        public async Task<IActionResult> AddItem(int productId,int qty=1,int redirect=0)
        {
            var cartCount = await _cartRepository.AddItem(productId, qty);
  
            if (redirect == 0)
            {
                return Ok(cartCount);
            }
           return RedirectToAction("GetUserCart");
        }

        public async Task<IActionResult> RemoveItem(int productId)
        {
            var cartCount = await _cartRepository.RemoveItem(productId);
            return RedirectToAction("GetUserCart");
        }

        public async Task<IActionResult> GetUserCart()
        {
            var cart = await _cartRepository.GetUserCart();
            return View(cart);
        }

        public async Task<IActionResult> GetTotalItemInCart()
        {
            int cartItem = await _cartRepository.getCartItemCount();
            return Json(cartItem);
        }
    }
}
