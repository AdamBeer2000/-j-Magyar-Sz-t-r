using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebNewmagyarszotar
{
    public class User
    {
        //csak adatot tárol!
        //username
        //permission
        private string username = "";
        //private int/enum permission = ?

        public string Username
        {
            get { return this.username; }
            set { this.username = value; }
        }

        public User() { }

    }
}