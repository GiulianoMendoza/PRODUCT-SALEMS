using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ISaleQuery
    {
        Task<List<Sale>> GetAllSale();
        Task<List<Sale>> GetSaleByDate(DateTime fromDate,DateTime toDate);
        Task<Sale> GetSaleById(int saleId);
    }
}
