using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Indicator.Lib.Infrastructure.HttpClient.Utils
{
    public interface IUtilsApi
    {
        Task<PortageResponse> PortageAsync(PortageRequest data);
    }
}
