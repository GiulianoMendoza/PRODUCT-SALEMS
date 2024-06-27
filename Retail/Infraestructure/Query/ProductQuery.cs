using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Query
{
    public class ProductQuery : IProductquery
    {
        private readonly AppDBContext _context;
        public ProductQuery(AppDBContext DBcontext) 
        { 
            this._context = DBcontext;
        }
        public async Task<List<Product>> GetAllProducts()
        {
            try
            {
                List<Product> products = await _context.Product
                    .Include(p => p.Categoria)
                    .Include(p => p.SaleProducts)
                    .ToListAsync();
                return products;
            }
            catch (DbUpdateException)
            {
                throw new ExceptionSintaxError("Error en la BD, Problemas para obtener los productos");
            }

        }
        public async Task<List<Product>> GetProductByCategory(int categoryId)
        {
            try
            {
                List<Product> products = await _context.Product
                    .Include(p => p.Categoria)
                    .Include(p => p.SaleProducts)
                    .Where(p => p.Categoria.CategoryId == categoryId)
                    .ToListAsync();
                return products;


            }
            catch(DbUpdateException)
            {
                throw new ExceptionConflict("Categoria no encontrada");
            }
        }
        public async Task<List<Product>> GetProductByName(string name)
        {
                try
                {
                    List<Product> products = await _context.Product
                        .Include(p => p.Categoria)
                        .Include(p => p.SaleProducts)
                        .Where(p => p.Name.Contains(name))
                        .ToListAsync();
                    return products;
                }
                catch (DbUpdateException)
                {
                    throw new ExceptionConflict("Nombre no encontrado");
                }
        }
        public async Task<List<Product>> GetProductPaged(int limit, int offset)
        {
            try
            {
                List<Product> products = await _context.Product
                .Include(p => p.Categoria)
                .Include(p => p.SaleProducts)
                .Skip(offset) 
                .Take(limit) 
                .ToListAsync();
                return products;
            }
            catch (DbUpdateException)
            {
                throw new ExceptionConflict("No se pudo filtrar");
            }
        }
        public async Task<Product> GetProductById(Guid productid)
        {
            try
            {
                return await _context.Product
                    .Include(p => p.Categoria)
                    .Include(p => p.SaleProducts)
                    .SingleOrDefaultAsync(p => p.ProductId == productid);

            }
            catch (DbUpdateException)
            {
                throw new ExceptionConflict("Problema al modificar el producto");
            }
        }
        public async Task<double> GetPriceById(Guid ProductId)
        {
            var price = await _context.Product
                .Where(p => p.ProductId == ProductId)
                .Select(p => p.Price)
                .FirstOrDefaultAsync();
            if (price == default(double))
            {
                throw new ExceptionNotFound("                                            Producto no encontrado                                            ");
            }
            return price;
        }
        public async Task<int> GetDiscountById(Guid ProductId)
        {
            var discount = await _context.Product
                .Where(p => p.ProductId == ProductId)
                .Select(p => p.Discount)
                .FirstOrDefaultAsync();
            if (discount == default(int))
            {
                return 0;
            }
            return discount;
        }
        public async Task<Caregory> GetCategoriaById(int categoryId)
        {
            
            var categoria = await _context.Caregory.FindAsync(categoryId);
            return categoria;
        }
    }
}
