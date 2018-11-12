using System.Data;
using System.Web.Services;
using System.Data.SQLite;

namespace StackDocsSharp.Services
{
    /// <summary>
    /// Summary description for CRUD
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
    // [System.Web.Script.Services.ScriptService]
    public class CRUD : System.Web.Services.WebService
    {
        [WebMethod]
        public void Create() { }

        public DataTable Read(string table)
        {
            IDataBase db = new IDataBase();
            var conn = db.GetConnection();
            conn.Open();

            DataTable dt = new DataTable();

            SQLiteCommand cmd = new SQLiteCommand(conn);
            cmd.CommandText = "SELECT * FROM " + table;
            SQLiteDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            reader.Close();
            conn.Close();

            return dt;
        }

        public void Update()
        {
        }

        public void Delete()
        {
        }
    }
}