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
    public class ClientDAL : IClientDALServices

    {
        private SqlConnection con = null;
        private SqlCommand cmd = null;

        public ClientDAL()
        {
            string s = ConfigurationManager.ConnectionStrings["FeedbackDBCon"].ConnectionString;
            con = new SqlConnection(s);
          cmd = new SqlCommand() { Connection = con };
        }
       





        public IEnumerable<Client> GetAllClients()
        {
            List<Client> response = new List<Client>();
            cmd.CommandText = "SELECT * FROM Client";
            SqlDataReader reader = null;

            try
            {
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Client client = new Client()
                    {
                        Client_ID = reader.GetInt32(0),
                        Client_Name = reader.GetString(1),
                       Client_Location = reader.GetString(2)
                       
                    };
                    response.Add(client);
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

        public Client GetClient(int Client_ID)
        {
            Client response = null;
            cmd.CommandText = "SELECT Client_Name, Client_Location from Client WHERE Client_ID =@Client_ID";
            cmd.Parameters.Add(new SqlParameter("@Client_ID", Client_ID));

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    response = new Client()
                    {
                        Client_ID = Client_ID,
                        Client_Name = reader.GetString(0),
                        Client_Location = reader.GetString(1)

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

        public bool AddClient(Client client)
        {
            bool response = false;
            cmd.CommandText = "INSERT Client VALUES(@Client_Name,@Client_Location)";
            cmd.Parameters.Add(new SqlParameter("@Client_Name", client.Client_Name));
            cmd.Parameters.Add(new SqlParameter("@Client_Location", client.Client_Location));
           
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

        public bool EditClient(Client client)
        {
            bool response = false;
            cmd.CommandText = "UPDATE Client SET Client_Name=@Client_Name,Client_Location=@Client_Location WHERE Client_ID =@Client_ID";
            cmd.Parameters.Add(new SqlParameter("@Client_ID", client.Client_ID));
            cmd.Parameters.Add(new SqlParameter("@Client_Name", client.Client_Name));
            cmd.Parameters.Add(new SqlParameter("@Client_Location", client.Client_Location));
           
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

        public bool RemoveClient(int Client_ID)
        {
            bool response = false;
            cmd.CommandText = "DELETE Client WHERE Client_ID = @Client_ID";
            cmd.Parameters.Add(new SqlParameter("@Client_ID", Client_ID));

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
