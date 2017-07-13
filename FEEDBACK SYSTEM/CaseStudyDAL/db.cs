using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using BusinessEntities;


namespace CaseStudyDALServicesLib
{
   public class db
   {
       public string con = "Data Source=(localdb)\\Projects;Initial Catalog=Casestudy;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
        public void connect()
        {   
            SqlConnection cn = new SqlConnection(con);
            cn.Open();


        }
    }
}
