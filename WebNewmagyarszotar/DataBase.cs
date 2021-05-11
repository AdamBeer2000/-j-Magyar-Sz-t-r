using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using System.Security.Cryptography;

namespace WebNewmagyarszotar
{
    public sealed class PasswordHash
    {
        public string encrpyt(string passw)
        {
            string hash;
            using (SHA512 shaM = new SHA512Managed())
            {
                byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(passw);
                var thing=shaM.ComputeHash(byteArray);
                hash = System.Text.Encoding.Default.GetString(thing);
            }
            return hash;
        }
    }

    public class DataBase
    {
        private static string conn_string = buildDefConnString();

        private static SqlConnection conn = new SqlConnection(conn_string);

        private static string buildDefConnString()
        {
            SqlConnectionStringBuilder defconn = new SqlConnectionStringBuilder("Server=tcp:the-first-git-emire.database.windows.net,1433");
            defconn.InitialCatalog = "NewMagyarSzotar";
            defconn.PersistSecurityInfo = false;
            defconn.UserID = "pistabacsi";
            defconn.Password = "Nemezajelszo1";
            defconn.MultipleActiveResultSets = false;
            defconn.Encrypt = true;
            defconn.TrustServerCertificate = false;
            defconn.ConnectTimeout = 30;
            return defconn.ConnectionString;
        }


        public DataBase()
        {

        }

        private string latestErrorMsg;

        public string getLatestErrorMsg()
        {
            string ret = latestErrorMsg;
            latestErrorMsg = "";
            return ret;
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

        public List<string> getAllEnglishWord()
        {
            List<string> send_this = new List<string>();
            string query = "SELECT szo FROM angolszo";
            SqlCommand command = new SqlCommand(query, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (!send_this.Contains(reader.GetString(0)))
                    {
                        send_this.Add(reader.GetString(0));
                    }
                }

                conn.Close();
            }
            catch (SqlException ex)
            {
                latestErrorMsg = ex.Message;
            }

            return send_this;
        }

        public void addEndlishWord(string word, string description, string username)
        {
            string insert = "INSERT INTO angolszo (szo, bekuldo, definicio) VALUES(\'" + word + "\', \'" + username + "\', \'" + description + "\')";
            //string tryfirst = "INSERT INTO angolszo (szo, bekuldo, definicio) VALUES(\'" + username +"\', \'" + username +"\', \'" + description +"\')";
            
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(insert, conn);
                SqlDataReader reader = command.ExecuteReader();
                conn.Close();
            }
            catch (Exception e)
            {
                latestErrorMsg = e.Message;
            }

        }

        public Dictionary<String, EnglishWord> getExploreWords()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "/Scripts/explorer_sql_a.sql";
            string query = File.ReadAllText(path);
            SqlCommand command = new SqlCommand(query, conn);
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
                        result[reader.GetString(1)].addTranslation(new HungarianWord(reader.GetInt32(2), reader.GetString(3), reader.GetInt32(6), reader.GetInt32(4), reader.GetInt32(5)));
                    }
                    else
                    {
                        result[reader.GetString(1)].addTranslation(new HungarianWord(reader.GetInt32(2), reader.GetString(3),reader.GetInt32(6), reader.GetInt32(4), reader.GetInt32(5)));
                    }

                }

                conn.Close();
            }
            catch (SqlException ex)
            {
                latestErrorMsg = ex.Message;
            }

            return result;
        }

        public Dictionary<String, EnglishWord> getAll(string searchField, int page_num)
        {
            //todo egyszerre ne az egészet hanem csak párat töltsön le pl 50-et mert egy 1000 szavas cucra ez sok
            //searchField = "%" + searchField + "%";"
            string path = AppDomain.CurrentDomain.BaseDirectory + "/Scripts/listquerryE.sql";
            string querry = File.ReadAllText(path);

            Dictionary<String, EnglishWord> words = new Dictionary<String, EnglishWord>();

            SqlCommand sqlCmd = new SqlCommand(querry, conn);

            SqlParameter p1 = new SqlParameter(@"@scale", 20);
            p1.SqlDbType = SqlDbType.Int;
            p1.Direction = ParameterDirection.Input;

            SqlParameter p2 = new SqlParameter(@"@pagenum", page_num);
            p2.SqlDbType = SqlDbType.Int;
            p2.Direction = ParameterDirection.Input;

            SqlParameter p3 = new SqlParameter(@"@search", searchField);
            p3.SqlDbType = SqlDbType.NVarChar;
            p3.Direction = ParameterDirection.Input;
           
            sqlCmd.Parameters.Add(p1);
            sqlCmd.Parameters.Add(p2);
            sqlCmd.Parameters.Add(p3);

            try
            {
                conn.Open();
                SqlDataReader reader = sqlCmd.ExecuteReader();
                while (reader.Read())
                {
                    if (!words.ContainsKey(reader.GetString(1)))
                    {
                        words.Add(reader.GetString(1), new EnglishWord(reader.GetInt32(0), reader.GetString(1), reader.GetString(2),reader.GetString(10), reader.GetInt32(3)));
                        words[reader.GetString(1)].addTranslation(new HungarianWord(reader.GetInt32(4), reader.GetString(5), reader.GetString(9), reader.GetInt32(6), reader.GetInt32(7), reader.GetInt32(8)));
                    }
                    else
                    {
                        words[reader.GetString(1)].addTranslation(new HungarianWord(reader.GetInt32(4), reader.GetString(5), reader.GetString(9), reader.GetInt32(6), reader.GetInt32(7), reader.GetInt32(8)));
                    }

                }
                conn.Close();
            }
            catch (Exception e)
            {
                latestErrorMsg = querry + " " + e.Message;
            }

            return words;
        }

        public void addReport(int userId,char wordType,int wordId,string comment)
        {
            string querry = "INSERT into reports values(@userId, @wordType, @wordId, @comment)";
            try
            {
                SqlCommand sqlCmd = new SqlCommand(querry, conn);

                SqlParameter p1 = new SqlParameter(@"@userId", userId);
                SqlParameter p2 = new SqlParameter(@"@wordType", wordType);
                SqlParameter p3 = new SqlParameter(@"@wordId", wordId);
                SqlParameter p4 = new SqlParameter(@"@comment", comment);

                sqlCmd.Parameters.Add(p1);
                sqlCmd.Parameters.Add(p2);
                sqlCmd.Parameters.Add(p3);
                sqlCmd.Parameters.Add(p4);

                sqlCmd.Connection.Open();
                sqlCmd.ExecuteNonQuery();
                sqlCmd.Connection.Close();
            }
            catch (Exception e)
            {
                latestErrorMsg = e.Message;
            }
        }

        public void addLike(int magyarszo_id,int felhasz_id)
        {
            //todo a felhasználó által likeolt szavak listájához adni
            //ha egyszer rákatint akkor like olja, ha mégegyszer akkor meg viszavonja

            string path = AppDomain.CurrentDomain.BaseDirectory + "/Scripts/addreaction.sql";
            string querry = File.ReadAllText(path);
            try
            {
                SqlCommand sqlCmd = new SqlCommand(querry, conn);

                SqlParameter p1 = new SqlParameter(@"@magyarszo_id", magyarszo_id);
                p1.SqlDbType = SqlDbType.VarChar;
                p1.Direction = ParameterDirection.Input;

                SqlParameter p2 = new SqlParameter(@"@felhasz_id", felhasz_id);
                p2.SqlDbType = SqlDbType.VarChar;
                p2.Direction = ParameterDirection.Input;

                SqlParameter p3 = new SqlParameter(@"@reaction", "L");
                p3.SqlDbType = SqlDbType.Char;
                p3.Direction = ParameterDirection.Input;

                sqlCmd.Parameters.Add(p1);
                sqlCmd.Parameters.Add(p2);
                sqlCmd.Parameters.Add(p3);

                sqlCmd.Connection.Open();
                sqlCmd.ExecuteNonQuery();
                sqlCmd.Connection.Close();
            }
            catch (Exception e)
            {
                latestErrorMsg = e.Message;
            }
        }
        public void addDislike(int magyarszo_id, int felhasz_id)
        {
            //todo a felhasználó által dislikeolt szavak listájához adni
            //ha egyszer rákatint akkor dislike olja, ha mégegyszer akkor meg viszavonja
            string path = AppDomain.CurrentDomain.BaseDirectory + "/Scripts/addreaction.sql";
            string querry = File.ReadAllText(path);

            try
            {
                SqlCommand sqlCmd = new SqlCommand(querry, conn);

                SqlParameter p1 = new SqlParameter(@"@magyarszo_id", magyarszo_id);
                p1.SqlDbType = SqlDbType.VarChar;
                p1.Direction = ParameterDirection.Input;

                SqlParameter p2 = new SqlParameter(@"@felhasz_id", felhasz_id);
                p2.SqlDbType = SqlDbType.VarChar;
                p2.Direction = ParameterDirection.Input;

                SqlParameter p3 = new SqlParameter(@"@reaction", "D");
                p3.SqlDbType = SqlDbType.Char;
                p3.Direction = ParameterDirection.Input;

                sqlCmd.Parameters.Add(p1);
                sqlCmd.Parameters.Add(p2);
                sqlCmd.Parameters.Add(p3);

                sqlCmd.Connection.Open();
                sqlCmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                latestErrorMsg = e.Message;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

        }
        public bool addHunWord(string magyarszo,int bekuldo_id, int angolszo_id)
        {
            //todo a felhasználó által dislikeolt szavak listájához adni
            //ha egyszer rákatint akkor dislike olja, ha mégegyszer akkor meg viszavonja
            string path = AppDomain.CurrentDomain.BaseDirectory + "/Scripts/addHunWord.sql";
            string querry = File.ReadAllText(path);

            try
            {
                SqlCommand sqlCmd = new SqlCommand(querry, conn);

                SqlParameter p1 = new SqlParameter(@"@magyarszo", magyarszo);
                p1.SqlDbType = SqlDbType.VarChar;
                p1.Direction = ParameterDirection.Input;

                SqlParameter p2 = new SqlParameter(@"@bekuldo_id", bekuldo_id);
                p2.SqlDbType = SqlDbType.Int;
                p2.Direction = ParameterDirection.Input;

                SqlParameter p3 = new SqlParameter(@"@angolszo_id", angolszo_id);
                p3.SqlDbType = SqlDbType.Int;
                p3.Direction = ParameterDirection.Input;

                sqlCmd.Parameters.Add(p1);
                sqlCmd.Parameters.Add(p2);
                sqlCmd.Parameters.Add(p3);

                sqlCmd.Connection.Open();
                sqlCmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception e)
            {
                latestErrorMsg = e.Message +""+querry+"\n"+magyarszo+","+ bekuldo_id+","+angolszo_id;
                return false;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
        private SqlConnection getSecureConn()
        {
            //return new SqlConnection("Data Source=tcp:the-first-git-emire.database.windows.net,1433;USER ID=pistabacsi;password=Nemezajelszo1;Initial Catalog=NewMagyarSzotar;Integrated Security=true;Column Encryption Setting=enabled;Trusted_Connection=False;Encrypt=True;TrustServerCertificate=True;");
            
            SqlConnectionStringBuilder tmp = new SqlConnectionStringBuilder("Data Source=tcp:the-first-git-emire.database.windows.net,1433");
            tmp.UserID = "pistabacsi";
            tmp.Password = "Nemezajelszo1";
            tmp.InitialCatalog = "NewMagyarSzotar";
            tmp.IntegratedSecurity = true;
            tmp.ColumnEncryptionSetting = SqlConnectionColumnEncryptionSetting.Enabled;
            tmp.Encrypt = true;
            tmp.Add("Trusted_Connection", false);
            tmp.TrustServerCertificate = true;

            return new SqlConnection(tmp.ConnectionString);
        }
        //https://docs.microsoft.com/hu-hu/azure/azure-sql/database/always-encrypted-certificate-store-configure

        public User verifyUser(string username, string jelszo)//ha létezik és sikeres a bejelentkezés felhaszidvel tér vissza egyébként -1
        {
            string querry = "";
            byte[] jelszo_hash;
            int id = -1;
            string jog="";

            try
            {
                querry = "SELECT id,felhasznalonev,jelszo,jogosultasag FROM felhasznalok WHERE felhasznalonev='" + username + "'";
                SqlCommand sqlCmd = new SqlCommand(querry, getSecureConn());

                /*
                SqlParameter passw = new SqlParameter(@"@passw", jelszo);
                passw.DbType = DbType.AnsiStringFixedLength;
                passw.Direction = ParameterDirection.Input;
                passw.Size = 32;
                */

                using (SHA512 shaM = new SHA512Managed())
                {
                    byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(jelszo);
                    jelszo_hash = shaM.ComputeHash(byteArray);
                }

                sqlCmd.Connection.Open();

                SqlDataReader reader = sqlCmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    if (reader.GetSqlBinary(2)!= jelszo_hash)
                    {
                        latestErrorMsg = "Rossz jelszó";
                    }
                    else
                    {
                        id = reader.GetInt32(0);
                        jog = reader.GetString(3);
                    }
                }
                else
                {
                    latestErrorMsg = "Nincs ilyen embör";
                }

                sqlCmd.Connection.Close();
                if(id!=-1)
                {
                    PERMISSION p=PERMISSION.GUEST;
                    if(jog=="+")
                    {
                        p = PERMISSION.LOGGED;
                    }
                    if (jog == "++")
                    {
                        p = PERMISSION.ADMIN;
                    }
                    if (jog == "-")
                    {
                        //tudo csökentett hozzáférés
                    }
                    return new User(username, id, PERMISSION.LOGGED);
                }
                else
                {
                    return null;
                }
                
            }
            catch (Exception e)
            {
                latestErrorMsg = e.Message;
                return null;
            }

        }

        public bool checkhUsername(string username)//igaz ha létezik
        {
            string querry;
            querry = "SELECT COUNT(*) FROM felhasznalok WHERE felhasznalonev='" + username + "'"+ "GROUP BY felhasznalonev";
            try
            {
                SqlCommand sqlCmd = new SqlCommand(querry, getSecureConn());

                SqlDataReader reader = sqlCmd.ExecuteReader();
                bool ret;

                sqlCmd.Connection.Open();

                reader.Read();

                ret = reader.GetInt32(0) > 0;

                sqlCmd.Connection.Close();

                return ret;
            }
            catch(Exception e)
            {
                latestErrorMsg = e.Message;
                return false;
            }
        }

        public bool regUser(string username,string email,string jelszo)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "/Scripts/registration.sql";
            string querry = File.ReadAllText(path);
            byte[] jelszo_hash;

            using (SHA512 shaM = new SHA512Managed())
            {
                byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(jelszo);
                jelszo_hash = shaM.ComputeHash(byteArray);
            }

            if (checkhUsername(username))
            {
                latestErrorMsg = "Van már ilyen felhsználónév";
                return false;
            }

            SqlCommand sqlCmd = new SqlCommand(querry);

            SqlParameter p1 = new SqlParameter(@"@p1", username);
            p1.SqlDbType = SqlDbType.VarChar;
            p1.Direction = ParameterDirection.Input;
            p1.Size = 32;

            SqlParameter p2 = new SqlParameter(@"@p2", email);
            p2.SqlDbType = SqlDbType.VarChar;
            p2.Direction = ParameterDirection.Input;
            p1.Size = 50;

            SqlParameter p3 = new SqlParameter(@"@p3", "+");
            p3.SqlDbType = SqlDbType.VarChar;
            p3.Direction = ParameterDirection.Input;
            p1.Size = 10;

            SqlParameter p4 = new SqlParameter(@"@p4", jelszo_hash);
            p4.SqlDbType = SqlDbType.Binary;
            p4.Direction = ParameterDirection.Input;

            sqlCmd.Parameters.Add(p1);
            sqlCmd.Parameters.Add(p2);
            sqlCmd.Parameters.Add(p3);
            sqlCmd.Parameters.Add(p4);

            using (sqlCmd.Connection= getSecureConn())
            {
                try
                {
                    sqlCmd.Connection.Open();

                    sqlCmd.ExecuteNonQuery();

                    sqlCmd.Connection.Close();
                }
                catch (Exception e)
                {
                    latestErrorMsg = e.Message;
                    return false;
                }
            }
            return true;
        }
        public User getUserById(int id)
        {
            string querry = "";
            string username="";
            string jog = "";

            try
            {
                querry = "SELECT id,felhasznalonev,jelszo,jogosultasag FROM felhasznalok WHERE id=" + id;
                SqlCommand sqlCmd = new SqlCommand(querry, getSecureConn());

                /*
                SqlParameter passw = new SqlParameter(@"@passw", jelszo);
                passw.DbType = DbType.AnsiStringFixedLength;
                passw.Direction = ParameterDirection.Input;
                passw.Size = 32;
                */
                sqlCmd.Connection.Open();

                SqlDataReader reader = sqlCmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    username = reader.GetString(1);
                    jog = reader.GetString(3);
                }
                else
                {
                    latestErrorMsg = "Nincs ilyen embör";
                }

                sqlCmd.Connection.Close();
                if (id != -1)
                {
                    PERMISSION p = PERMISSION.GUEST;
                    if (jog == "+")
                    {
                        p = PERMISSION.LOGGED;
                    }
                    if (jog == "++")
                    {
                        p = PERMISSION.ADMIN;
                    }
                    if (jog == "-")
                    {
                        //tudo csökentett hozzáférés
                    }
                    return new User(username, id, PERMISSION.LOGGED);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                latestErrorMsg = e.Message;
                return null;
            }
        }

        public EnglishWord getEnglishWord(string w)
        {
            string query = "SELECT * FROM angolszo WHERE szo = \'" + w + "\'";
            SqlCommand command = new SqlCommand(query, conn);
            EnglishWord result = new EnglishWord();

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result = new EnglishWord(reader.GetInt32(0), reader.GetString(1), reader.GetString(3), reader.GetString(2));
                }

                conn.Close();
            }
            catch (SqlException ex)
            {
                latestErrorMsg = ex.Message;
            }

            return result;
        }

        public int getMostLiked(int user_id)
        {
            //string query = "SELECT TOP(1) tetszes FROM magyarszo WHERE bekuldo = " + user_id + " ORDER BY tetszes DESC";
            string path = AppDomain.CurrentDomain.BaseDirectory + "/Scripts/getMostLiked.sql";
            string querry = File.ReadAllText(path);

            SqlCommand command = new SqlCommand(querry, conn);
            SqlParameter p = new SqlParameter(@"@user_id", user_id);
            command.Parameters.Add(p);
            int result = 0;

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result = reader.GetInt32(0);
                }

                conn.Close();
            }
            catch (SqlException ex)
            {
                latestErrorMsg = ex.Message;
            }

            return result;
        }

        public Dictionary<string, int> getAllMostLiked()
        {
            //string query = "SELECT TOP(1) tetszes FROM magyarszo WHERE bekuldo = " + user_id + " ORDER BY tetszes DESC";
            string path = AppDomain.CurrentDomain.BaseDirectory + "/Scripts/getAllMostLiked.sql";
            string querry = File.ReadAllText(path);

            SqlCommand command = new SqlCommand(querry, conn);
            //SqlParameter p = new SqlParameter(@"@user_id", user_id);
            //command.Parameters.Add(p);
            Dictionary<string, int> result = new Dictionary<string, int>();

            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(reader.GetString(0), reader.GetInt32(1));
                }

                conn.Close();
            }
            catch (SqlException ex)
            {
                latestErrorMsg = ex.Message;
            }

            return result;
        }
    }
}