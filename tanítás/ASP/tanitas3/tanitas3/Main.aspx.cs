using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;

namespace tanitas3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        static List<HtmlGenericControl> cc;
        static string theam = "light";


        protected void Page_Load(object sender, EventArgs e)
        {
            if (cc is null)
            {
                cc = new List<HtmlGenericControl>();
                lista1.Controls.Clear();

                cc.Add(generate("Ez"));
                cc.Add(generate("egy"));
                cc.Add(generate("lista"));
            }

            if (Request.Cookies["User"] != null)
            {
                theam = Request.Cookies["User"]["Theam"].ToString();
                Label1.Text = theam;
            }

            update();
        }

        HtmlGenericControl generate(String text)
        {
            HtmlGenericControl li = new HtmlGenericControl("li");
            li.InnerText = text;
            return li;
        }

        protected void doit(object sender, EventArgs e)
        {
            String input = inputmezo.Text;
            harmadik.InnerHtml = input;
            update();
        }

        protected void Hozzaad(object sender, EventArgs e)
        {
            cc.Add(generate("Also szöveg"));
            update();
        }

        void update()
        {
            lista1.Controls.Clear();

            mainPage.Attributes.Add("class", theam);

            foreach (HtmlGenericControl c in cc)
            {
                lista1.Controls.Add(c);
            }
        }

        protected void light_button_Click(object sender, EventArgs e)
        {
            theam = "light";
            if (Request.Cookies["User"] is null)
            {
                HttpCookie userInfo = new HttpCookie("User");
                userInfo["Theam"] = "light";
                Response.Cookies.Add(userInfo);
            }
            else
            {
                Response.Cookies["User"]["Theam"] = "light";
            }
            update();
        }

        protected void dark_button_Click(object sender, EventArgs e)
        {
            theam = "black";
            if (Request.Cookies["User"] is null)
            {
                HttpCookie userInfo = new HttpCookie("User");
                userInfo["Theam"] = "black";
                Response.Cookies.Add(userInfo);
            }
            else
            {
                Response.Cookies["User"]["Theam"] = "black";
            }
            update();
        }
    }
}