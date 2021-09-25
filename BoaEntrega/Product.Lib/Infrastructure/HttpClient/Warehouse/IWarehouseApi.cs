using Product.Lib.Infrastructure.HttpClient.WareHouse.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Product.Lib.Infrastructure.HttpClient.Warehouse
{
    public interface IWarehouseApi
    {
        Task<WareHouseResponse> GetById(Guid id);
    }
}
