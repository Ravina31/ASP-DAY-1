using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GetDateTime : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DateTime currentdate = DateTime.Now;
        Response.ContentType = "text/event-stream";
        while (currentdate.AddMinutes(1) > DateTime.Now)
        {
            Response.Write(string.Format("data: {0} \n\n",
                DateTime.Now.ToString()));
            Response.Flush(); //To prevent the server from sending all the info at once at the end
            System.Threading.Thread.Sleep(1000); }
        }
    }
