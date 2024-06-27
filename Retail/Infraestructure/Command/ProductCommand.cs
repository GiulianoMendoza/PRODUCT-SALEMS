using Application.Exceptions;
using Application.Interfaces;
using Application.Request;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Command
{
    public class ProductCommand : IProductCommand
    {
        private readonly AppDBContext _context;
        public ProductCommand(AppDBContext context) 
        { 
            _context = context;
        }
            public async Task<string> InsertProduct(Product product)
            {
                try
                {
                    _context.Add(product);
                    _context.SaveChangesAsync();
                    return product.ProductId.ToString();
                }
                catch(DbUpdateException) 
                {
                    throw new ExceptionConflict("Error en la base de datos: Problema en añadir el producto");
                }
            }
        public async Task<Product> UpdateProduct(Guid productid, ProductRequest product)
        {
            try
            {
                var productUpdate = await _context.Product.FirstOrDefaultAsync(p => p.ProductId == productid);
                productUpdate.Name = product.name;
                productUpdate.Description = product.description;
                productUpdate.Price = product.price;
                productUpdate.Discount = product.discount;
                productUpdate.ImageUrl = product.imageUrl;
                productUpdate.Category = product.Category;
                await _context.SaveChangesAsync();
                return productUpdate;
            }
            catch (DbUpdateException)
            {
                throw new ExceptionConflict("Problema al modificar el producto");
            }
        }
        public async Task<Product> DeleteProduct(Guid id)
        {
            try
            {

                var productDelete = await _context.Product.FirstOrDefaultAsync(p => p.ProductId == id);
                if (productDelete == null) 
                {
                    throw new ExceptionNotFound("El Producto con ID " + id + " no fue encontrado.");
                }
                _context.Product.Remove(productDelete);
                await _context.SaveChangesAsync();
                return productDelete;
            }
            catch (DbUpdateException)
            {
                throw new ExceptionConflict("Problema al Eliminar el producto");
            }
        }
    }
}
