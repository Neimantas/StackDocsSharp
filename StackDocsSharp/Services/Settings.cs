using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StackDocsSharp.Services
{
    public class Settings
    {
        public static int DefaultSelectCount;
        public static readonly string DefaultConnectionString = "Data source = C:\\Users\\" + Environment.UserName + "\\Documents\\StackDocsSharp\\Database\\DB.db ; New=false; Foreign Keys = True;";
    }
}