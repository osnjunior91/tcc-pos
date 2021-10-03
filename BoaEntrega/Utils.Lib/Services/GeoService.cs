using BoaEntrega.Lib.Constants;
using BoaEntrega.Lib.Infrastructure.Data.Model;
using Geocoding;
using Geocoding.Google;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Lib.Infrastructure.HttpClient.Geo;

namespace Utils.Lib.Services
{
    public class GeoService : IGeoService
    {
        private readonly IGeocoder _geocoder;
        private readonly IGoogleMapsApi _geoApi;
        public GeoService(IGoogleMapsApi geoApi)
        {
            _geoApi = geoApi;
            _geocoder = new GoogleGeocoder() { ApiKey = Keys.GOOGLE_MAPS_KEY };
        }
        public async Task<int> GetDistanceAsync(AddressModel from, AddressModel to)
        {
            var result = await _geoApi.GetDistanceToTwoAddress(from, to);

            if (result == null)
                throw new Exception("Erro ao calcular distancia");

            return (int)result;
        }

        public async Task<Coordinate> GetCordinatesByAddress(AddressModel address)
        {
            IEnumerable<Address> addresses = await _geocoder.GeocodeAsync(address.ToString());

            if (addresses?.Count() == 0)
                throw new Exception("Erro ao calcular distancia");

            return new Coordinate()
            {
                Latitude = addresses.FirstOrDefault()?.Coordinates?.Latitude,
                Longitude = addresses.FirstOrDefault()?.Coordinates?.Longitude
            };
        }
    }
}
