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
        private static int pagesize;

        public _Default()
        {
            _lower = ContainerInjector.Container.GetInstance<ILower>();
            _cache = ContainerInjector.Container.GetInstance<ICache>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            pagesize = gwtopics.PageSize;

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
            gwtopics.PageIndex = e.NewPageIndex;

            var resultTopics = GetTopics(DropDownList1.SelectedValue);

            gwtopics.DataSource = resultTopics;
            gwtopics.DataBind();
        }

        protected void Selection_Change(object sender, EventArgs e)
        {
            Paging totalCount = new Paging();
            gwtopics.PageIndex = 0;

            if (!string.IsNullOrEmpty(DropDownList1.SelectedValue))
            {
                List<CrudArgs> args = new List<CrudArgs> { new CrudArgs("DocTagId", "=", DropDownList1.SelectedValue) };
                gwtopics.VirtualItemCount = totalCount.GetTotalCount("Topics", args);

                gwtopics.DataSource = GetTopics(DropDownList1.SelectedValue);
                gwtopics.DataBind();
            }
        }

        protected DataTable GetTopics(string lang)
        {
            int currIndex = gwtopics.PageIndex;
            int prevIndex = gwtopics.PageIndex - 1;
            string topicIdKey = lang + currIndex;
            int prevTopicId = 0;
            int skip = currIndex * pagesize;

            Paging rows = new Paging();

            if (Cache.Get(lang + prevIndex) != null)
            {
                prevTopicId = (int)Cache.Get(lang + prevIndex);
                skip = 0;
            }

            List<CrudArgs> args = new List<CrudArgs> { (new CrudArgs("DocTagId", "=", lang)), (new CrudArgs("ID", ">", prevTopicId.ToString())) };
            PagingArgs pArgs = new PagingArgs() { TableName = "Topics", SkipRows = skip, TakeRows = pagesize };

            var topics = rows.GetNumOfRows(pArgs, args);
            int rowCount = topics.Rows.Count;
            int lastTopicID = Convert.ToInt32(topics.Rows[(rowCount - 1)][topics.Columns.IndexOf("Id")]);

            if (Cache.Get(topicIdKey) == null)
            { _cache.SetObjectToCache(topicIdKey, lastTopicID); }

            return topics;
        }
    }
}
