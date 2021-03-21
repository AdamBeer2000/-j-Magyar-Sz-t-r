using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebNewmagyarszotar
{
    public class HungarianWord
    {
        private int hun_ID, like, dislike, report_count;
        private string hun_word, user;
        
        public HungarianWord() { }
        
        public HungarianWord(int _ID, string _word, string _user, int _like = 0, int _dislike = 0)
        {
            this.hun_ID = _ID;
            this.like = _like;
            this.dislike = _dislike;
            this.hun_word = _word;
            this.user = _user;
            //this.report_count = _report;
        }

        //-------------------------------------------------------------|
        //--------------------[SETTERS / GETTERS]----------------------|
        //-------------------------------------------------------------|
        public void setLike(int param) { this.like = param; }
        public void setDislike(int param) { this.dislike = param; }
        public void setReport(int param) { this.report_count = param; }
        public void setID(int param) { this.hun_ID = param; }
        public void setHunWord(string param) { this.hun_word = param; }
        public void setUser(string param) { this.user = param; }

        public int getHunID() { return this.hun_ID; }
        public int getLike() { return this.like; }
        public int getDislike() { return this.dislike; }
        public int getReportCount() { return this.report_count; }
        public string getHunWord() { return this.hun_word; }
        public string getUser() { return this.user; }
        //-------------------------------------------------------------|

        public string toString()
        {
            return "" + this.hun_ID.ToString() + "_" + this.hun_word + "_" + this.user + "_" + this.like.ToString() + "_" + this.dislike.ToString() + "_" + this.report_count.ToString();
        }
    }
}