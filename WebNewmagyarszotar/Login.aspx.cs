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
            if(db.verifyUser(username_.Value, Password1.Value))
            {
                Label1.Text = "Fasza";
                Response.Cookies["User"]["Logged"] = username_.Value;
            }
            else
            {
                Label1.Text = "Nem Fasza "+db.getLatestErrorMsg();
            }
        }
    }
}