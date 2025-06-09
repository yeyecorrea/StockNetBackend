using System.ComponentModel.DataAnnotations.Schema;

namespace StockNet.Domain.Entities
{
    public class DetalleVenta
    {
        public int Id { get; set; }

        // Relación con Venta
        public Venta Venta { get; set; }
        public int VentaId { get; set; }

        // Relación con Producto
        public Producto Producto { get; set; }
        public int ProductoId { get; set; }

        public int Cantidad { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecioUnitario { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Descuento { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal PrecioTotal => (Cantidad * PrecioUnitario) - Descuento;
    }
}
