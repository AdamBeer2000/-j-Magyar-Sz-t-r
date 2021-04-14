using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace tanitas3
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        static string theam;
        static List<TableRow> TableRows;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["User"] != null)
            {
                theam = Request.Cookies["User"]["Theam"].ToString();
            }

            if (TableRows is null)
            {
                TableRows = new List<TableRow>();
                generateRowHead();
            }

            update();
        }

        void update()
        {
            mainPage.Attributes.Add("class", theam);
            foreach (TableRow row in TableRows)
            {
                Tablazat1.Rows.Add(row);
            }
        }

        protected void Hozzaad2(object sender, EventArgs e)
        {
            generateRow();
            update();
        }

        void generateRow()
        {
            TableRow row = new TableRow();
            /*
            row.Attributes.Add("runat", "server");
            for (int i = 0; i < 5; i++)
            {
                TableCell temp = new TableCell();
                //temp.Text = (i + 1) + ".Oszlop " + (TableRows.Count) + ".Sor";
                if(i==4)
                {
                    Button b = new Button();
                    b.ID = (i + 1) + ":" + (TableRows.Count - 1);
                    //b.Text = (TableRows.Count) + ".gomb";
                    b.Click += new EventHandler(this.Hozzaad2);

                    //b.Attributes.Add("AutoPostBack ", "true");

                    b.Attributes.Add("runat", "server");
                    temp.Controls.Add(b);
                }
                row.Cells.Add(temp);
            }
            */
            for (int i = 0; i < 5; i++)
            {
                TableCell temp = new TableCell();
                Button b = new Button();
                //HtmlButton b = new HtmlButton();

                b.ID = "gomb_"+(i + 1) + ":" + (TableRows.Count - 1);

                b.OnClientClick += new EventHandler(gombnyomva);

                b.Attributes.Add("runat", "server");
                b.Attributes.Add("AutoPostBack", "True");
                
                temp.Controls.Add(b);
                row.Cells.Add(temp);
            }

            TableRows.Add(row);
        }

        void gombnyomva(object sender, EventArgs e)
        {
            List<TableRow> TBW = new List<TableRow>(TableRows);

            foreach (TableRow row in TBW)
            {
                TableCell temp = new TableCell();
                temp.Text = (row.Cells.Count+1) + ".Oszlop ";
                row.Cells.Add(temp);
            }
            TableRows = TBW;
        }

        void generateRowHead()
        {
            TableRow row = new TableRow();
            TableRows.Add(row);

            for (int i = 0; i < 5; i++)
            {
                TableCell temp = new TableCell();
                temp.Text = (i + 1) + ".Oszlop";
                row.Cells.Add(temp);
            }
        }

        protected void elvesz(object sender, EventArgs e)
        {
            if (TableRows.Count > 1)
                TableRows.RemoveAt(TableRows.Count-1);
            update();
        }
    }
}