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
            doit();
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

        protected void doit()
        {
            string res = "";
            for (int i = 0; i < words.Count; i++)
            {
                res += words[i].toString();
            }
            
        }
    }
}