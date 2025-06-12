using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;


namespace Ecommerce.DataModels.Models
{
    public class CartDetails
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int? ShoppingCartId { get; set; }
        [Required]
        public int? ProductId { get; set; }
        [Required]
        public int? Quantity { get; set; }
        public double? UnitPrice { get; set; }
        public Product Product { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public bool Archived { get; set; } = false;
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public string CreateBy { get; set; }
    }
}
