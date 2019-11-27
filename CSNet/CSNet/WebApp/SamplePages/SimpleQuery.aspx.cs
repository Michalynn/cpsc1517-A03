
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


#region Additional Namespaces
using NorthwindSystem.Data;
using NorthwindSystem.BLL;
#endregion

namespace WebApp.SamplePages
{
    public partial class SimpleQuery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //empty old messages
            MessageLabel.Text = "";
        }

        protected void Fetch_Click(object sender, EventArgs e)
        {
            //validate the input
            if (string.IsNullOrEmpty(RegionIdArg.Text))
            {
                MessageLabel.Text = "Enter a region id value.";
            }
            else
            {
                int regionid = 0;
                if (!int.TryParse(RegionIdArg.Text, out regionid))
                {
                    MessageLabel.Text = "Region id must be a whole number.";
                }
                else
                {
                    if (regionid < 1)
                    {
                        MessageLabel.Text = "Region id must be a whole number greater than 0.";
                    }
                    else
                    {
                        
                        //any time you plan on leaving your web app project
                        //   to go to another project, you MUST use try/catch
                        //try
                        //{
                            //standard lookup of data
                            //steps
                            //   create an receiving data variable
                            //   create an instance of the controller class you are
                            //     go to make your request to
                            //   issue your request
                            //   check your results
                            //      a)List<T> use .Count
                            //      b)single record use == null
                            //   display according to your results
                            Region info = null;
                            RegionController sysmgr = new RegionController();
                            info = sysmgr.Regions_FindByID(regionid);
                            if (info == null)
                            {
                                MessageLabel.Text = "Region ID not found.";
                                RegionID.Text = "";
                                RegionDescription.Text = "";
                            }
                            else
                            {
                                RegionID.Text = info.RegionID.ToString();
                                RegionDescription.Text = info.RegionDescription;
                            }
                        //}
                        //catch (Exception ex)
                        //{
                        //    MessageLabel.Text = ex.Message;
                        //}
                    }
                }
            }
            
        }
    }
}