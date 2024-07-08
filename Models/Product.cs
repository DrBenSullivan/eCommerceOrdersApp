using System.ComponentModel.DataAnnotations;

namespace eCommerceOrdersApp.Models
{
    public class Product
    {
        [Required(ErrorMessage = "{0} can't be blank")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} should be a valid integer number")]
        [Display(Name = "Product Code")]
        public int? ProductCode { get; set; }

        [Required(ErrorMessage = "{0} can't be blank")]
        [Range(1, double.MaxValue, ErrorMessage = "{0} should be a valid double number")]
        public double? Price { get; set; } = null;

        [Required(ErrorMessage = "{0} can't be blank")]
        [Range(1, int.MaxValue, ErrorMessage = "{0} should be a valid integer number")]
        public int? Quantity { get; set; } = null;
    }
}
