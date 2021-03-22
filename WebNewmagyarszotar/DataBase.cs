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
        public Dictionary<String, EnglishWord> getExploreWords()
        {   
            string querry = "SELECT eng.ID, eng.szo, hun.ID, hun.szo, hun.tetszes, hun.nemtetszes, hun.bekuldo, eng.definicio, eng.bekuldo FROM szotar AS sz INNER JOIN magyarszo AS hun ON sz.magyarszo_id = hun.ID INNER JOIN angolszo AS eng ON eng.ID = sz.angolszo_id ORDER BY eng.szo";
            SqlCommand command = new SqlCommand(querry, conn);
            Dictionary<String, EnglishWord> result = new Dictionary<String, EnglishWord>();

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (!result.ContainsKey(reader.GetString(1)))
                    {
                        result.Add(reader.GetString(1), new EnglishWord(reader.GetInt32(0), reader.GetString(1), reader.GetString(7), reader.GetString(8)));
                        result[reader.GetString(1)].addTranslation(new HungarianWord(reader.GetInt32(4), reader.GetString(5), reader.GetString(6), reader.GetInt32(7), reader.GetInt32(8)));
                    }
                    else
                    {
                        result[reader.GetString(1)].addTranslation(new HungarianWord(reader.GetInt32(2), reader.GetString(3), reader.GetString(6), reader.GetInt32(4), reader.GetInt32(5)));
                    }

                }

                conn.Close();
            }
            catch
            {

            }

            return result;
        }

        public Dictionary<String, EnglishWord> getAll ()
        {
            //todo egyszerre ne az egészet hanem csak párat töltsön le pl 50-et mert egy 1000 szavas cucra ez sok
            string querry = "SELECT * FROM szotar JOIN angolszo on angolszo_id = angolszo.ID JOIN magyarszo on magyarszo_id = magyarszo.ID";
            SqlCommand c = new SqlCommand(querry, conn);

            Dictionary<String,EnglishWord> words = new Dictionary<String,EnglishWord>();

            try
            {
                conn.Open();
                SqlDataReader reader = c.ExecuteReader();

                while (reader.Read())
                {
                    if(!words.ContainsKey(reader.GetString(1)))
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
            catch
            {

            }

            return words;
        }

    }
}