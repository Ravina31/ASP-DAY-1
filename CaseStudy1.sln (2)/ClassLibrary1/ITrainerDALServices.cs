using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Data.SqlClient;

namespace BusinessEntities
{
    [ServiceContract(SessionMode = SessionMode.NotAllowed)]
    public interface ITrainerDALServices
    {   
        [OperationContract]
        [FaultContract(typeof(SqlException))]
        IEnumerable<Trainer> GetAllTrainers();

        [OperationContract]
        [FaultContract(typeof(SqlException))]
        Trainer GetTrainer(int Trainer_ID);

        [OperationContract]
        [FaultContract(typeof(SqlException))]
        bool AddTrainer(Trainer trainer);

         [OperationContract]
         [FaultContract(typeof(SqlException))]
        bool EditTrainer(Trainer trainer);

         [OperationContract]
         [FaultContract(typeof(SqlException))]
        bool RemoveTrainer(int Trainer_ID);


    }
}
