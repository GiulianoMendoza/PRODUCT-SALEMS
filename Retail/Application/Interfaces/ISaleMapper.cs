﻿using Application.Request;
using Application.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ISaleMapper
    {
        Task<SaleResponse> GenerateSaleResponse(Sale newSale);
        Task<SaleGetResponse> GetSale(Sale newSale);


    }
}
