using StackDocsSharp.Models.Const;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace StackDocsSharp.Services
{
    public class CRUD
    {
        public CRUD()
        {
            Settings.DefaultSelectCount++;
        }

        public void Create()
        {
        }

        public DataTable Read(string table, List<CrudArgs> args, string rowLimit="")
        {
            DataBase db = new DataBase();
            var conn = db.GetConnection();
            conn.Open();

            SQLiteCommand cmd = new SQLiteCommand(conn)
            {
                CommandText = "SELECT * FROM " + table + WhereStringBuilder(args) + rowLimit + ";"
            };
            SQLiteDataReader reader = cmd.ExecuteReader();
            DataTable tableSchema = reader.GetSchemaTable();
            DataTable dt = new DataTable();
            List<DataColumn> columnList = new List<DataColumn>();

            foreach (DataRow row in tableSchema.Rows)
            {
                string columnName = System.Convert.ToString(row["ColumnName"]);
                DataColumn column = new DataColumn(columnName, (Type)row["DataType"])
                {
                    Unique = (bool)row["IsUnique"],
                    AllowDBNull = (bool)row["AllowDBNull"],
                    AutoIncrement = (bool)row["IsAutoIncrement"]
                };
                columnList.Add(column);
                dt.Columns.Add(column);
            }
            while (reader.Read())
            {
                DataRow row = dt.NewRow();
                for (int i = 0; i < columnList.Count; i++)
                {
                    row[columnList[i]] = reader[i];
                }
                dt.Rows.Add(row);
            }
            reader.Close();
            conn.Close();
            return dt;
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

        public void Update()
        {
        }

        public void Delete()
        {
        }
    }
}