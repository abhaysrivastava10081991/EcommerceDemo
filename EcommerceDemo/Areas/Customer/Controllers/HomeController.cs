using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EcommerceDemo.Models;
using Ecommerce.DataAccess.Repository.IRepository;
using Ecommerce.DataModels.Models;

namespace EcommerceDemo.Controllers;

[Area("Customer")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private IUnitOfWork _unitOfWork;
    public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        List<Product> products = _unitOfWork.Product.GetAll(includeProperties: "Category").ToList();
        return View(products);
    }

    public IActionResult Details(int? productId)
    {
        Product products = _unitOfWork.Product.Get(u=>u.ID == productId, includeProperties: "Category");
        return View(products);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
