using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace StackDocsSharp.Services
{
    /// <summary>
    /// Summary description for IHigher1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class IHigher : System.Web.Services.WebService
    {
        CRUD readData = new CRUD();

        List<string> listTopics = new List<string>();

        [WebMethod]
        public List<string> GetTopicsList()
        {
            DataTable dt = new DataTable();
            dt = readData.Read("Doctags");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listTopics.Add(dt.Rows[i]["Title"].ToString());

            }

            return listTopics;
        }
    }
}
