using System;
using System.Data.SQLite;
using System.Web.Services;

namespace StackDocsSharp.Services
{
    /// <summary>
    /// Summary description for IDataBase
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
    // [System.Web.Script.Services.ScriptService]
    public class IDataBase : System.Web.Services.WebService
    {
        private string _conUrl = "Data source = C:\\Users\\" + Environment.UserName + "\\Documents\\StackDocsSharp\\Database\\DB.db ; New=false; Foreign Keys = True;";

        [WebMethod]
        public SQLiteConnection GetConnection()
        {
            try
            {
                var cnn = new SQLiteConnection(_conUrl);
                return cnn;
            }
            catch (SQLiteException ex) {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }
    }
}