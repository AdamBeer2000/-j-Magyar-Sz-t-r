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
            if(db.regUser(Text1.Value,Text2.Value, Password1.Value))
            {
                Label1.Text = "Fasza";
            }
            else
            {
                Label1.Text = "Nem Fasza "+db.getLatestErrorMsg();
            }
        }
    }
}