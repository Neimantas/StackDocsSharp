using StackDocsSharp.Models.BL;
using StackDocsSharp.Models.Const;
using StackDocsSharp.Models.DAL;
using System.Collections.Generic;

namespace StackDocsSharp.Services
{
    public class IHigher
    {
        public List<string> GetTopicsList()
        {
            ILower readData = new ILower();
            List<string> listTopics = new List<string>();
            List<DALDoctags> list = readData.ReadDALDoctags();

            for (int i = 0; i < list.Count; i++)
            {
                listTopics.Add(list[i].title);
            }

            return listTopics;
        }

        public List<BLTopics> GetTopics(params CrudArgs[] args)
        {
            ILower readData = new ILower();
            List<BLTopics> topicsFormatted = new List<BLTopics>();
            List<DALTopics> dalTopics = readData.ReadDALTopics(args);
            foreach(DALTopics topic in dalTopics)
            {
                string concat = ConcatExamplesByTopicId(topic.id);
                topicsFormatted.Add(new BLTopics(topic, concat) );
            }

            return topicsFormatted;
        }

        public string ConcatExamplesByTopicId(string id)//sumeta i viena stringa examples
        {
            ILower readData = new ILower();
            List<DALExamples> list = readData.ReadDALExamples(new CrudArgs("DocTopicId", "=", id));
            string concat = "";
            foreach (DALExamples obj in list)
            {
                concat += "<h3>" + obj.title + "</h3>" + obj.bodyHTML;
            }
            return concat;
        }

    }
}