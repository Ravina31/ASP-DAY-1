using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class PaymentTerms
    {
       
            public string PaymentTermId { get; set; }
            public string PaymentTermName { get; set; }

            public string NoOfDays { get; set; }
             public string Discount { get; set; }

        public string DiscountDays { get; set; }

        public string PaymentTermCode { get; set; }


    }
}