using System.Security.Claims;

namespace StockNet.Application.DTOs.Token
{
    public class TokenValidationResultDto
    {
        public bool IsValid { get; set; }
        public string? Reason { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public List<string>? Roles { get; set; }
    }

}
