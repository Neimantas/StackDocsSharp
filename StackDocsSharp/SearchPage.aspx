<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchPage.aspx.cs" Inherits="StackDocsSharp.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="row">
        <h1>Search</h1>
        <p>
        <asp:TextBox ID ="txtSearch" runat="server" />
        <asp:Button ID="btnSearch" Text="Search" runat="server" />
        </p>
    </div>
    <div class="row">
        <asp:GridView ID="gwSearch" AllowPaging="true" AllowCustomPaging="true" PageSize="20" OnPageIndexChanging="GwSearch_PageIndexChanging"
        runat="server" DataKeyNames="DocTagID" AutoGenerateColumns="false" GridLines="None">
            <PagerSettings Mode="Numeric" PageButtonCount="5" FirstPageText="First" LastPageText="Last" />
            <Columns>
                <asp:HyperLinkField DataTextField="title" HeaderText="Topics" DataNavigateUrlFormatString="~/Topics.aspx?Title={0}&DocTagID={1}&Id={2}" DataNavigateUrlFields="Title,DocTagID,Id" />
                <asp:BoundField DataField="text" HeaderText="" />
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>