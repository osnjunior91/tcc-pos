using Newtonsoft.Json;
using Product.Lib.Infrastructure.HttpClient.WareHouse.Response;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Product.Lib.Infrastructure.HttpClient.Warehouse
{
    public class WarehouseApi : IWarehouseApi
    {
        private readonly System.Net.Http.HttpClient _httpClient;

        public WarehouseApi(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient("warehouseClient");
        }

        public async Task<WareHouseResponse> GetById(Guid id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"api/v1/Warehouse/{id}");

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string responseStream = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<WareHouseResponse>(responseStream);
            }
            else
            {
                return null;
            }
        }
    }
}
