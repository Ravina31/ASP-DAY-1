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
    public interface ISchedule_TrainingDALService
    {
        [OperationContract]
        [FaultContract(typeof(SqlException))]
         IEnumerable<Schedule_Training> GetAllSchedule_Trainings();

        [OperationContract]
        [FaultContract(typeof(SqlException))]
        Schedule_Training GetSchedule_Training(int Training_ID);

        [OperationContract]
        [FaultContract(typeof(SqlException))]
        bool AddSchedule_Training(Schedule_Training schedule_training);

        [OperationContract]
        [FaultContract(typeof(SqlException))]
        bool EditSchedule_Training(Schedule_Training schedule_training);

        [OperationContract]
        [FaultContract(typeof(SqlException))]
        bool RemoveSchedule_Training(int Training_ID);




    }
}
