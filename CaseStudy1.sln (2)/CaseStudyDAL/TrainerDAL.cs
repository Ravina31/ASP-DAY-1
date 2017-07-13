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
{   [ServiceBehavior]

    public class TrainerDAL : ITrainerDALServices
    {
        private SqlConnection con = null;
        private SqlCommand cmd = null;

        public TrainerDAL()
        {
             con = new SqlConnection(ConfigurationManager.ConnectionStrings["FeedbackDBCon"].ConnectionString);
             cmd = new SqlCommand() { Connection = con };
        }





        public IEnumerable<Trainer> GetAllTrainers()
        {
            List<Trainer> response = new  List<Trainer>();
            cmd.CommandText = "SELECT * FROM Trainer";
           SqlDataReader reader = null;

            try
            {
                con.Open();
               reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Trainer trainer = new Trainer()
                    {
                        Trainer_ID = reader.GetInt32(0),
                        Trainer_Name = reader.GetString(1),
                        Email_ID = reader.GetString(2),
                        Base_Location = reader.GetString(3),
                        Profile_Link = reader.GetString(4)
                    };
                    response.Add(trainer);
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
      

        public Trainer GetTrainer(int Trainer_ID)
        {

            Trainer response = null;
            cmd.CommandText = "SELECT Trainer_Name, Email_ID, Base_Location, Profile_Link from Trainer WHERE Trainer_ID = @Trainer_ID";
            cmd.Parameters.Add(new SqlParameter("@Trainer_ID", Trainer_ID));

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    response = new Trainer()
                    {
                        Trainer_ID = Trainer_ID,
                        Trainer_Name = reader["Trainer_Name"].ToString(),
                        Email_ID = reader.GetString(1),
                        Base_Location = reader.GetString(2),
                        Profile_Link = reader.GetString(3)


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

        public bool AddTrainer(Trainer trainer)
        {
            bool response = false;
            cmd.CommandText = "INSERT Trainer VALUES(@Trainer_Name,@Email_ID,@Base_Location,@Profile_Link)";
            cmd.Parameters.Add(new SqlParameter("@Trainer_Name",trainer.Trainer_Name));
                 cmd.Parameters.Add(new SqlParameter("@Email_ID",trainer.Email_ID));
                 cmd.Parameters.Add(new SqlParameter("@Base_Location",trainer.Base_Location));
                  cmd.Parameters.Add(new SqlParameter("@Profile_Link",trainer.Profile_Link));

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

                  finally {
                     
                      if (con.State != System.Data.ConnectionState.Closed)
                      {
                          con.Close();
                      }
                  }

            cmd.Parameters.Clear();
            cmd.CommandText = string.Empty;
            return response;
        }

        public bool EditTrainer(Trainer trainer)
        {

            bool response = false;
            cmd.CommandText = "UPDATE Trainer SET Trainer_Name=@Trainer_Name,Email_ID=@Email_ID,Base_Location=@Base_Location,Profile_Link=@Profile_Link WHERE Trainer_ID =@Trainer_ID";
            cmd.Parameters.Add(new SqlParameter("@Trainer_ID", trainer.Trainer_ID));
            cmd.Parameters.Add(new SqlParameter("@Trainer_Name", trainer.Trainer_Name));
            cmd.Parameters.Add(new SqlParameter("@Email_ID", trainer.Email_ID));
            cmd.Parameters.Add(new SqlParameter("@Base_Location", trainer.Base_Location));
            cmd.Parameters.Add(new SqlParameter("@Profile_Link", trainer.Profile_Link));

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

        public bool RemoveTrainer(int Trainer_ID)
        {
            bool response = false;
            cmd.CommandText = "DELETE TRAINER WHERE Trainer_ID = @Trainer_ID";
            cmd.Parameters.Add(new SqlParameter("@Trainer_ID", Trainer_ID));
           
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
