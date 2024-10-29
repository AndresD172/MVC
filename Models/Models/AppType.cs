using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using Utilities;

namespace Models
{
    [Authorize(Roles = Constants.AdminRole)]
    public class AppType
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Name { get; set; }

    }
}
