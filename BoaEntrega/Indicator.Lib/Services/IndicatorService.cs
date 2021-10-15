using Indicator.Lib.Data;
using Indicator.Lib.Infrastructure.HttpClient.Customer;
using Indicator.Lib.Infrastructure.HttpClient.Order;
using Indicator.Lib.Infrastructure.HttpClient.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Indicator.Lib.Services
{
    public class IndicatorService : IIndicatorService
    {
        private readonly IOrderApi _orderApi;
        private readonly ICustomerApi _customerApi;
        private readonly IUtilsApi _utilsApi;
        public IndicatorService(IOrderApi orderApi, ICustomerApi customerApi, IUtilsApi utilsApi)
        {
            _orderApi = orderApi;
            _customerApi = customerApi;
            _utilsApi = utilsApi;
        }
        public async Task<Heatmap> GetByPeriodAsync(DateTime start, DateTime end)
        {
            if (start > end)
                throw new ArgumentException("Data inicial deve ser menor que data final");

            var response = new Heatmap(start, end);
            response.Start = start;
            response.End = end;
            var orders = await _orderApi.GetByPeriodAsync(start, end);
            response.Count = orders.Count;
            foreach (var order in orders)
            {
                var customer = await _customerApi.GetByIdAsync(order.CustomerId);
                var coordinates = await _utilsApi.GetCoordinateAsync(customer.Address);
                response.Items.Add(new HeatmapItem()
                {
                    CustomerId = order.CustomerId,
                    Id = order.Id,
                    Coordinates = coordinates
                });
            }

            return response;
        }
    }
}
