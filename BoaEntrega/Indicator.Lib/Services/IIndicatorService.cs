using Indicator.Lib.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Indicator.Lib.Services
{
    public interface IIndicatorService
    {
        public Task<Heatmap> GetByPeriodAsync(DateTime start, DateTime end);
        public Task<OrderDelayed> GetOrderDelayedAsync(DateTime start, DateTime end);
    }
}
