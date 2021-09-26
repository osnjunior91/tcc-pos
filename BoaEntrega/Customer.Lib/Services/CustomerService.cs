using BoaEntrega.Lib.Infrastructure.Data.Repository;
using Customer.Lib.Infrastructure.Data.Model;
using Customer.Lib.Infrastructure.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Customer.Lib.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<CustomerModel> _repository;
        public CustomerService(IRepository<CustomerModel> repository)
        {
            _repository = repository;
        }
        public async Task<CustomerModel> CreateAsync(CustomerModel item)
        {
            var validator = new CustomerValidator();
            validator.ValidateAndThrow(item);
            return await _repository.CreateAsync(item);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<List<CustomerModel>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<CustomerModel> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException();
            return await _repository.GetByIdAsync(id);
        }

        public Task<CustomerModel> UpdateAsync(Guid id, CustomerModel item)
        {
            throw new NotImplementedException();
        }
    }
}
