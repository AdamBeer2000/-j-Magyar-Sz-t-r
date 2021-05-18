using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebNewmagyarszotar
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        private int top_likes_on_word = 0;
        private int user_id = -1;
        private string none_rank = "NONE";
        private List<string> ranks = new List<string>();
        private Dictionary<string, int> all_ranks = new Dictionary<string, int>();

        private DataBase db = DataBase.Instance;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.loadRanks();
            if (Request.Cookies["User"] != null)
            {
                if (Request.Cookies["User"]["Logged"] != null)
                {
                    this.user_id = Convert.ToInt32(Request.Cookies["User"]["Logged"]);
                    this.top_likes_on_word = db.getMostLiked(user_id);
                }
            }
            if (Request.Cookies["User"] == null)
            {
                //Response.Redirect("index.aspx");
            }
            this.setRank();
        }

        private void setRank()
        {
            rank_table.Rows.Clear();

            if (user_id != -1)
            {
                this.rankSelector(top_likes_on_word, true);
            }
            else
            {
                rank_label.Text = none_rank;
                need_to_next_rank_label.Text = "-";
            }

            all_ranks = db.getAllMostLiked();
            this.tableMaker(rank_table);

            for (int k = ranks.Count()-1; k >=0 ; k--)
            foreach (KeyValuePair<String, int> one_rank in all_ranks)
            {
                if(rankId(one_rank.Value, false)==k)
                addOneRow(one_rank.Key, rankSelector(one_rank.Value, false));
            }

        }

        private string rankSelector(int top, bool highlighted)
        {
            string tmp_rank = "";
            int tmp_num = 0;
            if (top == 0)
            {
                tmp_rank = ranks[0];
                if (highlighted) tmp_num = 0;
            }
            else if (top < 10)
            {
                tmp_rank = ranks[1];
                if (highlighted) tmp_num = (10 - top);
            }
            else if (top < 20)
            {
                tmp_rank = ranks[2];
                if (highlighted) tmp_num = (20 - top);
            }
            else if (top < 50)
            {
                tmp_rank = ranks[3];
                if (highlighted) tmp_num = (50 - top);
            }
            else if (top < 75)
            {
                tmp_rank = ranks[4];
                if (highlighted) tmp_num = (75 - top);
            }
            else if (top < 100)
            {
                tmp_rank = ranks[5];
                if (highlighted) tmp_num = (100 - top);
            }
            else if (top < 125)
            {
                tmp_rank = ranks[6];
                if (highlighted) tmp_num = (125 - top);
            }
            else if (top < 150)
            {
                tmp_rank = ranks[7];
                if (highlighted) tmp_num = (150 - top);
            }
            else if (top < 200)
            {
                tmp_rank = ranks[8];
                if (highlighted) tmp_num = (200 - top);
            }
            else if (top < 250)
            {
                tmp_rank = ranks[9];
                if (highlighted) tmp_num = (250 - top);
            }
            else if (top < 300)
            {
                tmp_rank = ranks[10];
                if (highlighted) tmp_num = (300 - top);
            }
            else if (top < 350)
            {
                tmp_rank = ranks[11];
                if (highlighted) tmp_num = (350 - top);
            }
            else if (top < 400)
            {
                tmp_rank = ranks[12];
                if (highlighted) tmp_num = (400 - top);
            }
            else if (top >= 400)
            {
                tmp_rank = ranks[13];
                if (highlighted) need_to_next_rank_label.Text = "Its Over Obi-Wan, you have the high ground!";
            }

            if (highlighted) rank_label.Text = tmp_rank;

            if (top < 400 && highlighted)
            {
                need_to_next_rank_label.Text = Convert.ToString(tmp_num);
            }

            return tmp_rank;
        }

        private int rankId(int top, bool highlighted)
        {
            if (top == 0)
            {
                return 0;
            }
            else if (top < 10)
            {
                return 1;
            }
            else if (top < 20)
            {
                return 2;
            }
            else if (top < 50)
            {
                return 3;
            }
            else if (top < 75)
            {
                return 4;
            }
            else if (top < 100)
            {
                return 5;
            }
            else if (top < 125)
            {
                return 6;
            }
            else if (top < 150)
            {
                return 7;
            }
            else if (top < 200)
            {
                return 8;
            }
            else if (top < 250)
            {
                return 9;
            }
            else if (top < 300)
            {
                return 10;
            }
            else if (top < 350)
            {
                return 11;
            }
            else if (top < 400)
            {
                return 12;
            }
            else if (top >= 400)
            {
                return 13;
            }
            return 13;
        }
        private void loadRanks()
        {
            ranks.Add("Thats not good enough");
            ranks.Add("Kezdő");
            ranks.Add("Középhaladó");
            ranks.Add("Haladó");
            ranks.Add("Lifeless");
            ranks.Add("ÉnÉn Master");
            ranks.Add("ÉnÉn Master++");
            ranks.Add("JoJo");
            ranks.Add("MUDAMUDAMUDA");
            ranks.Add("ÉnÉn God");
            ranks.Add("Unbreakable");
            ranks.Add("ÉnÉn Lord");
            ranks.Add("Hivatalos \"Hello There\" tulajdonos");
            ranks.Add("UnLiMiTeD HiGh GroUNd");
        }

        private void tableMaker(HtmlTable table)
        {
            HtmlTableRow row = new HtmlTableRow();
            HtmlTableCell cell1 = new HtmlTableCell();
            HtmlTableCell cell2 = new HtmlTableCell();

            table.Attributes.Add("class", "rangtabla");

            cell1.Attributes.Add("class", "cimsor");
            cell2.Attributes.Add("class", "cimsor");

            cell1.InnerText = "Felhasználó";
            cell2.InnerText = "Rang";

            row.Cells.Add(cell1);
            row.Cells.Add(cell2);

            row.Attributes.Add("class", "cimsor");

            table.Rows.Add(row);
        }

        private void addOneRow(string _name, string _rank)
        {
            HtmlTableRow row = new HtmlTableRow();

            HtmlTableCell cell1 = new HtmlTableCell();
            HtmlTableCell cell2 = new HtmlTableCell();

            cell1.Attributes.Add("class", "simasor");
            cell2.Attributes.Add("class", "simasor");

            cell1.InnerText = _name;
            cell2.InnerText = _rank;

            row.Controls.Add(cell1);
            row.Controls.Add(cell2);

            rank_table.Rows.Add(row);
        }
    }
}