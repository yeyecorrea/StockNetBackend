using System.ComponentModel.DataAnnotations;

namespace StockNet.Domain.Entities
{
    public class CategoriaProducto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        // Relación con Productos
        public ICollection<Producto> Productos { get; set; }
    }
}
