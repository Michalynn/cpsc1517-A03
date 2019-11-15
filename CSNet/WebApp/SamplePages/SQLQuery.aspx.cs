using NorthwindSystem.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class SQLQuery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MessageLabel.Text = "";
            if (!Page.IsPostBack)
            {
                BindCategoryList();
            }
        }

        protected void BindCategoryList()
        {
            //This will be a standard look up for the Category Records
            try
            {
                CategoryController sysmgr = new CategoryController();
                List<Category> info = null;
                info = sysmgr.Categories_List();
                info.Sort((x, y) => x.CategoryName.CompareTo(y.CategoryName));
                CategoryList.DataSource = info;
                CategoryList.DataTextField = nameof(Category.CategoryName);
                CategoryList.DataTextField = nameof(Category.CategoryID);
                CategoryList.DataBind();
                CategoryList.Items.Insert(0,"select...");
            }
            catch (Exception ex)
            {

                MessageLabel.Text = ex.Message;
            }
        }
        protected void Fetch_Click(object sender, EventArgs e)
        {
            if (CategoryList.SelectedIndex==0)
            {
                MessageLabel.Text = "Select a category to view its products";
            }
            else
            {
                //standard look-up
            }
        }
    }
}