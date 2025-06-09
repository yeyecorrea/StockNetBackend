using Microsoft.AspNetCore.Identity;

namespace StockNet.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string? NombreCompleto { get; set; }
        public string? FotoPerfilUrl { get; set; }
        public DateTime? FechaNacimiento { get; set; }
    }
}
