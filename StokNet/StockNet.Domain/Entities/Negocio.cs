using System.ComponentModel.DataAnnotations;

namespace StockNet.Domain.Entities
{
    public class Negocio
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        public string FotoUrl { get; set; }

        [StringLength(20)]
        public string NIT { get; set; }

        [StringLength(200)]
        public string Direccion { get; set; }

        [StringLength(20)]
        public string Telefono { get; set; }

        [StringLength(100)]
        public string Correo { get; set; }

        // Clave foránea
        public string ApplicationUserId { get; set; }

        // Propiedad de navegación
        public ApplicationUser? ApplicationUser { get; set; }

        // Relación con Clientes
        public ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
    }
}
