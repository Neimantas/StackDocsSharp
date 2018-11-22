using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SQLite;
using StackDocsSharp.Models.Const;

namespace StackDocsSharp.Services
{
    public class paging
    {
        public int lastRowID;

        CRUD readData = new CRUD();

        public DataTable getFirstTenRows(string table, List<CrudArgs> args, int pageSize)
        {
            string rowlimit = "order by id Limit " + pageSize.ToString();
            var firstTen = readData.Read(table,args,rowlimit);
            lastRowID = Convert.ToInt32(firstTen.Rows[19][5]);
            return firstTen;
        }

        public int getTotalCount(string table)
        {
            DataBase db = new DataBase();
            var conn = db.GetConnection();
            conn.Open();

            SQLiteCommand cmd = new SQLiteCommand(conn);
            cmd.CommandText = "SELECT COUNT(*) FROM " + table;
            SQLiteDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();

            dt.Load(reader);

            return Convert.ToInt32(dt.Rows[0][0].ToString());


        }
        

    }
}