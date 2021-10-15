using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Indicator.Lib.Infrastructure.HttpClient.Order
{
    public class OrderApi : IOrderApi
    {
        private readonly System.Net.Http.HttpClient _httpClient;

        public OrderApi(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient("orderClient");
        }
        public async Task<List<OrderResponse>> GetByPeriodAsync(DateTime start, DateTime end)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"api/Order/period?start={start.ToString("yyyy-MM-dd")}&end={end.ToString("yyyy-MM-dd")}");

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string responseStream = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<OrderResponse>>(responseStream);
            }
            else
            {
                return null;
            }
        }
    }
}
