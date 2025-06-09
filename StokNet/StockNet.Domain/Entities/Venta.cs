using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockNet.Domain.Entities
{
    public class Venta
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string NumeroDocumento { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        // Relación con Cliente
        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }

        public string Descripcion { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Subtotal { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Descuento { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Envio { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }

        [StringLength(100)]
        public string FacturaProveedor { get; set; }

        [StringLength(200)]
        public string DatosDeEnvio { get; set; }

        // Relación con Detalles
        public ICollection<DetalleVenta> DetallesVenta { get; set; }
    }
}
