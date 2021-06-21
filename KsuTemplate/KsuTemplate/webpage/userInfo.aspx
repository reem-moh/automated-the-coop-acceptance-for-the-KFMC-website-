<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="userInfo.aspx.cs" Inherits="KsuTemplate.webpage.userInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <br />


    <table class="nav-justified">
        <tr>
            <td colspan="4" style="text-align: center"> Intern Information</td>
        </tr>
        <tr>
            <td style="text-align: center">Intern name:</td>
            <td style="height: 22px">
                <asp:TextBox ID="txtIntern" runat="server"></asp:TextBox>
            </td>
            <td style="text-align: center">Intern Id:</td>
            <td>
                <asp:TextBox ID="txtId" runat="server" TextMode="Number"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">Mobile Number:</td>
            <td>
                <asp:TextBox ID="txtMobileNum" runat="server" TextMode="Phone"></asp:TextBox>
            </td>
            <td style="text-align: center; height: 22px;">Email :</td>
            <td style="height: 22px">
                <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>
            </td>
        </tr>
        
        <tr>
            <td style="text-align: center">University name:</td>
            <td>
                <asp:TextBox ID="txtUni" runat="server">King Saud University</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: center; height: 22px;">Major:</td>
            <td style="height: 22px">
                <asp:DropDownList ID="ddlMajor" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">Track:</td>
            <td>
                <asp:RadioButton ID="rbnTrack" runat="server" Text="Yes" GroupName="Group1" />
            </td>
        </tr>

        <tr>
            <td style="text-align: center; height: 22px;">Start Date :</td>
            <td style="height: 22px">
                <asp:TextBox ID="txtSDate" runat="server" TextMode="Date"></asp:TextBox>
            </td>
            <td style="text-align: center; height: 22px;">End Date :</td>
            <td style="height: 22px">
                <asp:TextBox ID="txtEDate" runat="server" TextMode="Month"></asp:TextBox>
            </td>
        </tr>

 

        <tr>
            <td style="width: 176px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
