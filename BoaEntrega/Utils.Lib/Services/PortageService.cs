﻿using BoaEntrega.Lib.Infrastructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Lib.Services
{
    public class PortageService : IPortageService
    {
        private readonly double PRICE_BASE = 0.000013;
        private readonly IGeoService _geoService;

        public PortageService(IGeoService geoService)
        {
            _geoService = geoService;
        }

        public async Task<double> GetPriceAsync(AddressModel from, AddressModel to, double weight)
        {
            var distance = await _geoService.GetDistanceAsync(from, to);

            if (distance < 1)
                throw new Exception("Erro ao recuperar distancia");

            return ((distance * weight) * PRICE_BASE);
        }
    }
}
