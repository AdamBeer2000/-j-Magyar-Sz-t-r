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
        protected void Page_Load(object sender, EventArgs e)
        {
            db= new DataBase();

            foreach (KeyValuePair<String, EnglishWord> word in db.getAll(searchBox.Text))
            {
                string all = "";

                foreach (HungarianWord trans in word.Value.getTranslations())
                {
                    all += trans.getHunWord() + ", ";
                }
                all = all.Substring(0, all.Length - 2);
                addOneRow(word.Key, all);
            }
            
        }
        
        private void addOneRow(string eng,string hun)
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

            row.ID = "rowStyle";

            SzotarTable.Rows.Add(row);
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
            cell3.InnerText ="angol";

            row.Cells.Add(cell1);
            row.Cells.Add(cell2);
            row.Cells.Add(cell3);

            row.ID = "rowStyle";

            SzotarTable.Rows.Add(row);

            foreach (KeyValuePair<String, EnglishWord> word in db.getAll(searchBox.Text))
            {
                string all = "";

                foreach (HungarianWord trans in word.Value.getTranslations())
                {
                    all += trans.getHunWord() + ", ";
                }
                all = all.Substring(0, all.Length - 2);
                addOneRow(word.Key, all);
            }
        }
    }
}