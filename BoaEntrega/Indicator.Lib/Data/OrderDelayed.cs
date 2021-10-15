using System;
using System.Collections.Generic;
using System.Text;

namespace Indicator.Lib.Data
{
    public class OrderDelayed
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Count { get; set; }
        public int Delayed { get; set; }
        public int NotDelayed { get; set; }
    }
}
