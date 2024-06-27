using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProductquery
    {
        Task<List<Product>> GetAllProducts();
        Task<List<Product>> GetProductByCategory(int categoryId);
        Task<List<Product>> GetProductByName(string name);
        Task<List<Product>> GetProductPaged(int limit, int offset);
        Task<Product> GetProductById(Guid productid);
        Task<int> GetDiscountById(Guid ProductId);
        Task<double> GetPriceById(Guid ProductId);
        Task<Caregory> GetCategoriaById(int categoryId);

    }
}
