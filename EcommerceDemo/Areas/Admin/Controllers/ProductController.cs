using Ecommerce.DataAccess.Repository;
using Ecommerce.DataAccess.Repository.IRepository;
using Ecommerce.DataModels.Models;
using Ecommerce.DataModels.ModelView;
using Ecommerce.DataUtility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace EcommerceDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class ProductController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Product> products = _unitOfWork.Product.GetAll(includeProperties : "Category").ToList();
            return View(products);
        }
        public IActionResult Upsert(int? id)
        {
            ProductVM productVM = new ProductVM()
            {
                Product = new Product(),
                CategoryList = _unitOfWork.Category.GetAll().Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.ID.ToString()
                })
            };

            if(id==null || id==0)
            {
                return View(productVM);
            }
            else
            {
                productVM.Product = _unitOfWork.Product.Get(o => o.ID == id);
                return View(productVM);
            }
               
        }
        [HttpPost]
        public IActionResult Upsert(ProductVM productVM, IFormFile file)
        {
            string DisMsg = "";
            ModelState.Remove("file");
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\products");
                    if (!Directory.Exists(productPath))
                    {
                        Directory.CreateDirectory(productPath);
                    }
                    if(!string.IsNullOrEmpty(productVM.Product.ImageUrl))
                    {
                        var oldImageUrlPath = Path.Combine(wwwRootPath, productVM.Product.ImageUrl.TrimStart('\\'));
                        if(System.IO.File.Exists(oldImageUrlPath))
                        {
                            System.IO.File.Delete(oldImageUrlPath);
                        }
                    }
                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    productVM.Product.ImageUrl = @"\images\products\" + fileName;

                    if (productVM.Product.ID==0)
                    {
                        DisMsg = "Product Created Successfully";
                        _unitOfWork.Product.Add(productVM.Product);
                    }
                    else
                    {
                        DisMsg = "Product Updated Successfully";
                        _unitOfWork.Product.Update(productVM.Product);
                    }
                }
                _unitOfWork.Save();
                TempData["Success"] = DisMsg;
                return RedirectToAction("Index");
            }
            else
            {
                productVM.CategoryList = _unitOfWork.Category.GetAll().Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.ID.ToString()
                });
                
                return View(productVM);
            }
                
        }

        
        //public IActionResult Delete(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }

        //    Product? product = _unitOfWork.Product.Get(o => o.ID == id); ;

        //    if (product == null)
        //    {
        //        return NotFound();

        //    }
        //    return View(product);
        //}

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Product? product = _unitOfWork.Product.Get(o => o.ID == id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                _unitOfWork.Product.Remove(product);
                _unitOfWork.Save();
                TempData["Success"] = "Product Deleted Successfully";
                return RedirectToAction("Index");
            }

        }

        #region Api Call

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Product> objproductLists = _unitOfWork.Product.GetAll(includeProperties: "Category").ToList();
            return Json(new {data= objproductLists });
        }
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var productDelete = _unitOfWork.Product.Get(u => u.ID == id);
            if(productDelete!=null)
            {
                string oldImgPath=  Path.Combine(_webHostEnvironment.WebRootPath, productDelete.ImageUrl.TrimStart('\\'));
                if (System.IO.File.Exists(oldImgPath))
                {
                    System.IO.File.Delete(oldImgPath);
                }
            }
            _unitOfWork.Product.Remove(productDelete);
            _unitOfWork.Save();
            return Json(new { success=true,Message="Product Deleted Successfully"});
        }
        #endregion

    }
}


