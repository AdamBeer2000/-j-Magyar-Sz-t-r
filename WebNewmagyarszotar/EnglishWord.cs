using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebNewmagyarszotar
{
    public class EnglishWord
    {
        int eng_ID,userId;
        string eng_word, eng_desc, user;
        List<HungarianWord> hun = new List<HungarianWord>();

        public EnglishWord() { }
        public EnglishWord(int _ID, string _word, string _desc, int _userId)
        {
            this.eng_ID = _ID;
            this.eng_desc = _desc;
            this.eng_word = _word;
            this.userId = _userId;
        }
        public EnglishWord(int _ID, string _word, string _desc,string _user)
        {
            this.eng_ID = _ID;
            this.eng_desc = _desc;
            this.eng_word = _word;
            this.user = _user;
        }
        public EnglishWord(int _ID, string _word, string _desc, string _user,int _userId)
        {
            this.eng_ID = _ID;
            this.eng_desc = _desc;
            this.eng_word = _word;
            this.user = _user;
            this.userId = _userId;
        }

        //-------------------------------------------------------------|
        //--------------------[SETTERS / GETTERS]----------------------|
        //-------------------------------------------------------------|
        public void setID(int param){ this.eng_ID = param; }
        public void setEngWord(string param){ this.eng_word = param; }
        public void setDesc(string param){ this.eng_desc = param; }
        public void setUser(string param){ this.user = param; }

        public int getEngID(){ return this.eng_ID; }
        public string getDesc(){ return this.eng_desc; }
        public string getUser(){ return this.user; }
        public string getWord() { return this.eng_word; }
        public List<HungarianWord> getHunList() { return this.hun; }
        //-------------------------------------------------------------|

        public void addTranslation(HungarianWord word) { hun.Add(word); }
        public List<HungarianWord> getTranslations() { return hun; }

        public override string ToString()
        {
            string str="" + this.eng_ID.ToString() + "_" + this.eng_word + "_" + this.eng_desc + "_" + this.user+" : ";
            foreach(HungarianWord word in hun)
            {
                str += word.ToString();
            }
            return str;
        }
    }

}