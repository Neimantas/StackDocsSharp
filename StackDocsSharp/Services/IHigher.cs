using StackDocsSharp.Models.BL;
using StackDocsSharp.Models.Const;
using StackDocsSharp.Models.DAL;
using System.Collections.Generic;

namespace StackDocsSharp.Services
{
    public interface IHigher
    {
        List<string> GetTopicsList();
            ILower readData = new ILower();
            List<DALDoctags> list = readData.ReadDALDoctags();
        }

        public List<BLTopics> GetTopics(params CrudArgs[] args)
            List<BLTopics> topicsFormatted = new List<BLTopics>();
            List<DALTopics> dalTopics = readData.ReadDALTopics(args);
            foreach(DALTopics topic in dalTopics)
            {
                string concat = ConcatExamplesByTopicId(topic.id);
                topicsFormatted.Add(new BLTopics(topic, concat) );
            }

        List<BLTopics> GetTopics(params CrudArgs[] args);

        string ConcatExamplesByTopicId(string id);
        {
            ILower readData = new ILower();
            List<DALExamples> list = readData.ReadDALExamples(new CrudArgs("DocTopicId", "=", id));
            string concat = "";
            foreach (DALExamples obj in list)
            {
                concat += "<h3>" + obj.title + "</h3>" + obj.bodyHTML;
            return concat;
        }

    }
}