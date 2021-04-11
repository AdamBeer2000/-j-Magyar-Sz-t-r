using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebNewmagyarszotar
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        int engWordId=-666;
        public WebForm8()
        {

        }
        public WebForm8(int engWordId)
        {
            this.engWordId = engWordId;
        }
        DataBase db = new DataBase();
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text =""+ engWordId;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["User"] != null)
            {
                if(Request.Cookies["User"]["Logged"] != null)
                {
                    if(db.addHunWord(TextBox1.Text, Convert.ToInt32(Request.Cookies["User"]["Logged"]), engWordId))
                        Label1.Text = "Fasza";
                    else Label1.Text = "Nem Fasza"+db.getLatestErrorMsg();
                    return;
                }
            }
            Label1.Text = "Nem Fasza";
        }
    }
}