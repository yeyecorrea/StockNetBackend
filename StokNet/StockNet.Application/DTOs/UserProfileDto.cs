namespace StockNet.Application.DTOs
{
    public class UserProfileDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string? NombreCompleto { get; set; }
        public string? FotoPerfilUrl { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string NumeroTelefono { get; set; }
    }
}
