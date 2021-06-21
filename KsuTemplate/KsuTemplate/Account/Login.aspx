<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="KsuTemplate.Account.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
    <br />
</p>
    <br />
    <asp:Login ID="Login1" runat="server" Height="227px" Width="582px">
    </asp:Login>
    <asp:Label ID="lblReg" runat="server" Text="Don't have an account?"></asp:Label>
    <asp:Label ID="lblReg1" runat="server" Text=""><a runat="server" href="~/Account/Registration">Register</a></asp:Label>
    <br />
    <br />
</asp:Content>
