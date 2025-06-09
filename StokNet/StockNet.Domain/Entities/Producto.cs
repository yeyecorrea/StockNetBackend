using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockNet.Domain.Entities
{
    public class Producto
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Codigo { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        // Relación con Categoría
        public CategoriaProducto Categoria { get; set; }
        public int CategoriaId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Costo { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecioVenta { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal Margen { get; set; }

        // Relaciones
        public ICollection<DetalleVenta> DetallesVenta { get; set; }
        public Inventario Inventario { get; set; }
    }
}
