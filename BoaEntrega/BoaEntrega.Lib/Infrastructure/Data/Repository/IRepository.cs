using BoaEntrega.Lib.Infrastructure.Data.Model;
using System.Threading.Tasks;

namespace BoaEntrega.Lib.Infrastructure.Data.Repository
{
    public interface IRepository<T> where T : ModelBase
    {
        Task<T> CreateAsync(T item);
    }
}
