using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StackDocsSharp.Models.BL
{
    public class SearchResult
    {
        string title, text;
        private string id;

        public SearchResult(string a, string b, string c)
        {
            id = a;
            title = b;
            text = c;
        }
    }
}