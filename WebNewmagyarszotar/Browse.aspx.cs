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
        DataBase db = new DataBase();
        static public int pagenum = 0;
        static public List<String> showall = new List<string>();

        protected bool update()
        {
            int i=0;
            if(searchBox==null)
            {
                return false;
            }

            Dictionary<String, EnglishWord> words = db.getAll(searchBox.Text, pagenum);

            if (words.Count == 0)
            {
                return false;
            }

            SzotarTable.Rows.Clear();
            addHeaderRow(SzotarTable);

            foreach (KeyValuePair<String, EnglishWord> word in words)
            {
                if(word.Value.getTranslations().Count>1)
                {
                    addOneRowMoultipleTrans(word.Value,SzotarTable);
                }
                else
                {
                    addOneRow(word.Key,word.Value.getTranslations()[0], SzotarTable);
                }
                i++;
            }
            Label1.Text = Convert.ToString(pagenum) +" it: "+i;
            return true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            update();
        }
        private void addHeaderRow(HtmlTable table)
        {
            HtmlTableRow row = new HtmlTableRow();
            HtmlTableCell cell1 = new HtmlTableCell();
            HtmlTableCell cell3 = new HtmlTableCell();

            cell1.InnerText = "Angol";
            cell3.InnerText = "Magyar";

            row.Cells.Add(cell1);
            row.Cells.Add(cell3);

            row.Attributes.Add("class", "cimsor");

            table.Rows.Add(row);
        }
        private void addOneRowMoultipleTrans(EnglishWord eng, HtmlTable table)
        {
            //addOneRow(eng.getWord(),"-----------", table);
            HtmlTableRow row = new HtmlTableRow();
       
            HtmlTableCell cell1 = new HtmlTableCell();
            HtmlTableCell cell2 = new HtmlTableCell();
            HtmlTableCell cell3 = new HtmlTableCell();
            HtmlTableCell cell4 = new HtmlTableCell();

            HtmlButton lenyit = new HtmlButton();

            lenyit.ID = "Button_lenyit_" + eng.getWord();

            lenyit.ServerClick += new System.EventHandler(this.show_all);
            lenyit.Attributes.Add("runat", "server");
            lenyit.InnerText = "etc....";

            cell1.InnerText = eng.getWord();
            cell2.InnerText = eng.getTranslations()[0].getHunWord()+"\t";
            cell2.Controls.Add(lenyit);

            row.Cells.Add(cell1);
            row.Cells.Add(cell2);
            row.Cells.Add(cell4);

            row.Attributes.Add("class", "rowStyle");
            table.Rows.Add(row);

            if (showall.Contains(eng.getWord()))
                foreach (HungarianWord trans in eng.getTranslations())
                {
                    addOneRow("|", trans, table);
                }
        }

        private void addOneRow(string eng, HungarianWord hun, HtmlTable table)
        {
            HtmlTableRow row = new HtmlTableRow();

            HtmlTableCell cell1 = new HtmlTableCell();
            HtmlTableCell cell3 = new HtmlTableCell();

            HtmlTableCell cell4 = new HtmlTableCell();
            HtmlButton like = new HtmlButton();

            HtmlTableCell cell5 = new HtmlTableCell();

            HtmlButton dislike = new HtmlButton();

            cell1.InnerText = eng;
            cell3.InnerText = hun.getHunWord();

            row.Cells.Add(cell1);
            row.Cells.Add(cell3);


            like.ID="Button_like_" + hun.getHunID();
            like.ServerClick += new System.EventHandler(this.like_button_button_Click);
            like.Attributes.Add("runat", "server");
            like.InnerText = "Testszik";

            dislike.ID = "Button_dislike_" + hun.getHunID();
            dislike.ServerClick += new System.EventHandler(this.dislike_button_button_Click);
            dislike.Attributes.Add("runat", "server");
            dislike.InnerText = "Nem tetszik";

            cell4.InnerText = "" + hun.getLike();
            cell4.Controls.Add(like);
            

            cell5.InnerText = "" + hun.getDislike();
            cell5.Controls.Add(dislike);
            

            row.Cells.Add(cell4);
            row.Cells.Add(cell5);

            row.Attributes.Add("class", "rowStyle");

            table.Rows.Add(row);
        }

        protected void searchBox_TextChanged(object sender, EventArgs e)
        {
            update();
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

        protected void like_button_button_Click(object sender, EventArgs e)
        {
            Label1.Text = "Megnyomva :"+((HtmlButton)sender).ID;
            string id = (((HtmlButton)sender).ID);
            id = id.Replace("Button_like_", "");

            db.addLike(Convert.ToInt32(id));

            update();

        }
        protected void dislike_button_button_Click(object sender, EventArgs e)
        {
            Label1.Text = "Megnyomva :"+ ((HtmlButton)sender).ID;
            string id = (((HtmlButton)sender).ID);
            id = id.Replace("Button_dislike_", "");

            db.addDislike(Convert.ToInt32(id));

            update();

        }
        protected void show_all(object sender, EventArgs e)
        {
            string id = (((HtmlButton)sender).ID);
            id = id.Replace("Button_lenyit_", "");

            if (!showall.Contains(id))
            {
                showall.Add(id);
            }
            else
            {
                showall.Remove(id);
            }

            update();
        }
    }
}