using Ecommerce.DataAccess.Repository.IRepository;
using Ecommerce.DataModels.Models;
using EcommerceDemo.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DataAccess.Repository
{
    public class UserOrderRepository : IUserOrderRepository
    {
        private readonly  ApplicationDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<IdentityUser> _userManager;
        public UserOrderRepository(ApplicationDbContext dbContext , IHttpContextAccessor httpContextAccessor, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }
        public async Task<IEnumerable<Order>> UserOrders()
        {
            var userId= getUserId();
            if(string.IsNullOrEmpty(userId))
            {
                throw new Exception("User not loged in");
            }
            var orders = await _dbContext.Orders.
                Include(o => o.OrderDetails).
                 Include(o => o.OrderStatus).
                Include(p=>p.Products).
                ThenInclude(p=>p.ProductDetails).
                Include(c=>c.Category)
                .Where(o => o.UserId == userId && !o.Archived)
                .ToListAsync();
            // Logic to handle user order
            // This is a placeholder for the actual implementation
            // You would typically interact with the _dbContext to save the order details
            return orders; // Simulating async operation
        }
        private string getUserId()
        {
            var principal = _httpContextAccessor.HttpContext?.User;
            var UserId = _userManager.GetUserId(principal);
            return UserId ?? string.Empty;
        }

    }
}
