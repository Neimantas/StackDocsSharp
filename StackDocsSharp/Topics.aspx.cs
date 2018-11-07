using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StackDocsSharp.Services;

namespace StackDocsSharp
{
    public partial class Topics : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Topic.Text = e.ToString();
            GetTopics();
        }

        public void GetTopics()
        {
            var readTopics = new CRUD();
            var topicsData = readTopics.Read("Topics");
            gwtopics.DataSource = topicsData;
            gwtopics.DataBind();


        }



    }
}