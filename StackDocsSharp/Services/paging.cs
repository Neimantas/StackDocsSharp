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
        //public int lastRowID;
        private IDataBase _conn;
        CRUD readData = new CRUD();

        public Paging()
        {
            _conn = ContainerInjector.Container.GetInstance<IDataBase>();
        }

        public DataTable GetNumOfRows(PagingArgs pagingArgs, List<CrudArgs> args = null)
        {

            string rowlimit = "order by id Limit " + pagingArgs.SkipRows.ToString() + "," + pagingArgs.TakeRows.ToString();
            var firstTen = readData.Read(pagingArgs.TableName, args, rowlimit);
            //int rowCount = firstTen.Rows.Count;
            //lastRowID = Convert.ToInt32(firstTen.Rows[(rowCount-1)][firstTen.Columns.IndexOf(uIdCollumn)]);
            return firstTen;
        }

        public int GetTotalCount(string table, List<CrudArgs> args = null)
        {
            var conn = _conn.GetConnection();

            //DataBase db = new DataBase();
            //var conn = db.GetConnection();
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