using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContractsLib;

namespace ServicesLib
{
    public class DataService : IDataService
    {
        public string SayHello(string name)
        {
            return string.Format("Welcome {0}!", name);
        }
    }
}
