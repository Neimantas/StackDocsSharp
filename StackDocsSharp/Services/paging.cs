using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SQLite;
using StackDocsSharp.Models.Const;

namespace StackDocsSharp.Services
{
    public class Paging
    {
        public int lastRowID;

        CRUD readData = new CRUD();

        public DataTable GetNumOfRows(string table, string uIdCollumn, int pageSize, List<CrudArgs> args = null)
        {
            string rowlimit = "order by id Limit " + pageSize.ToString();
            var firstTen = readData.Read(table,args,rowlimit);
            int rowCount = firstTen.Rows.Count;
            lastRowID = Convert.ToInt32(firstTen.Rows[(rowCount-1)][firstTen.Columns.IndexOf(uIdCollumn)]);
            return firstTen;
        }

        public int GetTotalCount(string table,List<CrudArgs> args=null)
        {
            DataBase db = new DataBase();
            var conn = db.GetConnection();
            conn.Open();

            SQLiteCommand cmd = new SQLiteCommand(conn);
            cmd.CommandText = "SELECT COUNT(*) FROM " + table + WhereStringBuilder(args);
            SQLiteDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();

            dt.Load(reader);

            return Convert.ToInt32(dt.Rows[0][0].ToString());


        }

        private string WhereStringBuilder(List<CrudArgs> args)
        {
            string whereString = " Where 1=1";
            if (args.Count > 0 || args != null)
            {
                for (int i = 0; i < args.Count; i++)
                {
                    whereString += " AND " + args[i].column + " " + args[i].argument + " " + "'" + args[i].value + "'";
                }
            }

            return whereString;
        }


    }
}