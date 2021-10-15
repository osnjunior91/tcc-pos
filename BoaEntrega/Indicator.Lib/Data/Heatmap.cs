using BoaEntrega.Lib.Infrastructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Indicator.Lib.Data
{
    public class Heatmap
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public List<HeatmapItem> Items { get; set; }
        public int Count { get; set; }

        public Heatmap(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
            Items = new List<HeatmapItem>();
        }
    }

    public class HeatmapItem
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Coordinate Coordinates { get; set; }
    }
}
