using Application.Exceptions;
using Application.Interfaces;
using Application.Request;
using Application.Response;
using Azure;
using Azure.Core;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase
{
    public class ProductService : IProductService
    {
        private readonly IProductquery _query;
        private readonly IProductMapper _mapper;
        private readonly IProductCommand _command;

        public ProductService(IProductquery productquery, IProductMapper productMapper, IProductCommand productCommand) 
        { 
            _query = productquery;
            _mapper = productMapper;
            _command = productCommand;
        }
        public async Task<List<ProductGetResponse>> GetProductByFilters(List<int> categories, string name, int limit, int offset)
        {
            List<Product> listproducts = new ();

            if (categories.Count() == 0 && name == null && limit == 0 && offset == 0)
            {
                listproducts = await _query.GetAllProducts();
            }
            else
            {
                if (categories.Count() > 0 && categories.Count() <= 10)
                {
                    foreach (int categoryId in categories)
                    {
                        var productsByCategory = await _query.GetProductByCategory(categoryId);    
                        if (limit == 0 && offset == 0)
                        {
                            listproducts.AddRange(productsByCategory);
                        }
                        else
                        {
                            listproducts.AddRange(productsByCategory);
                        }
                    }
                }

                if (name != null) 
                {
                    if (categories.Count() > 0 && categories.Count() <= 10)
                    {
                        var secundarylist = listproducts;
                        listproducts.Clear();
                        listproducts = secundarylist.Where(product => product.Name.ToLower().Contains(name.ToLower())).ToList();
                    }
                    var productbyname = await _query.GetProductByName(name);
                    listproducts.AddRange(productbyname);
                    listproducts = listproducts.Where(product => product.Name.ToLower().Contains(name.ToLower())).ToList();
                    if (limit == 0 && offset == 0)
                    {
                        listproducts = listproducts.Where(product => product.Name.ToLower().Contains(name.ToLower())).ToList();
                    }
                    
                }
                if (limit > 0 && offset >= 0)
                {
                    if(listproducts.Count > 0)
                    {
                        listproducts = listproducts.Skip(offset).Take(limit).ToList();
                    }
                    else
                    {
                        listproducts = await _query.GetProductPaged(limit, offset);
                    }
                    
                }
            }

            return await _mapper.GenerateListProductsGetResponse(listproducts);

        }
        public async Task<ProductResponse> RegisterProduct(ProductRequest productrequest)
        {
            try
            {
                if (productrequest == null)
                {
                    throw new ExceptionSintaxError("Solicitud incorrecta campos vacios.");
                }

                if (string.IsNullOrWhiteSpace(productrequest.name))
                {
                    throw new ExceptionSintaxError("El nombre del producto no puede estar vacío.");
                }

                var productwithname = await _query.GetProductByName(productrequest.name);
                if (productwithname.Any(p => p.Name == productrequest.name))
                {
                    throw new ExceptionConflict("Conflicto, el producto ya existe.");
                }

                ValidateProductRequest(productrequest);

                var categoriaSeleccionada = await _query.GetCategoriaById(productrequest.Category);
                if (categoriaSeleccionada == null)
                {
                    throw new ExceptionSintaxError("La categoría especificada no existe.");
                }

                var newProduct = new Product
                {
                    Name = productrequest.name,
                    Description = productrequest.description,
                    Price = productrequest.price,
                    Discount = productrequest.discount,
                    ImageUrl = productrequest.imageUrl,
                    Category = productrequest.Category,
                    Categoria = categoriaSeleccionada
                };

                string productId = await _command.InsertProduct(newProduct);
                newProduct.ProductId = new Guid(productId);

                var response = await _mapper.GenerateProductResponse(newProduct);
                response.category = new Category
                {
                    id = newProduct.Category,
                    Name = newProduct.Categoria.Name
                };

                return response;
            }
            catch (ExceptionSintaxError ex)
            {
                throw new ExceptionSintaxError("Error: " + ex.Message);
            }
            catch (ExceptionConflict ex)
            {
                throw new ExceptionConflict("Error: " + ex.Message);
            }
        }
        public async Task<ProductResponse> GetProductById(Guid id)
        {
            try
            {
                var productById = await _query.GetProductById(id);
                if (productById == null)
                {
                  throw new ExceptionNotFound("No existe producto con ese ID.");
                }
                else
                {
                   var productResponse = await _mapper.GenerateProductResponse(productById);
                   productResponse.category = new Category
                   {
                      id = productById.Category,
                      Name = productById.Categoria.Name
                   };
                   return productResponse;
                }                
            }
            catch (ExceptionNotFound ex)
            {
                throw new ExceptionNotFound("Error: " +ex.Message);
            }
        }
        public async Task<ProductResponse> UpdateProduct(Guid id, ProductRequest productrequest)
        {
            try
            {
               
                if (productrequest == null)
                {
                    throw new ExceptionSintaxError("Solicitud incorrecta campos vacios.");
                }
                Product productup = await _query.GetProductById(id);
                if (productup == null)
                {
                    throw new ExceptionNotFound("No existe producto con ese ID.");
                }
                else
                {
                        List<Product> listaProducts = await _query.GetAllProducts();
                        if (productrequest.name == "")
                        {
                            throw new ExceptionSintaxError("No puede estar el nombre vacio");
                        }
                        if (listaProducts.Any(p => p.Name.ToLower() == productrequest.name.ToLower() && p.ProductId != id))
                        {
                            throw new ExceptionConflict("Ya existe producto con ese nombre");
                        }
                        ValidateProductRequest(productrequest);
                        productup = await _command.UpdateProduct(id, productrequest);
                        var response = await _mapper.GenerateProductResponse(productup);
                        response.category = new Category
                        {
                            id = productup.Category,
                            Name = productup.Categoria.Name
                        };
                        return response;
                    
                }
            }
            catch (ExceptionSintaxError ex)
            {
                throw new ExceptionSintaxError("Error: " + ex.Message);
            }
            catch (ExceptionNotFound ex)
            {
                throw new ExceptionNotFound("Error: " + ex.Message);
            }
            catch (ExceptionConflict ex)
            {
                throw new ExceptionConflict("Error: " + ex.Message);
            }

        }
        public async Task<ProductResponse> DeleteProduct(Guid id)
        {
            try
            {
                    Product productdelete = await _query.GetProductById(id);
                    if (productdelete != null)
                    {
                        if (productdelete.SaleProducts.Count() != 0)
                        {
                            throw new ExceptionConflict("No se puede borrar un producto que tenga una venta asociada");
                        }
                        productdelete = await _command.DeleteProduct(id);
                        var response = await _mapper.GenerateProductResponse(productdelete);
                        response.category = new Category
                        {
                            id = productdelete.Category,
                            Name = productdelete.Categoria.Name
                        };
                        return response;
                    }
                    else
                    {
                        throw new ExceptionNotFound("No existe ningun producto con ese id");
                    }
                
            }
            catch (ExceptionNotFound ex)
            {
                throw new ExceptionNotFound("Error: " + ex.Message);
            }
            catch (ExceptionConflict ex)
            {
                throw new ExceptionConflict("Error: " + ex.Message);
            }
        }

        public async Task<double> GetPriceById(Guid ProductId)
        {
            return await _query.GetPriceById(ProductId);
        }
        public async Task<int> GetDiscountById(Guid ProductId)
        {
            return await _query.GetDiscountById(ProductId);
        }
        private void ValidateProductRequest(ProductRequest productRequest)
        {
            if (productRequest.description == "")
            {
                throw new ExceptionSintaxError("debe tener una descripcion minima.");
            }
            if (productRequest.price <= 0)
            {
                throw new ExceptionSintaxError("El precio debe ser mayor a 0");
            }
            if (productRequest.discount < 0)
            {
                throw new ExceptionSintaxError("El descuento debe ser mayor o igual a 0");
            }
            if (productRequest.imageUrl == "")
            {
                throw new ExceptionSintaxError("debe ingresar una URL.");
            }
            if (productRequest.Category <= 0 || productRequest.Category > 10)
            {
                throw new ExceptionSintaxError("Categoría del 1 al 10");
            }
        }
    }
}
