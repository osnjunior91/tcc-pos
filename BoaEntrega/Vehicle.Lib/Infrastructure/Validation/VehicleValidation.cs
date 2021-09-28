using FluentValidation;
using Vehicle.Lib.Infrastructure.Data;

namespace Vehicle.Lib.Infrastructure.Validation
{
    public class VehicleValidation : AbstractValidator<VehicleModel>
    {
        public VehicleValidation()
        {
            RuleFor(x => x.Model).NotNull().NotEmpty();
            RuleFor(x => x.Plate).NotNull().NotEmpty();
            RuleFor(x => x.Year).NotNull().NotEmpty();
            RuleFor(x => x.Capacity).NotNull().GreaterThanOrEqualTo(0);
        }
    }
}
