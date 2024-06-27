using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase
{
    public class SaleProductService : ISaleProductService
    {
        private readonly ISaleProductCommand _command;

        public SaleProductService(ISaleProductCommand command)
        {
            _command = command;
        }
        public async Task<SaleProduct> RegisterSaleProduct(SaleProduct saleProduct)
        {
            return await _command.insertSP(saleProduct);

        }
    }
}
