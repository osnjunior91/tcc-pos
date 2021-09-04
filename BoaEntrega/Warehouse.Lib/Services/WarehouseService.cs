using BoaEntrega.Lib.Infrastructure.Data.Repository;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Warehouse.Lib.Infrastructure.Data;
using Warehouse.Lib.Infrastructure.Validation;

namespace Warehouse.Lib.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IRepository<WarehouseModel> _repository;
        public WarehouseService(IRepository<WarehouseModel> repository)
        {
            _repository = repository;
        }
        public Task<WarehouseModel> CreateAsync(WarehouseModel item)
        {
            var validator = new WarehouseValidation();
            validator.ValidateAndThrow(item);
            return _repository.CreateAsync(item);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<List<WarehouseModel>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<WarehouseModel> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException();
            return await _repository.GetByIdAsync(id);
        }

        public Task<WarehouseModel> UpdateAsync(Guid id, WarehouseModel item)
        {
            throw new NotImplementedException();
        }
    }
}
