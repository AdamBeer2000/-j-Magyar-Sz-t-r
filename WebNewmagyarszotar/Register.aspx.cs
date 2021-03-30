﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebNewmagyarszotar
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        static DataBase db = new DataBase();

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
            int count=0;
            //üres ellenőrzés
            if (usernameBox.Text == String.Empty)
            {
                count++;
                hiba_username.InnerText = "Nincs megadva felhasználónév";
            }
            if (passwordBox1.Text == String.Empty)
            {
                count++;
                hiba_password1.InnerText = "Nincs megadva jelszó";
            }
            if (passwordBox2.Text == String.Empty)
            {
                count++;
                hiba_password2.InnerText = "Nincs megadva ellenőrző jelszó";
            }
            if (emailBox.Text==String.Empty)
            {
                count++;
                hiba_email.InnerText = "Nincs megadva e-mail cím";
            }

            if (passwordBox1.Text!= passwordBox2.Text)
            {
                count++;
                hiba_password2.InnerText = "A jelszó nem egyezik az ellenőrző jelszóval";
            }

            if(count!=0)
            {
                Label1.Text =""+ count;
                return;
            }

            if (db.regUser(usernameBox.Text, passwordBox1.Text, emailBox.Text))
            {
                Label1.Text = "Sikeres regisztráció :";
            }
            else
            {
                Label1.Text = "Sikertelen regisztráció: "+db.getLatestErrorMsg();
            }
        }
    }
}