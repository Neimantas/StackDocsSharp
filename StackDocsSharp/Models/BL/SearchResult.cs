using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StackDocsSharp.Models.BL
{
    public class SearchResult
    {
        public string id, title, text;

        public SearchResult(string a, string b, string c)
        {
            id = a;
            title = b;
            text = c;
        }
    }
}