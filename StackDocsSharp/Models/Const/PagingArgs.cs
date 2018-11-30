using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StackDocsSharp.Models.Const
{
    public class PagingArgs
    {
        private string _tableName;
        private int _takeRows;
        private int _skipRows;

           
        public string TableName { get; set; }
        public int TakeRows { get; set; }
        public int SkipRows { get; set; }
    }
}
        
        
    

