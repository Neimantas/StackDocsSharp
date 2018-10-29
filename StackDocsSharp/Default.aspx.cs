using StackDocsSharp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StackDocsSharp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                IHigher higher = new IHigher();

                List<string> naujas = higher.GetTopicsList();

                foreach (string topic in naujas)
                {
                    DropDownList1.Items.Add(new ListItem(topic, topic.ToLower()));
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            tabMarkup.Visible = true;
            langText.Text = DropDownList1.SelectedValue;
            searchText.Text = wordas.Text;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}