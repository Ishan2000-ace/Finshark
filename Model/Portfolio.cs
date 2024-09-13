using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Model
{
    public class Portfolio
    {
        public string  AppUserId { get; set; }

        public int stockId { get; set; }

        public AppUser appUser {get; set;}

        public Stocks stocks { get; set; }
    }
}