using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DataModels.Models
{
    public class Order
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string UserId { get; set; }
        public int OrderStatusId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
        public bool Archived { get; set; } = false;
        public DateTime CreatedDate { get; set; }=DateTime.Now;
        public string CreatedBy { get; set; }
    }
}
