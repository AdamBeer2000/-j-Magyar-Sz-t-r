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
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = username_.Value;
            int id = db.verifyUser(username, Password1.Value);
            if (id!=-1)
            {
                Label1.Text = "Fasza Üdv "+username;
                Response.Cookies["User"]["Logged"] = id.ToString();
                Response.Cookies["User"].Expires = DateTime.Now.AddHours(8);

                //Response.Redirect("index.aspx");
            }
            else
            {
                Label1.Text = "Nem Fasza "+db.getLatestErrorMsg();
            }
        }
    }
}