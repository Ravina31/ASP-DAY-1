using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Sample1 : System.Web.UI.Page
{
    string con = "Data Source=(localdb)\\Projects;Initial Catalog=records;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
    SqlDataAdapter da;
    DataSet dt;
    protected void Page_Load(object sender, EventArgs e)
    {
  //      bindgrid();
       // string username = Request.Form["txtuser"];
       // string password = Request.Form["txtpwd"];
       // string conpwd = Request.Form["conpwd"];
       // string email = Request.Form["email"];
       //string age = Request.Form["age"];
       // string mobile = Request.Form["mobile"];
      
       // Response.Write("Username-" + username + "<br/>Password-" + password + "<br/>Confirm password-"+conpwd+"<br/>Email-"+email+"<br/>Age-"+age+"<br/>Mobile-"+mobile);
        //string username = txtuser.Value;
        //string password = txtpwd.Value;
        //string em = email.Value;
        //string ag = age.Value;
        //string mob = mobile.Value;
        //Response.Write(username+ password+ em+ ag+ mob);
        if (!IsPostBack)
        {
            country.Items.Add(new ListItem("--Select Country--", "--Select Country") { Selected = true });
            country.Items.Add(new ListItem("India", "India"));
            country.Items.Add(new ListItem("US", "US"));
            country.Items.Add(new ListItem("canada", "canada"));
            bindgrid();
        }



    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            string username = txtuser.Text;
            string password = txtpwd.Text;
            string em = email.Text;
            string ag = age.Text;
            string mob = mobile.Text;
            string c = country.Text;
            lblheader.Text = String.Format("Username: {0} <br/> Password: {1} <br/> Email: {2} <br/> Age: {3} <br/> Mobile {4} ", username, password, em, ag, mob);
            
            
           
            SqlConnection cn = new SqlConnection(con);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
          cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into form values ('" + username + "' ,'" + password + "','" + em + "',"+ag+"," +mob+",'"+c+"')";
            cn.Open();
           cmd.ExecuteNonQuery();
          bindgrid();
         



        }
        else
        {
            lblheader.Text = "Page is not valid";
        }
        }
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (args.Value.Length != 10)
        {
            args.IsValid = false;
        }
    }
    protected void bindgrid()
    {
        try
        {
            SqlConnection cn = new SqlConnection(con);
            da = new SqlDataAdapter( "select * from form", cn);
            dt = new DataSet();
            da.Fill(dt, "form");
            GridView1.DataSource = dt.Tables["form"];
            GridView1.DataBind();



            
        }
        catch (Exception ex)
        {

            lblheader.Text = ex.Message;
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        bindgrid();
       
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        bindgrid();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string rid = GridView1.Rows[e.RowIndex].Cells[1].Text;
        try
        {
            SqlConnection cn = new SqlConnection(con);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from form where username=('" + rid+ "')";
            cn.Open();
            cmd.ExecuteNonQuery();
            
            GridView1.DataSource = dt.Tables["form"];
            bindgrid();





        }
        catch (Exception ex)
        {

            lblheader.Text = ex.Message;
        }


    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string usernm = GridView1.Rows[e.RowIndex].Cells[1].Text;
        string pwd = (GridView1.Rows[e.RowIndex].Cells[2].Controls[0] as TextBox).Text;
        string m = (GridView1.Rows[e.RowIndex].Cells[3].Controls[0] as TextBox).Text;
        string age = (GridView1.Rows[e.RowIndex].Cells[4].Controls[0] as TextBox).Text;
        string mob = (GridView1.Rows[e.RowIndex].Cells[5].Controls[0] as TextBox).Text;
        string c = (GridView1.Rows[e.RowIndex].Cells[6].Controls[0] as TextBox).Text;
        try
        {
            SqlConnection cn = new SqlConnection(con);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update form set username='" + usernm + "',password='"+pwd+ "',email='"+m+ " ',age='"+age+
                "'where mobile= '" + mob+ "'";
            cn.Open();
            cmd.ExecuteNonQuery();
            bindgrid();




        }
        catch (Exception ex)
        {

            lblheader.Text = ex.Message;
        }
        

    }
}