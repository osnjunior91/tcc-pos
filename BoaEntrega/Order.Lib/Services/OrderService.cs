using BoaEntrega.Lib.Infrastructure.Data.Repository;
using FluentValidation;
using Order.Lib.Infrastructure.Data;
using Order.Lib.Infrastructure.HttpClient.Customer;
using Order.Lib.Infrastructure.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Order.Lib.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<OrderModel> _repository;
        private readonly ICustomerApi _customerApi;

        public OrderService(IRepository<OrderModel> repository, ICustomerApi customerApi)
        {
            _repository = repository;
            _customerApi = customerApi;
        }

        public async Task<OrderModel> CreateAsync(OrderModel item)
        {
            var validator = new OrderValidation();
            validator.ValidateAndThrow(item);

            var customer = await _customerApi.GetByIdAsync(item.WarehouseId);
            if (customer == null)
                throw new ArgumentException("Invalid parameter CustomerId");



            item.Status = OrderStatus.Separation;
            return await Task.FromResult(item);
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OrderModel> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<OrderModel> UpdateAsync(Guid id, OrderModel item)
        {
            throw new NotImplementedException();
        }
    }
}
