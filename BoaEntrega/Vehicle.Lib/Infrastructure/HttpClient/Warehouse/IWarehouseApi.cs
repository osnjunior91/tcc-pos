using System;
using System.Threading.Tasks;
using Vehicle.Lib.Infrastructure.HttpClient.WareHouse.Response;

namespace Vehicle.Lib.Infrastructure.HttpClient.Warehouse
{
    public interface IWarehouseApi
    {
        Task<WareHouseResponse> GetById(Guid id);
    }
}
