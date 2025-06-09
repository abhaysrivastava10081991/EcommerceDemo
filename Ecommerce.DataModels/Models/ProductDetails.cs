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
        public double? Width1 { get; set; }
        public double? Width2 { get; set; }
        public double? Width3 { get; set; }
        public double? Height1 { get; set; }
        public double? Height2 { get; set; }
        public double? Height3 { get; set; }
        public string? GripColour1 { get; set; }
        public string? GripColour2 { get; set; }
        public string? GripColour3 { get; set; }
        public string? BatShape1 { get; set; }
        public string? BatShape2 { get; set; }
        public string? BatShape3 { get; set; }
        public bool Archived { get; set; }=false;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? CreatedBy { get; set; }
    }
}
