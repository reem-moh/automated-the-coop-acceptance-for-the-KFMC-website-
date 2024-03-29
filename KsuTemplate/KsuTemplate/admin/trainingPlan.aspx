﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="trainingPlan.aspx.cs" Inherits="KsuTemplate.admin.trainingPlan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron" style="text-align: center">
        <asp:Label ID="lblOutput" runat="server" ForeColor="#339966" style="font-size: large"></asp:Label>

        <h2 class="text-center"><strong>Training Plan</strong></h2>
        <p class="text-center">&nbsp;</p>

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <table class="nav-justified">
            <tr>
                <td class="text-right"><strong>Summary of Training Plan</strong></td>
                <td class="text-left">
                    <br />
                    <asp:TextBox ID="txtSummary" runat="server" BorderColor="#EEEEEE" Height="125px" TextMode="MultiLine" Width="400px"></asp:TextBox>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="text-right"><strong>Expected Training Outcomes</strong></td>
                <td class="text-left">
                    <br />
                    <asp:TextBox ID="txtOutcomes" runat="server" BorderColor="#EEEEEE" Height="125px" TextMode="MultiLine" Width="400px"></asp:TextBox>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="text-center" colspan="2">
                    <br />
                    <asp:Button ID="btnSubmit" runat="server" BackColor="#1C5085" CssClass="btn btn-primary btn-lg" Text="Submit" Width="147px" OnClick="btnSubmit_Click1" />
                </td>
            </tr>
        </table>

        </div>
</asp:Content>
