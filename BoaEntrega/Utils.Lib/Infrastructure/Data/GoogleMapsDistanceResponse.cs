using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Utils.Lib.Infrastructure.Data
{
    public class GoogleMapsDistanceResponse
    {
        public List<Row> Rows { get; set; }
        public string Status { get; set; }
    }

    public class Row
    {
        public List<Element> Elements { get; set; }
    }

    public class Element
    {
        public Result Distance { get; set; }
        public Result Duration { get; set; }
    }
    public class Result
    {
        public string Text { get; set; }
        public int Value { get; set; }
    }
}
