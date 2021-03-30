using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebNewmagyarszotar
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void usernameBox_TextChanged(object sender, EventArgs e)
        {
            //már létező felhasználónév
        }

        protected void passwordBox1_TextChanged(object sender, EventArgs e)
        {
            //nem elég hosszú jelszó, nincs benne nagy betű, speciális karakter
        }

        protected void passwordBox2_TextChanged(object sender, EventArgs e)
        {
            //nem egyezik meg a két jelszó
        }

        protected void emailBox_TextChanged(object sender, EventArgs e)
        {
            //nem megfelelő formátumú email
        }

        protected void tovabb_Click(object sender, EventArgs e)
        {
            //submit button
        }
    }
}