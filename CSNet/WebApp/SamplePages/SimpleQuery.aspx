<%@ Page Title="Simple Query" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SimpleQuery.aspx.cs" Inherits="WebApp.SamplePages.SimpleQuery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Simple Query: PKey Record Lookup</h1>
    <div class="row">
        <div class="col-md-6">
            <div class="offset-1">
                <asp:Label ID="Label1" runat="server" Text="Enter a RegionID: "></asp:Label>&nbsp&nbsp
                <asp:TextBox ID="RegionIdArg" runat="server"></asp:TextBox>
                <asp:Button ID="Fetch" runat="server" Text="Fetch" OnClick="Fetch_Click" />
                <br /><br />
                 <asp:Label ID="MessageLabel" runat="server"></asp:Label>
               
            </div>
            <div class="col-md-6">
                <h5>Output Results</h5>
                 <asp:Label ID="Label2" runat="server" Text="RegionID: "></asp:Label>
                 <asp:Label ID="RegionID" runat="server"></asp:Label>
                <br /><br />
                <asp:Label ID="Label3" runat="server" Text="Description: "></asp:Label>
                <asp:Label ID="RegionDescription" runat="server"></asp:Label>
            </div>
        </div>
    </div>







</asp:Content>
