using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SQLite;

namespace StackDocsSharp.Services

{
    public class CRUD
    {
        public void Create() { }

        public DataTable Read(string table)
        
        {
            DataBase db  = new DataBase();
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


        public void Update() { }


        public void Delete() { }

    }
}