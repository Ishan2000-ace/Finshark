using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DTOs
{
    public class UserDTO
    {
        [Required]
        public string UserName { get; set; } = string.Empty;

        [EmailAddress]
        [Required]
        public string EmailAddress { get; set; } = string.Empty;

        [Required]

        public string Password {get; set;} = string.Empty;
    }
}