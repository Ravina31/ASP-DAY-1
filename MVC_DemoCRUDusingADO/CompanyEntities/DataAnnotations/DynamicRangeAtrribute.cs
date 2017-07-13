using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace CompanyEntities.DataAnnotations
{
    //class DynamicRangeAttribute : ValidationAttribute
    //{
    //    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    //    {
    //        int target = Convert.ToInt32(value);
    //        int min = int.Parse(ConfigurationManager.AppSettings["min"]);
    //        int max = int.Parse(ConfigurationManager.AppSettings["max"]);

    //        if(target>=min && target <=max)
    //        {
    //            return null;
    //        }
    //        else
    //        {
    //            return new ValidationResult($"The value for {validationContext.DisplayName} must be between {min} and {max} ");
    //        }
    //    }
    //}
    public class DynamicRangeAttribute : RangeAttribute
    {
        public DynamicRangeAttribute():base(int.Parse(ConfigurationManager.AppSettings["min"]), int.Parse(ConfigurationManager.AppSettings["max"]))
        {
        
        }
    }

}
