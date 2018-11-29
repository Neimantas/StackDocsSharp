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
        private ICache _cache;
        private static int lastTopicID;
        private int pagesize;


        public _Default()
        {
            _lower = ContainerInjector.Container.GetInstance<ILower>();
            _cache = ContainerInjector.Container.GetInstance<ICache>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                
                
                var dropDown = _lower.ReadDALDoctags(new List<CrudArgs> { });
                var readDocTags = new CRUD();
                readDocTags.Read("DocTags", new List<CrudArgs> { });

                DropDownList1.Items.Add(new ListItem());

                foreach (var language in dropDown)
                {
                    DropDownList1.Items.Add(new ListItem(language.title, language.id));
                }
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        { }

        protected void GwTopics_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            pagesize = gwtopics.PageSize;
            gwtopics.PageIndex = e.NewPageIndex;

            string topicsKey = "ten_topics";
            
            var resultTopics = GetTenTopics(DropDownList1.SelectedValue);
            
            _cache.SetObjectToCache(topicsKey, resultTopics);

            gwtopics.DataSource = _cache.GetObjectFromCache(topicsKey);
            gwtopics.DataBind();

        }

        protected void Selection_Change(object sender, EventArgs e)
        {
            Paging totalCount = new Paging();
            pagesize = gwtopics.PageSize;

            if(!string.IsNullOrEmpty(DropDownList1.SelectedValue))
            { 
            List<CrudArgs> args = new List<CrudArgs> { new CrudArgs("DocTagId", "=", DropDownList1.SelectedValue) };
            gwtopics.VirtualItemCount = totalCount.GetTotalCount("Topics", args);

            GetFirstTenTopics(DropDownList1.SelectedValue);
            }
        }

        protected void GetFirstTenTopics(string lang)
        {
            Paging firstTenRows = new Paging();
            List<CrudArgs> args = new List<CrudArgs> { new CrudArgs("DocTagId", "=", lang) };

            var topics = firstTenRows.GetNumOfRows("Topics", "Id", pagesize, args);
            lastTopicID = firstTenRows.lastRowID;
                 

            gwtopics.DataSource = topics;
            gwtopics.DataBind();
        }

        protected DataTable GetTenTopics(string lang)
        {
            Paging tenRows = new Paging();
            List<CrudArgs> args = new List<CrudArgs> { (new CrudArgs("DocTagId", "=", lang)), (new CrudArgs("ID", ">", lastTopicID.ToString())) };
            var topics = tenRows.GetNumOfRows("Topics", "Id" ,pagesize, args);
            lastTopicID = tenRows.lastRowID;
            return topics;
            //gwtopics.DataSource = topics;
            //gwtopics.DataBind();
        }

    }
}
