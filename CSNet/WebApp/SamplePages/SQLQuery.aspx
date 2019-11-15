<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SQLQuery.aspx.cs" Inherits="WebApp.SamplePages.SQLQuery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>SqlQuery: Secondary queries in BLL</h1>
    <div class="offset-2">
        <asp:Label ID="Label1" runat="server" Text="Select a Category:"></asp:Label>&nbsp&nbsp
        <asp:DropDownList ID="CategoryList" runat="server"></asp:DropDownList>&nbsp&nbsp
        <asp:Button ID="Fetch" runat="server" Text="Button" OnClick="Fetch_Click" />
        <br /><br />
        <asp:Label ID="MessageLabel" runat="server"></asp:Label>
        <br />
        <asp:GridView ID="ProductList" runat="server">


            <Columns>
                <asp:TemplateField HeaderText="ID">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>


                <asp:TemplateField HeaderText="Name">
                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="$">
                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                <ItemTemplate>
                    <%# string.Format("{0:0.00}") %>
                </ItemTemplate>
                    </asp:TemplateField>

                <asp:TemplateField HeaderText="Disc">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                No data to display
            </EmptyDataTemplate>
        </asp:GridView>
     </div>
</asp:Content>
