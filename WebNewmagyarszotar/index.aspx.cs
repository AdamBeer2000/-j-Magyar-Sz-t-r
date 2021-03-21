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
        string connection_info = "Pending";
        DataBase db = new DataBase();

        protected void Page_Load(object sender, EventArgs e)
        {
            connection_info = db.connect();
            if(connection_info.Equals("CONNECTED"))
            {
                //YEY ->Connection check
            }
            //connection_info = db.getAllDataDEBUG();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}