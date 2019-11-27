using NorthwindSystem.BLL;
using NorthwindSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class SqlQuery : System.Web.UI.Page
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
            //this will be a standard lookup for the Category records
            try
            {
                CategoryController sysmgr = new CategoryController();
                List<Category> info = null;
                info = sysmgr.Categories_List();
                info.Sort((x, y) => x.CategoryName.CompareTo(y.CategoryName));
                CategoryList.DataSource = info;
                CategoryList.DataTextField = nameof(Category.CategoryName);
                CategoryList.DataValueField = nameof(Category.CategoryID);
                CategoryList.DataBind();
                CategoryList.Items.Insert(0, "select...");
            }
            catch (Exception ex)
            {
                MessageLabel.Text = ex.Message;
            }
        }

        protected void Fetch_Click(object sender, EventArgs e)
        {
            if (CategoryList.SelectedIndex == 0)
            {
                MessageLabel.Text = "Select a category to view its products";
            }
            else
            {
                //standard lookup
                try
                {
                    ProductController sysmgr = new ProductController();
                    List<Product> info = null;
                    info = sysmgr.Products_FindByCategory(int.Parse(CategoryList.SelectedValue));
                    info.Sort((x, y) => x.ProductName.CompareTo(y.ProductName));
                    ProductList.DataSource = info;
                    ProductList.DataBind();

                }
                catch (Exception ex)
                {
                    MessageLabel.Text = ex.Message;
                }
            }
        }

        protected void ProductList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //web controls on events get passed arguments DEPENDING on the control
            //check your method header to see the argument class type
            //since the arguments are in a class, use appropriate object referencing to 
            //    obtain the data value required

            //you MUST set the gridview page index property
            //the new page index value is located in the supplied event arguments
            ProductList.PageIndex = e.NewPageIndex;

            //you must refresh your data collection
            Fetch_Click(sender, new EventArgs());
        }

        protected void ProductList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //a gridview can be thought of as a table of indexed rows
            //to access a piece of data of the gridview you need to reference the Row
            //   of the gridview display collection
            //   then you need to reference the data by using the appropriate data access
            //   technique which depends on how the column is displaying the data
            //we will limit are examples to Template with web controls
            GridViewRow agvrow = ProductList.Rows[ProductList.SelectedIndex];

            //to access the piece of data used the method .FindControl("xxxx") where xxxx
            //   is the id of the control on the GridView
            //syntax    (agvrow.FindControl("xxxxx") as controltype).controltypeaccess
            //example for label
            //(agvrow.FindControl("xxxxx") as Label).Text
            //data is returned as a string
            string productid = (agvrow.FindControl("ProductID") as Label).Text;

            //pass the obtained data to another page
            Response.Redirect("ReceivingPage.aspx?pid=" + productid);

        }
    }
}