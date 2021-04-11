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
        static public DataBase db = new DataBase();
        static public int pagenum = 0;
        static public List<String> showall = new List<string>();
        static int addwordid;

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
                    addOneRow(word.Value,word.Value.getTranslations()[0], SzotarTable,false);
                }
                i++;
            }
            Label1.Text = Convert.ToString(pagenum) +" it: "+i;
            return true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            update();
            Label1.Text = db.getLatestErrorMsg();
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

            ImageButton lenyit = new ImageButton();

            Button addWord = new Button();
            addWord.Text = "+";
            addWord.Click += new EventHandler(this.OpenWindow);
            addWord.ID = "add_" + eng.getEngID();
            

            lenyit.ID = "Button_lenyit_" + eng.getWord();

            lenyit.Click += new ImageClickEventHandler(this.show_all);
            lenyit.Attributes.Add("runat", "server");

            if(showall.Contains(eng.getWord()))
                lenyit.ImageUrl = "https://i.imgur.com/kkF7JDM.png";//lenéz
            else
                lenyit.ImageUrl = "https://i.imgur.com/kkF7JDM.png";//felnéz

            lenyit.Attributes.Add("class", "lenyitbutton");
            cell1.InnerText = eng.getWord();
            cell2.InnerText = eng.getTranslations()[0].getHunWord()+"\t";
            cell2.Controls.Add(lenyit);

            row.Cells.Add(cell1);
            cell1.Controls.Add(addWord);

            row.Cells.Add(cell2);
            row.Cells.Add(cell4);

            row.Attributes.Add("class", "rowStyle");
            row.Attributes.Add("max-height", "30%");
            table.Rows.Add(row);

            if (showall.Contains(eng.getWord()))
            {
                //lenéz
                foreach (HungarianWord trans in eng.getTranslations())
                {
                    addOneRow(eng, trans, table,true);
                }
            }
        }

        private void addOneRow(EnglishWord eng_world, HungarianWord hun, HtmlTable table,bool ismultiple)
        {
            string eng = eng_world.getWord();

            HtmlTableRow row = new HtmlTableRow();

            HtmlTableCell cell1 = new HtmlTableCell();
            HtmlTableCell cell3 = new HtmlTableCell();

            HtmlTableCell cell4 = new HtmlTableCell();

            ImageButton like = new ImageButton();
            ImageButton dislike = new ImageButton();

            HtmlTableCell cell5 = new HtmlTableCell();
            cell1.InnerText = eng;

            cell1.InnerText = eng;
            if(!ismultiple)
            {
                Button addWord = new Button();
                addWord.Text = "+";
                addWord.Click += new EventHandler(this.OpenWindow);
                addWord.ID = "add_" + eng_world.getEngID();
                cell1.Controls.Add(addWord);
            }
            

            cell3.InnerText = hun.getHunWord();
            cell3.BorderColor = "#898E01";
            

            row.Cells.Add(cell1);
            row.Cells.Add(cell3);


            like.ID="Button_like_" + hun.getHunID();
            like.Click += new ImageClickEventHandler(this.like_button_button_Click);
            like.Attributes.Add("runat", "server");
            like.ImageUrl = "https://i.imgur.com/WXVaypj.png";
            like.Attributes.Add("class", "likebutton");

            dislike.ID = "Button_dislike_" + hun.getHunID();
            dislike.Click+=new ImageClickEventHandler(this.dislike_button_button_Click);
            dislike.Attributes.Add("runat", "server");
            dislike.ImageUrl = "https://i.imgur.com/aXezCAu.png";
            dislike.Attributes.Add("class", "likebutton");


            cell4.InnerText = "" + hun.getLike();
            cell4.Controls.Add(like);
            

            cell5.InnerText = "" + hun.getDislike();
            cell5.Controls.Add(dislike);
            

            row.Cells.Add(cell4);
            row.Cells.Add(cell5);

            row.Attributes.Add("class", "rowStyle");
            row.Attributes.Add("max-height", "30%");

            table.Rows.Add(row);
        }

        protected void OpenWindow(object sender, EventArgs e)
        {
            if (Request.Cookies["User"] != null)
            {
                if (Request.Cookies["User"]["Logged"] != null)
                {
                    string partid = ((Button)sender).ID;
                    partid = partid.Split('_')[1];
                    int id = Convert.ToInt32(partid);
                    addwordid = id;
                    mp1.Show();
                }
            }
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

        protected void like_button_button_Click(object sender, ImageClickEventArgs e)
        {
            Label1.Text = "Megnyomva :"+((ImageButton)sender).ID;
            string id = (((ImageButton)sender).ID);
            id = id.Replace("Button_like_", "");
            if (Request.Cookies["User"] != null)
                if (Request.Cookies["User"]["Logged"] != null)
                    db.addLike(Convert.ToInt32(id), Convert.ToInt32(Request.Cookies["User"]["Logged"]));

            update();

        }
        protected void dislike_button_button_Click(object sender, ImageClickEventArgs e)
        {
            Label1.Text = "Megnyomva :"+ ((ImageButton)sender).ID;
            string id = (((ImageButton)sender).ID);
            id = id.Replace("Button_dislike_", "");

            if (Request.Cookies["User"] != null)
                if (Request.Cookies["User"]["Logged"] != null)
                    db.addDislike(Convert.ToInt32(id), Convert.ToInt32(Request.Cookies["User"]["Logged"]));

            update();

        }
        protected void show_all(object sender, EventArgs e)
        {
            string id = (((ImageButton)sender).ID);
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

        protected void WordAddInputConfirm_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["User"] != null)
            {
                if (Request.Cookies["User"]["Logged"] != null)
                {
                    bool state=!db.addHunWord(WordAddInputBox.Text,Convert.ToInt32(Request.Cookies["User"]["Logged"]),addwordid);
                    update();
                    if(state)
                    {
                        db.getLatestErrorMsg();
                        Response.Write("<script>alert('Vótmá')</script>");
                    }
                    else
                    {
                        
                        Response.Write("<script>alert('Sikeresen hozzáadva')</script>");
                    }
                }
            }
            
        }
    }
}