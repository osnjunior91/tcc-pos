using BoaEntrega.Lib.Infrastructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Lib.Services
{
    public interface IGeoService
    {
        Task<int> GetDistanceAsync(AddressModel from, AddressModel to);
        Task<Coordinate> GetCordinatesByAddress(AddressModel address);
    }
}
