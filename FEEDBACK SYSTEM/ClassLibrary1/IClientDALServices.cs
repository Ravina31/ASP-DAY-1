using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Data.SqlClient;

namespace BusinessEntities
{

    [ServiceContract]
    public interface IClientDALServices
    {

        [OperationContract]
        [FaultContract(typeof(SqlException))]
        IEnumerable<Client> GetAllClients();

        [OperationContract]
        [FaultContract(typeof(SqlException))]
        Client GetClient(int Client_ID);

        [OperationContract]
        [FaultContract(typeof(SqlException))]
        bool AddClient(Client client);

        [OperationContract]
        [FaultContract(typeof(SqlException))]
        bool EditClient(Client client);

        [OperationContract]
        [FaultContract(typeof(SqlException))]
        bool RemoveClient(int Client_ID);


    }
}
