using StackDocsSharp.Models.BL;
using StackDocsSharp.Models.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StackDocsSharp.Services
{
    public class SearchEngine
    {
        public List<SearchResult> Search(string args)
        {
            Higher _higher = new Higher();
            List<SearchResult> results = new List<SearchResult>();
            List<CrudArgs> argsC = null;
            foreach(string search in ParseSearchQuery(args))
            {
                CrudArgs arg = new CrudArgs("Contains(*, '"+search+"')", "", "");
                argsC.Add(arg);
            }
            List<BLTopics> topicsList = _higher.GetTopics(argsC);
            foreach(BLTopics topic in topicsList)//search each topic and get the string with the text, title and id
            {
                string description = GetDescription(topic.introductionPlain);
                SearchResult obj = new SearchResult(topic.id, topic.title, description);
                results.Add(obj);
            }
            return results;
        }

        public List<string> ParseSearchQuery(string text)
        {
            var punctuation = text.Where(Char.IsPunctuation).Distinct().ToArray();
            List<string> list = (List<string>) text.Split().Select(x => x.Trim(punctuation));
            return list;
        }

        public string GetDescription(string introduction)
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