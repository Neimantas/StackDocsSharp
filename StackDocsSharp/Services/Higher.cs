using StackDocsSharp.Models.BL;
using StackDocsSharp.Models.Const;
using StackDocsSharp.Models.DAL;
using System.Collections.Generic;

namespace StackDocsSharp.Services
{
    public class Higher : IHigher
    {
        private Lower _lower;

        public Higher()
        {
            _lower = new Lower();
        }

        public List<string> GetTopicsList()
        {
            List<string> listTopics = new List<string>();
            List<DALDoctags> list = _lower.ReadDALDoctags(new List<CrudArgs>());

            for (int i = 0; i < list.Count; i++)
            {
                listTopics.Add(list[i].title);
            }

            return listTopics;
        }

        public List<BLTopics> GetTopics(List<CrudArgs> args)
        {
            List<BLTopics> topicsFormatted = new List<BLTopics>();
            List<DALTopics> dalTopics = _lower.ReadDALTopics(args);
            foreach (DALTopics topic in dalTopics)
            {
                string concat = ConcatExamplesByTopicId(topic.id);
                topicsFormatted.Add(new BLTopics(topic, concat));
            }

            return topicsFormatted;
        }

        public string ConcatExamplesByTopicId(string id)//sumeta i viena stringa examples
        {
            List<DALExamples> list = _lower.ReadDALExamples(new List<CrudArgs>() { new CrudArgs("DocTopicId", "=", id) } );
            string concat = "";
            foreach (DALExamples obj in list)
            {
                concat += "<h3>" + obj.title + "</h3>" + obj.bodyHTML;
            }
            return concat;
        }
    }
}