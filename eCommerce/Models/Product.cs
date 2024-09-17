using eCommerce.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Product
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre del producto es obligatorio")]
    public string Name { get; set; }

    [Required(ErrorMessage = "La descripción corta es obligatoria")]
    public string ShortDescription { get; set; }

    [Required(ErrorMessage = "La descripción es obligatoria")]
    public string Description { get; set; }

    [Required(ErrorMessage = "El precio del producto es obligatorio")]
    public double Price { get; set; }

    public string ImageUrl { get; set; }

    [ForeignKey("CategoryKey")]
    public virtual Category Category { get; set; }

    [ForeignKey("TipoAplicacionKey")]
    public virtual TipoAplicacion TipoAplicacion { get; set; }
}