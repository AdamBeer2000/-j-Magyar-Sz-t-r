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

<<<<<<< Updated upstream
        
=======
        public string  test ()
        {
            string querry = "SELECT eng.szo, hun.szo FROM szotar AS sz INNER JOIN magyarszo AS hun ON sz.magyarszo_id = hun.ID INNER JOIN angolszo AS eng ON eng.ID = sz.angolszo_id ORDER BY eng.szo";
            SqlCommand c = new SqlCommand(querry, conn);
            string thing="";
            try
            {
                conn.Open();
                SqlDataReader reader = c.ExecuteReader();
                while (reader.Read())
                {
                    thing += reader.GetString(0)+":"+reader.GetString(1)+"<br>";
                }

                conn.Close();
            }
            catch
            {
                return "Fuck";
            }
            return thing;
        }
>>>>>>> Stashed changes
    }
}