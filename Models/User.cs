using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SCSDataBase.Models
{
    public class User
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string Password { get; set; }
        public char isAdmin { get; set; }
    
    }
}