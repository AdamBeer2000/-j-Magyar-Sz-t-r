using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebNewmagyarszotar
{
    public enum PERMISSION
    {
        ADMIN,
        LOGGED,
        GUEST
    }

    public class User
    {
        //ONLY data storage! + functions what we need
        private string username;
        private PERMISSION permission;

        public string Username //GETTER - USERNAME
        {
            get { return this.username; }
            //set { this.username = value; }
        }
        public PERMISSION Permission //GETTER - PERMISSION
        {
            get { return this.permission; }
            //set { this.permission = value; }
        }

        public User() //CONSTRUCTOR
        {
            this.username = "";
            this.permission = PERMISSION.GUEST;
        }

        public void resetUser(string name, PERMISSION perm) //RESET USER [LOG OUT -> name=""; perm = PERMISSION.GUEST;] [LOG IN -> name="User"; perm = PERMISSION.LOGGED;]
        {
            this.username = name;
            this.permission = perm;
        }
    }
}