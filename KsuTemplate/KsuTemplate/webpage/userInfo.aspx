<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="userInfo.aspx.cs" Inherits="KsuTemplate.webpage.userInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <br />


    <br />
    <asp:Label ID="lblInfo" runat="server"></asp:Label>


    <table class="nav-justified">
        <tr>
            <td colspan="4" style="text-align: center"> Intern Information</td>
        </tr>
        <tr>
            <td style="text-align: center">Intern name:</td>
            <td style="height: 22px">
                <asp:TextBox ID="txtIntern" runat="server"></asp:TextBox>
            </td>
            <td style="text-align: center">Intern University Id:</td>
            <td>
                <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">Mobile Number:</td>
            <td>
                <asp:TextBox ID="txtMobileNum" runat="server"></asp:TextBox>
            </td>
            <td style="text-align: center">Telephone :</td>
            <td>
                <asp:TextBox ID="txtTelephone" runat="server"></asp:TextBox>
            </td>
            
        </tr>
        <tr>
            
            <td style="text-align: center; height: 22px;">Email :</td>
            <td style="height: 22px">
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </td>
            
        </tr>
        
        <tr>
            <td style="text-align: center">University name:</td>
            <td>
                <asp:TextBox ID="txtUni" runat="server" Enabled="False">King Saud University</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: center; height: 22px;">Major:</td>
            <td style="height: 22px">
                <asp:DropDownList ID="ddlMajor" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMajor_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">Track:</td>
            <td>
                <asp:DropDownList ID="ddlTrack" runat="server">
                </asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td colspan="4"; style="text-align: center; height: 22px; "> You need to follow this format YYYY-DD-MM</td>
            
        </tr>
        <tr>
            <td style="text-align: center; height: 22px;">Start Date :</td>
            <td style="height: 22px">
                <asp:TextBox ID="txtSDate" runat="server"></asp:TextBox>
            </td>
            <td style="text-align: center; height: 22px;">End Date :</td>
            <td style="height: 22px">
                <asp:TextBox ID="txtEDate" runat="server"></asp:TextBox>
            </td>
        </tr>

 

        <tr>
            <td style="width: 176px">&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>


    <br />
                <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" />


</asp:Content>
