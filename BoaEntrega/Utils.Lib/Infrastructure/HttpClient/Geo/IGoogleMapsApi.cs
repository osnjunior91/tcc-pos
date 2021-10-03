using BoaEntrega.Lib.Infrastructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Lib.Infrastructure.HttpClient.Geo
{
    public interface IGoogleMapsApi
    {
        Task<int?> GetDistanceToTwoAddress(AddressModel from, AddressModel to);
    }
}
