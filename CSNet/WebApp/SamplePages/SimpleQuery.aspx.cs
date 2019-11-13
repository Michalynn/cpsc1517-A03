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
                MessageLabel.Text = "Enter a RegionID value.";
            }
            else
            {
                //make sure that its an int
                int regionid = 0;
                if (!int.TryParse(RegionIdArg.Text, out regionid))
                {
                    MessageLabel.Text = "RegionID must be a WHOLE number.";
                }
                else
                {
                    if (regionid < 1)
                    {
                        MessageLabel.Text = "RegionID must be a WHOLE number greater than zero.";
                    }
                    else
                    {
                        
                        //anytime you plan on leaving your webapp project
                        //   to go to another project, you MUST use "try/catch"
                        try
                        {
                            //standard lookup of data (if its valid)
                            //STEPS:
                            //   Create a receiving data variable
                            //   Create an instance of the controller class you are
                            //      going to make your request to 
                            //     issue your request
                            //     check your results
                            //  a) List<T> use .Count
                            //  b) Single record use == null
                            // Display according to your results
                            Region info = null;
                            RegionController sysmgr = new RegionController();
                            info = sysmgr.Regions_FindByID(regionid);
                            if (info == null)
                            {
                                MessageLabel.Text = "RegionID not found";
                                RegionID.Text = "";
                                RegionDescription.Text = "";
                            }
                            else
                            {
                                RegionID.Text = info.RegionID.ToString();
                                RegionDescription.Text = info.RegionDescription;
                            }
                        }
                        catch (Exception ex)
                        {

                            MessageLabel.Text = ex.Message;
                        }
                    }
                }
            }  
        }
    }
}