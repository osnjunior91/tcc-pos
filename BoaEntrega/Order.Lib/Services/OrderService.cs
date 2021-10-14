using BoaEntrega.Lib.Infrastructure.Data.Repository;
using FluentValidation;
using Order.Lib.Infrastructure.Data;
using Order.Lib.Infrastructure.HttpClient.Customer;
using Order.Lib.Infrastructure.HttpClient.Warehouse;
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
        private readonly IWarehouseApi _warehouseApi;

        public OrderService(
            IRepository<OrderModel> repository, ICustomerApi customerApi, 
            IWarehouseApi warehouseApi)
        {
            _repository = repository;
            _customerApi = customerApi;
            _warehouseApi = warehouseApi;
        }

        public async Task<OrderModel> CreateAsync(OrderModel item)
        {
            var validator = new OrderValidation();
            validator.ValidateAndThrow(item);

            var customer = await _customerApi.GetByIdAsync(item.CustomerId);
            if (customer == null)
                throw new ArgumentException("Invalid parameter CustomerId");

            var warehouse = await _warehouseApi.GetById(item.WarehouseId);
            if (warehouse == null)
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
