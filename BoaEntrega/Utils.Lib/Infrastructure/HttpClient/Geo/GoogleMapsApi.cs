using BoaEntrega.Lib.Constants;
using BoaEntrega.Lib.Infrastructure.Data.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Utils.Lib.Infrastructure.Data;

namespace Utils.Lib.Infrastructure.HttpClient.Geo
{
    public class GoogleMapsApi : IGoogleMapsApi
    {
        private readonly System.Net.Http.HttpClient _httpClient;

        public GoogleMapsApi(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient("googleClient");
        }

        public async Task<int?> GetDistanceToTwoAddress(AddressModel from, AddressModel to)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"distancematrix/json?destinations={to}&origins={from}&key={Keys.GOOGLE_MAPS_KEY}");

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string responseStream = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<GoogleMapsDistanceResponse>(responseStream);

                return result.Rows.FirstOrDefault().Elements.FirstOrDefault().Distance.Value;
            }
           
            return null;
        }
    }
}
