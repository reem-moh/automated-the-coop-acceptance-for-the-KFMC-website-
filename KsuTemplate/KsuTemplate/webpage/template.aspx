<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="template.aspx.cs" Inherits="KsuTemplate.webpage.template" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="CSS/contactStyleSheet1.css" rel="stylesheet" />

    <h3 class="text-center">
            <asp:Label ID="lblOutput" runat="server" ForeColor="#339966"></asp:Label>
    </h3>
    <br />

    

    <div  class="jumbotron">
        <div class="wrap-contact100" style="text-align: center">
            <p class="text-center">
                <h2  class="text-center">Intern Templates</h2>
    
                <br />
                <br />

                <asp:Label ID="lblUni" runat="server" Text="University:"></asp:Label>
                <asp:DropDownList ID="ddlUni" runat="server" BorderColor="#E4E4E4" Height="30px" Width="220px" BorderStyle="Solid" AutoPostBack="True" OnSelectedIndexChanged="ddlUni_SelectedIndexChanged">
                </asp:DropDownList>
                <br />
                <br />
                <br />
                <asp:Label ID="lblTemplate" runat="server" Text="Template:"></asp:Label>
                <asp:DropDownList ID="ddlTemplate" runat="server" AutoPostBack="True" BorderColor="#E4E4E4" Height="30px" Width="220px" BorderStyle="Solid">
                </asp:DropDownList>
            </p>
            <p class="text-center">
                <asp:Label ID="lblData" runat="server"></asp:Label>
                <br />
                <br />
                <asp:Label ID="lblExport" runat="server" Text="Export to:"></asp:Label>
                <asp:Button ID="btnDoc" runat="server" OnClick="btnDoc_Click" Text="Word Document" BackColor="#2E5882" ForeColor="White" Height="42px" Width="175px" BorderColor="#2E5882" CssClass="btn btn-primary btn-lg" />
                <asp:Button ID="btnPdf" runat="server" OnClick="btnPdf_Click" Text=" pdf" BackColor="#2E5882" ForeColor="White" Height="42px" Width="175px" BorderColor="#2E5882" CssClass="btn btn-primary btn-lg" />
                <br />
            </p>
        </div>
    </div>
</asp:Content>
