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
    <a runat="server" href="~/admin/showRoles" class="btn btn-primary btn-lg">show Roles </a> <a runat="server" href="~/admin/changePassword" class="btn btn-primary btn-lg">Change Password</a> <a runat="server" href="~/admin/passwordRecovery" class="btn btn-primary btn-lg">Password Recovery</a> <a runat="server" href="~/admin/register" class="btn btn-primary btn-lg">Register</a> <a runat="server" href="~/admin/internInfo" class="btn btn-primary btn-lg">Interns</a>

   </pre>
        </div>
</asp:Content>
