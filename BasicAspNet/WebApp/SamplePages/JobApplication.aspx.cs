using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    
    public partial class JobApplication : System.Web.UI.Page
    {
        public static List<JobApps> AppList = new List<JobApps>();
        protected void Page_Load(object sender, EventArgs e)
        {
            Message.Text = "";
            if (!Page.IsPostBack)
            {
                AppList = new List<JobApps>();
            }
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            FullName.Text = "";
            EmailAddress.Text = "";
            PhoneNumber.Text = "";
            FullOrPartTime.ClearSelection();
            Jobs.ClearSelection();
        }//EOClear

        protected void Submit_Click(object sender, EventArgs e)
        {
            //need to collect data 
            //string fullname = FullName.Text;
            string email = EmailAddress.Text;
            string phonenumber = PhoneNumber.Text;
            string time = FullOrPartTime.SelectedValue;

            //need to create a message containing the entered data
            string msg = string.Format("Name: {0} Email: {1} Phone: {2} Time: {3}",
                                        FullName.Text, email, phonenumber,time);
            //need to traverse the checkboxlist and
            //     obtain the data that was selected
            //need to add the data from the checkboxlist to the message
            string jobs = " Jobs: ";
            bool found = false;
            foreach (ListItem item in Jobs.Items)
            {
                if (item.Selected)
                {
                    jobs += item.Value + " ";
                    found = true;
                }
            }
            if (!found)
            {
                jobs += " you did NOT select a job. Application rejected.";
            }
            else
            {
                //saving application once submitted
                AppList.Add(new JobApps(FullName.Text, email, phonenumber, time, jobs));
            }
            //set the message label to the message
            Message.Text = msg + jobs;

            //display the current job application collection
            JobApplicationList.DataSource = AppList;
            JobApplicationList.DataBind();

        }//EOSubmit
    }
}