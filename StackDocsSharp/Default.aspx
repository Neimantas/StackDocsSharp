﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="StackDocsSharp._Default" %>

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
    <input id="Text1" type="text" style="width: 348px; height: 20px" />
    <asp:Button ID="Button1" runat="server" Text="Button" style="margin-left: 82" Width="106px" OnClick="Button1_Click" />
        
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
</asp:Content>
