using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DataModels.Models
{
    public class ShoppingCart
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [DisplayName("User Id")]
        public string? UserId { get; set; }

        public ICollection<CartDetails> CartDetails { get; set; }
        public bool Archived { get; set; } = false;
        public DateTime? CreatedDate { get; set; } =DateTime.Now;
        public string CreatedBy { get; set; }
    }
}
