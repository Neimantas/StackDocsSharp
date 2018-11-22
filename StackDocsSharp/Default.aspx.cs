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
        private int lastTopicID;
        private int pagesize;


        public _Default()
        {
            _lower = ContainerInjector.Container.GetInstance<ILower>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                paging totalCount = new paging();
                gwtopics.VirtualItemCount = totalCount.getTotalCount("Topics");
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
            pagesize = gwtopics.PageSize;
            gwtopics.PageIndex = e.NewPageIndex;
            GetTenTopics(DropDownList1.SelectedValue);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //GetTopics(DropDownList1.SelectedValue);

            //Testing new logic with paging - get First 10 rows only 
            pagesize = gwtopics.PageSize;
            GetFirstTenTopics(DropDownList1.SelectedValue);
        }

        protected void GetFirstTenTopics(string lang)
        {
            paging firstTenRows = new paging();
            List<CrudArgs> args = new List<CrudArgs> { new CrudArgs("DocTagId", "=", lang) };

            var topics = firstTenRows.getFirstTenRows("Topics", args, pagesize);
            lastTopicID = firstTenRows.lastRowID;

            gwtopics.DataSource = topics;
            gwtopics.DataBind();
        }

        protected void GetTenTopics(string lang)
        {
            paging tenRows = new paging();
            List<CrudArgs> args = new List<CrudArgs> { (new CrudArgs("DocTagId", "=", lang)), (new CrudArgs("ID", ">", lastTopicID.ToString())) };
            var topics = tenRows.getFirstTenRows("Topics", args, pagesize);
            lastTopicID = tenRows.lastRowID;

            gwtopics.DataSource = topics;
            gwtopics.DataBind();
        }

        //protected void GetTopics(string lang)
        //{
        //    var readTopics = new CRUD();

        //    List<CrudArgs> args = new List<CrudArgs> { new CrudArgs("DocTagId", "=", lang) };

        //    var topicsData = readTopics.Read("Topics", args);
        //    gwtopics.DataSource = topicsData;
        //    gwtopics.DataBind();

        //}
    }
}