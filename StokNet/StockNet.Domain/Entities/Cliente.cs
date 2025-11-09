using System.ComponentModel.DataAnnotations;

namespace StockNet.Domain.Entities
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(20)]
        public string Documento { get; set; }

        [StringLength(200)]
        public string Direccion { get; set; }

        [StringLength(20)]
        public string Telefono { get; set; }

        [StringLength(100)]
        public string Correo { get; set; }

        // Relación con Ventas
        public ICollection<Venta> Ventas { get; set; }

        //Relacion con Negocio
        public int NegocioId { get; set; }
        public Negocio Negocio { get; set; }
    }
}
