using Application.Request;
using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ISaleService
    {
        Task<List<SaleGetResponse>> GetSale(DateTime from, DateTime to);
        Task<SaleResponse> RegisterSale(SaleRequest saleRequest);
        Task<SaleResponse> GetSaleById(int id);

    }
}
