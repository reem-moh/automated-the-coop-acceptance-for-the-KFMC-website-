<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="template.aspx.cs" Inherits="KsuTemplate.webpage.template" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <asp:DropDownList ID="ddlTemplate" runat="server" AutoPostBack="True">
        </asp:DropDownList>
    </p>
    <p>
        <asp:Label ID="lblData" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblExport" runat="server" Text="Export to:"></asp:Label>
        <asp:Button ID="btnDoc" runat="server" OnClick="btnDoc_Click" Text="Word Document" />
        <asp:Button ID="btnPdf" runat="server" OnClick="btnPdf_Click" Text=" pdf" />
        <br />
    </p>
    
</asp:Content>
