using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebNewmagyarszotar
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        DataBase db = new DataBase();
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = String.Empty;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = username_.Value;
            var user = db.verifyUser(username, Password1.Value);
            if (user!=null)
            {
                Label1.Text = "Fasza Üdv "+username;
                Response.Cookies["User"]["Logged"] = user.id.ToString();
                Response.Cookies["User"].Expires = DateTime.Now.AddHours(8);
                Response.Redirect("index.aspx");
                //Response.Redirect("index.aspx");
            }
            else
            {
                Label1.Text = db.getLatestErrorMsg();
            }
        }
    }
}