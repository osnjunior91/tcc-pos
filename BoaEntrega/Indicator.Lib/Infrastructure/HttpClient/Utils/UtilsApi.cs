using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Indicator.Lib.Infrastructure.HttpClient.Utils
{
    public class UtilsApi : IUtilsApi
    {
        private readonly System.Net.Http.HttpClient _httpClient;

        public UtilsApi(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient("utilsClient");
        }
        public async Task<PortageResponse> PortageAsync(PortageRequest data)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "api/v1/Portage/price");

            request.Content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string responseStream = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<PortageResponse>(responseStream);

                return result;
            }

            return null;
        }
    }
}
