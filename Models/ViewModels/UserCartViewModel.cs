using Models;

namespace eCommerce.ViewModels
{
    public class UserCartViewModel
    {
        public User User { get; set; }
        public IList<Product> Products { get; set; }
    }
}
