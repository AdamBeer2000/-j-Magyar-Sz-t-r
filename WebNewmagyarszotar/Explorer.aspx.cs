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
        int session_id = 0;
        static Dictionary<int, DataBase> dbMap = new Dictionary<int, DataBase>();

        protected void Page_Load(object sender, EventArgs e)
        {
            session_id = 69420;

            if (Request.Cookies["User"] != null)
            {
                if (Request.Cookies["User"]["Logged"] != null)
                {
                    session_id = Convert.ToInt32(Request.Cookies["User"]["Logged"]);
                }
            }
            if (!dbMap.ContainsKey(session_id))
            {
                dbMap.Add(session_id, new DataBase(true));
            }
            if (Request.Cookies["User"] == null)
            {
                Response.Redirect("index.aspx");
            }

            int[] ids = { -1, -1 };
            if (!idspp.ContainsKey(session_id))
                idspp.Add(session_id, ids);
            
            getWords();
            vizualize();
        }

        //DataBase db = DataBase.Instance;
        
        List<EnglishWord> words = new List<EnglishWord>();
        static Dictionary<int, int[]> idspp = new Dictionary<int, int[]>();

        Random rand = new Random();
        static bool loaded=false;
       

        private int getRand() { return rand.Next(0, words.Count); }

        public EnglishWord exploreVisualization()
        {
            EnglishWord result = new EnglishWord();
            int random_id = this.getRand();
            random_id = this.getRand();//LEKEZELNI, HA A WORDS üres 
            result = this.words[random_id];
            return result;
        }

        public void getWords()
        {
            Dictionary<String, EnglishWord> temp = new Dictionary<string, EnglishWord>();
            temp = dbMap[session_id].getExploreWords(Convert.ToInt32(Request.Cookies["User"]["Logged"]));
            words = temp.Values.ToList<EnglishWord>();
        }

        public void vizualize()
        {
            if (words.Count > 0)
            {
                var ids = idspp[session_id];
                if (ids[0] == -1 && ids[1] == -1)
                {
                    EnglishWord env = this.exploreVisualization();
                    angol_szo_label.Text = env.getWord();

                    List<HungarianWord> hun_list = env.getHunList();
                    int f, s;
                    f = rand.Next(0, hun_list.Count);
                    do
                    {
                        s = rand.Next(0, hun_list.Count);
                    } while (s == f);

                    first_forditas.Text = hun_list[f].getHunWord();
                    second_forditas.Text = hun_list[s].getHunWord();
                    ids[0] = hun_list[f].getHunID();
                    ids[1] = hun_list[s].getHunID();
                    loaded = true;
                    idspp[session_id] = ids;
                }
            }
            else
            {
                angol_szo_label.Text = "Nincs több olyan szó, ami több fordítással rendelkezik, és még nem likeoltad";
                first_forditas.Text = "";
                second_forditas.Text = "";
            }
        }

        protected void upClick(object sender, ImageClickEventArgs e)
        {
            var ids = idspp[session_id];
            Console.WriteLine();
            if (words.Count > 0)
            {
                //update elso forditas like++
                if (Request.Cookies["User"]["Logged"] != null)
                {
                    dbMap[session_id].addLike(ids[0], Convert.ToInt32(Request.Cookies["User"]["Logged"]));
                    ids[0] = -1;
                    ids[1] = -1;
                    idspp[session_id] = ids;
                    getWords();
                }
                this.vizualize();
            }
        }

        protected void downClick(object sender, ImageClickEventArgs e)
        {
            var ids = idspp[session_id];
            if (words.Count > 0)
            {
                //update masodik forditas like++
                if (Request.Cookies["User"]["Logged"] != null)
                {
                    dbMap[session_id].addLike(ids[1], Convert.ToInt32(Request.Cookies["User"]["Logged"]));
                    ids[0] = -1;
                    ids[1] = -1;
                    idspp[session_id] = ids;
                    getWords();
                }
                this.vizualize();
            }
        }
    }
}