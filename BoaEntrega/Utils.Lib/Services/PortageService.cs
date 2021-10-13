using BoaEntrega.Lib.Infrastructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utils.Lib.Infrastructure.HttpClient.Warehouse;

namespace Utils.Lib.Services
{
    public class PortageService : IPortageService
    {
        private readonly double PRICE_BASE = 0.000013;
        private readonly IGeoService _geoService;
        private readonly IWarehouseApi _warehouseApi;

        public PortageService(IGeoService geoService, IWarehouseApi warehouseApi)
        {
            _geoService = geoService;
            _warehouseApi = warehouseApi;
        }

        public async Task<double> GetPriceAsync(Guid userId, Guid warehouseId, double weight)
        {

            var warehouse = await _warehouseApi.GetById(warehouseId);
            if (warehouse == null || warehouse.Id == Guid.Empty)
                throw new ArgumentException("Invalid parameter WarehouseId");

            var distance = 11; //await _geoService.GetDistanceAsync(from, to);

            if (distance < 1)
                throw new Exception("Erro ao recuperar distancia");

            return await Task.FromResult(((distance * weight) * PRICE_BASE));
        }
    }
}
