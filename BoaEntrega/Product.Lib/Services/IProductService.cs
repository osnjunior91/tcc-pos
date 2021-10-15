using BoaEntrega.Lib.Service;
using Product.Lib.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Product.Lib.Services
{
    public interface IProductService : IService<ProductModel>
    {
        public Task UpdateAmountAsync(Guid id, double amount);
    }
}
