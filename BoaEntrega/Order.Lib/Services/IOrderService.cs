using BoaEntrega.Lib.Service;
using Order.Lib.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Order.Lib.Services
{
    public interface IOrderService : IService<OrderModel>
    {
        Task<List<OrderModel>> GetOrderByPeriodAsync(DateTime start, DateTime end);
        Task<OrderModel> UpdateStatusAsync(Guid id, OrderStatus status);
    }
}
