using System.Collections.Generic;
using System.Data;

namespace StackDocsSharp.Services
{
    public class IHigher
    {
        public string readData()
        {
            CRUD readData = new CRUD();

            //    List<string> listTopics = new List<string>();

            DataTable dt = readData.Read("Topics");

            string val = "";

            if (dt.Rows.Count > 0)
            {
                val = dt.Rows[1]["Title"].ToString();
            }

            return val;
        }
    }
}