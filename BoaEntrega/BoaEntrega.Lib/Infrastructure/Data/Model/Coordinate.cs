using System;
using System.Collections.Generic;
using System.Text;

namespace BoaEntrega.Lib.Infrastructure.Data.Model
{
    public class Coordinate
    {
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }


        public override string ToString()
        {
            return $"{Latitude.ToString().Replace(',', '.')},{Longitude.ToString().Replace(',', '.')}";
        }
    }
}
