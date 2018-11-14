<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Topics.aspx.cs" Inherits="StackDocsSharp.Topics" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="container" id="cont1">
        <h1 class="bd-title" id="cont2">
            <asp:Label ID="TopicTitle" runat="server" /></h1>
        <div class="row">
            <!-- Button trigger modal -->
            <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#Examples">Examples</button>

            <!-- Modal -->
            <div id="Examples" class="modal fade" role="dialog">
                <div class="modal-dialog">

                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title">Examples</h4>
                        </div>
                        <div class="modal-body">
                            <p>Some text in the modal.</p>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        </div>
                    </div>

                </div>
            </div>
        </div>


    </div>

    <div class="row">
        <asp:GridView ID="gwtopics" runat="server" DataKeyNames="ID" AutoGenerateColumns="false" GridLines="None">
            <Columns>
                <asp:BoundField DataField="IntroductionHTML" HtmlEncode="false" />
            </Columns>
        </asp:GridView>
    </div>

    <div class="row">
        <asp:Label ID="lblHello" runat="server" />
    </div>

    <div class="row">
        <asp:Label ID="lblParameters" runat="server" />
    </div>

    <div class="row">
        <asp:Label ID="lblRemarks" runat="server" />
    </div>

    <div class="row">
        <asp:Label ID="lblSyntax" runat="server" />
    </div>


</asp:Content>
