using System.ComponentModel.DataAnnotations.Schema;

namespace StockNet.Domain.Entities
{
    public class Inventario
    {
        public int Id { get; set; }

        // Relación con Producto (1:1)
        public Producto Producto { get; set; }
        public int ProductoId { get; set; }

        public int InventarioInicial { get; set; }
        public int Entradas { get; set; }
        public int Salidas { get; set; }
        public int InventarioFinal { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal CostoUnitario { get; set; }

        public decimal CostoTotal { get; set; }
    }
}
