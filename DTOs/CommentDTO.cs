using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTOs
{
    public class CommentDTO
    {
        public int ID { get; set; }

        public string Title { get; set; } = string.Empty;

        public string content { get; set; } = string.Empty;

        public DateTime dateTime {get; set;} = DateTime.Now;
        public int? stockId { get; set; }

        

    }
}