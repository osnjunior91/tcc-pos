using BoaEntrega.Lib.Infrastructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Lib.Services
{
    public interface IGeoService
    {
        Task<double> GetDistanceAsync(AddressModel from, AddressModel to);
    }
}
