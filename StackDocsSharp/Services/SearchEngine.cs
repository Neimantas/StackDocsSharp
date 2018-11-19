using StackDocsSharp.Models.BL;
using StackDocsSharp.Models.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StackDocsSharp.Services
{
    public class SearchEngine//TODO
    {
        private Higher _higher;
        public List<SearchResult> Search(List<string> args)
        {
            List<SearchResult> list = new List<SearchResult>();
            List<CrudArgs> argsC = null;
            foreach(string search in args)
            {
                CrudArgs arg = new CrudArgs("Contains(*, '"+search+"')", "", "");
                argsC.Add(arg);
            }
            List<BLTopics> topicsList = _higher.GetTopics(argsC);

            return list;
        }
    }
}