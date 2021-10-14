using BoaEntrega.Lib.Infrastructure.Data.Repository;
using FluentValidation;
using Order.Lib.Infrastructure.Data;
using Order.Lib.Infrastructure.HttpClient.Customer;
using Order.Lib.Infrastructure.HttpClient.Product;
using Order.Lib.Infrastructure.HttpClient.Warehouse;
using Order.Lib.Infrastructure.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Lib.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<OrderModel> _repository;
        private readonly ICustomerApi _customerApi;
        private readonly IWarehouseApi _warehouseApi;
        private readonly IProductApi _productApi;

        public OrderService(
            IRepository<OrderModel> repository, ICustomerApi customerApi, 
            IWarehouseApi warehouseApi, IProductApi productApi)
        {
            _repository = repository;
            _customerApi = customerApi;
            _warehouseApi = warehouseApi;
            _productApi = productApi;
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
                throw new ArgumentException("Invalid parameter WarehouseId");

            List<ProductApiResponse> products = new List<ProductApiResponse>();

            foreach (var product in item.Items)
            {
                var productResponse = await _productApi.GetByIdAsync(product.Id);
                
                if(warehouse.Id != productResponse.WarehouseId)
                    throw new Exception("Produto não pertence ao deposito.");
                if (product.Amount > productResponse.Amount)
                    throw new Exception("Não existe produtos suficientes.");
                
                product.Name = productResponse.Name;
                product.Price = productResponse.Price;
                product.Weight = productResponse.Weight;
            }

            item.Weight = (double)item.Items.Sum(x => x.Weight * x.Amount);

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
