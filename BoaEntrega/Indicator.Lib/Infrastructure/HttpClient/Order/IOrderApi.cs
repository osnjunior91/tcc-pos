using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Indicator.Lib.Infrastructure.HttpClient.Order
{
    public interface IOrderApi
    {
        Task<List<OrderResponse>> GetByPeriodAsync(DateTime start, DateTime end);
    }
}
