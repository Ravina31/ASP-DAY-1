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
  public   interface IFeedbackDALServices
    {
        [OperationContract]
        [FaultContract(typeof(SqlException))]
         IEnumerable<Feedback> GetAllFeedbacks();

        [OperationContract]
        [FaultContract(typeof(SqlException))]
        Feedback GetFeedback(int Identity_ID);

        [OperationContract]
        [FaultContract(typeof(SqlException))]
        bool AddFeedback(Feedback feedback);

        [OperationContract]
        [FaultContract(typeof(SqlException))]
        bool EditFeedback( Feedback feedback);

        [OperationContract]
        [FaultContract(typeof(SqlException))]
        bool RemoveFeedback(int Identity_ID);


    }
}
