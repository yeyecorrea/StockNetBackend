using System.ComponentModel.DataAnnotations.Schema;

namespace StockNet.Domain.Entities
{
    public class DetalleCompra
    {
        public int Id { get; set; }

        // Relación con MateriaPrima
        public MateriaPrima MateriaPrima { get; set; }
        public int MateriaPrimaId { get; set; }

        public int Cantidad { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecioUnitario { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Descuento { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal PrecioTotal => (Cantidad * PrecioUnitario) - Descuento;
    }
}
