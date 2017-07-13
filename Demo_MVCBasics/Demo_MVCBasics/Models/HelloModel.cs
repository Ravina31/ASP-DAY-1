using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Demo_MVCBasics.Models
{
    public class HelloModel
    {   
        [Display(Name= "Enter some text")]
        public string Data { get; set; }
    }
}