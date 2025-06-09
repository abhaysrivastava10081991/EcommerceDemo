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

    //public IActionResult Index()
    //{
    //    List<Product> products = _unitOfWork.Product.GetAll(includeProperties: "Category").ToList();
    //    return View(products);
    //}

    public IActionResult Index(string? searchString)
    {
        var products = _unitOfWork.Product.GetAll(includeProperties: "Category").ToList();
        if (!string.IsNullOrEmpty(searchString))
        {
            products = products.Where(p =>
                (!string.IsNullOrEmpty(p.Name) && p.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase)) ||
                (!string.IsNullOrEmpty(p.Description) && p.Description.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            ).ToList();
        }

        return View(products.ToList());
    }

    public IActionResult Details(int? productId)
    {
        Product products = _unitOfWork.Product.Get(u=>u.ID == productId, includeProperties: "Category");
        ProductDetails productDetails = _unitOfWork.ProductDetails.Get(u => u.ProductId == productId);
        if (products == null || productDetails == null)
        {
            return NotFound();
        }
        else
        {
            products.ProductDetails = productDetails;
            products.Category = _unitOfWork.Category.Get(u => u.ID == products.CategoryId);
        }
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
