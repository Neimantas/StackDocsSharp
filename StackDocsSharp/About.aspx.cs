using System;
using System.Web.UI;

namespace StackDocsSharp
{
    public partial class About : Page
    {
        public string Petras_;
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Button1.Enabled = false;
        }
    }
}