using SimpleInjector;
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
        private ILower _lower;

        public _Default()
        {
            _lower = ContainerInjector.Container.GetInstance<ILower>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            { 
                var dropDown = _lower.ReadDALDoctags(new List<CrudArgs> { });
                var readDocTags = new CRUD();
                readDocTags.Read("DocTags", new List<CrudArgs> { });


                foreach (var language in dropDown)
                {             
                    DropDownList1.Items.Add(new ListItem(language.title, language.id));
                }


            }
        }

        protected void gwtopics_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gwtopics.PageIndex = e.NewPageIndex;
            GetTopics(DropDownList1.SelectedValue);

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GetTopics(DropDownList1.SelectedValue);
        }

        protected void GetTopics(string lang)
        {
            var readTopics = new CRUD();
           
            List<CrudArgs> argArray = new List<CrudArgs> { new CrudArgs("DocTagId", "=", lang) };
                                  
            var topicsData = readTopics.Read("Topics", argArray);
            gwtopics.DataSource = topicsData;
            gwtopics.DataBind();
            
        }
    }
}