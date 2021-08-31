using Amazon.DynamoDBv2.DataModel;
using BoaEntrega.Lib.Infrastructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoaEntrega.Lib.Infrastructure.Data.Repository
{
    public interface IRepository<T> where T : ModelBase
    {
        Task<T> CreateAsync(T item);
        Task<T> GetByIdAsync(Guid id);
        Task<List<T>> GetAllAsync();
        Task DeleteAsync(Guid id);
        Task UpdateAsync(T item);
        Task<List<T>> GetAllByFilterAsync(List<ScanCondition> filter);
    }
}
