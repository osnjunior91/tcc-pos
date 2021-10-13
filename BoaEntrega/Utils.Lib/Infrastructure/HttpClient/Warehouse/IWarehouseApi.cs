using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Lib.Infrastructure.HttpClient.Warehouse
{
    public interface IWarehouseApi
    {
        Task<WareHouseResponse> GetById(Guid id);
    }
}
