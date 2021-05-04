using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebNewmagyarszotar
{
    public partial class EngWordPlusPlus : System.Web.UI.Page
    {
        private DataBase db = new DataBase();
        private User logged = new User();
        private List<string> english_words = new List<string>();
        private string word = "", description = "No data", hunword = "", username = "GUEST";
        private bool valid = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            List<string> temporary = new List<string>();
            temporary = db.getAllEnglishWord();

            for (int i = 0; i < temporary.Count; i++)
            {
                english_words.Add(temporary[i].ToUpper());
            }

            if (Request.Cookies["User"] != null)
            {
                if (Request.Cookies["User"]["Logged"] != null)
                {
                    logged = db.getUserById(Convert.ToInt32(Request.Cookies["User"]["Logged"]));
                    if (logged != null)
                        username = logged.Username;
                }
            }
        }

        private void validate(string str)
        {
            if(!english_words.Contains(str.ToUpper()))
            {
                valid = true;
            }
            else
            {
                valid = false;
            }
        }

        private void addNewWord()
        {
            if (Request.Cookies["User"] != null)
            {
                if (Request.Cookies["User"]["Logged"] != null)
                {
                    this.validate(eng_word_textbox.Text);
                    if (word != "" && valid)
                    {
                        string new_word = this.word;
                        string new_desc = this.description;
                        db.addEndlishWord(new_word, new_desc, this.username);
                        debugl.Text = db.getLatestErrorMsg();

                        EnglishWord e = db.getEnglishWord(word);
                        int engid = e.getEngID();

                        if (ht.Text != "")
                        {
                            hunword = ht.Text;
                            db.addHunWord(hunword, Convert.ToInt32(Request.Cookies["User"]["Logged"]), engid);
                            debugl.Text = db.getLatestErrorMsg();
                        }
                    }
                    else if (!valid)
                    {
                        error_label.Text = "Ez a szó már létezik a szótárban!";
                    }
                    else
                    {
                        error_label.Text = "Nem megfelelő szó!";
                    }
                }
            }
        }

        protected void add_eng_button_Click(object sender, EventArgs e)
        {
            this.addNewWord();
        }

        protected void eng_description_textbox_TextChanged(object sender, EventArgs e)
        {
            if (eng_description_textbox.Text != "")
            {
                this.description = eng_description_textbox.Text;
            }
        }

        protected void eng_word_textbox_TextChanged(object sender, EventArgs e)
        {
            error_label.Text = "";
            this.word = eng_word_textbox.Text;
        }
    }
}