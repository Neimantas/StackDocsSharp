using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StackDocsSharp.Models.Const
{
    public class CrudArgs
    {
        public string column, argument, value;
        public CrudArgs(string a, string b, string c)
        {
            column = a;
            argument = b;
            value = c;
        }
    }
}