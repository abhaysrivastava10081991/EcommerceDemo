using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DataModels.Models
{
    public class ProductDetails
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        public string? Width { get; set; }
        public string? Height { get; set; }
        public string? Size { get; set; }
        public string? Color { get; set; }
        public string? HandleType { get; set; }
        public string? HandleShape { get; set; }
        public string? HandleThickNess { get; set; }
        public bool IsAvailable { get; set; } = true;
        public bool Archived { get; set; }=false;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? CreatedBy { get; set; }
    }
}
