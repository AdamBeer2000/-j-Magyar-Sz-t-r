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
            foreach(KeyValuePair<String,EnglishWord>word in db.getAll())
            {
                string all = "";

                foreach (HungarianWord trans in word.Value.getTranslations())
                {
                    all += trans.getHunWord()+", "; 
                }
                all = all.Substring(0, all.Length-2);
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
    }
}