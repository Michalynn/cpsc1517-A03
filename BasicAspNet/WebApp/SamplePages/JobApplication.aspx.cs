﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class JobApplication : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Message.Text = "";
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

        }//EOSubmit
    }
}