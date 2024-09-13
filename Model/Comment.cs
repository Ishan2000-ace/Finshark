using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Model
{
    public class Comment
    {
        public int ID { get; set; }

        public string Title { get; set; } = string.Empty;

        public string content { get; set; } = string.Empty;

        public DateTime dateTime {get; set;} = DateTime.Now;
        public int? stockId { get; set; }

        public Stocks? stock { get; set; }

        public string UserId {get; set;}

        public AppUser Id { get; set; }
    }
}