using Ecommerce.DataModels.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace Ecommerce.DataModels.ModelView
{
    public class ProductVM
    {
        public Product Product { get; set; }
        
        [ValidateNever]
        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}
