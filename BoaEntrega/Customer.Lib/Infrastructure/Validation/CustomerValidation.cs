using Customer.Lib.Infrastructure.Data.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Customer.Lib.Infrastructure.Validation
{
    public class CustomerValidator : AbstractValidator<CustomerModel>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.Document).NotNull().NotEmpty();
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Name).NotNull().NotEmpty();
        }
    }
}
