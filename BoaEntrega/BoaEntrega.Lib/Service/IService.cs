using BoaEntrega.Lib.Infrastructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BoaEntrega.Lib.Service
{
    public interface IService<T> where T : ModelBase
    {
        Task<T> CreateAsync(T item);
        Task<T> GetByIdAsync(Guid id);
        Task<List<T>> GetAllAsync();
        Task<T> UpdateAsync(Guid id, T item);
        Task DeleteAsync(Guid id);
    }
}
