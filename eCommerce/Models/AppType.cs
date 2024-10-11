using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace eCommerce.Models
{
    // Refactor later
    public class AppType
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Name { get; set; }

    }
}
