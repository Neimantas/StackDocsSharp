using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SQLite;
using StackDocsSharp.Models.Const;
using StackDocsSharp.Services;

namespace StackDocsSharp.Services
{
    public class Paging
    {
        
        private IDataBase _conn;
        CRUD readData = new CRUD();

        public Paging()
        {
            _conn = ContainerInjector.Container.GetInstance<IDataBase>();
        }

        public DataTable GetNumOfRows(PagingArgs pagingArgs, List<CrudArgs> args = null)
        {
            string rowlimit = "order by id Limit " + pagingArgs.SkipRows.ToString() + "," + pagingArgs.TakeRows.ToString();
            var numOfRows = readData.Read(pagingArgs.TableName, args, rowlimit);
            return numOfRows;
        }

        public int GetTotalCount(string table, List<CrudArgs> args = null)
        {
            var conn = _conn.GetConnection();
            conn.Open();

            SQLiteCommand cmd = new SQLiteCommand(conn);
            DataTable dt = new DataTable();

            cmd.CommandText = "SELECT COUNT(*) FROM " + table + WhereStringBuilder(args);
            SQLiteDataReader reader = cmd.ExecuteReader();
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