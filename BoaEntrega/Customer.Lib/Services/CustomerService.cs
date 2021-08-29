using Customer.Lib.Infrastructure.Data.Model;
using System;
using System.Threading.Tasks;

namespace Customer.Lib.Services
{
    public class CustomerService : ICustomerService
    {
        public Task<CustomerModel> CreateAsync(CustomerModel item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(CustomerModel item)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerModel> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerModel> UpdateAsync(Guid id, CustomerModel item)
        {
            throw new NotImplementedException();
        }
    }
}
