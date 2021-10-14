using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Order.Lib.Infrastructure.HttpClient.Product
{
    public class ProductApi : IProductApi
    {
        private readonly System.Net.Http.HttpClient _httpClient;

        public ProductApi(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient("productClient");
        }
        public async Task<ProductApiResponse> GetByIdAsync(Guid id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"api/v1/Product/{id}");

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string responseStream = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ProductApiResponse>(responseStream);
            }
            else
            {
                return null;
            }
        }
    }
}
