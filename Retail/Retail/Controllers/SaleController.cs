using Application.Exceptions;
using Application.Interfaces;
using Application.Request;
using Application.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Retail.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleService;
        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        /// <summary>
        /// Obtiene un listado de ventas.
        /// </summary>
        /// <response code="200">Éxito al recuperar las ventas.</response>
        /// <response code="400">Solicitud incorrecta.</response>
        /// <remarks>Recupera un resumen de las ventas realizadas, con opción de filtrado por fecha.</remarks>
        [HttpGet]
        [ProducesResponseType(typeof(SaleGetResponse), 200)]
        [ProducesResponseType(typeof(ApiError), 400)]
        public async Task<IActionResult> GetAllSale(DateTime from, DateTime to)
        {
            try
            {
                var result = await _saleService.GetSale(from, to);
                return new JsonResult(result) { StatusCode = 200 };
            }
            catch (ExceptionSintaxError ex)
            {
                return new JsonResult(new ApiError { message = ex.Message }) { StatusCode = 400 };
            }

        }
        /// <summary>
        /// Registra una nueva venta.
        /// </summary>
        /// <response code="201">Venta registrada con éxito.</response>
        /// <response code="400">Solicitud incorrecta.</response>
        /// <remarks>Permite ingresar una nueva venta al sistema.</remarks>
        [HttpPost]
        [ProducesResponseType(typeof(SaleResponse), 201)]
        [ProducesResponseType(typeof(ApiError), 400)]
        public async Task<IActionResult> RegisterSale(SaleRequest request)
        {
            try
            {
                var result = await _saleService.RegisterSale(request);
                return new JsonResult(result) { StatusCode = 201 };
            }
            catch (ExceptionSintaxError ex)
            {
                return new JsonResult(new ApiError { message = ex.Message }) { StatusCode = 400 };
            }
        }
        /// <summary>
        /// Obtiene detalles de una venta específica.
        /// </summary>
        /// <response code="200">Éxito al recuperar los detalles de la venta.</response>
        /// <response code="404">Venta no encontrada.</response>
        /// <remarks>Recupera los detalles de una venta por su ID único.</remarks>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SaleResponse), 200)]
        [ProducesResponseType(typeof(ApiError), 404)]
        public async Task<IActionResult> GetSaleById(int id)
        {
            try
            {
                var result = await _saleService.GetSaleById(id);
                return new JsonResult(result) { StatusCode = 200 };
            }
            catch (ExceptionSintaxError ex) 
            {
                return new JsonResult(new ApiError { message = ex.Message }) { StatusCode = 404 };
            }
        }
    }
}
