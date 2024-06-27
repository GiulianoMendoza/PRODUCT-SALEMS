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
    public interface IProductService
    {
        Task<List<ProductGetResponse>> GetProductByFilters(List<int> categories, string name, int limit, int offset);
        Task<ProductResponse> RegisterProduct(ProductRequest request);
        Task<ProductResponse> GetProductById(Guid id);
        Task<ProductResponse> UpdateProduct(Guid id,ProductRequest productrequest);
        Task<ProductResponse> DeleteProduct(Guid id);
        Task<double> GetPriceById(Guid ProductId);
        Task<int> GetDiscountById(Guid ProductId);
    }
}
