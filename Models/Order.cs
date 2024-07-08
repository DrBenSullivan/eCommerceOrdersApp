using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace eCommerceOrdersApp.Models
{
    public class Order : IValidatableObject
    {
        [BindNever]
        [Display(Name = "Order Number")]
        public int? OrderNo { get; set; } = new Random().Next(1, 99999);

        [Required(ErrorMessage = "{0} can't be blank")]
        [Display(Name = "Order Date")]
        public DateTime? OrderDate { get; set; }

        [Required(ErrorMessage = "{0} can't be blank")]
        [Display(Name = "Invoice Price")]
        public double? InvoicePrice { get; set; } = null;

        [Required(ErrorMessage = "{0} can't be blank")]
        public List<Product> Products { get; set; } = new List<Product>();

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            double productPriceTotal = 0;

            if (Products.Any())
            {
                foreach (var product in Products)
                {
                    if (product.Price != null && product.Quantity != null)
                    {
                        productPriceTotal += (double)(product.Price * product.Quantity);
                    }
                }
            }

            if (productPriceTotal != (double)InvoicePrice)
            {
                yield return new ValidationResult(
                    "InvoicePrice doesn't match with the total cost of the specified products in the order.", 
                    [nameof(InvoicePrice)]
                );
            }

            if (OrderDate < DateTime.Parse("2000-01-01"))
            {
                yield return new ValidationResult(
                    "OrderDate must be after 2000-01-01.",
                    [nameof(OrderDate)]
                );
            }
        }
    }
}
