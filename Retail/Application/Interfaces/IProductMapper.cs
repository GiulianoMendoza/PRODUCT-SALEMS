using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProductMapper
    {
        Task<ProductGetResponse> GenerateProductGetResponse(Product newProduct);
        Task<ProductResponse> GenerateProductResponse(Product newProduct);
        Task<List<ProductGetResponse>> GenerateListProductsGetResponse(List<Product> Products);
    }
}
