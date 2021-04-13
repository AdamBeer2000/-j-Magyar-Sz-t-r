using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace tanitas3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        static int gomblenyomva = 0;
        static List<HtmlGenericControl> cc;
        
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
            update();
        }

        protected void doit(object sender, EventArgs e)
        {
            String input = inputmezo.Text;
            harmadik.InnerHtml = input;
        }

        protected void Hozzaad(object sender, EventArgs e)
        {
            cc.Add(generate("Also szöveg"));
            update();
        }

        void update()
        {
            lista1.Controls.Clear();
            foreach (HtmlGenericControl c in cc)
            {
                lista1.Controls.Add(c);
            }
        }

        HtmlGenericControl generate(String text)
        {
            HtmlGenericControl li = new HtmlGenericControl("li");
            li.InnerText = text;
            return li;
        }
    }
}