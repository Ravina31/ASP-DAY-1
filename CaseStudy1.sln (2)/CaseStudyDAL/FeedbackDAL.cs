using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using System.Data.SqlClient;
using System.Data;
using System.ServiceModel;
using System.Configuration;

namespace CaseStudyDALServicesLib
{
    [ServiceBehavior]
    public class FeedbackDAL : IFeedbackDALServices
    {   
        
          private SqlConnection con = null;
        private SqlCommand cmd = null;

        public FeedbackDAL()
        { 
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["FeedbackDBCon"].ConnectionString);
            cmd = new SqlCommand() { Connection = con };
        }


        public IEnumerable<Feedback> GetAllFeedbacks()
        {
            List<Feedback> response = new List<Feedback>();
            cmd.CommandText = "SELECT * FROM Feedback";
            SqlDataReader reader = null;

            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Feedback feedback = new Feedback()
                    {
                        Identity_ID = reader.GetInt32(0),
                        Training_Name = reader.GetString(1),
                        Trainer_Name = reader.GetString(2),
                        Participant_Name = reader.GetString(3),
                        Designation = reader.GetString(4),
                        P_Email = reader.GetString(5),
                        O_Email = reader.GetString(6),
                        Mobile_No = reader.GetString(7),
                        Office_No = reader.GetString(8),
                        QOC = reader.GetString(9),
                        QOE = reader.GetString(10),
                        PSOT = reader.GetString(11),
                        QSBT = reader.GetString(12),
                        OQOP = reader.GetString(13),
                        Interest = reader.GetString(14),
                        Liked = reader.GetString(15),
                        Disliked = reader.GetString(16),
                        Comments = reader.GetString(17)

                    };
                    response.Add(feedback);
                }
            }
            catch (SqlException ex)
            {

                throw new FaultException<SqlException>(ex, ex.Message);
            }

            finally
            {

                if (con.State != System.Data.ConnectionState.Closed)
                {
                    con.Close();
                }
            }

            cmd.Parameters.Clear();
            cmd.CommandText = string.Empty;
            return response;
        }

        public Feedback GetFeedback(int Identity_ID)
        {
            Feedback response = null;
            cmd.CommandText = "SELECT Training_Name,Trainer_Name,Participant_Name,Designation,P_Email,O_Email,Mobile_No,Office_No,QOC,QOE,PSOT,QSBT,OQOP,Interest,Liked,Disliked,Comments from Feedback WHERE Identity_ID=@Identity_ID";
            cmd.Parameters.Add(new SqlParameter("@Identity_ID", Identity_ID));

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    response = new Feedback()
                    {
                        Identity_ID = Identity_ID,
                        Training_Name = reader.GetString(0),
                        Trainer_Name = reader.GetString(1),
                        Participant_Name = reader.GetString(2),
                        Designation = reader.GetString(3),
                        P_Email = reader.GetString(4),
                        O_Email = reader.GetString(5),
                        Mobile_No = reader.GetString(6),
                        Office_No = reader.GetString(7),
                        QOC = reader.GetString(8),
                        QOE = reader.GetString(9),
                        PSOT = reader.GetString(10),
                        QSBT = reader.GetString(11),
                        OQOP = reader.GetString(12),
                        Interest = reader.GetString(13),
                        Liked = reader.GetString(14),
                        Disliked = reader.GetString(15),
                        Comments = reader.GetString(16)
                     
                        

                    };
                }
            }
            catch (SqlException ex)
            {

                throw new FaultException<SqlException>(ex, ex.Message);
            }

            finally
            {

                if (con.State != System.Data.ConnectionState.Closed)
                {
                    con.Close();
                }
            }

            cmd.Parameters.Clear();
            cmd.CommandText = string.Empty;
            return response;
        }

        public bool AddFeedback(Feedback feedback)
        {
            bool response = false;
            cmd.CommandText = "INSERT Feedback VALUES(@Training_Name,@Trainer_Name,@Participant_Name,@Designation,@P_Email,@O_Email,@Mobile_No,@Office_No,@QOC,@QOE,@PSOT,@QSBT,@OQOP,@Interest,@Liked,@Disliked,@Comments)";
            cmd.Parameters.Add(new SqlParameter("@Training_Name", feedback.Training_Name));
            cmd.Parameters.Add(new SqlParameter("@Trainer_Name", feedback.Trainer_Name));
            cmd.Parameters.Add(new SqlParameter("@Participant_Name", feedback.Participant_Name));
            cmd.Parameters.Add(new SqlParameter("@Designation", feedback.Designation));
            cmd.Parameters.Add(new SqlParameter("@P_Email", feedback.P_Email));
            cmd.Parameters.Add(new SqlParameter("@O_Email", feedback.O_Email));
            cmd.Parameters.Add(new SqlParameter("@Mobile_No", feedback.Mobile_No));
            cmd.Parameters.Add(new SqlParameter("@Office_No", feedback.Office_No));
            cmd.Parameters.Add(new SqlParameter("@QOC", feedback.QOC));
            cmd.Parameters.Add(new SqlParameter("@QOE", feedback.QOE));
            cmd.Parameters.Add(new SqlParameter("@PSOT", feedback.PSOT));
            cmd.Parameters.Add(new SqlParameter("@QSBT", feedback.QSBT));
            cmd.Parameters.Add(new SqlParameter("@OQOP", feedback.OQOP));
            cmd.Parameters.Add(new SqlParameter("@Interest", feedback.Interest));
            cmd.Parameters.Add(new SqlParameter("@Liked", feedback.Liked));
            cmd.Parameters.Add(new SqlParameter("@Disliked", feedback.Disliked));
            cmd.Parameters.Add(new SqlParameter("@Comments", feedback.Comments));
       

            try
            {
                con.Open();
                int result = cmd.ExecuteNonQuery();
                response = (result == 1);
            }
            catch (SqlException ex)
            {

                throw new FaultException<SqlException>(ex, ex.Message);
            }

            finally
            {

                if (con.State != System.Data.ConnectionState.Closed)
                {
                    con.Close();
                }
            }

            cmd.Parameters.Clear();
            cmd.CommandText = string.Empty;
            return response;
        }

        public bool EditFeedback(Feedback feedback)
        {
            bool response = false;
            cmd.CommandText = "UPDATE Feedback SET Training_Name=@Training_Name,Trainer_Name=@Trainer_Name,Participant_Name=@Participant_Name,Designation=@Designation,P_Email=@P_Email,O_Email=@O_Email,Mobile_No=@Mobile_No,Office_No=@Office_No,QOC=@QOC,QOE=@QOE,PSOT=@PSOT,QSBT=@QSBT,OQOP=@OQOP,Interest=@Interest,Liked=@Liked,Disliked=@Disliked,Comments=@Comments WHERE Identity_ID =Identity_ID";
            cmd.Parameters.Add(new SqlParameter("@Training_Name", feedback.Training_Name));
            cmd.Parameters.Add(new SqlParameter("@Trainer_Name", feedback.Trainer_Name));
            cmd.Parameters.Add(new SqlParameter("@Participant_Name", feedback.Participant_Name));
            cmd.Parameters.Add(new SqlParameter("@Designation", feedback.Designation));
            cmd.Parameters.Add(new SqlParameter("@P_Email", feedback.P_Email));
            cmd.Parameters.Add(new SqlParameter("@O_Email", feedback.O_Email));
            cmd.Parameters.Add(new SqlParameter("@Mobile_No", feedback.Mobile_No));
            cmd.Parameters.Add(new SqlParameter("@Office_No", feedback.Office_No));
            cmd.Parameters.Add(new SqlParameter("@QOC", feedback.QOC));
            cmd.Parameters.Add(new SqlParameter("@QOE", feedback.QOE));
            cmd.Parameters.Add(new SqlParameter("@PSOT", feedback.PSOT));
            cmd.Parameters.Add(new SqlParameter("@QSBT", feedback.QSBT));
            cmd.Parameters.Add(new SqlParameter("@OQOP", feedback.OQOP));
            cmd.Parameters.Add(new SqlParameter("@Interest", feedback.Interest));
            cmd.Parameters.Add(new SqlParameter("@Liked", feedback.Liked));
            cmd.Parameters.Add(new SqlParameter("@Disliked", feedback.Disliked));
            cmd.Parameters.Add(new SqlParameter("@Comments", feedback.Comments));
            try
            {
                con.Open();
                int result = cmd.ExecuteNonQuery();
                response = (result == 1);
            }
            catch (SqlException ex)
            {

                throw new FaultException<SqlException>(ex, ex.Message);
            }

            finally
            {

                if (con.State != System.Data.ConnectionState.Closed)
                {
                    con.Close();
                }
            }

            cmd.Parameters.Clear();
            cmd.CommandText = string.Empty;
            return response;
        }

        public bool RemoveFeedback(int Identity_ID)
        {
            bool response = false;
            cmd.CommandText = "DELETE Feedback WHERE Identity_ID = @Identity_ID";
            cmd.Parameters.Add(new SqlParameter("@Identity_ID", Identity_ID));

            try
            {
                con.Open();
                int result = cmd.ExecuteNonQuery();
                response = (result == 1);
            }
            catch (SqlException ex)
            {

                throw new FaultException<SqlException>(ex, ex.Message);
            }

            finally
            {

                if (con.State != System.Data.ConnectionState.Closed)
                {
                    con.Close();
                }
            }

            cmd.Parameters.Clear();
            cmd.CommandText = string.Empty;
            return response;
        }
    }
}
