using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StackDocsSharp.Models.Const
{
    public class PagingArgs
    {
        public string TableName { get; set; }
        public int TakeRows { get; set; }
        public int SkipRows { get; set; }
    }
}




