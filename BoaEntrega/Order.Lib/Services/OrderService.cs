using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using BoaEntrega.Lib.Infrastructure.Data.Repository;
using FluentValidation;
using Order.Lib.Infrastructure.Data;
using Order.Lib.Infrastructure.HttpClient.Customer;
using Order.Lib.Infrastructure.HttpClient.Product;
using Order.Lib.Infrastructure.HttpClient.Utils;
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
        private readonly IUtilsApi _utilsApi;

        public OrderService(
            IRepository<OrderModel> repository, ICustomerApi customerApi, 
            IWarehouseApi warehouseApi, IProductApi productApi, IUtilsApi utilsApi)
        {
            _repository = repository;
            _customerApi = customerApi;
            _warehouseApi = warehouseApi;
            _productApi = productApi;
            _utilsApi = utilsApi;
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

                if (!await _productApi.UpdateAmountAsync(product.Id, (productResponse.Amount - product.Amount)))
                {
                    throw new Exception("Error ao atualizar os estoque.");
                }

                product.Name = productResponse.Name;
                product.Price = productResponse.Price;
                product.Weight = productResponse.Weight;
            }

            item.Weight = (double)item.Items.Sum(x => x.Weight * x.Amount);

            var portage = await _utilsApi.PortageAsync(new PortageRequest(warehouse.Address, customer.Address, item.Weight));
            item.ShippingCost = portage.Price;
            item.PrevisionDeliveryDate = CalculateDateDelivery(portage.Distance);

            item.Status = OrderStatus.Separation;

            return await _repository.CreateAsync(item);
        }

        private DateTime? CalculateDateDelivery(double distance)
        {
            if (distance < 50000)
            {
                return DateTime.UtcNow.AddDays(1);
            }
            else if (distance < 200000)
            {
                return DateTime.UtcNow.AddDays(3);
            }
            else
            {
                return DateTime.UtcNow.AddDays(5);
            }
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

        public async Task<List<OrderModel>> GetOrderByPeriodAsync(DateTime start, DateTime end)
        {
            List<ScanCondition> filter = new List<ScanCondition>();
            filter.Add(new ScanCondition("CreatedAt", ScanOperator.Between, new object[] { start, end }));
            return await _repository.GetAllByFilterAsync(filter);
        }
    }
}
