using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp.SamplePages
{
    public partial class BasicControls : System.Web.UI.Page
    {
        //global variable available to the entire page and will
        //  tempoarily represent data from the database
        public static List<DDLClass> DataCollection;
        protected void Page_Load(object sender, EventArgs e)
        {
            //this event will happen EACH and EVERY time your page is executed
            //this event will happen BEFORE ANY of YOUR control events happen
            //this is a great place to intialize items (controls) that are common
            //    to many events and need to be done every time

            //example: old messages should be cleared out on every pass
            //         you can empty the MessageLabel control under each event
            //         OR do it once here for ALL events
            MessageLabel.Text = "";

            //this is a great place to do 1st time intialization of controls
            //(similar to the else side of the IsPost from Razor)
            if (!Page.IsPostBack)  //Page.IsPostBack == false
            {
                //load the DDL on the first pass
                //create a new instance of the DDLClass
                //create 4 entries for the collection
                //place the collection into the DDL
                DataCollection = new List<DDLClass>();
                DataCollection.Add(new DDLClass(1, "COMP1008"));
                DataCollection.Add(new DDLClass(2, "CPSC1517"));
                DataCollection.Add(new DDLClass(3, "DMIT1508"));
                DataCollection.Add(new DDLClass(4, "DMIT2018"));

                //SORT the data collection for the DDL by course name
                //syntax: CollectionName.Sort((x,y) => x.fieldname.CompareTo(y.namefield))
                //collection name is where your List<t> resides 
                //(x,y) represent and TWO values (records) in your collection at any point in time
                // =>(lamda) can be thought of as "do the following to x and y"
                // our delgate for => is comparing x and y on fieldname
                //x compare to y is an ascending sort
                //y compare to x is an descending sort
                DataCollection.Sort((x, y) => x.DisplayField.CompareTo(y.DisplayField));


                //steps in loading your DDL
                //A) Assign the datasource to the control
                CollectionChoiceList.DataSource = DataCollection;
                //B) Indicate the display field to the control
                //<option value=valuefield>DisplayField</option>
                CollectionChoiceList.DataTextField = "DisplayField"; //nonobject style
                //C) Indicate the value field to the control
                CollectionChoiceList.DataValueField = nameof(DDLClass.ValueField);//object style
                //D) Physically bind the data to the control
                CollectionChoiceList.DataBind();

                //Optional promptline
                CollectionChoiceList.Items.Insert(0,"select...");
            }
        }

        protected void SubmitNumberChoice_Click(object sender, EventArgs e)
        {
            MessageLabel.Text = "you pressed the button Submit";
            //to grab the contents of a control will DEPEND on the control access type
            // for TextBox, Label, Literal use .Text
            // for Lists (RadioButtonList, DropDownList) you may use
            //  .SelectedValue, SelectedIndex, SelectedItem
            // for Checkbox use .Checked

            //for the most part ALL data from a control returns as a STRING
            //      Except for boolean type controls 

            //since the control is on the "right" side of an assignment statement
            // the object instance uses the GET
            string submitchoice = NumberChoice.Text;

            if (string.IsNullOrEmpty(submitchoice))
            {
                //"LEFT" side uses the properties of SET
                MessageLabel.Text = "you did not enter a value for your program choice";
                ResetFields();
           
            }
            else
            {
                //you can set the RadioButtonList choice by either using 
                // .SelectedValue OR .SelectedIndex OR .SelectedItem
                //It is best to use .SelectedValue
                ChoiceList.SelectedValue = submitchoice;

                //place a checkmark in the checkbox IF the chosen course 
                //  is a program
                if (submitchoice.Equals("2") || submitchoice.Equals("4"))
                {
                    ProgrammingCourseActive.Checked = true;
                    AlterLabel.ForeColor = System.Drawing.Color.BlueViolet;
                }
                else
                {
                    ProgrammingCourseActive.Checked = false;
                    AlterLabel.ForeColor = System.Drawing.Color.PaleVioletRed;
                }

                //DDL can be positioned using 
                //  .SelectedValue OR .SelectedIndex OR .SelectedItems
                //It is BEST to use .SelectedValue
                CollectionChoiceList.SelectedValue = submitchoice;

                //demostration of what is obtained by the different .Selected-blahblah-
                // .SelectedValue returns the value of the DataValueField
                // .SelectedIndex returns the index value of the selected row
                // . SelectedItem returns the value of the DisplayText
                DisplayDataRO.Text = CollectionChoiceList.SelectedItem.Text
                    + " at index " + CollectionChoiceList.SelectedIndex
                    + " having a value of " + CollectionChoiceList.SelectedValue;
            }
        }

        protected void ColectionSubmit_Click(object sender, EventArgs e)
        {
            MessageLabel.Text = "You pressed the link button Selection Submit";
        }

        protected void ResetFields()
        {
            DisplayDataRO.Text = "";
            ProgrammingCourseActive.Checked = false;
            ChoiceList.ClearSelection();
            //ChoiceList.SelectedIndex = -1; //This is an optional way of deselecting
            CollectionChoiceList.ClearSelection();
            AlterLabel.ForeColor = System.Drawing.Color.Black;
        }
    }
}