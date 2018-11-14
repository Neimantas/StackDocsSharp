using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StackDocsSharp.Services;
using StackDocsSharp.Models.Const;

namespace StackDocsSharp
{
    public partial class Topics : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TopicTitle.Text = Request["Title"];
            GetTopicsInfo(Request.QueryString["Title"], Request.QueryString["DocTagID"]);
        }

        public void GetTopicsInfo(string topicTitle, string ID)
        {
            var readTopics = new CRUD();
           
            CrudArgs[] argCombo = new CrudArgs[] { (new CrudArgs("Title", "=", topicTitle)), (new CrudArgs("DocTagID", "=", ID)) };
            
            var topicsData = readTopics.Read("Topics",argCombo);
            gwtopics.DataSource = topicsData;
            gwtopics.DataBind();

            lblHello.Text = topicsData.Rows[0]["HelloWorldVersionsHtml"].ToString();
            lblParameters.Text = topicsData.Rows[0]["ParametersHtml"].ToString();
            lblRemarks.Text = topicsData.Rows[0]["RemarksHtml"].ToString();
            lblSyntax.Text = topicsData.Rows[0]["SyntaxHtml"].ToString();
        }



    }
}