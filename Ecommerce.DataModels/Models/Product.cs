using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

using EcommerceDemo.Models;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Http;

namespace Ecommerce.DataModels.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [DisplayName("Name")]
        public string? Name { get; set; }
        [Required]
        [DisplayName("Description")]
        public string? Description { get; set; }
        [Required]
        [DisplayName("Price")]
        public double? Price{ get; set; }

        [DisplayName("Discount")]
        public double? Discount { get; set; }

        [ValidateNever]
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }

        public int ProductId { get; set; }
        [ValidateNever]
        public ProductDetails? ProductDetails { get; set; }
       // [ValidateNever]
        //public OrderDetails? OrderDetails { get; set; }
        //[ValidateNever]
        //public CartDetails? CartDetails { get; set; }
    }
}
