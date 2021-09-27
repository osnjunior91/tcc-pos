using BoaEntrega.Lib.Infrastructure.Data.Repository;
using FluentValidation;
using Product.Lib.Infrastructure.Data;
using Product.Lib.Infrastructure.HttpClient.Warehouse;
using Product.Lib.Infrastructure.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Product.Lib.Services
{
    public class ProductService : IProductService
    {
        private readonly IWarehouseApi _warehouseApi;
        private readonly IRepository<ProductModel> _repository;
        public ProductService(IWarehouseApi warehouseApi, IRepository<ProductModel> repository)
        {
            _warehouseApi = warehouseApi;
            _repository = repository;
        }
        public async Task<ProductModel> CreateAsync(ProductModel item)
        {
            var validator = new ProductValidation();
            validator.ValidateAndThrow(item);

            var warehouse = await _warehouseApi.GetById(item.WarehouseId);
            if (warehouse == null || warehouse.Id == Guid.Empty)
                throw new ArgumentException("Invalid parameter WarehouseId");
            
            return await _repository.CreateAsync(item);
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ProductModel> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException();
            return await _repository.GetByIdAsync(id);
        }

        public Task<ProductModel> UpdateAsync(Guid id, ProductModel item)
        {
            throw new NotImplementedException();
        }
    }
}
