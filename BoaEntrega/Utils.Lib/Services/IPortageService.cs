using BoaEntrega.Lib.Infrastructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Utils.Lib.Services
{
    public interface IPortageService
    {
        Task<double> GetPriceAsync(Guid userId, Guid warehouseId, double weight);
    }
}
