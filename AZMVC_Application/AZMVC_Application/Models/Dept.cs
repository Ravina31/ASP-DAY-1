using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AZMVC_Application.Models
{   
[Table(name:"Depts")]

    public class Dept
    {
        [Key]
        public int DeptNo { get; set; }


        [MaxLength(50)]
        public string SName { get; set; }


        [MaxLength(50)]
        public string Location { get; set; }
    }
}