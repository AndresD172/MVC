using eCommerce.Models;

namespace eCommerce.ViewModels
{
    public class UserCartViewModel
    {
        public User user { get; set; }
        public IList<Product> products { get; set; }
    }
}
