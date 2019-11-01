using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class ContestEntry : System.Web.UI.Page
    {
        public static List<CEntry> Entries;
        protected void Page_Load(object sender, EventArgs e)
        {
            Message.Text = "";
            if (!Page.IsPostBack)
            {
                Entries = new List<CEntry>();
            }
        }


        protected void Clear_Click(object sender, EventArgs e)
        {
            FirstName.Text = "";
            LastName.Text = "";
           StreetAddress1.Text = "";
            StreetAddress2.Text = "";
            City.Text = "";
            PostalCode.Text = "";
            Province.SelectedIndex = 0;
            EmailAddress.Text = "";
            Terms.Checked = false;
            CheckAnswer.Text = "";

        }

        protected void Submit_Click(object sender, EventArgs e)
        {

        }
    }
}