using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_DemoCustomControllerFactory.BizLayer
{
    public class BizLayer2 : IBizLayer
    {
        public string GetData()
        {
            return "Hello again Looking for DI to work! From BizLAyer2.GetData()";
        }
    }
}