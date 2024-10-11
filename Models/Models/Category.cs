using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la categoría es obligatorio")]
        public string Name { get; set; }

        [Required(ErrorMessage = "La orden es obligatoria")]
        [Range(1, int.MaxValue, ErrorMessage = "El valor debe ser mayor que cero")]
        public int ShowOrder { get; set; }
    }
}
