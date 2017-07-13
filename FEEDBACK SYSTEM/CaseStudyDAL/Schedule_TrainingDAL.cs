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
   public class Schedule_TrainingDAL: ISchedule_TrainingDALService
    {
         
          private SqlConnection con = null;
        private SqlCommand cmd = null;

        public Schedule_TrainingDAL()
        { 
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["FeedbackDBCon"].ConnectionString);
            cmd = new SqlCommand() { Connection = con };
        }


    //    public void insertST(Schedule_Training st)
    //    {
    //        try
    //        {
    //            db d = new db();
    //            d.connect();
    //            string con = "Data Source=(localdb)\\Projects;Initial Catalog=Casestudy;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False"; 
    //            SqlConnection cn = new SqlConnection(con);
    //            SqlCommand cmd = new SqlCommand();
    //            cmd.Connection = cn;
    //            cn.Open();
    //            cmd.CommandType = CommandType.Text;
    //            cmd.CommandText = "INSERT Schedule_Training VALUES(@trainingName,@trainerName,@Start_Date,@End_Date)";//"insert into Schedule_Training values ('" + st.Training_Name + "','" + st.Trainer_Name + "',#" + st.Start_Date + "#,#" + st.End_Date + "#)";
    //            cmd.Parameters.Add(new SqlParameter("@trainingName", st.Training_Name));
    //            cmd.Parameters.Add(new SqlParameter("@trainerName", st.Trainer_Name));
    //            cmd.Parameters.Add(new SqlParameter("@Start_Date", st.Start_Date));
    //            cmd.Parameters.Add(new SqlParameter("@End_Date", st.End_Date));
    //            cmd.ExecuteNonQuery();

    //            cn.Close();


    //        }
    //        catch (Exception e)
    //        {

    //        }
    //    }

        public IEnumerable<Schedule_Training> GetAllSchedule_Trainings()
        {
            List<Schedule_Training> response = new List<Schedule_Training>();
            cmd.CommandText = "SELECT * FROM Schedule_Training";
            SqlDataReader reader = null;

            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Schedule_Training schedule_training = new Schedule_Training()
                    {
                        Training_ID = reader.GetInt32(0),
                        Training_Name = reader.GetString(1),
                        Trainer_Name = reader.GetString(2),
                         Start_Date = reader.GetDateTime(3),
                        End_Date = reader.GetDateTime(4)

                    };
                    response.Add(schedule_training);
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

        public Schedule_Training GetSchedule_Training(int Training_ID)
        {
            Schedule_Training response = null;
            cmd.CommandText = "SELECT Training_Name ,Trainer_Name,Start_Date,End_Date from Schedule_Training WHERE Training_ID=@Training_ID";
            cmd.Parameters.Add(new SqlParameter("@Training_ID", Training_ID));

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    response = new Schedule_Training()
                    {
                        Training_ID = Training_ID,
                        Training_Name = reader.GetString(0),
                        Trainer_Name = reader.GetString(1),
                        Start_Date = reader.GetDateTime(2),
                        End_Date = reader.GetDateTime(3)
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

        public bool AddSchedule_Training(Schedule_Training schedule_training)
        {
            bool response = false;
            cmd.CommandText = "INSERT Schedule_Training VALUES(@Training_Name,@Trainer_Name,@Start_Date,@End_Date)";
            cmd.Parameters.Add(new SqlParameter("@Training_Name", schedule_training.Training_Name));
            cmd.Parameters.Add(new SqlParameter("@Trainer_Name", schedule_training.Trainer_Name));
            cmd.Parameters.Add(new SqlParameter("@Start_Date", schedule_training.Start_Date));
            cmd.Parameters.Add(new SqlParameter("@End_Date", schedule_training.End_Date));

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

        public bool EditSchedule_Training(Schedule_Training schedule_training)
        {
            bool response = false;
            cmd.CommandText = "UPDATE Schedule_Training SET Training_Name=@Training_Name,Trainer_Name=@Trainer_Name,Start_Date=@Start_Date,End_Date=@End_Date WHERE Training_ID =@Training_ID";
            cmd.Parameters.Add(new SqlParameter("@Training_ID", schedule_training.Training_ID));
            cmd.Parameters.Add(new SqlParameter("@Training_Name", schedule_training.Training_Name));
            cmd.Parameters.Add(new SqlParameter("@Trainer_Name", schedule_training.Trainer_Name));
            cmd.Parameters.Add(new SqlParameter("@Start_Date", schedule_training.Start_Date));
            cmd.Parameters.Add(new SqlParameter("@End_Date", schedule_training.End_Date));

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

        public bool RemoveSchedule_Training(int Training_ID)
        {
            bool response = false;
            cmd.CommandText = "DELETE Schedule_Training WHERE Training_ID = @Training_ID";
            cmd.Parameters.Add(new SqlParameter("@Training_ID", Training_ID));

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
