using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StackDocsSharp
{
    public partial class TableData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void Unnamed_Click(object sender, EventArgs e)
        {
            Response.Redirect("Page2.aspx");
        }
        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("TableData.aspx");
        }
    }
}