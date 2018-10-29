using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace StackDocsSharp.Services
{
    public class IDataBase
    {

        private string _conUrl = "Data source = C:\\Users\\" + Environment.UserName + "\\Documents\\StackDocsSharp\\Database\\DB.db ; New=false; Foreign Keys = True;";

        public IDataBase()
        {
        }

        public SQLiteConnection GetConnection()
        {
            try
            {
                var cnn = new SQLiteConnection(_conUrl);
                return cnn;
                //cnn.Open();
            }
            catch (SQLiteException ex) { Console.WriteLine(ex.ToString()); }

            return null;

        }
    }
}



