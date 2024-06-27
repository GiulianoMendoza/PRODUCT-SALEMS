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

namespace Infraestructure.Comand
{
    public class SaleCommand : ISaleCommand
    {
        private readonly AppDBContext _context;
        public SaleCommand(AppDBContext context)
        {
            this._context = context;
        }
        public async Task<Sale> InsertVenta(Sale sale)
        {
            try
            {
                await _context.AddAsync(sale);
                await _context.SaveChangesAsync();
                return sale;
            }
            catch (DbUpdateException)
            {
                throw new ExceptionNotFound("                                            No se pudo Registrar una venta                                            ");
            }
        }
    }
}
