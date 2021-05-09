using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebNewmagyarszotar
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        private int top_likes_on_word = 0;
        private int user_id = -1;
        private string none_rank = "NONE";
        private List<string> ranks = new List<string>();

        private DataBase db = new DataBase();

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
            if(Request.Cookies["User"] == null)
            {
                Response.Redirect("index.aspx");
            }
            this.setRank();
        }

        private void setRank()
        {
            if(user_id != -1)
            {
                this.rankSelector();
            }
            else
            {
                rank_label.Text = none_rank;
                need_to_next_rank_label.Text = "-";
            }
        }

        private void rankSelector()
        {
            string tmp_rank = "";
            int tmp_num = 0;
            if(top_likes_on_word == 0)
            {
                tmp_rank = ranks[0];
                tmp_num = 0;
            }
            else if(top_likes_on_word < 10)
            {
                tmp_rank = ranks[1];
                tmp_num = (10 - top_likes_on_word);
            }
            else if (top_likes_on_word < 20)
            {
                tmp_rank = ranks[2];
                tmp_num = (20 - top_likes_on_word);
            }
            else if (top_likes_on_word < 30)
            {
                tmp_rank = ranks[3];
                tmp_num = (30 - top_likes_on_word);
            }
            else if (top_likes_on_word < 40)
            {
                tmp_rank = ranks[4];
                tmp_num = (40 - top_likes_on_word);
            }
            else if (top_likes_on_word < 50)
            {
                tmp_rank = ranks[5];
                tmp_num = (50 - top_likes_on_word);
            }
            else if (top_likes_on_word < 60)
            {
                tmp_rank = ranks[6];
                tmp_num = (60 - top_likes_on_word);
            }
            else if (top_likes_on_word < 70)
            {
                tmp_rank = ranks[7];
                tmp_num = (70 - top_likes_on_word);
            }
            else if (top_likes_on_word < 80)
            {
                tmp_rank = ranks[8];
                tmp_num = (80 - top_likes_on_word);
            }
            else if (top_likes_on_word < 90)
            {
                tmp_rank = ranks[9];
                tmp_num = (90 - top_likes_on_word);
            }
            else if (top_likes_on_word < 100)
            {
                tmp_rank = ranks[10];
                tmp_num = (100 - top_likes_on_word);
            }
            else if (top_likes_on_word < 150)
            {
                tmp_rank = ranks[11];
                tmp_num = (150 - top_likes_on_word);
            }
            else if (top_likes_on_word < 200)
            {
                tmp_rank = ranks[12];
                tmp_num = (200 - top_likes_on_word);
            }
            else if (top_likes_on_word >= 200)
            {
                tmp_rank = ranks[13];
                need_to_next_rank_label.Text = "Its Over Obi-Wan, you have the high ground!";
            }

            rank_label.Text = tmp_rank;
            if (top_likes_on_word < 200)
            {
                need_to_next_rank_label.Text = Convert.ToString(tmp_num);
            }
        }

        private void loadRanks()
        {
            ranks.Add("Előbb likeolják a szavadat Bástya");
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
    }
}