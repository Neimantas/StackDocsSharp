<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TableData.aspx.cs" Inherits="StackDocsSharp.TableData" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainTable" runat="server">
    

   

    <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem ID="lang1">Java</asp:ListItem>
        <asp:ListItem ID="lang2">Python</asp:ListItem>
        <asp:ListItem ID="lang3">JavaScript</asp:ListItem>
        <asp:ListItem ID="lang4">C#</asp:ListItem>
        <asp:ListItem ID="lang5">Ruby</asp:ListItem>
        <asp:ListItem ID="lang6">CSS</asp:ListItem>
        <asp:ListItem ID="lang7">R#</asp:ListItem>
</asp:DropDownList>
    <asp:TextBox ID="text1" runat="server"> </asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="Button" style="margin-left: 82" Width="106px" OnClick="Button1_Click" />

    <asp:Table ID="Table1" runat="server"></asp:Table>
    <asp:Label ID="tabel1" runat="server" Text="Label">Test</asp:Label>
    <asp:Button  runat="server" OnClick="Back_Click"  Text="Back"/>
    <asp:Button  runat="server" OnClick="Unnamed_Click" Text="More Info" />
  
</asp:Content>
