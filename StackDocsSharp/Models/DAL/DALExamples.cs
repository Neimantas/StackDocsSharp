using System.Data;

namespace StackDocsSharp.Models.DAL
{
    public class DALExamples
    {
        public string id, docTopicId, score, title, creationDate, bodyHTML;
        public bool isPinned;

        public DALExamples(DataRow row)
        {
            docTopicId = row["DocTopicId"].ToString();
            id = row["Id"].ToString();
            title = (string)row["Title"];
            bodyHTML = (string)row["BodyHtml"];
            isPinned = (bool)row["IsPinned"];
        }
    }
}