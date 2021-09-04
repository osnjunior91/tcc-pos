using BoaEntrega.Lib.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Lib.Infrastructure.Data;

namespace Warehouse.Lib.Services
{
    public class WarehouseService : IWarehouseService
    {
        public Task<WarehouseData> CreateAsync(WarehouseData item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<WarehouseData>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<WarehouseData> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<WarehouseData> UpdateAsync(Guid id, WarehouseData item)
        {
            throw new NotImplementedException();
        }
    }
}
