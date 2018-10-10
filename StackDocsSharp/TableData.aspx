<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TableData.aspx.cs" Inherits="StackDocsSharp.TableData" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainTable" runat="server">
    <asp:Table ID="Table1" runat="server"></asp:Table>
    <asp:Label ID="Label1" runat="server" Text="Label">Test</asp:Label>
    <asp:Button  runat="server" OnClick="Back_Click"  Text="Back"/>
    <asp:Button  runat="server" OnClick="Unnamed_Click" Text="More Info" />
   
</asp:Content>
