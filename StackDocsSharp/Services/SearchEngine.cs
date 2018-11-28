using StackDocsSharp.Models.BL;
using StackDocsSharp.Models.Const;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StackDocsSharp.Services
{
    public class SearchEngine
    {
        public List<SearchResult> Search(string args)
        {
            Higher _higher = new Higher();
            List<SearchResult> results = new List<SearchResult>();
            List<BLTopics> topicsList = _higher.GetTopics(ParseSearchQuery(args));
            foreach(BLTopics topic in topicsList)//search each topic and get the string with the text, title and id
            {
                string description = GetDescription(topic.introductionPlain);
                SearchResult obj = new SearchResult(topic.id, topic.title, description);
                results.Add(obj);
            }
            return results;
        }

        private List<CrudArgs> ParseSearchQuery(string text)
        {
            string[] arr = text.Split(' ');
            List<CrudArgs> result = new List<CrudArgs>();
            foreach (string word in arr)
            {
                if (word == " " || word == "") continue;
                CrudArgs arg = new CrudArgs("*", "LIKE", "'%" + word + "%'");
                result.Add(arg);
            }
            return result;
        }

        private string GetDescription(string introduction)
        {
            if (introduction != null || introduction != "")
            {
                int endOfSentence = introduction.IndexOf(".");
                return introduction.Substring(0, endOfSentence);
            }
            return null;
        }
    }
}