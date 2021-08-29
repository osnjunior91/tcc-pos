using Customer.Lib.Infrastructure.Data.Model;
using Customer.Lib.Infrastructure.Validation;
using FluentValidation;
using System;
using System.Threading.Tasks;

namespace Customer.Lib.Services
{
    public class CustomerService : ICustomerService
    {
        public Task<CustomerModel> CreateAsync(CustomerModel item)
        {
            var validator = new CustomerValidator();
            validator.ValidateAndThrow(item);
            return Task.FromResult(item);
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
