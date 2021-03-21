using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebNewmagyarszotar
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataBase db = new DataBase();
            Label1.Text = "Test<br>";
            foreach (KeyValuePair<String, EnglishWord> word in db.getAll())
            {
                Label1.Text += word.ToString() + "<br>";
            }
        }

    }
}