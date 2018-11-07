<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Topics.aspx.cs" Inherits="StackDocsSharp.Topics" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <%--<nav class="navbar navbar-expand-lg navbar-dark bg-dark">
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>
  <div class="collapse navbar-collapse" id="navbarNav">
    <ul class="navbar-nav">
      <li class="nav-item">
        <a class="nav-link" href="puslapis">Pagrindinis</a>
      </li>
    </ul>
  </div>
</nav>--%>
<div class="container" id="cont1">
	<h1 class="bd-title" id="cont2"><asp:Label ID="Topic" runat="server"/></h1>
	<div class="row">
		<!-- Button trigger modal -->
		<button type="button" class="btn btn-primary" data-toggle="modal" data-target="#Examples">
		  Examples
		</button>

		<!-- Modal -->
		<div class="modal fade" id="ExamplesModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLongTitle" aria-hidden="true">
		  <div class="modal-dialog" role="document">
			<div class="modal-content">
			  <div class="modal-header">
				<h5 class="modal-title" id="exampleModalLongTitle"><asp:Label ID="Examples" runat="server"/></h5>
				<button type="button" class="close" data-dismiss="modal" aria-label="Close">
				  <span aria-hidden="true">&times;</span>
				</button>
			  </div>
			  <div class="modal-body" id="exampleBody">
				<ul id="exampleList"></ul>
				<script>
					function addExamples(){
						//for @topics.exampleCount add new <a href= @Examples.ExampleId> etc 
						let listExample = document.createElement("ul");
						let bodyExample = document.getElementById("exampleBody");
						bodyExample.AppendChild(listExample);
						for(let i=0;i<@Topics.ExampleCount;i++){
							let exampleLink = document.createElement("a");
							exampleLink.text = @Examples[i].Title;
							exampleLink.href = "javascript:setexample(i)";
							listExample.appendChild(exampleLink);
						}
					}
					function setexample(i){
						let bodyExample = document.getElementById("exampleBody")
						bodyExample.text = @Examples[i].BodyHtml;
					}
				</script>
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
                    <asp:BoundField DataField="Title" HeaderText="Topics" />
                    <asp:BoundField DataField="IntroductionHtml" HeaderText="Intro" />
                </Columns>
            </asp:GridView>
        </div>
       
    <div class="row">
        @Topics.HelloWorldVersionsHtml
	</div>
	<div class="row">
		@Topics.IntroductionHtml
	</div>
	<div class="row">
		@Topics.ParametersHtml
	</div>
	<div class="row">
		@Topics.RemarksHtml
	</div>
	<div class="row">
		@Topics.SyntaxHtml
	</div>
</div>

   
       

 <!--<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" />-->
<!--<script type="text/javascript" src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>  -->
<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js"></script>
<!--<script type="text/javascript" src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js"></script> -->

</asp:Content>
