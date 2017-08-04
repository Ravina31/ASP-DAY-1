using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using WebApplication4.Models;

namespace WebApplication4
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //string con = "Server=tcp:hx67tx2ygu.database.windows.net,1433;Database=DEV_SetupManager;User ID=gep_sql_admin;Password=Password@123;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
            //SqlConnection conn = new SqlConnection(con);
            //conn.Open();
            //SqlCommand cmd = new SqlCommand();
            //cmd.CommandText = "INSERT CSM_PaymentTerms1 VALUES(@PaymentTermId,@PaymentTermName,@NoOfDays,@Discount,@DiscountDays,@PaymentTermCode)";
            //cmd.Parameters.Add(new SqlParameter("@PaymentTermId", PaymentTermId));
            //cmd.Parameters.Add(new SqlParameter("@PaymentTermId", PaymentTermName));
            //cmd.Parameters.Add(new SqlParameter("@PaymentTermId", NoOfDays));
            //cmd.Parameters.Add(new SqlParameter("@PaymentTermId", Discount));
            //cmd.Parameters.Add(new SqlParameter("@PaymentTermId", DiscountDays));
            //cmd.Parameters.Add(new SqlParameter("@PaymentTermId", PaymentTermCode));

        }
    }
}