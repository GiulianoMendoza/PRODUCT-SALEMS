using Application.Interfaces;
using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapper
{
    public class ProductMapper : IProductMapper
    {
        public ProductMapper()
        {

        }

        public async Task<ProductResponse> GenerateProductResponse(Product newProduct)
        {
            return new ProductResponse
            {
                id = newProduct.ProductId,
                name = newProduct.Name,
                description = newProduct.Description,
                price = newProduct.Price,
                discount = newProduct.Discount,
                imageUrl = newProduct.ImageUrl
            };
        }
        public async Task<ProductGetResponse> GenerateProductGetResponse(Product newProduct)
        {
            return new ProductGetResponse
            {
                id = newProduct.ProductId,
                name = newProduct.Name,
                price = newProduct.Price,
                discount = newProduct.Discount,
                imageUrl = newProduct.ImageUrl,
                categoryName = newProduct.Categoria.Name
            };
        }

        public async Task<List<ProductGetResponse>> GenerateListProductsGetResponse(List<Product> Products)
        {
            List<ProductGetResponse> productsResponse = new();
            foreach (Product product in Products)
            {
                productsResponse.Add(await GenerateProductGetResponse(product));
            }
            return productsResponse;
        }
    }
}
