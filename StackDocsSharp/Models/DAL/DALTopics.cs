using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StackDocsSharp.Models.DAL
{
    public class DALTopics
    {
        public int Id, DocTagId, ExampleCount, ExampleScore;
        public bool IsHelloWorldTopic;
        public string Title, IntroductionHtml, SyntaxHtml, ParametersHtml, RemarksHtml, IntroductionMarkdown,
            SyntaxMarkdown, ParametersMarkdown, RemarksMarkdown, HelloWorldVersionsHtml;
        public DateTime CreationDate;
    }
}