using System.ComponentModel.DataAnnotations;

namespace StockNet.Domain.Entities
{
    public class Proveedor
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(20)]
        public string Nit { get; set; }

        [StringLength(150)]
        public string Direccion { get; set; }

        [StringLength(20)]
        public string Telefono { get; set; }

        [StringLength(100)]
        public string Correo { get; set; }

        // Relación con Compras
        public ICollection<Compra> Compras { get; set; }
    }
}
