using FluentResults;
using StockNet.Application.DTOs.Dashboard;
using StockNet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockNet.Business.Interfaces.Dashboard
{
    public interface IBusinessService
    {
        Task<Result<BusinessCreatedResponseDto>> CreateBusinessAsync(BusinessDto dto);
        Task<Result<Negocio>> UpdateBusinessAsync(BusinessEditDto dto);
    }
}
