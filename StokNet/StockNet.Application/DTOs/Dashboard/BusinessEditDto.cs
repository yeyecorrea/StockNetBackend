namespace StockNet.Application.DTOs.Dashboard
{
    public class BusinessEditDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string FotoUrl { get; set; }
        public string NIT { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        public string Correo { get; set; }

        public string ApplicationUserId { get; set; }
    }
}
