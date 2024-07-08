using eCommerceOrdersApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceOrdersApp.Controllers
{
    public class HomeController : Controller
    {
        [Route("order")]
        public IActionResult Order(Order order)
        {
            if (!ModelState.IsValid)
            {
                string errors = string.Join("\n", ModelState.Values
                    .SelectMany(val => val.Errors)
                    .Select(err => err.ErrorMessage)
                );
                return BadRequest(errors);
            }

            return Ok(order.OrderNo);
        }
    }
}
