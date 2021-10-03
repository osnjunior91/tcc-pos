using BoaEntrega.Lib.Infrastructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Lib.Services
{
    public class GeoService : IGeoService
    {
        public Task<double> GetDistanceAsync(AddressModel from, AddressModel to)
        {
            throw new NotImplementedException();
        }
    }
}
