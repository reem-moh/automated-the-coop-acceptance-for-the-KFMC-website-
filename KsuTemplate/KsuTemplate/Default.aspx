<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="KsuTemplate._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>King Fahad Medical City </h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <asp:LoginView ID="HeadLoginView" runat="server" EnableViewState="false">
            <AnonymousTemplate>
                </br>
                <p>
                    <a href="Account/Login.aspx" class="btn btn-primary btn-lg">Log In</a>
                    <a href="Account/Registration.aspx" class="btn btn-primary btn-lg">Register</a>
                </p>
            </AnonymousTemplate>
            <LoggedInTemplate>
                <p class="lead"> Welcome 
                
                    <asp:LoginName ID="HeadLoginName" runat="server" />
                </p>
                </br>
                </br>
                <a href="webpage/userInfo.aspx" class="btn btn-primary btn-lg">Profile</a>
                <a href="webpage/template.aspx" class="btn btn-primary btn-lg">Template</a>
                <asp:LoginStatus class="btn btn-primary btn-lg" runat="server" LogoutAction="Redirect" LogoutText="Log Out"
                 LogoutPageUrl="~/default.aspx" />
            </LoggedInTemplate>
        </asp:LoginView>



    </div>
    <!--
    <div class="row">
        <div class="col-md-4">
            <h2>Getting started</h2>
            <p>
                ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Get more libraries</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Web Hosting</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
    </div>
    -->
</asp:Content>
