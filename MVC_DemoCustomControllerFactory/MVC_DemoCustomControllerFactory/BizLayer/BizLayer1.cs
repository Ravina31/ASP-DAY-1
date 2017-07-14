using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_DemoCustomControllerFactory.BizLayer
{
    public class BizLayer1 : IBizLayer
    {
        public string GetData()
        {
            return "Hello there from bizlayer 1.GetData()";
        }
    }
}