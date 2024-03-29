﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="KsuTemplate._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>King Fahad Medical City Forms </h1>
        <p class="lead">The easiest way to fill your needs form!</p>
        <asp:LoginView ID="HeadLoginView" runat="server" EnableViewState="false">
            <AnonymousTemplate>
                <br>
                </br>
                <p>
                    <a href="Account/Login.aspx" class="btn btn-primary btn-lg">Log In</a>
                    <a href="Account/Registration.aspx" class="btn btn-primary btn-lg">Register</a>
                </p>
            </AnonymousTemplate>
            <LoggedInTemplate>
                <br />
                <p class="lead"> Welcome 
                
                    <asp:LoginName ID="HeadLoginName" runat="server" />
                </p>
                
                <asp:LoginStatus class="btn btn-primary btn-lg" runat="server" LogoutAction="Redirect" LogoutText="Log Out"
                 LogoutPageUrl="~/default.aspx" />
            </LoggedInTemplate>
        </asp:LoginView>


        <asp:Button ID="btnUserInfo" class="btn btn-primary btn-lg" runat="server" Text="Profile" OnClick="btnUserInfo_Click" />
        
        <asp:Button ID="btnTemplate" class="btn btn-primary btn-lg" runat="server" Text="Template" OnClick="btnTemplate_Click" />

        <asp:Button ID="btnShowRoles" class="btn btn-primary btn-lg" runat="server" Text="Show Roles" OnClick="btnShowRoles_Click" />

        <asp:Button ID="btnInternInfo" class="btn btn-primary btn-lg" runat="server" Text="Intern Information" OnClick="btnInternInfo_Click" />

        <asp:Button ID="btnTrainingPlan" class="btn btn-primary btn-lg" runat="server" Text="Training Plan" OnClick="btnTrainingPlan_Click" />

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
