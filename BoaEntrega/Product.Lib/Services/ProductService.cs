using Product.Lib.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Product.Lib.Services
{
    public class ProductService : IProductService
    {
        public Task<ProductModel> CreateAsync(ProductModel item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProductModel> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductModel> UpdateAsync(Guid id, ProductModel item)
        {
            throw new NotImplementedException();
        }
    }
}
