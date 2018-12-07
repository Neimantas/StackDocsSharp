using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace StackDocsSharp.Models.DAL
{
    public class DALTopics
    {
        public string id, docTagId, exampleCount, exampleScore, title, introductionHTML, syntaxHTML, parametersHTML, remarksHTML, 
            helloWorldVersionsHTML, isHelloWorldTopic, introductionMark, syntaxMark, parametersMark, remarksMark;
        //public bool isHelloWorldTopic;

        public DALTopics(DataRow row)
        {
            docTagId = row["DocTagId"].ToString();
            id = row["Id"].ToString();
            title = row["Title"].ToString();
            introductionHTML = row["IntroductionHtml"].ToString();
            parametersHTML = row["ParametersHtml"].ToString();
            remarksHTML = row["RemarksHtml"].ToString();
            syntaxHTML = row["SyntaxHtml"].ToString();
            helloWorldVersionsHTML = row["HelloWorldVersionsHtml"].ToString();
            isHelloWorldTopic = row["IsHelloWorldTopic"].ToString();
            introductionMark = row["IntroductionMarkdown"].ToString();
            syntaxMark = row["SyntaxMarkdown"].ToString();
            parametersMark = row["ParametersMarkdown"].ToString();
            remarksMark = row["RemarksMarkdown"].ToString();
        }
    }
}