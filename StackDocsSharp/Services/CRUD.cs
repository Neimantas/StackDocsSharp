using StackDocsSharp.Models.Const;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace StackDocsSharp.Services
{
    public class CRUD
    {
        public void Create()
        {
        }

        public DataTable Read(string table, params CrudArgs[] argarray)
        {
            DataBase db = new DataBase();
            var conn = db.GetConnection();
            conn.Open();

            SQLiteCommand cmd = new SQLiteCommand(conn);
            cmd.CommandText = "SELECT * FROM " + table + WhereStringBuilder(argarray) + ";";
            SQLiteDataReader reader = cmd.ExecuteReader();
            DataTable tableSchema = reader.GetSchemaTable();
            DataTable dt = new DataTable();
            List<DataColumn> columnList = new List<DataColumn>();

            foreach (DataRow row in tableSchema.Rows)
            {
                string columnName = System.Convert.ToString(row["ColumnName"]);
                DataColumn column = new DataColumn(columnName, (Type)(row["DataType"]));
                column.Unique = (bool)row["IsUnique"];
                column.AllowDBNull = (bool)row["AllowDBNull"];
                column.AutoIncrement = (bool)row["IsAutoIncrement"];
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

        private string WhereStringBuilder(params CrudArgs[] argarray)
        {
            string whereString = " Where 1=1";
            if (argarray.Length > 0)
            {
                for (int i = 0; i < argarray.Length; i++)
                {
                    whereString += " AND " + argarray[i].column + " " + argarray[i].argument + " " + "'" + argarray[i].value + "'";
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