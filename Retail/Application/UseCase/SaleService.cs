using Application.Exceptions;
using Application.Interfaces;
using Application.Request;
using Application.Response;
using Azure.Core;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase
{
    public class SaleService : ISaleService
    {
        private readonly ISaleMapper _mapper;
        private readonly ISaleQuery _query;
        private readonly ISaleCommand _command;
        private readonly IProductService _productService;
        private readonly ISaleProductService _saleProductService;
        public SaleService(ISaleMapper mapper, ISaleQuery saleQuery, ISaleCommand command, IProductService productService, ISaleProductService saleProductService) 
        {
            _mapper = mapper;
            _query = saleQuery;
            _command = command;
            _productService = productService;
            _saleProductService = saleProductService;
        }
        public async Task<List<SaleGetResponse>> GetSale(DateTime from, DateTime to)
        {
            try
            {
                if (from > to)
                {
                    throw new ExceptionSintaxError("La fecha de inicio no puede ser mayor que la fecha de fin.");
                }
                List<SaleGetResponse> listsaleGetResponses = new List<SaleGetResponse>();
                List<Sale> listSale = new List<Sale>();
                if (from == default && to == default)
                {
                    listSale = await _query.GetAllSale();
                }
                else
                {
                    if (from == DateTime.MinValue || to == DateTime.MinValue)
                    {
                        throw new ExceptionSintaxError("Fechas no válidas o la fecha de inicio es mayor que la fecha de fin.");
                    }
                    listSale = await _query.GetSaleByDate(from, to);
                }

                foreach (var sale in listSale)
                {
                    SaleGetResponse saleResponse = await _mapper.GetSale(sale);
                    listsaleGetResponses.Add(saleResponse);
                }

                return listsaleGetResponses;
            }
            catch (Exception ex) when (!(ex is ExceptionSintaxError))
            {
                throw new ExceptionSintaxError(ex.Message);
            }

        }
        public async Task<SaleResponse> RegisterSale(SaleRequest saleRequest)
        {

            try
            {
                if (saleRequest == null)
                {
                    throw new ExceptionSintaxError("Solicitud incorrecta campos vacios y/o recuerde que productID solo admite tipos GUID: '3fa85f64-5717-4562-b3fc-2c963f66afa6'");
                }
                if (saleRequest.products == null || !saleRequest.products.Any())
                {
                    throw new ExceptionSintaxError("La solicitud debe contener al menos un producto.");
                }

                foreach (var saleproductrequest in saleRequest.products)
                {
                    var product = await _productService.GetProductById(saleproductrequest.ProductId);
                    if (saleproductrequest.quantity <= 0)
                    {
                        throw new ExceptionSintaxError("La cantidad debe ser mayor que 0.");
                    }
                }
                double subtotal = 0;
                double totalDiscount = 0;
                decimal taxes = 1.21m;
                foreach (var saleproductrequest in saleRequest.products)
                {
                    decimal price = (decimal) await _productService.GetPriceById(saleproductrequest.ProductId);
                    int discount = await _productService.GetDiscountById(saleproductrequest.ProductId);
                    subtotal +=  (double)price * saleproductrequest.quantity;
                    totalDiscount += ((double)price * discount / 100) * saleproductrequest.quantity;
                }
                double totalpay = Math.Round((subtotal - totalDiscount) * (double)taxes, 2);
                totalpay = Math.Round(totalpay, 2);
                double totalPayedRounded = Math.Round((double)saleRequest.totalPayed, 2);
                if (totalPayedRounded < 0)
                {
                    throw new ExceptionSintaxError("El valor de totalPayed no puede ser negativo.");
                }
                if (totalPayedRounded < totalpay)
                {
                    throw new ExceptionSintaxError("La cantidad a pagar debe ser mayor o igual a: " + totalpay);
                }
                var sale = new Sale
                {
                    TotalPay = (decimal)totalpay,
                    Subtotal = (decimal)subtotal,
                    TotalDiscount = (decimal)totalDiscount,
                    Taxes = taxes,
                    Date = DateTime.Now,
                };
                var newSale = await _command.InsertVenta(sale);
                await RegisterSaleProducts(newSale, saleRequest.products);
                var response = await _mapper.GenerateSaleResponse(newSale);
                response.subtotal = (double)subtotal;
                response.totalDiscount = (double)totalDiscount;
                response.taxes = (double)taxes;
                return response;
            }
            catch (ExceptionNotFound ex)
            {
                throw new ExceptionSintaxError(ex.Message);
            }
            catch (ExceptionSintaxError ex)
            {
                throw new ExceptionSintaxError(ex.Message);
            }
        }
        public async Task<SaleResponse> GetSaleById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new ExceptionSintaxError("El id debe ser mayor a 0");
                }
                var salebyId = await _query.GetSaleById(id);
                if (salebyId == null)
                {
                    throw new ExceptionSintaxError("Venta no encontrada");
                }
                return await _mapper.GenerateSaleResponse(salebyId);
            }
            catch(ExceptionSintaxError ex)
            {
                throw new ExceptionSintaxError(ex.Message);
            }
            catch (ExceptionNotFound ex)
            {
                throw new ExceptionNotFound(ex.Message);
            }

        }
        private async Task RegisterSaleProducts(Sale newSale, IEnumerable<SaleProductRequest> saleProductRequests)
        {
            foreach (var saleproductrequest in saleProductRequests)
            {
                var product = await _productService.GetProductById(saleproductrequest.ProductId);
                if (product == null)
                {
                    throw new ExceptionSintaxError("El producto con ID " + saleproductrequest.ProductId + " no existe.");
                }
                if (saleproductrequest.quantity <= 0)
                {
                    throw new ExceptionSintaxError("La cantidad debe ser mayor que 0.");
                }
                double price = await _productService.GetPriceById(saleproductrequest.ProductId);
                int discount = await _productService.GetDiscountById(saleproductrequest.ProductId);
                var saleProduct = new SaleProduct
                {
                    Sale = newSale.SaleId,
                    Product = saleproductrequest.ProductId,
                    Price = (decimal)price,
                    Discount = discount,
                    Quantity = saleproductrequest.quantity
                };
                await _saleProductService.RegisterSaleProduct(saleProduct);
            }
        }
    }
}
