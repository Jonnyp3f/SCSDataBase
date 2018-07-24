using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SCSDataBase.Models
{
    public class DataBase
    {
            [Required]
            [Url]
            public string URL { get; set; }
            [Required]
            public string category { get; set; }
            [Required]
            public string description { get; set; }
            public bool isApproved { get; set; }
            [Required]
            public string user { get; set; }
            public int id { get; set; }


       
    }
    
}