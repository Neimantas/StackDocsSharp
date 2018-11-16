using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace StackDocsSharp.Models.DAL
{
    public class DALTopics
    {
        public string id, docTagId, exampleCount, exampleScore, title, introductionHTML, syntaxHTML, parametersHTML, remarksHTML, helloWorldVersionsHTML, isHelloWorldTopic;
        //public bool isHelloWorldTopic;

        public DALTopics(DataRow row)
        {
            docTagId = row["DocTagId"].ToString();
            id = row["Id"].ToString();
            title = (string)row["Title"];
            introductionHTML = (string)row["IntroductionHtml"];
            parametersHTML = (string)row["ParametersHtml"];
            remarksHTML = (string)row["RemarksHtml"];
            syntaxHTML = (string)row["SyntaxHtml"];
            helloWorldVersionsHTML = (string)row["HelloWorldVersionsHtml"];
            isHelloWorldTopic = row["IsHelloWorldTopic"].ToString();
        }
    }
}