using Application.Interfaces;
using Application.Request;
using Application.Response;
using Azure;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapper
{
    public class SaleMapper : ISaleMapper
    {

   
        public SaleMapper()
        {
        }
        public async Task<SaleResponse> GenerateSaleResponse(Sale newSale)
        {
            SaleResponse response = new SaleResponse
            {
                id = newSale.SaleId,
                totalPay = (double)newSale.TotalPay,
                subtotal = (double)newSale.Subtotal,
                totalDiscount = (double)newSale.TotalDiscount,
                taxes = (double)newSale.Taxes,
                date = newSale.Date,
                products = new List<SaleProductReponse>()
            };
            foreach (var saleProduct in newSale.SaleProducts)
            {
                response.products.Add(new SaleProductReponse
                {
                    id = saleProduct.Sale,
                    productId = saleProduct.Product,
                    Quantity = saleProduct.Quantity,
                    price = (double)saleProduct.Price,
                    discount = saleProduct.Discount,
                });
            }
            response.totalQuantity = response.products.Sum(p => p.Quantity);
            return response;
        }
        public async Task<SaleGetResponse> GetSale(Sale newSale)
        {
            int totalQuantity = newSale.SaleProducts.Sum(sp => sp.Quantity);
            return new SaleGetResponse
            {
                id = newSale.SaleId,
                totalPay = (double)newSale.TotalPay,
                totalQuantity = totalQuantity,
                date = newSale.Date
            };
        }

    }
}
