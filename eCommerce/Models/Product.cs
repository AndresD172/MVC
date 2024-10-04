using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerce.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del producto es obligatorio")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "La descripción corta es obligatoria")]
        public string? ShortDescription { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "El precio del producto es obligatorio")]
        public double Price { get; set; }

        public string? ImageUrl { get; set; }


        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }

        public virtual Category? Category { get; set; }

        [ForeignKey("TipoAplicacionId")]
        public int TipoAplicacionId { get; set; }

        public virtual AppType? TipoAplicacion { get; set; }
    }
}