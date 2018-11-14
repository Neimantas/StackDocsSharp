using StackDocsSharp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StackDocsSharp.Models.DAL;
using System.Data;
using StackDocsSharp.Models.Const;

namespace StackDocsSharp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ILower higher = new ILower();

                var dropDown = higher.ReadDALDoctags();

                foreach (var language in dropDown)
                {             
                    DropDownList1.Items.Add(new ListItem(language.title, language.id));
                }


            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            GetTopics(DropDownList1.SelectedValue);
        }

        public void GetTopics(string lang)
        {
            var readTopics = new CRUD();
           
            CrudArgs[] argArray = new CrudArgs[] { new CrudArgs("DocTagId", "=", lang) };
                                  
            var topicsData = readTopics.Read("Topics", argArray);
            gwtopics.DataSource = topicsData;
            gwtopics.DataBind();
            
        }
    }
}