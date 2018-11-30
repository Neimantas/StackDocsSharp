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
        //private static int lastTopicID;
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

            //string topicsKey = "topics"+ gwtopics.PageIndex;

            var resultTopics = GetTopics(DropDownList1.SelectedValue);

            //if (Cache.Get(topicsKey) == null)
            //{ _cache.SetObjectToCache(topicsKey, resultTopics); }

            gwtopics.DataSource = resultTopics;
                //_cache.GetObjectFromCache(topicsKey);
            gwtopics.DataBind();

        }

        protected void Selection_Change(object sender, EventArgs e)
        {
            Paging totalCount = new Paging();
            pagesize = gwtopics.PageSize;

            if (!string.IsNullOrEmpty(DropDownList1.SelectedValue))
            {
                List<CrudArgs> args = new List<CrudArgs> { new CrudArgs("DocTagId", "=", DropDownList1.SelectedValue) };
                gwtopics.VirtualItemCount = totalCount.GetTotalCount("Topics", args);

                gwtopics.DataSource = GetFirstTopics(DropDownList1.SelectedValue);
                gwtopics.DataBind();

            }
        }

        protected DataTable GetFirstTopics(string lang)
        {
            int currIndex = gwtopics.PageIndex;
            string topicIdKey = "topicId" + currIndex;

            Paging firstRows = new Paging();
            List<CrudArgs> args = new List<CrudArgs> { new CrudArgs("DocTagId", "=", lang) };
            PagingArgs pArgs = new PagingArgs() { TableName = "Topics", SkipRows = 0, TakeRows = pagesize };

            var topics = firstRows.GetNumOfRows(pArgs, args);
            int rowCount = topics.Rows.Count;
            int lastTopicID = Convert.ToInt32(topics.Rows[(rowCount - 1)][topics.Columns.IndexOf("Id")]);

            if (Cache.Get(topicIdKey) == null)
            { _cache.SetObjectToCache(topicIdKey, lastTopicID); }

            return topics;
        }

        protected DataTable GetTopics(string lang)
        {
            int currIndex = gwtopics.PageIndex;
            int prevIndex = gwtopics.PageIndex - 1;
            string topicIdKey = "topicId" + currIndex;
            
            if (currIndex > 0)
            {
                int prevTopicId = (int)Cache.Get("topicId" + prevIndex);

                Paging rows = new Paging();
                List<CrudArgs> args = new List<CrudArgs> { (new CrudArgs("DocTagId", "=", lang)), (new CrudArgs("ID", ">", prevTopicId.ToString())) };
                PagingArgs pArgs = new PagingArgs() { TableName = "Topics", SkipRows = 0, TakeRows = pagesize };

                var topics = rows.GetNumOfRows(pArgs, args);
                                
                int rowCount = topics.Rows.Count;
                int lastTopicID = Convert.ToInt32(topics.Rows[(rowCount - 1)][topics.Columns.IndexOf("Id")]);

                if (Cache.Get(topicIdKey) == null)
                { _cache.SetObjectToCache(topicIdKey, lastTopicID); }

                return topics;
            }
            
            else
            {
                return GetFirstTopics(DropDownList1.SelectedValue);
            }

            
                
            
        }

    }
}
