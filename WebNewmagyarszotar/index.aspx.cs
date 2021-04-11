using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebNewmagyarszotar
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        DataBase db = new DataBase();

        protected void Page_Load(object sender, EventArgs e)
        {
            //connection_info = db.getAllDataDEBUG();
            if (Request.Cookies["User"] != null)
            {
                if (Request.Cookies["User"]["Logged"] != null)
                {
                    user_label.Text = Request.Cookies["User"]["Logged"].ToString();
                }
                else
                {
                    user_label.Text = "Unlogged";
                }
            }
            
        }

    }
}