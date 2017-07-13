using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Sender : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {   //client side using query string
       // Response.Redirect("Receiver.aspx?name=" + txtName.Text);

        //client side using forms collection
       // Server.Transfer("Receiver.aspx");

        //client side using cookies
        //HttpCookie ck = new HttpCookie("dataCookie");
        //ck.Values.Add("name", txtName.Text);
        //ck.Expires = DateTime.Now.AddMinutes(1);
        //Response.Cookies.Add(ck);
        //Response.Redirect("Receiver.aspx");

        //server side- application/session
        Application["applevel_name"] = txtName.Text;
        Session["sessionlevel_name"] = txtName.Text;

    }
}