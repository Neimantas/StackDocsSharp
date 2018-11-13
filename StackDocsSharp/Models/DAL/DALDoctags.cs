using System;
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
            id = (string)row["Id"];
            title = (string)row["Title"];
            helloWorldDocTopicId = (string)row["HelloWorldDocTopicId"];
            topicCount = (string)row["TopicCount"];
            creationDate = (string)row["CreationDate"];
            tag = (string)row["Tag"];
        }
    }
}