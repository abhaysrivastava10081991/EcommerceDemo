using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DataModels.Models
{
    public class OrderStatus
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int StatusId { get; set; }

        [Required,MaxLength(30)]
        public string? StatusName { get; set; }

        public bool Archived { get; set; }=false;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; }
    }
}
