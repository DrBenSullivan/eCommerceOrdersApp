using System.ComponentModel.DataAnnotations;

namespace eCommerceOrdersApp.Models
{
    public class Product
    {
        [Required(ErrorMessage = "{0} can't be blank")]
        [Range(1, 99999)]
        public int? ProductCode { get; set; }
        [Required(ErrorMessage = "{0} can't be blank")]
        public double? Price { get; set; } = null;
        [Required(ErrorMessage = "{0} can't be blank")]
        public int? Quantity { get; set; } = null;
    }


}
