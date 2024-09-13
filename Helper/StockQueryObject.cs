using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper
{
    public class StockQueryObject
    {
        public string Symboll { get; set; } = string.Empty;

        public string CompanyName { get; set; } = string.Empty;

        public string  sortBY { get; set; } = string.Empty;

        public bool isDscending {get; set;} = false;

        public int PageNo { get; set; } = 1;

        public int PageSize {get; set;} = 20;
    }
}