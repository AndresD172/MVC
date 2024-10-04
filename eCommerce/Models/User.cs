using Microsoft.AspNetCore.Identity;

namespace eCommerce.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
    }
}
