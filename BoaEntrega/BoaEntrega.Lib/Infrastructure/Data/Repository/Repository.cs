using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using BoaEntrega.Lib.Infrastructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoaEntrega.Lib.Infrastructure.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : ModelBase
    {
        private readonly AmazonDynamoDBClient _dynamoClient;
        private readonly DynamoDBContext _context;

        public Repository()
        {
            _dynamoClient = new AmazonDynamoDBClient(RegionEndpoint.SAEast1);
            _context = new DynamoDBContext(_dynamoClient);
        }

        public async Task<T> CreateAsync(T item)
        {
            await _context.SaveAsync(item);
            return item;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _context.DeleteAsync(id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.ScanAsync<T>(new List<ScanCondition>()).GetRemainingAsync();
        }

        public async Task<List<T>> GetAllByFilterAsync(List<ScanCondition> filter)
        {
            return await _context.ScanAsync<T>(filter).GetRemainingAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _context.LoadAsync<T>(id, new DynamoDBContextConfig
            {
                ConsistentRead = true
            });
        }

        public async Task UpdateAsync(T item)
        {
            await _context.SaveAsync(item);
        }
    }
}
