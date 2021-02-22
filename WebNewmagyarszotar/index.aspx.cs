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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Server=tcp:the-first-git-emire.database.windows.net,1433;Initial Catalog=NewMagyarSzotar;Persist Security Info=False;User ID=pistabacsi;Password=Nemezajelszo1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                con.Open();
                Label1.Text = "Fasza :)";
                con.Close();
            }
            catch
            {
                Label1.Text = "Nem Fasza :(";
            }
            
        }
    }
}