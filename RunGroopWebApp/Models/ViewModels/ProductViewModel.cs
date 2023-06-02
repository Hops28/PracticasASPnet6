using System.ComponentModel.DataAnnotations;

namespace RunGroopWebApp.Models.ViewModels
{
    public class ProductViewModel
    {
        [Required]
        [Display(Name = "Nombre de producto")]
        public string NombreProducto { get; set; }

        [Required]
        [Display(Name = "Precio")]
        public decimal PrecioProducto { get; set; }

        [Display(Name = "Descripcion")]
        public string? DescripcionProducto { get; set; }
    }
}
