using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Receiver : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       // Label1.Text = Request.QueryString["name"];

       // Label1.Text = Request.Form["txtName"];

       // HttpCookie ck = Request.Cookies["dataCookie"];
      //  Label1.Text = ck.Values["name"];

        Label1.Text = Application["applevel_name"].ToString() +
            " <br/> " + Session["sessionlevel_name"].ToString();
    }
}