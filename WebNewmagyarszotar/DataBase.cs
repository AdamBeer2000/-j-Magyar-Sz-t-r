using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace WebNewmagyarszotar
{
    public class DataBase
    {
        private SqlConnection conn = new SqlConnection("Server=tcp:the-first-git-emire.database.windows.net,1433;Initial Catalog=NewMagyarSzotar;Persist Security Info=False;User ID=pistabacsi;Password=Nemezajelszo1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        
        public DataBase()
        {

        }

        public string connect()
        {
            string result = "";

            try
            {
                conn.Open();
                result = "CONNECTED";
                conn.Close();               
            }
            catch (SqlException ex)
            {
                result = ex.Message;
            }

            return result;
        }
    }
}