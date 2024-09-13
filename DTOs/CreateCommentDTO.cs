using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTOs
{
    public class CreateCommentDTO
    {
        public string Title { get; set; } = string.Empty;

        public string content { get; set; } = string.Empty;
    }
}