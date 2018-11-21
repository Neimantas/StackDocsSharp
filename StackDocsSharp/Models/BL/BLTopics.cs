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
            parametersHTML, remarksHTML, helloWorldVersionsHTML, exampleText, isHelloWorldTopic, introductionPlain, parametersPlain, remarksPlain, syntaxPlain;
       // public bool isHelloWorldTopic;

        public BLTopics(DALTopics o, string examples, string introduction, string parameters, string remarks, string syntax) //reikia DAL ir concat examples string
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
            introductionPlain = introduction;
            parametersPlain = parameters;
            remarksPlain = remarks;
            syntaxPlain = syntax;
        }
    }
}