using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using ContractsLib;

namespace ServicesLib
{
    public class DataService : IDataService
    {

        public string sayHello(string name)
        {
            return string.Format("welcome {0}", name);
        }
    }
}
