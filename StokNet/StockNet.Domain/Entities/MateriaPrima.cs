using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockNet.Domain.Entities
{
    public class MateriaPrima
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Codigo { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        // Relación con Categoría
        public CategoriaMateriaPrima Categoria { get; set; }
        public int CategoriaId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Costo { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecioVenta { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal Margen { get; set; }

        // Relación con DetallesCompra
        public ICollection<DetalleCompra> DetallesCompra { get; set; }
    }
}
