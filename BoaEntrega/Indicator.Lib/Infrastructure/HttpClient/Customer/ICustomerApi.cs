using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Indicator.Lib.Infrastructure.HttpClient.Customer
{
    public interface ICustomerApi
    {
        Task<CustomerResponse> GetByIdAsync(Guid id);
    }
}
