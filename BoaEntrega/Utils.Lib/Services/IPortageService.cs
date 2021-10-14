using BoaEntrega.Lib.Infrastructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utils.Lib.Infrastructure.Data;

namespace Utils.Lib.Services
{
    public interface IPortageService
    {
        Task<Portage> GetPriceAsync(AddressModel from, AddressModel to, double weight);
    }
}
