using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace StackDocsSharp.Services
{
    public class IHigher
    {
        CRUD readData = new CRUD();

        List<string> listTopics = new List<string>();
       
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