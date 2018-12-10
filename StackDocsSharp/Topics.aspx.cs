using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StackDocsSharp.Services;
using StackDocsSharp.Models.Const;
using SimpleInjector;
using StackDocsSharp.Models.BL;

namespace StackDocsSharp
{
    public partial class Topics : System.Web.UI.Page
    {
        private IHigher _higher;
        private BLTopics topic;
        public Topics()
        {
            _higher = ContainerInjector.Container.GetInstance<IHigher>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                List<BLTopics> topiclist = _higher.GetTopics(new List<CrudArgs> { new CrudArgs("Id", "=", Request.QueryString["ID"]) });
                if(topiclist.Count == 1)
                {
                    topic = topiclist[0];
                    TopicTitle.Text = topic.title;
                    lblHello.Text = topic.helloWorldVersionsHTML;
                    lblIntro.Text = topic.introductionHTML;
                    lblParameters.Text = topic.parametersHTML;
                    lblRemarks.Text = topic.remarksHTML;
                    lblSyntax.Text = topic.syntaxHTML;
                    modallbl.Text = topic.exampleText;
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
        }
    }
}