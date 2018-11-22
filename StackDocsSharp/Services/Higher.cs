using StackDocsSharp.Models.BL;
using StackDocsSharp.Models.Const;
using StackDocsSharp.Models.DAL;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace StackDocsSharp.Services
{
    public class Higher : IHigher
    {
        public List<string> GetTopicsList()
        {
            Lower _lower = new Lower();
            List<string> listTopics = new List<string>();
            List<DALDoctags> list = _lower.ReadDALDoctags(new List<CrudArgs>());

            for (int i = 0; i < list.Count; i++)
            {
                listTopics.Add(list[i].title);
            }

            return listTopics;
        }

        public List<BLTopics> GetTopics(List<CrudArgs> args = null)
        {
            Lower _lower = new Lower();
            List<BLTopics> topicsFormatted = new List<BLTopics>();
            List<DALTopics> dalTopics = _lower.ReadDALTopics(args);
            foreach (DALTopics topic in dalTopics)
            {
                string concat = ConcatExamplesByTopicId(topic.id);
                string introductionPlain = StripMarkdownTags(topic.introductionMark);
                string parametersPlain = StripMarkdownTags(topic.parametersMark);
                string remarksPlain = StripMarkdownTags(topic.remarksMark);
                string syntaxPlain = StripMarkdownTags(topic.syntaxMark);
                
                topicsFormatted.Add(new BLTopics(topic, concat, introductionPlain, parametersPlain, remarksPlain, syntaxPlain));

            }

            return topicsFormatted;
        }

        public string ConcatExamplesByTopicId(string id)//sumeta i viena stringa examples
        {
            Lower _lower = new Lower();
            List<DALExamples> list = _lower.ReadDALExamples(new List<CrudArgs>() { new CrudArgs("DocTopicId", "=", id) } );
            string concat = "";
            foreach (DALExamples obj in list)
            {
                concat += "<h3>" + obj.title + "</h3>" + obj.bodyHTML;
            }
            return concat;
        }

        private string StripMarkdownTags(string content)
        {
            // Headers
            content = Regex.Replace(content, "/\n={2,}/g", "\n");
            // Strikethrough
            content = Regex.Replace(content, "/~~/g", "");
            // Codeblocks
            content = Regex.Replace(content, "/`{3}.*\n/g", "");
            // HTML Tags
            content = Regex.Replace(content, "/<[^>]*>/g", "");
            // Remove setext-style headers
            content = Regex.Replace(content, "/^[=\\-]{2,}\\s*$/g", "");
            // Footnotes
            content = Regex.Replace(content, "/\\[\\^.+?\\](\\: .*?$)?/g", "");
            content = Regex.Replace(content, "/\\s{0,2}\\[.*?\\]: .*?$/g", "");
            // Images
            content = Regex.Replace(content, "/\\!\\[.*?\\][\\[\\(].*?[\\]\\)]/g", "");
            // Links
            content = Regex.Replace(content, "/\\[(.*?)\\][\\[\\(].*?[\\]\\)]/g", "$1");
            return content;
        }
    }
}