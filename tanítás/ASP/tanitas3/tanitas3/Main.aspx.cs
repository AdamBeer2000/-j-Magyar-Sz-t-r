using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace tanitas3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        static int gomblenyom = 0;
        //1.a Sql connection basic
        //{
        //SqlConnection test = new SqlConnection(@"Server=localhost\MSSQLSERVER02;Database=master;Trusted_Connection=True;");
        //}

        //1.b Sql connection builder
        //{
        
        SqlConnection test2 = new SqlConnection(buildCon());

        static public string buildCon()
        {
            SqlConnectionStringBuilder b = new SqlConnectionStringBuilder(@"Server=localhost\MSSQLSERVER02");
            b.Add("Trusted_Connection", true);
            b.Add("Database","tanitas");
            return b.ConnectionString;
        }

        //}

        //2.a Sql basic lekérdezés
        //{

        //lekérdezi hogy az szgk táblában  melyik márkából hány darab van
        void feladat1a()
        {
            string querry = "select gyarto,COUNT(*) from szgk GROUP BY gyarto";
            SqlCommand c = new SqlCommand(querry, test2);
            try
            {
                c.Connection.Open();

                SqlDataReader reader = c.ExecuteReader();

                while (reader.Read())
                {
                    Label1.Text += reader.GetString(0) + " " + reader.GetInt32(1)+"<BR>";
                }

                c.Connection.Close();
            }
            catch(Exception e)
            {
                Response.Write("<script>alert('Hiba:"+ e.Message + "')</script>");
            }
        }

        //lekérdezi hogy az szgk táblában  melyik márkából hány darab van és egy pie charton megjeleníti
        void feladat1b()
        {
            string querry = "select gyarto,COUNT(*) from szgk GROUP BY gyarto";
            SqlCommand c = new SqlCommand(querry, test2);
            try
            {
                c.Connection.Open();

                SqlDataReader reader = c.ExecuteReader();

                Chart1.Series.Add("s1");
                Chart1.Series["s1"].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Pie;

                while (reader.Read())
                {
                    Chart1.Series["s1"].Points.AddXY(reader.GetString(0), reader.GetInt32(1));
                }

                c.Connection.Close();
            }
            catch(Exception e)
            {
                Response.Write("<script>alert('Hiba:"+ e.Message + "')</script>");
            }
            
        }
        //}

        //2.a Sql basic adatbeszúrás
        //{
        protected void feladat2a(object sender, EventArgs e)
        {
            //INSERT INTO orszag VALUES('CHI', 'China')
            string querry = "INSERT INTO orszag VALUES('"+inputmezo.Text+ "','" + inputmezo2.Text + "')";
            SqlCommand c = new SqlCommand(querry, test2);
            
            try
            {
                c.Connection.Open();
                c.ExecuteNonQuery();
                c.Connection.Close();
            }
            catch (Exception exc)
            {
                Response.Write("<script>alert('Hiba:" + exc.Message + "')</script>");
            }
        }

        protected void feladat2b(object sender, EventArgs e)
        {
            //INSERT INTO orszag VALUES('CHI', 'China')
            string querry = "INSERT INTO orszag VALUES(@orszag_id,@orszag_nev)";
            SqlCommand c = new SqlCommand(querry, test2);

            c.Parameters.Add(new SqlParameter(@"@orszag_id",inputmezo.Text));
            c.Parameters.Add(new SqlParameter(@"@orszag_nev", inputmezo2.Text));

            try
            {
                c.Connection.Open();
                c.ExecuteNonQuery();
                c.Connection.Close();
            }
            catch (Exception exc)
            {
                Response.Write("<script>alert('Hiba:" + exc.Message + "')</script>");
            }
            finally
            {
                Response.Write("<script>alert('Done')</script>");
            }
        }
        //}

        //3.b Sql tsql script
        //{

        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            test2.Open();
            if (test2.State == ConnectionState.Open)
                harmadik.InnerHtml = "open";
            else
                harmadik.InnerHtml = "close";
            test2.Close();
        }

        protected void doit(object sender, EventArgs e)
        {
            /*
            String input = inputmezo.Text;
            harmadik.InnerHtml = input;
            */
            if(gomblenyom < 1)
            {
                feladat1a();
            }
            
            if(gomblenyom>=1)
            {
                feladat1b();
            }
            gomblenyom++;
        }
    }
}