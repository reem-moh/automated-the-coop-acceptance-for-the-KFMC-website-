<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="internInfo.aspx.cs" Inherits="KsuTemplate.admin.internInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    
<div>

    <table align="center" class="nav-justified" style="width: 115%">
        <tr>
            <td style="width: 373px; font-size: medium;" class="text-center"><strong>Templates</strong></td>
            <td>
                <asp:RadioButtonList ID="rbnForms" runat="server" RepeatDirection="Horizontal" style="margin-left: 0px" Height="50px" OnSelectedIndexChanged="rbnForms_SelectedIndexChanged" Width="668px">
                    <asp:ListItem Value="1">Effective Date Notice Form</asp:ListItem> 
                    <asp:ListItem Value="2">Training Plan Form</asp:ListItem>
                    <asp:ListItem Value="3">Trainee&#39;s Attendance Form</asp:ListItem>
                    <asp:ListItem Value="4">All</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td style="width: 373px; font-size: medium; height: 183px;" class="text-left">
                <asp:Button ID="btnExportToWord" runat="server" BackColor="#2E5882" ForeColor="White" Height="49px" Text="Export to excel" Width="154px" CssClass="btn btn-primary btn-lg" OnClick="btnExportToWord_Click" /> <br />
                <br />
                <asp:Button ID="btnShowAllIntern" runat="server" BackColor="#2E5882" CssClass="btn btn-primary btn-lg" Height="49px" OnClick="btnShowAllIntern_Click" Text="Show All Interns" Width="154px" />
                <br />
            </td>
            <td style="height: 183px">
                <asp:GridView ID="gvInternInfo" runat="server">
                </asp:GridView>
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
        </tr>
    </table>

</div>

</asp:Content>
