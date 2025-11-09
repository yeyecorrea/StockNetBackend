using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockNet.Application.DTOs.Dashboard
{
    public class BusinessCreatedResponseDto
    {
        public BusinessDto Business { get; set; } = null!;
        public string Token { get; set; } = string.Empty;
    }
}
