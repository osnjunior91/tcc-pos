using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Order.Lib.Infrastructure.HttpClient.Product
{
    public interface IProductApi
    {
        Task<ProductApiResponse> GetByIdAsync(Guid id);
    }
}
