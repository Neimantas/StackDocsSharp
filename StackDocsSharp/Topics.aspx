<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Topics.aspx.cs" Inherits="StackDocsSharp.Topics" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="container" id="cont1">
        <h1 class="bd-title" id="cont2">
            <asp:Label ID="TopicTitle" runat="server" /></h1>
        <div class="row">
            <!-- Button trigger modal -->
            <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#Examples">
                Examples
            </button>
         </div>
    
            <!-- Modal -->
            <div class="modal fade" id="ExamplesModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLongTitle" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLongTitle">
                                <asp:Label ID="Examples" runat="server" /></h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body" id="exampleBody">
                            <ul id="exampleList"></ul>
                            <%--<script>
                                function addExamples() {
                                    //for @topics.exampleCount add new <a href= @Examples.ExampleId> etc 
                                    let listExample = document.createElement("ul");
                                    let bodyExample = document.getElementById("exampleBody");
                                    bodyExample.AppendChild(listExample);
                                    for (let i = 0; i <@Topics.ExampleCount; i++) {
                                        let exampleLink = document.createElement("a");
                                        exampleLink.text = @Examples[i].Title;
                                        exampleLink.href = "javascript:setexample(i)";
                                        listExample.appendChild(exampleLink);
                                    }
                                }
                                function setexample(i) {
                                    let bodyExample = document.getElementById("exampleBody")
                                    bodyExample.text = @Examples[i].BodyHtml;
                                }
                            </script>--%>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
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
                      
            <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js"></script>
</asp:Content>
