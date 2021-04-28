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

        public string Username
        {
            get { return this.username; }
            //set { this.username = value; }
        }
        public PERMISSION Permission
        {
            get { return this.permission; }
            //set { this.permission = value; }
        }

        public User() 
        {
            this.username = "";
            this.permission = PERMISSION.GUEST;
        }

        public void resetUser(string name, PERMISSION perm)
        {
            this.username = name;
            this.permission = perm;
        }

    }
}