<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="StackDocsSharp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem ID="lang1">Java</asp:ListItem>
        <asp:ListItem ID="lang2">Python</asp:ListItem>
        <asp:ListItem ID="lang3">JavaScript</asp:ListItem>
        <asp:ListItem ID="lang4">C#</asp:ListItem>
        <asp:ListItem ID="lang5">Ruby</asp:ListItem>
        <asp:ListItem ID="lang6">CSS</asp:ListItem>
        <asp:ListItem ID="lang7">R#</asp:ListItem>
</asp:DropDownList>
    <asp:TextBox ID="wordas" runat="server" type="text" style="width: 348px; height: 20px" />
    <asp:Button ID="Button1" runat="server" Text="Button" style="margin-left: 82" Width="106px" OnClick="Button1_Click" />
        
    
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    

    <asp:Table id="tabMarkup" runat="server" Visible="false" >
        <asp:TableRow HorizontalAlign="Center"  
                      TableSection="TableHeader"
                  BackColor="#FFFF80" 
                  Font-Bold="True">
          <asp:TableCell Width="100px" Text="Language"> 
          </asp:TableCell>
          <asp:TableCell Width="100px" Text="Search Result">
          </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow HorizontalAlign="Center" 
                  BackColor="#FFFFC0">
          <asp:TableCell ID="langText" runat="server" Text=""></asp:TableCell>
          <asp:TableCell ID="searchText" Text=""></asp:TableCell>
        </asp:TableRow>
        <%--<asp:TableRow HorizontalAlign="Center"
                  BackColor="#FFFFC0">
          <asp:TableCell Text="45.3"></asp:TableCell>
          <asp:TableCell Text="16.5"></asp:TableCell>
        </asp:TableRow>--%>
      </asp:Table>
    
    
</asp:Content> 
