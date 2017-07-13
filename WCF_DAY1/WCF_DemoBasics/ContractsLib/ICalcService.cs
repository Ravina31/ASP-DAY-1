using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ContractsLib
{   
    [ServiceContract]

    public interface ICalcService
    {   [OperationContract]
        double Add(double a, double b);

         [OperationContract]
        double Subtract(double a, double b);

         [OperationContract]
        double Divide(double a, double b);

         [OperationContract]
        double Multiply(double a, double b);

         [OperationContract]
        double Modulus(double a, double b);


    }
}
