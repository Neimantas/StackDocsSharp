using System.Data;

namespace StackDocsSharp.Models.DAL
{
    public class DALExamples
    {
        public string id, docTopicId, score, title, creationDate, bodyHTML;
        public bool isPinned;

        public DALExamples(DataRow row)
        {
            docTopicId = (string)row["DocTopicId"];
            id = (string)row["Id"];
            title = (string)row["Title"];
            bodyHTML = (string)row["BodyHtml"];
            isPinned = (bool)row["IsPinned"];
        }
    }
}