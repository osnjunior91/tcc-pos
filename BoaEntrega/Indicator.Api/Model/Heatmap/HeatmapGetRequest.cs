﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indicator.Api.Model.Heatmap
{
    public class HeatmapGetRequest
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
