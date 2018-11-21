using StackDocsSharp.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StackDocsSharp.Models.BL
{
    public class BLTopics
    {
        public string id, docTagId, exampleCount, exampleScore, title, introductionHTML, syntaxHTML,
            parametersHTML, remarksHTML, helloWorldVersionsHTML, exampleText, isHelloWorldTopic, markdownText;
       // public bool isHelloWorldTopic;

        public BLTopics(DALTopics o, string examples) //reikia DAL ir concat examples string
        {
            docTagId = o.docTagId;
            id = o.id;
            title = o.title;
            introductionHTML = o.introductionHTML;
            parametersHTML = o.parametersHTML;
            remarksHTML = o.remarksHTML;
            syntaxHTML = o.syntaxHTML;
            helloWorldVersionsHTML = o.helloWorldVersionsHTML;
            isHelloWorldTopic = o.isHelloWorldTopic;
            exampleText = examples;
            markdownText = o.introductionMark + "\n" + o.syntaxMark + "\n" + o.parametersMark + "\n" + o.remarksMark;

        }
    }
}