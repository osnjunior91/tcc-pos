using FluentValidation;
using Product.Lib.Infrastructure.Data;
using System;

namespace Product.Lib.Infrastructure.Validation
{
    public class ProductValidation : AbstractValidator<ProductModel>
    {
        public ProductValidation()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Weight).NotNull().LessThanOrEqualTo(0);
            RuleFor(x => x.Amount).NotNull().LessThanOrEqualTo(0);
            RuleFor(x => x.Price).NotNull().LessThanOrEqualTo(0);
            RuleFor(x => x.WarehouseId).Must(ValidateBar).When(x => x.WarehouseId != null);
        }

        private bool ValidateBar(Guid guid)
        {
            return guid != Guid.Empty;
        }
    }
}
