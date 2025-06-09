using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockNet.Domain.Entities
{
    public class Compra
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string NumeroDocumento { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        // Relación con Proveedor
        public Proveedor Proveedor { get; set; }
        public int ProveedorId { get; set; }

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
        public ICollection<DetalleCompra> DetallesCompra { get; set; }
    }
}
