using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using BoaEntrega.Lib.Infrastructure.Data.Model;
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
    }
}
