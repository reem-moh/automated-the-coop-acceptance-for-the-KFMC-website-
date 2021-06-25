<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="trainingPlan.aspx.cs" Inherits="KsuTemplate.admin.trainingPlan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h2 class="text-center"><strong>Training Plan</strong></h2>

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <table class="nav-justified">
            <tr>
                <td class="text-right"><strong>Summary of Training Plan</strong></td>
                <td class="text-left">
                    <br />
                    <asp:TextBox ID="TextBox1" runat="server" BorderColor="#EEEEEE" BorderStyle="Solid" Height="125px" Width="400px"></asp:TextBox>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="text-right"><strong>Expected Training Outcomes</strong></td>
                <td class="text-left">
                    <br />
                    <asp:TextBox ID="TextBox2" runat="server" BorderColor="#EEEEEE" BorderStyle="Solid" Height="125px" Width="400px"></asp:TextBox>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="text-center" colspan="2">
                    <br />
                    <asp:Button ID="btnSubmit" runat="server" BackColor="#1C5085" CssClass="btn btn-primary btn-lg" Text="Submit" Width="147px" />
                </td>
            </tr>
        </table>

        </div>
</asp:Content>
