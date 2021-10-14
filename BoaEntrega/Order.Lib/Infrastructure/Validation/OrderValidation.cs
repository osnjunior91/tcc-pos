using FluentValidation;
using Order.Lib.Infrastructure.Data;

namespace Order.Lib.Infrastructure.Validation
{
    public class OrderValidation : AbstractValidator<OrderModel>
    {
        public OrderValidation()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty();
            RuleFor(x => x.Items).NotNull();
            RuleFor(x => x.WarehouseId).NotNull().NotEmpty();
        }
    }
}
