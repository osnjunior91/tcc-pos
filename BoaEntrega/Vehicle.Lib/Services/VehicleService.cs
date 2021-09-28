using BoaEntrega.Lib.Infrastructure.Data.Repository;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vehicle.Lib.Infrastructure.Data;
using Vehicle.Lib.Infrastructure.HttpClient.Warehouse;
using Vehicle.Lib.Infrastructure.Validation;

namespace Vehicle.Lib.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IRepository<VehicleModel> _repository;
        private readonly IWarehouseApi _warehouseApi;
        public VehicleService(IRepository<VehicleModel> repository, IWarehouseApi warehouseApi)
        {
            _repository = repository;
            _warehouseApi = warehouseApi;
        }
        public async Task<VehicleModel> CreateAsync(VehicleModel item)
        {
            var validator = new VehicleValidation();
            validator.ValidateAndThrow(item);

            var warehouse = await _warehouseApi.GetById(item.WharehouseLocationId);
            if (warehouse == null || warehouse.Id == Guid.Empty)
                throw new ArgumentException("Invalid parameter WharehouseLocationId");

            return await _repository.CreateAsync(item);
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<VehicleModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<VehicleModel> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<VehicleModel> UpdateAsync(Guid id, VehicleModel item)
        {
            throw new NotImplementedException();
        }
    }
}
