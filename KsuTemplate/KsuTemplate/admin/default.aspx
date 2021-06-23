<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="KsuTemplate.admin._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <ul class="">
        <br /> <br />
          <li><a runat="server" href="~/admin/showRoles">show Roles </a></li>
        <li><a runat="server" href="~/admin/changePassword">Change Password</a></li>
        <li><a runat="server" href="~/admin/passwordRecovery">Password Recovery</a></li>
        <li><a runat="server" href="~/admin/register">Register</a></li>
       <li><a runat="server" href="~/admin/internInfo">Interns</a></li>

    </ul>

</asp:Content>
