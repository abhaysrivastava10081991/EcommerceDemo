using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EcommerceDemo.Models
{
    /// <summary>
    /// Represents a category of products in the e-commerce application.
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Primary key for the category.
        /// </summary>
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// Name of the category.
        /// </summary>
        [Required]
        [DisplayName("Category Name")]
        public string? Name { get; set; }
        /// <summary>
        /// Description of the Display Order.
        /// </summary>
        [DisplayName("Display Order")]
        [Range(1,1000)]
        public int DisplayOrder { get; set; }
    }
}

