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
        DataBase db = DataBase.Instance;
        User logged = new User();
        protected void Page_Load(object sender, EventArgs e)
        {
            //connection_info = db.getAllDataDEBUG();
            if (Request.Cookies["User"] != null)
            {
                if (Request.Cookies["User"]["Logged"] != null)
                {
                    User logged = db.getUserById(Convert.ToInt32(Request.Cookies["User"]["Logged"]));
                    if (logged != null)
                    {
                        user_label.Visible = true;
                        user_label.Text = logged.Username;
                        register.Visible = false;
                        login.Visible = false;
                        deletebutton1.Visible = true;
                    }
                }
                else
                {
                    user_label.Text = "Unlogged";
                }
            }
            if(Request.Cookies["User"] == null)
            {
                explorer.Visible = false;
                engword.Visible = false;
                user_label.Visible = false;
                Button1.Visible = false;
                deletebutton1.Visible = false;
            }
        }

        protected void Logout_Click(object sender, ImageClickEventArgs e)
        {
            Response.Cookies["User"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect(Request.RawUrl);
        }

        protected void deletebutton1_Click(object sender, ImageClickEventArgs e)
        {
            DeleteUser.Show();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.Cookies["User"]["Logged"]);
            Response.Cookies["User"].Expires = DateTime.Now.AddDays(-1);
            db.deleteUser(id);
            DeleteUser.Hide();
            Response.Redirect("index.aspx");
        }

        protected void Cnacle_Click(object sender, EventArgs e)
        {
            DeleteUser.Hide();
        }
    }
}