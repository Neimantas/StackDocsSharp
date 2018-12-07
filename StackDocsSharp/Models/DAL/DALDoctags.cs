﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace StackDocsSharp.Models.DAL
{
    public class DALDoctags
    {
        public string id, helloWorldDocTopicId, topicCount, creationDate, tag, title;

        public DALDoctags(DataRow row)
        {
            id = row["Id"].ToString();
            title = row["Title"].ToString();
            helloWorldDocTopicId = row["HelloWorldDocTopicId"].ToString();
            topicCount = row["TopicCount"].ToString();
            creationDate = row["CreationDate"].ToString();
            tag = row["Tag"].ToString();
        }
    }
}