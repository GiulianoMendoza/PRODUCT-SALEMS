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
    public class SaleQuery : ISaleQuery
    {
        private readonly AppDBContext _context;
        public SaleQuery(AppDBContext DBcontext)
        {
            this._context = DBcontext;
        }
        public async Task<List<Sale>> GetAllSale()
        {
            try
            {
                List<Sale> allSale = _context.Sale.Include(s => s.SaleProducts).ToList();
                return allSale;
            }
            catch(DbUpdateException)
            {
                throw new ExceptionConflict("Error en la base de datos: Problemas para obtener ventas");
            }
        }
        public async Task<List<Sale>> GetSaleByDate(DateTime fromDate, DateTime toDate)
        {
            try
            {
                List<Sale> salebydate = _context.Sale.Include(s => s.SaleProducts).Where(s => s.Date.Date >= fromDate.Date && s.Date.Date <= toDate.Date).ToList();
                return salebydate;
            }
            catch (DbUpdateException)
            {
                throw new ExceptionConflict("Error en la base de datos: problema al obtener ventas");
            }
        }
        public async Task<Sale> GetSaleById(int saleId)
        {
            try
            {
                return await _context.Sale.Include(s => s.SaleProducts).SingleOrDefaultAsync(s => s.SaleId == saleId);
            }
            catch(DbUpdateException e)
            {
                throw new ExceptionConflict(e.Message);
            }
        }
    }
}
