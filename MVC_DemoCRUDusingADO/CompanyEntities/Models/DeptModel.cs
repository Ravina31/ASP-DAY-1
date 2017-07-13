using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using CompanyEntities.DataAnnotations;

namespace CompanyEntities.Models
{  
    public class DeptModel
    {
        [Display(Name = "Department #")]
        [Required(ErrorMessage ="Department # is mandatory")]
        [RegularExpression("[1-9][0-9]*")]
        //[Range(10,10000)]
        [DynamicRangeAttribute] //writing attribute is not mandatory
        public int DeptNo { get; set; }

        [Display(Name = "Department Name")]
        [Required(ErrorMessage = "Department # is mandatory")]
        [MaxLength(50)]
        [RegularExpression("[A-Za-z][A-Za-z ._-]*",ErrorMessage ="Name is incorrect")]
        public string DName { get; set; }

        [Display(Name = "Department Location")]
        [MaxLength(50)]
        [RegularExpression("[A-Za-z][A-Za-z ._-]*",ErrorMessage ="Enter the correct location")]
        public string Location { get; set; }

    }
}