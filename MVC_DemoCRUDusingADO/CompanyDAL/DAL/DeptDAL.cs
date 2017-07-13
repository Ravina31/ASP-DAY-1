using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using CompanyEntities.Models;

namespace CompanyDAL.DAL
{
    public class DeptDAL
    {
        private SqlConnection con = null;
        private SqlCommand cmd = null;


        public DeptDAL()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["CompanyCon"].ConnectionString);
            cmd = new SqlCommand() { Connection = con};
        }

        public List<DeptModel> GetAllDepts()
        {
            cmd.CommandText = "SELECT * FROM Depts";
            List<DeptModel> depts = new List<DeptModel>();
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                DeptModel dept = new DeptModel()
                {
                    DeptNo = reader.GetInt32(0),
                    DName = reader.GetString(1),
                    Location = reader.GetString(2)
                };
                depts.Add(dept);
            }
            reader.Close();
            con.Close();
            cmd.CommandText = string.Empty;
            return depts;
           
        }



           public DeptModel GetDept(int DeptNo)
        {
            cmd.CommandText = "SELECT DName,Location FROM Depts where DeptNo = @DeptNo";
            DeptModel dept = null;
            cmd.Parameters.Add(new SqlParameter("@DeptNo", DeptNo));
            con.Open();
            List<DeptModel> depts = new List<DeptModel>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dept = new DeptModel()
                {
                    DeptNo = DeptNo,
                    DName = reader.GetString(0),
                    Location = reader.GetString(1)
                };
                depts.Add(dept);
            }
            reader.Close();
            con.Close();
            cmd.Parameters.Clear();
            cmd.CommandText = string.Empty;
            return dept;   
        }


        public bool CreateDept(DeptModel dept)
        {
            cmd.CommandText = "INSERT depts VALUES (@DeptNo, @DName, @Location)";
            cmd.Parameters.Add(new SqlParameter("@DeptNo", dept.DeptNo));
            cmd.Parameters.Add(new SqlParameter("@DName", dept.DName));
            cmd.Parameters.Add(new SqlParameter("@Location", dept.Location));

            
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            cmd.Parameters.Clear();
            cmd.CommandText = string.Empty;
            return result==1;
            
        }
           public bool EditDept(DeptModel dept)
        {
            cmd.CommandText = "UPDATE depts SET DName=@DName, Location=@Location WHERE DeptNo=@DeptNo";
            cmd.Parameters.Add(new SqlParameter("@DeptNo", dept.DeptNo));
            cmd.Parameters.Add(new SqlParameter("@DName", dept.DName));
            cmd.Parameters.Add(new SqlParameter("@Location", dept.Location));
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            cmd.Parameters.Clear();
            cmd.CommandText = string.Empty;
            return result == 1;
           
        }

        public bool DeleteDept(int DeptNo)
        {
            cmd.CommandText = "DELETE depts WHERE DeptNo=@DeptNo";
            cmd.Parameters.Add(new SqlParameter("@DeptNo", DeptNo));
            con.Open();
            int result = cmd.ExecuteNonQuery();
            con.Close();
            cmd.Parameters.Clear();
            cmd.CommandText = string.Empty;
            return result == 1;

        }
        
    }
}