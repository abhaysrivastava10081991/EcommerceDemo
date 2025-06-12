using Ecommerce.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EcommerceDemo.Areas.Customer.Controllers
{
    [Authorize]
    [Area("Customer")]
    public class UserOrderController : Controller
    {
       private readonly IUserOrderRepository _userOrderRepository;
        public UserOrderController(IUserOrderRepository userOrderRepository)
        {
            _userOrderRepository=userOrderRepository;
        }
        public async Task<IActionResult> UserOrders()
        {
            var userOrder= await _userOrderRepository.UserOrders();
            return View();
        }
    }
}
