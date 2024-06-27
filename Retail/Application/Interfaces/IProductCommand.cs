using Application.Request;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProductCommand
    {
        Task<string> InsertProduct(Product product);
        Task<Product> UpdateProduct(Guid id, ProductRequest product);
        Task<Product> DeleteProduct(Guid id);
    }
}
