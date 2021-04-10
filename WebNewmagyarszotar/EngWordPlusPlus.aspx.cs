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
        private List<string> english_words = new List<string>();
        private string word = "", description = "No data", username = "Martin"; // IDEIGLENES DEBUG USERNAME
        private bool valid = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            english_words = db.getAllEnglishWord();
        }

        private void debug1()
        {
            string str = "";
            foreach (var element in english_words)
            {
                str += element + "   ";
            }
            debugl.Text = str;
        }

        private void debug2()
        {
            debugl.Text = eng_word_textbox.Text;
        }

        private void debug3()
        {
            debugl.Text = valid.ToString();
        }
        private void validate(string str)
        {
            if(!english_words.Contains(str))
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
            this.validate(eng_word_textbox.Text);
            if (word != "" && valid)
            {
                string new_word = this.word;
                string new_desc = this.description;
                db.addEndlishWord(new_word, new_desc, this.username);
                debugl.Text = db.getLatestErrorMsg();
            }
            else if(!valid)
            {
                error_label.Text = "Ez a szó már létezik a szótárban!";
            }
            else
            {
                error_label.Text = "Nem megfelelő szó!";
            }
        }

        protected void add_eng_button_Click(object sender, ImageClickEventArgs e)
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
            this.word = eng_word_textbox.Text;
        }
    }
}