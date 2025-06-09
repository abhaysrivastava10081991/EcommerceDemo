using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DataModels.Models
{
    public class OrderDetails
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double? UnitPrice { get; set; }
        public Order Order { get; set; }
        public bool Archived { get; set; } = false;
        public DateTime CreatedDate { get; set; }= DateTime.Now;
        public string CreatedBy { get; set; }

    }
}
