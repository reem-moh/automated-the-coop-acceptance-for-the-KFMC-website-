 <%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="KsuTemplate.admin._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <style>
h1 {text-align: center;}
p {text-align: center;}
div {text-align: center;}
</style>
    <br /> 
    <br /> 
    <div>
    <pre>
    &nbsp
    
        <a runat="server" href="~/admin/internInfo" class="btn btn-primary btn-lg">Interns Informations</a>        <a runat="server" href="~/admin/trainingPlan" class="btn btn-primary btn-lg">Training Plan</a>

   </pre>
        </div>
</asp:Content>
