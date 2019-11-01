<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ContestEntry.aspx.cs" Inherits="WebApp.SamplePages.ContestEntry" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header">
        <h1>Contest Entry</h1>
    </div>

    <div class="row col-md-12">
        <div class="alert alert-info">
            <blockquote style="font-style: italic">
                This illustrates some simple controls to fill out an entry form for a contest. 
                This form will use basic bootstrap formatting and illustrate Validation.
            </blockquote>
            <p>
                Please fill out the following form to enter the contest. This contest is only available to residents in Western Canada.
            </p>

        </div>
    </div>
  
    <%-- Validation Controls --%>
    <asp:RequiredFieldValidator ID="RequiredFirstName" runat="server" 
        ErrorMessage="First name is required" Display ="None"
         ControlToValidate="FirstName" ForeColor="#990000"
         SetFocusOnError="true">
    </asp:RequiredFieldValidator>

    <asp:RequiredFieldValidator ID="RequiredLastName" runat="server" 
        ErrorMessage="Last name is required" Display ="None"
         ControlToValidate="LastName" ForeColor="#990000"
         SetFocusOnError="true">
    </asp:RequiredFieldValidator>

    <asp:RequiredFieldValidator ID="RequiredStreetAddress1" runat="server" 
        ErrorMessage="Street Address1 is required" Display ="None"
         ControlToValidate="StreetAddress1" ForeColor="#990000"
         SetFocusOnError="true">
    </asp:RequiredFieldValidator>

    <asp:RequiredFieldValidator ID="RequiredCity" runat="server" 
        ErrorMessage="City is required" Display ="None"
         ControlToValidate="City" ForeColor="#990000"
         SetFocusOnError="true">
    </asp:RequiredFieldValidator>

        <asp:RequiredFieldValidator ID="RequiredPostalCode" runat="server" 
        ErrorMessage="Postal Code is required" Display ="None"
         ControlToValidate="PostalCode" ForeColor="#990000"
         SetFocusOnError="true">
    </asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegExPostalCode" runat="server" 
        ErrorMessage="Invaild postal code format (T5L0G0)" Display="None" 
         ControlToValidate="PostalCode"  ForeColor="#860dff"
         SetFocusOnError="true"
        ValidationExpression="[a-zA-Z][0-9][a-zA-Z][0-9][a-zA-Z][0-9]">
    </asp:RegularExpressionValidator>

        <asp:RequiredFieldValidator ID="RequiredEmailAddress" runat="server" 
        ErrorMessage="Email is required" Display ="None"
         ControlToValidate="EmailAddress" ForeColor="#990000"
         SetFocusOnError="true"
         ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$">
    </asp:RequiredFieldValidator>

      <asp:RegularExpressionValidator ID="RegExEmailAddress" runat="server" 
        ErrorMessage="Invaild postal code format (T5L0G0)" Display="None" 
         ControlToValidate="PostalCode"  ForeColor="#860dff"
         SetFocusOnError="true">
    </asp:RegularExpressionValidator>

        <asp:RequiredFieldValidator ID="RequiredCheckAnswer" runat="server" 
        ErrorMessage="Skill test answer is required is required" Display ="None"
         ControlToValidate="CheckAnswer" ForeColor="#990000"
         SetFocusOnError="true">
    </asp:RequiredFieldValidator>

    <%--<asp:CompareValidator ID="CompareCheckAnswer" runat="server" 
        ErrorMessage="DataType validation" Display="None"
        ForeColor="#990000" SetFocusOnError="true"
        ControlToValidate="CheckAnswer" Operator="DataTypeCheck" Type="Integer">

    </asp:CompareValidator>--%>
    <asp:CompareValidator ID="CompareCheckAnswer" runat="server" 
        ErrorMessage="Static Value validation" Display="None"
        ForeColor="#990000" SetFocusOnError="true"
        ControlToValidate="CheckAnswer" Operator="Equal" ValueToCompare="15"
           Type="Integer"> 
    </asp:CompareValidator>

   <%--  <asp:CompareValidator ID="CompareCheckAnswer" runat="server" 
        ErrorMessage="Compare to another field validation" Display="None"
        ForeColor="#990000" SetFocusOnError="true"
        ControlToValidate="CheckAnswer" Operator="Equal"
        ControlToCompare="StreetAddress2" Type="Integer"> 
    </asp:CompareValidator>--%>
    <asp:RangeValidator ID="RangeSample" runat="server" 
        ErrorMessage="errormessage" Display="None" ForeColor="#990000" SetFocusOnError="true"
        ControlToValidate="StreetAddress2" MinimumValue="0" MaximumValue="100" 
        Type="Integer" />
    <%-- Display Validation Errors --%>
    <div class="row">
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
             HeaderText="Please correct the following concerns and resubmit"
             CssClass="alert alert-danger" />
    </div>
    <div class="row">
        <div class ="col-md-6">
            <fieldset class="form-horizontal">
                <legend>Application Form</legend>

                <asp:Label ID="Label1" runat="server" Text="First Name"
                     AssociatedControlID="FirstName"></asp:Label>
                <asp:TextBox ID="FirstName" runat="server" 
                    ToolTip="Enter your first name." MaxLength="25"></asp:TextBox> 
                  
                 <asp:Label ID="Label6" runat="server" Text="Last Name"
                     AssociatedControlID="LastName"></asp:Label>
                <asp:TextBox ID="LastName" runat="server" 
                    ToolTip="Enter your last name." MaxLength="25"></asp:TextBox> 
                        
                <asp:Label ID="Label3" runat="server" Text="Street Address 1"
                     AssociatedControlID="StreetAddress1"></asp:Label>
                <asp:TextBox ID="StreetAddress1" runat="server" 
                    ToolTip="Enter your street address." MaxLength="75"></asp:TextBox> 
                  
                  <asp:Label ID="Label7" runat="server" Text="Street Address 2"
                     AssociatedControlID="StreetAddress2"></asp:Label>
                <asp:TextBox ID="StreetAddress2" runat="server" 
                    ToolTip="Enter your additional street address." MaxLength="75"></asp:TextBox> 
                  <br />
                 <asp:Label ID="Label8" runat="server" Text="City"
                     AssociatedControlID="City"></asp:Label>
                <asp:TextBox ID="City" runat="server" 
                    ToolTip="Enter your City name" MaxLength="50"></asp:TextBox> 
                  
                 <asp:Label ID="Label9" runat="server" Text="Province"
                     AssociatedControlID="Province"></asp:Label>
                <asp:DropDownList ID="Province" runat="server" Width="75px">
                    <asp:ListItem Value="AB" Text="AB"></asp:ListItem>
                     <asp:ListItem Value="BC" Text="BC"></asp:ListItem>
                     <asp:ListItem Value="MN" Text="MN"></asp:ListItem>
                     <asp:ListItem Value="SK" Text="SK"></asp:ListItem>
                </asp:DropDownList>
                  
                 <asp:Label ID="Label10" runat="server" Text="Postal Code"
                     AssociatedControlID="PostalCode"></asp:Label>
                <asp:TextBox ID="PostalCode" runat="server" 
                    ToolTip="Enter your postal code"  MaxLength="6"></asp:TextBox> 
                 
                <asp:Label ID="Label2" runat="server" Text="Email"
                     AssociatedControlID="EmailAddress"></asp:Label>
                <asp:TextBox ID="EmailAddress" runat="server" 
                    ToolTip="Enter your email address"
                     TextMode="Email"></asp:TextBox> 
                  
              </fieldset>   
           <p>Note: You must agree to the contest terms in order to be entered.
               <br />
               <asp:CheckBox ID="Terms" runat="server" Text="I agree to the terms of the contest" />
           </p>

            <p>
                Enter your answer to the following calculation instructions:<br />
                Multiply 15 times 6<br />
                Add 240<br />
                Divide by 11<br />
                Subtract 15<br />
                <asp:TextBox ID="CheckAnswer" runat="server" ></asp:TextBox>
            </p>
        </div>
        <div class="col-md-6">   
            <div class="col-md-offset-2">
                <p>
                    <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" />&nbsp;&nbsp;
                    <asp:Button ID="Clear" runat="server" Text="Clear" CausesValidation="true" OnClick="Clear_Click"  />
                </p>
                <asp:Label ID="Message" runat="server" ></asp:Label><br />
                <asp:GridView ID="GridViewCEntry" runat="server"></asp:GridView>
            </div>
        </div>
    </div>
    <script src="../Scripts/bootwrap-freecode.js"></script>
</asp:Content>
