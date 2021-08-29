using BoaEntrega.Lib.Infrastructure.Data.Model;

namespace BoaEntrega.Lib.Infrastructure.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : ModelBase
    {
    }
}
