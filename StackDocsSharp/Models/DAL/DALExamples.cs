using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StackDocsSharp.Models.DAL
{
    public class DALExamples
    {
        public int Id, DocTopicId, Score;
        public string Title, CreationDate, BodyHtml, BodyMarkdown;
        public bool IsPinned;
    }
}