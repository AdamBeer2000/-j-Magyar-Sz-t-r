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

        private string latestErrorMsg;

        public string getLatestErrorMsg()
        {
            return latestErrorMsg;
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

        public Dictionary<String, EnglishWord> getAll()
        {
            //todo egyszerre ne az egészet hanem csak párat töltsön le pl 50-et mert egy 1000 szavas cucra ez sok
            string querry = "SELECT angolszo_id,angolszo.szo,definicio,angolszo.bekuldo,magyarszo_id,magyarszo.szo,magyarszo.bekuldo,tetszes,nemtetszes FROM szotar JOIN angolszo on angolszo_id = angolszo.ID JOIN magyarszo on magyarszo_id = magyarszo.ID";

            Dictionary<String, EnglishWord> words = new Dictionary<String, EnglishWord>();

            SqlCommand c = new SqlCommand(querry, conn);
            try
            {
                conn.Open();
                SqlDataReader reader = c.ExecuteReader();

                while (reader.Read())
                {
                    if (!words.ContainsKey(reader.GetString(1)))
                    {
                        words.Add(reader.GetString(1), new EnglishWord(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3)));
                        words[reader.GetString(1)].addTranslation(new HungarianWord(reader.GetInt32(4), reader.GetString(5), reader.GetString(6), reader.GetInt32(7), reader.GetInt32(8)));
                    }
                    else
                    {
                        words[reader.GetString(1)].addTranslation(new HungarianWord(reader.GetInt32(4), reader.GetString(5), reader.GetString(6), reader.GetInt32(7), reader.GetInt32(8)));
                    }

                }
                conn.Close();
            }
            catch (Exception e)
            {
                latestErrorMsg = e.Message;
            }

            return words;
        }
        public void addLike(int id)
        {
            string querry = "UPDATE magyarszo SET tetszes = tetszes + 1 WHERE id = "+id;
            try
            {
                conn.Open();
                SqlCommand c = new SqlCommand(querry, conn);
                SqlDataReader reader = c.ExecuteReader();
                conn.Close();

            }
            catch (Exception e)
            {
                latestErrorMsg = e.Message;
            }
        }
        public void addDislike(int id)
        {
            string querry = "UPDATE magyarszo SET nemtetszes = nemtetszes + 1 WHERE id = " + id;
            try
            {
                conn.Open();
                SqlCommand c = new SqlCommand(querry, conn);
                SqlDataReader reader = c.ExecuteReader();
                conn.Close();
            }
            catch (Exception e)
            {
                latestErrorMsg = e.Message;
            }
        }
    }
}