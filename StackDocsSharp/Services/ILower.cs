﻿using StackDocsSharp.Models.BL;
using StackDocsSharp.Models.Const;
using StackDocsSharp.Models.DAL;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace StackDocsSharp.Services
{
    public class ILower
    {
        
       
        public List<DALTopics> ReadDALTopics(params CrudArgs[] args)
        {
            CRUD readData = new CRUD();
            DataRow[] rows = readData.Read("Topics", args).Select();
            List<DALTopics> list = new List<DALTopics>();
            foreach(DataRow dataRow in rows)
            {
                list.Add(new DALTopics(dataRow));
            }
            return list;
        }

        public List<DALDoctags> ReadDALDoctags(params CrudArgs[] args)
        {
            CRUD readData = new CRUD();
            DataRow[] rows = readData.Read("DocTags", args).Select();
            List<DALDoctags> list = new List<DALDoctags>();
            foreach (DataRow dataRow in rows)
            {
                list.Add(new DALDoctags(dataRow));
            }
            return list;
        }

        public List<DALExamples> ReadDALExamples(params CrudArgs[] args)
        {
            CRUD readData = new CRUD();
            DataRow[] rows = readData.Read("Examples", args).Select();
            List<DALExamples> list = new List<DALExamples>();
            foreach (DataRow dataRow in rows)
            {
                list.Add(new DALExamples(dataRow));
            }
            return list;
        }

    }
}