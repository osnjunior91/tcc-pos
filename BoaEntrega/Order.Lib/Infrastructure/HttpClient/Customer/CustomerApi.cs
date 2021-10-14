using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Order.Lib.Infrastructure.HttpClient.Customer
{
    public class CustomerApi : ICustomerApi
    {
        private readonly System.Net.Http.HttpClient _httpClient;

        public CustomerApi(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient("customerClient");
        }
        public async Task<CustomerResponse> GetByIdAsync(Guid id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"api/v1/Customer/{id}");

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string responseStream = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<CustomerResponse>(responseStream);
            }
            else
            {
                return null;
            }
        }
    }
}
