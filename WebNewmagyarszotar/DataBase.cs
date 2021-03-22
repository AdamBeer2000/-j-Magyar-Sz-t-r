using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.IO;

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
        public Dictionary<String, EnglishWord> getExploreWords()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "/Scripts/explorer_sql_a.sql";
            string querry = File.ReadAllText(path);
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
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public Dictionary<String, EnglishWord> getAll(string searchField,int page_num)
        {
            //todo egyszerre ne az egészet hanem csak párat töltsön le pl 50-et mert egy 1000 szavas cucra ez sok
            //searchField = "%" + searchField + "%";"
            string path = AppDomain.CurrentDomain.BaseDirectory+"/Scripts/listquerryB.sql";
            string querry = File.ReadAllText(path);

            querry=querry.Replace("PAR_1",Convert.ToString(20));
            querry=querry.Replace("PAR_2", Convert.ToString((page_num*20)));
            querry=querry.Replace("PAR_3", searchField);

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
                latestErrorMsg = querry+ " "+e.Message;
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