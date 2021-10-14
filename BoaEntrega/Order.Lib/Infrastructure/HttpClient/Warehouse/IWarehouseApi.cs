using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Order.Lib.Infrastructure.HttpClient.Warehouse
{
    public interface IWarehouseApi
    {
        Task<WareHouseResponse> GetById(Guid id);
    }
}
