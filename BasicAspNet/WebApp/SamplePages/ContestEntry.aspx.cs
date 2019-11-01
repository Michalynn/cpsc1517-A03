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
            Province.SelectedIndex = 0;
            PostalCode.Text = "";
            EmailAddress.Text = "";
            Terms.Checked = false;
            CheckAnswer.Text = "";

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            //the client side execution of your validation controls 
            //is done BY using Page.Isvalid
            if (Page.IsValid)
            {
                // you may have logical testing to do
                //if you have a prompt line on your DDL, test for it
                //our entry form has a "terms" acceptance test
                //yes: save entry, add to collection
                //no: message
                //the Term data will NOT be saved
                //the checkanswer will NOT be saved
                if (Terms.Checked)
                {
                    //need a new instance of CEntry
                    CEntry theEntry = new CEntry();
                    //need to fill/load the instance
                    theEntry.FirstName = FirstName.Text;
                    theEntry.LastName = LastName.Text;
                    theEntry.StreetAddress1 = StreetAddress1.Text;
                    theEntry.StreetAddress2 = string.IsNullOrEmpty(StreetAddress2.Text) ? 
                                              null: StreetAddress2.Text;
                    theEntry.City = City.Text;
                    theEntry.Province = Province.SelectedValue;
                    theEntry.PostalCode = PostalCode.Text;
                    theEntry.EmailAddress = EmailAddress.Text;

                    //need to add the instance to my collection
                    Entries.Add(theEntry);

                    //Entries.Add(new CEntry(FirstName.Text,
                    //    LastName.Text,
                    //    StreetAddress1.Text,
                    //    string.IsNullOrEmpty(StreetAddress2.Text) ? null : StreetAddress2.Text,
                    //   Province.SelectedValue, PostalCode.Text, EmailAddress.Text));
                    //need to display the collection
                    EntryList.DataSource = Entries;
                    EntryList.DataBind();
                }
                else
                {
                    Message.Text = "You did not agree to term. Entry Rejected";
                }
            }
        }
    }
}