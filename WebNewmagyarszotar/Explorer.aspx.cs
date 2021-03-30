using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebNewmagyarszotar
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            getWords();
            vizualize();
        }

        DataBase db = new DataBase();
        List<EnglishWord> words = new List<EnglishWord>();
        Random rand = new Random();

        private int getRand() { return rand.Next(0, words.Count); }

        public bool moreThanTwo(int _id)
        {
            if (words[_id].getHunList().Count > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        

        public EnglishWord exploreVisualization()
        {
            EnglishWord result = new EnglishWord();
            int random_id = this.getRand();

            do
            {
                random_id = this.getRand();
            } while (!moreThanTwo(random_id));

            result = this.words[random_id];
            return result;
        }

        public void getWords()
        {
            Dictionary<String, EnglishWord> temp = new Dictionary<string, EnglishWord>();
            temp = db.getExploreWords();
            words = temp.Values.ToList<EnglishWord>();
        }

        public void vizualize()
        {
            EnglishWord env = this.exploreVisualization();
            angol_szo_label.Text = env.getWord();

            List<HungarianWord> hun_list = new List<HungarianWord>();
            hun_list = env.getHunList();
            int f, s;
            f = rand.Next(0, hun_list.Count);
            do
            {
                s = rand.Next(0, hun_list.Count);
            } while (s == f);

            first_forditas.Text = hun_list[f].getHunWord();
            second_forditas.Text = hun_list[s].getHunWord();
        }
    }
}