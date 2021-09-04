using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Warehouse.Lib.Infrastructure.Data;

namespace Warehouse.Lib.Infrastructure.Validation
{
    public class WarehouseValidation : AbstractValidator<WarehouseModel>
    {
        public WarehouseValidation()
        {
            RuleFor(x => x.CorporateName).NotNull().NotEmpty();
            RuleFor(x => x.RegisterNumber).NotNull().NotEmpty();
            RuleFor(x => x.FantasyName).NotNull().NotEmpty();
        }
    }
}
