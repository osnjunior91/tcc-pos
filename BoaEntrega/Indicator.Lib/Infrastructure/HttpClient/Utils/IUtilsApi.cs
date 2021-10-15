using BoaEntrega.Lib.Infrastructure.Data.Model;
using System.Threading.Tasks;

namespace Indicator.Lib.Infrastructure.HttpClient.Utils
{
    public interface IUtilsApi
    {
        Task<Coordinate> GetCoordinateAsync(AddressModel data);
    }
}
