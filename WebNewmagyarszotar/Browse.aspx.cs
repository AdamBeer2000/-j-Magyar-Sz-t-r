using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace WebNewmagyarszotar
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        DataBase db;
        static public int pagenum = 0;
        static public Dictionary<String, EnglishWord> words;

        protected bool update()
        {
            int i=0;
            
            words = db.getAll(searchBox.Text, pagenum);
            if (words.Count == 0)
            {
                return false;
            }

            SzotarTable.Rows.Clear();
            addHeaderRow(SzotarTable);

            foreach (KeyValuePair<String, EnglishWord> word in words)
            {
                string all = "";
                foreach (HungarianWord trans in word.Value.getTranslations())
                {
                    all += trans.getHunWord() + ", ";
                }
                all = all.Substring(0, all.Length - 2);
                addOneRow(word.Key, all, SzotarTable);
                i++;
            }
            Label1.Text = Convert.ToString(pagenum) +" it: "+i;
            return true;
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            db = new DataBase();
            update();
        }
        private void addHeaderRow(HtmlTable table)
        {
            HtmlTableRow row = new HtmlTableRow();
            HtmlTableCell cell1 = new HtmlTableCell();
            HtmlTableCell cell2 = new HtmlTableCell();
            HtmlTableCell cell3 = new HtmlTableCell();

            cell1.InnerText = "Angol";
            cell2.InnerText = "placeholder test";
            cell3.InnerText = "Magyar";

            row.Cells.Add(cell1);
            row.Cells.Add(cell2);
            row.Cells.Add(cell3);

            row.Attributes.Add("class", "rowStyle");

            table.Rows.Add(row);
        }
        private void addOneRow(string eng, string hun, HtmlTable table)
        {
            HtmlTableRow row = new HtmlTableRow();
            HtmlTableCell cell1 = new HtmlTableCell();
            HtmlTableCell cell2 = new HtmlTableCell();
            HtmlTableCell cell3 = new HtmlTableCell();

            cell1.InnerText = eng;
            cell2.InnerText = "placeholder test";
            cell3.InnerText = hun;

            row.Cells.Add(cell1);
            row.Cells.Add(cell2);
            row.Cells.Add(cell3);

            row.Attributes.Add("class", "rowStyle");

            table.Rows.Add(row);
        }

        protected void searchBox_TextChanged(object sender, EventArgs e)
        {
            //SzotarTable.InnerHtml = "<table id='SzotarTable' runat='server'>< tr >< td >< h1 style = 'color:#898E01;font-family: Calibri;' >angol szó</ h1 ></ td >< td >< h1  style = 'color:#898E01;font-family: Calibri;' >eredeti magyar jelentése</ h1 ></ td >< td >< h1  style = 'color:#898E01;font-family: Calibri;' >vicces magyar jelentése</ h1 ></ td ></ tr ></ table >";
            SzotarTable = new HtmlTable();
            HtmlTableRow row = new HtmlTableRow();

            HtmlTableCell cell1 = new HtmlTableCell();
            HtmlTableCell cell2 = new HtmlTableCell();
            HtmlTableCell cell3 = new HtmlTableCell();

            cell1.InnerText = "Magyar";
            cell2.InnerText = "ez nem lesz itt";
            cell3.InnerText = "angol";

            row.Cells.Add(cell1);
            row.Cells.Add(cell2);
            row.Cells.Add(cell3);

            row.Attributes.Add("class", "rowStyle");

            SzotarTable.Rows.Add(row);
        }

        protected void forward_button_Click(object sender, ImageClickEventArgs e)
        {
            pagenum++;
            if(!update())
            {
                pagenum--;
            }
        }

        protected void back_button_Click(object sender, ImageClickEventArgs e)
        {
            if(pagenum>0)
            pagenum--;
            update();
        }
    }
}