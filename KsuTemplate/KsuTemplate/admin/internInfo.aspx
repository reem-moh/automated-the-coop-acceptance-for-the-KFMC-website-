<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="internInfo.aspx.cs" Inherits="KsuTemplate.admin.internInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    
<div>

    <table align="center" class="nav-justified">
        <tr>
            <td style="width: 324px; font-size: medium;" class="text-center"><strong>Templates</strong></td>
            <td>
                <asp:RadioButtonList ID="rbnForms" runat="server" RepeatDirection="Horizontal" style="margin-left: 0px">
                    <asp:ListItem Value="1">Effective Date Notice Form</asp:ListItem> 
                    <asp:ListItem Value="2">Training Plan Form</asp:ListItem>
                    <asp:ListItem Value="3">Trainee&#39;s Attendance Form</asp:ListItem>
                    <asp:ListItem Value="4">All</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <br />
                <asp:GridView ID="gvInternInfo" runat="server">
                </asp:GridView>
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnExportToWord" runat="server" BackColor="#2E5882" ForeColor="White" Height="38px" Text="Export to Word" Width="109px" />
                <asp:Button ID="btnExportToPdf" runat="server" BackColor="#2E5882" ForeColor="White" Height="38px" Text="Export to pdf" Width="109px" />
            </td>
        </tr>
    </table>

</div>

</asp:Content>
