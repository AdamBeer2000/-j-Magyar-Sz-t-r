using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Threading;

namespace WebNewmagyarszotar
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        //public DataBase db = DataBase.Instance;
        //public DataBase db = new DataBase(true);
        public DataBase db = DataBase.Instance;

        //static public int pagenum = 0;
        static public List<String> showall = new List<string>();

        protected void update()
        {
            Dictionary<String, EnglishWord> words;
            int pagecount = 0;
            int pagenum;
            if (Request.Cookies["Thing"] == null)
            {
                pagenum = 0;
            }
            else
            {
                pagenum = Convert.ToInt32(Request.Cookies["Thing"]["Page"]);
            }

            int id = -1;
            if (Request.Cookies["User"] != null)
            {
                if (Request.Cookies["User"]["Logged"] != null)
                {
                    id = Convert.ToInt32(Request.Cookies["User"]["Logged"]);
                }
            }
            bool retry=true;
            
            words = db.getAll(searchBox.Text, pagenum, id);
            pagecount = db.rowCount(searchBox.Text, 20);
            retry = false;
            

            SzotarTable.Rows.Clear();
            addHeaderRow(SzotarTable);

            foreach (KeyValuePair<String, EnglishWord> word in words)
            {
                if (word.Value.getTranslations().Count > 1)
                {
                    addOneRowMoultipleTrans(word.Value, SzotarTable);
                }
                else
                {
                    addOneRow(word.Value, word.Value.getTranslations()[0], SzotarTable, false);
                }
            }
            //Label1.Text = Convert.ToString(pagenum) + " it: " + i;

            pagenums.Controls.Clear();

            for (int k = 0; k <= pagecount+1; k++)
            {
                LinkButton lb = new LinkButton();
                if (k == pagenum)
                {
                    lb.CssClass = "lapozofocus";
                }
                else
                {
                    lb.CssClass = "lapozo";
                }
                lb.ID = k + "_Page";
                lb.Text = "" + k;
                int tmp = k;
                lb.CommandArgument += tmp;
                lb.Command += new CommandEventHandler(skip_forwad_button_Click);
                pagenums.Controls.Add(lb);

                Label l = new Label();
                l.Text = " ";
                pagenums.Controls.Add(l);
            }
            
            if(!db.isReady())
            {
                Thread.Sleep(15000);
                update();
            }
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["Thing"]==null)
            {
                Response.Cookies.Add(new HttpCookie("Thing"));
                Response.Cookies["Thing"]["Page"] = "0";
                Response.Cookies["Thing"]["Ser"] = "";
                Response.Cookies["Thing"].Expires = DateTime.Now.AddHours(1);
            }
            update();
            //Label1.Text = db.getLatestErrorMsg();
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
            ImageButton dummy = new ImageButton();
            ImageButton like = new ImageButton();
            ImageButton dislike = new ImageButton();

            HtmlTableCell cell1 = new HtmlTableCell();
            HtmlTableCell cell2 = new HtmlTableCell();
            HtmlTableCell cell3 = new HtmlTableCell();
            HtmlTableCell cell4 = new HtmlTableCell();
            HtmlTableCell cell5 = new HtmlTableCell();

            ImageButton lenyit = new ImageButton();

            ImageButton addWord = new ImageButton();
            addWord.ImageUrl = "https://i.imgur.com/ceYONF2.png";
            addWord.Attributes.Add("class", "addbutton");
            addWord.Click += new ImageClickEventHandler(this.OpenWindow);
            addWord.ID = "add_" + eng.getEngID();
            addWord.Attributes.Add("title", "Hozzáadás");

            ImageButton reportWord = new ImageButton();
            reportWord.ImageUrl = "https://i.imgur.com/9Ml0E1o.png";
            reportWord.Attributes.Add("class", "reportbutton");
            reportWord.CommandArgument = "E," + eng.getEngID();
            reportWord.Command += new CommandEventHandler(this.OpenWindowReport);
            reportWord.ID = "rep_e_" + eng.getEngID();
            reportWord.Attributes.Add("title", "Jelentés");

            lenyit.ID = "Button_lenyit_" + eng.getWord();

            lenyit.Click += new ImageClickEventHandler(this.show_all);
            lenyit.Attributes.Add("runat", "server");

            if (showall.Contains(eng.getWord()))
                lenyit.ImageUrl = "https://i.imgur.com/4Qv1V8L.png";//lenéz
            else
                lenyit.ImageUrl = "https://i.imgur.com/kkF7JDM.png";//felnéz

            lenyit.Attributes.Add("class", "lenyitbutton");
            //cell1.InnerText = eng.getWord();
            //cell2.InnerText = eng.getTranslations()[0].getHunWord() + "\t";

            LinkButton engWorld = new LinkButton();
            engWorld.Text = eng.getWord();
            engWorld.ID = "eng_word_label_" + eng.getEngID();
            engWorld.CssClass = "textStyle";
            engWorld.Command += new CommandEventHandler(OpenWindowInfo);
            engWorld.CommandArgument = eng.getWord() + ";" + eng.getUser() + ";" + eng.getDesc();
            cell1.Controls.Add(engWorld);
            

            LinkButton hunWorld = new LinkButton();
            hunWorld.Text = eng.getTranslations()[0].getHunWord();
            hunWorld.ID="hun_word_label_" + eng.getTranslations()[0].getHunID();
            hunWorld.CssClass = "textStyle";
            hunWorld.Command += new CommandEventHandler(OpenWindowInfo);
            hunWorld.CommandArgument = eng.getTranslations()[0].getHunWord() + ";" + eng.getTranslations()[0].getUser() + ";";
            cell2.Controls.Add(hunWorld);

            ImageButton reportWordHun = new ImageButton();
            reportWordHun.ImageUrl = "https://i.imgur.com/9Ml0E1o.png";
            reportWordHun.Attributes.Add("class", "reportbutton");
            reportWordHun.CommandArgument = "H," + eng.getTranslations()[0].getHunID();
            reportWordHun.Command += new CommandEventHandler(this.OpenWindowReport);
            reportWordHun.ID = "rep_m_" + eng.getTranslations()[0].getHunID();
            reportWordHun.Attributes.Add("title", "Jelentés");

            cell2.Controls.Add(reportWordHun);
            cell2.Controls.Add(lenyit);

            row.Cells.Add(cell1);
            cell1.Controls.Add(addWord);
            cell1.Controls.Add(reportWord);

            row.Cells.Add(cell2);
            row.Cells.Add(cell4);

            row.Attributes.Add("class", "rowStyle");
            row.Attributes.Add("max-height", "30%");
            table.Rows.Add(row);

            /*
            dummy.ImageUrl = "https://i.imgur.com/Oc1Ynsm.png";
            dummy.Attributes.Add("class", "likebutton");
            dummy.ID = "dummy_h_" + eng.getEngID();
            cell4.Controls.Add(dummy);
            cell5.Controls.Add(dummy);

            row.Cells.Add(cell4);
            row.Cells.Add(cell5);
            */
            HungarianWord hun = eng.getTranslations()[0];

            like.ID = "Button_like_" + hun.getHunID();

            //like.Click += new ImageClickEventHandler(this.like_button_button_Click);
            like.CommandArgument += hun.getHunID();
            like.Command += new CommandEventHandler(this.like_button_button_Click);

            like.Attributes.Add("runat", "server");

            if(hun.loggedreact=="L")
            {
                like.ImageUrl = "https://i.imgur.com/zQYyaiB.png";
            }
            else
            {
                like.ImageUrl = "https://i.imgur.com/WXVaypj.png";
            }

            like.Attributes.Add("class", "likebutton");

            dislike.ID = "Button_dislike_" + hun.getHunID();

            dummy.ImageUrl = "https://i.imgur.com/Oc1Ynsm.png";
            //dummy.Attributes.Add("class", "likebutton");
            dummy.CssClass = "likebutton";

            //dislike.Click+=new ImageClickEventHandler(this.dislike_button_button_Click);
            dislike.CommandArgument += hun.getHunID();
            dislike.Command += new CommandEventHandler(this.dislike_button_button_Click);

            dislike.Attributes.Add("runat", "server");
            dislike.ImageUrl = "https://i.imgur.com/aXezCAu.png";
            if (hun.loggedreact == "D")
            {
                dislike.ImageUrl = "https://i.imgur.com/ypitBGN.png";
            }
            else
            {
                dislike.ImageUrl = "https://i.imgur.com/aXezCAu.png";
            }
            dislike.Attributes.Add("class", "likebutton");

            cell1.BgColor = "#101000";
            cell2.BgColor = "#101000";

            cell4.InnerText = "" + hun.getLike();
            cell4.Controls.Add(like);

            cell5.InnerText = "" + hun.getDislike();
            cell5.Controls.Add(dislike);

            row.Cells.Add(cell4);
            row.Cells.Add(cell5);


            if (showall.Contains(eng.getWord()))
            {
                //lenéz
                cell1.Attributes.Add("rowspan", Convert.ToString((eng.getTranslations().Count())));
                foreach (HungarianWord trans in eng.getTranslations())
                {
                    if(trans!=eng.getTranslations()[0])
                    addOneRow(eng, trans, table, true,true);
                }
            }
        }

        private void addOneRow(EnglishWord eng_world, HungarianWord hun, HtmlTable table, bool ismultiple,bool spawn=false)
        {
            string eng = eng_world.getWord();

            HtmlTableRow row = new HtmlTableRow();

            HtmlTableCell cell1 = new HtmlTableCell();
            HtmlTableCell cell3 = new HtmlTableCell();

            HtmlTableCell cell4 = new HtmlTableCell();

            ImageButton like = new ImageButton();
            ImageButton dislike = new ImageButton();

            ImageButton dummy = new ImageButton();

            HtmlTableCell cell5 = new HtmlTableCell();

            LinkButton engWorld = new LinkButton();

            if (!ismultiple)
            {
                engWorld.Text = eng;
                engWorld.CssClass = "textStyle";
                engWorld.ID = "eng_word_label_" + eng_world.getEngID();
                //cell1.InnerText = eng;
                cell1.Controls.Add(engWorld);
                

                ImageButton addWord = new ImageButton();
                addWord.ImageUrl = "https://i.imgur.com/ceYONF2.png";
                addWord.Attributes.Add("class", "addbutton");
                addWord.Click += new ImageClickEventHandler(this.OpenWindow);
                addWord.ID = "add_" + eng_world.getEngID();
                cell1.Controls.Add(addWord);
                addWord.Attributes.Add("title", "Hozzáadás");

                ImageButton reportWord = new ImageButton();
                reportWord.ImageUrl = "https://i.imgur.com/9Ml0E1o.png";
                reportWord.Attributes.Add("class", "reportbutton");
                reportWord.CommandArgument = "E," + eng_world.getEngID();
                reportWord.Command += new CommandEventHandler(this.OpenWindowReport);
                reportWord.ID = "rep_e_" + eng_world.getEngID();
                reportWord.Attributes.Add("title", "Jelentés");
                cell1.Controls.Add(reportWord);
                

                engWorld.Command += new CommandEventHandler(OpenWindowInfo);
                engWorld.CommandArgument = eng_world.getWord() + ";" + eng_world.getUser() + ";" + eng_world.getDesc();
            }


            //cell3.InnerText = hun.getHunWord();
            LinkButton hunWord = new LinkButton();
            
            hunWord.Text = hun.getHunWord();
            hunWord.CommandArgument = hun.getHunWord() + ";" + hun.getUser();
            hunWord.CssClass = "textStyle2";
            hunWord.Command += new CommandEventHandler(OpenWindowInfo);
            cell3.Controls.Add(hunWord);
            cell3.BorderColor = "#898E01";
            

            if (!spawn)
            {
                row.Cells.Add(cell1);
            }
            

            row.Cells.Add(cell3);

            if (hun.getHunID() != -1)//csak akkor -1 ha még nincs arra az angol szóra fordítás
            {
                if(ismultiple)
                {
                    hunWord.ID = "hun_word_label_m" + hun.getHunID();
                }
                else
                {
                    hunWord.ID = "hun_word_label" + hun.getHunID();
                }
                

                ImageButton reportWordHun = new ImageButton();
                reportWordHun.ImageUrl = "https://i.imgur.com/9Ml0E1o.png";
                reportWordHun.Attributes.Add("class", "reportbutton");
                reportWordHun.CommandArgument = "H," + hun.getHunID();
                reportWordHun.Command += new CommandEventHandler(this.OpenWindowReport);
                reportWordHun.ID = "rep_h_" + hun.getHunID();
                reportWordHun.Attributes.Add("title", "Jelentés");
                cell3.Controls.Add(reportWordHun);

                like.ID = "Button_like_" + hun.getHunID();

                //like.Click += new ImageClickEventHandler(this.like_button_button_Click);
                like.CommandArgument += hun.getHunID();
                like.Command += new CommandEventHandler(this.like_button_button_Click);

                like.Attributes.Add("runat", "server");
                if (hun.loggedreact == "L")
                {
                    like.ImageUrl = "https://i.imgur.com/zQYyaiB.png";
                }
                else
                {
                    like.ImageUrl = "https://i.imgur.com/WXVaypj.png";
                }
                like.Attributes.Add("class", "likebutton");

                dislike.ID = "Button_dislike_" + hun.getHunID();

                dummy.ImageUrl = "https://i.imgur.com/Oc1Ynsm.png";
                //dummy.Attributes.Add("class", "likebutton");
                dummy.CssClass = "likebutton";

                //dislike.Click+=new ImageClickEventHandler(this.dislike_button_button_Click);
                dislike.CommandArgument += hun.getHunID();
                dislike.Command += new CommandEventHandler(this.dislike_button_button_Click);

                dislike.Attributes.Add("runat", "server");
                if (hun.loggedreact == "D")
                {
                    dislike.ImageUrl = "https://i.imgur.com/ypitBGN.png";
                }
                else
                {
                    dislike.ImageUrl = "https://i.imgur.com/aXezCAu.png";
                }
                dislike.Attributes.Add("class", "likebutton");

                cell4.InnerText = "" + hun.getLike();
                cell4.Controls.Add(like);

                cell5.InnerText = "" + hun.getDislike();
                cell5.Controls.Add(dislike);

                row.Cells.Add(cell4);
                row.Cells.Add(cell5);
            }else
            {
                dummy.ImageUrl = "https://i.imgur.com/Oc1Ynsm.png";
                dummy.Attributes.Add("class", "likebutton");
                dummy.ID= "dummy_" + eng_world.getEngID();
                cell4.Controls.Add(dummy);
                cell5.Controls.Add(dummy);

                row.Cells.Add(cell4);
                row.Cells.Add(cell5);

                hunWord.ID = "hun_word_label_" + hun.getHunID()+"_"+ eng_world.getEngID();
            }

            row.Attributes.Add("class", "rowStyle");
            row.Attributes.Add("max-height", "30%");

            table.Rows.Add(row);
        }

        protected void OpenWindow(object sender, ImageClickEventArgs e)
        {
            AddWordResponseLable.Text = "";
            WordAddInputBox.Text = "";
            if (Request.Cookies["User"] != null)
            {
                if (Request.Cookies["User"]["Logged"] != null)
                {
                    string partid = ((ImageButton)sender).ID;
                    partid = partid.Split('_')[1];
                    int id = Convert.ToInt32(partid);
                    Response.Cookies["TMPEgy"]["AddId"] = ""+id;
                    mp1.Show();
                }
            }
        }
        protected void WordAddInputConfirm_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["User"] != null)
            {
                if (Request.Cookies["User"]["Logged"] != null)
                {
                    bool state = !db.addHunWord(WordAddInputBox.Text, Convert.ToInt32(Request.Cookies["User"]["Logged"]), Convert.ToInt32(Request.Cookies["TMPEgy"]["AddId"]));
                    if (state)
                    {
                        db.getLatestErrorMsg();
                        AddWordResponseLable.Text = "Vótmá";
                        AddWordResponseLable.CssClass = "LableBad";
                        //Response.Write("<script>alert('Vótmá')</script>");
                    }
                    else
                    {
                        AddWordResponseLable.Text = "Sikeresen hozzáadva";
                        AddWordResponseLable.CssClass = "LableGood";
                        //Response.Write("<script>alert('Sikeresen hozzáadva')</script>");
                    }
                }
            }
            mp1.Show();
        }
        protected void OpenWindowReport(object sender, CommandEventArgs e)
        {
            ReportWordResponseLable.Text = "";
            reportCommentInput.Text = "";
            Button3.Text = "Mégse";
            if (Request.Cookies["User"] != null)
            {
                if (Request.Cookies["User"]["Logged"] != null)
                {
                    e.ToString().Split();
                    int id = Convert.ToInt32(e.CommandArgument.ToString().Split(',')[1]);
                    char wordType = Convert.ToChar(e.CommandArgument.ToString().Split(',')[0][0]);
                    Response.Cookies["TMPKetto"]["RepId"] = "" + id;
                    mp2.Show();
                }
            }
        }
        protected void WordAddReportConfirm_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["User"] != null)
            {
                if (Request.Cookies["User"]["Logged"] != null)
                {
                    db.addReport(Convert.ToInt32(Request.Cookies["User"]["Logged"]), '?', Convert.ToInt32(Request.Cookies["TMPKetto"]["RepId"]), reportCommentInput.Text);
                    ReportWordResponseLable.Text = "A bejelentést megkaptuk.Köszönjük a viszajelzést!";
                    ReportWordResponseLable.CssClass = "LableGood";
                    Button3.Text = "Vissza";
                }
            }
            mp2.Show();
        }

        protected void OpenWindowInfo(object sender, CommandEventArgs e)
        {
            string[] split = e.CommandArgument.ToString().Split(';');
            World.Text = split[0];
            Creator.Text = "Beküldte: " + split[1];
            if (split.Length == 3)
                Definicon.Text = "Definició: " + split[2];
            WorldInfoExtender.Show();
        }

        protected void searchBox_TextChanged(object sender, EventArgs e)
        {
            Response.Cookies["Thing"]["Page"] = "0";
            Response.Cookies["Thing"].Expires = DateTime.Now.AddHours(1);
            //pagenum =0;
            Response.Redirect("Browse.aspx");
        }

        protected void forward_button_Click(object sender, ImageClickEventArgs e)
        {
            int pagenum = Convert.ToInt32(Request.Cookies["Thing"]["Page"]);
            if (db.rowCount(searchBox.Text, 20) >= pagenum)
            {
                Response.Cookies["Thing"]["Page"] =""+(pagenum+1);
                Response.Cookies["Thing"].Expires = DateTime.Now.AddHours(1);
            }
            Response.Redirect("Browse.aspx");
        }

        protected void back_button_Click(object sender, ImageClickEventArgs e)
        {
            int pagenum = Convert.ToInt32(Request.Cookies["Thing"]["Page"]);
            if (0< pagenum)
            {
                Response.Cookies["Thing"]["Page"] = "" + (pagenum-1);
                Response.Cookies["Thing"].Expires = DateTime.Now.AddHours(1);
            }
            Response.Redirect("Browse.aspx");
        }

        protected void skip_forwad_button_Click(object sender, CommandEventArgs e)
        {
            Response.Cookies["Thing"]["Page"] = ""+Convert.ToInt32(e.CommandArgument);
            Response.Cookies["Thing"].Expires = DateTime.Now.AddHours(1);
            Response.Redirect("Browse.aspx");
        }

        protected void like_button_button_Click(object sender, CommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();

            if (Request.Cookies["User"] != null)
                if (Request.Cookies["User"]["Logged"] != null)
                    db.addLike(Convert.ToInt32(id), Convert.ToInt32(Request.Cookies["User"]["Logged"]));

            update();

        }
        protected void dislike_button_button_Click(object sender, CommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();

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

        
        protected void WordAddCancle_Click(object sender, EventArgs e)
        {
            mp1.Hide();
        }

       
        protected void WordReportCancle_Click(object sender, EventArgs e)
        {
            mp2.Hide();
        }

        protected void searchBox_TextChanged1(object sender, EventArgs e)
        {

        }
    }
}