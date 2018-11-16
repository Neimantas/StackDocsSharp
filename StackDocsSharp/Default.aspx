<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="StackDocsSharp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
    <asp:Button ID="Button1" runat="server" Text="Search" style="margin-left: 82" Width="106px" OnClick="Button1_Click" />

    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    
    <div class="row">
            <asp:GridView ID="gwtopics" runat="server" DataKeyNames="DocTagID" AutoGenerateColumns="false" GridLines="None">
                <Columns>
                    <asp:HyperLinkField DataTextField="Title" HeaderText="Topics" DataNavigateUrlFormatString="~/Topics.aspx?Title={0}&DocTagID={1}&Id={2}" DataNavigateUrlFields="Title,DocTagID,Id" />
                </Columns>
            </asp:GridView>
        </div>

</asp:Content> 
