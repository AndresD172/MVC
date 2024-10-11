using Microsoft.AspNetCore.Mvc.Rendering;
using Models;

namespace eCommerce.ViewModels
{
    public class ProductViewModel
    {
        public Product? Product { get; set; }
        public IEnumerable<SelectListItem>? Categories { get; set; }
        public IEnumerable<SelectListItem>? AppTypes { get; set; }
    }
}
