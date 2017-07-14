using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MV_DemoModelBinding.Models
{
    public class PersonModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }
    }
}