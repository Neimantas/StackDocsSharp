using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StackDocsSharp.Services;
using StackDocsSharp.Models.Const;
using SimpleInjector;

namespace StackDocsSharp
{
    public partial class Topics : System.Web.UI.Page
    {
        private IHigher _higher;

        public Topics()
        {
            _higher = ContainerInjector.Container.GetInstance<IHigher>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            { 
            TopicTitle.Text = Request["Title"];
            GetTopicsInfo(Request.QueryString["Title"], Request.QueryString["DocTagID"]);
            modallbl.Text = Server.HtmlDecode(GetExamples(Request.QueryString["ID"]));
            }
        }

        protected string GetExamples(string TopicID) {
            var readExamples = _higher.GetTopics(new CrudArgs("Id", "=", TopicID));
            return readExamples[0].exampleText;
          
            
        }

        protected void GetTopicsInfo(string topicTitle, string ID)
        {
            var readTopics = new CRUD();
           
            CrudArgs[] argCombo = new CrudArgs[] { (new CrudArgs("Title", "=", topicTitle)), (new CrudArgs("DocTagID", "=", ID)) };
            
            var topicsData = readTopics.Read("Topics",argCombo);
            

            if (topicsData.Rows.Count > 0)
            {
                lblHello.Text = Server.HtmlDecode(topicsData.Rows[0]["HelloWorldVersionsHtml"].ToString());
                lblIntro.Text = Server.HtmlDecode(topicsData.Rows[0]["IntroductionHTML"].ToString());
                lblParameters.Text = Server.HtmlDecode(topicsData.Rows[0]["ParametersHtml"].ToString());
                lblRemarks.Text = Server.HtmlDecode(topicsData.Rows[0]["RemarksHtml"].ToString());
                lblSyntax.Text = Server.HtmlDecode(topicsData.Rows[0]["SyntaxHtml"].ToString());
            }
            else {Response.Redirect("~/Default.aspx");}
        }



    }
}