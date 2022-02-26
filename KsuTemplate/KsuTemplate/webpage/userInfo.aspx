<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="userInfo.aspx.cs" Inherits="KsuTemplate.webpage.userInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <link href="CSS/contactStyleSheet1.css" rel="stylesheet" />

    <h3 class="text-center">
        <asp:Label ID="lblInfo" runat="server" ForeColor="#339966"></asp:Label>
    </h3>
    
    <div class="container-contact100 jumbotron">
        <div class="wrap-contact100" style="text-align: center">

            <h2 class="text-center">Intern Information</h2>
            <table class="nav-justified" style="height: 316px; width: 86%;">
                <tr>
                    <td class="text-center" style="width: 108px; height: 60px">Intern name:</td>
                    <td style="height: 40px">
                        <asp:TextBox ID="txtIntern" runat="server" BorderColor="#E4E4E4" Height="30px" Width="220px" BorderStyle="Solid"></asp:TextBox>
                    </td>
                    <td class="text-center" style="width: 108px; height: 60px">University Id:</td>
                    <td style="height: 40px">
                        <asp:TextBox ID="txtId" runat="server" BorderColor="#E4E4E4" Height="30px" Width="220px" BorderStyle="Solid"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="text-center" style="width: 108px; height: 60px">Mobile Number:</td>
                    <td style="height: 40px">
                        <asp:TextBox ID="txtMobileNum" runat="server" BorderColor="#E4E4E4" Height="30px" Width="220px" BorderStyle="Solid"></asp:TextBox>
                    </td>
                    <td class="text-center" style="width: 108px; height: 60px">Telephone :</td>
                    <td style="height: 40px">
                        <asp:TextBox ID="txtTelephone" runat="server" BorderColor="#E4E4E4" Height="30px" Width="220px" BorderStyle="Solid"></asp:TextBox>
                    </td>

                </tr>
                <tr>

                    <td class="text-center" style="width: 108px; height: 60px">Email :</td>
                    <td style="height: 40px">
                        <asp:TextBox ID="txtEmail" runat="server" BorderColor="#E4E4E4" Height="30px" Width="220px" BorderStyle="Solid"></asp:TextBox>
                    </td>

                </tr>

                <tr>
                    <td class="text-center" style="width: 108px; height: 60px">University name:</td>
                    <td style="height: 40px">
                        <asp:DropDownList ID="ddlUni" runat="server" AutoPostBack="True" BorderColor="#E4E4E4" Height="30px" Width="220px" BorderStyle="Solid">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="text-center" style="width: 108px; height: 60px">Major:</td>
                    <td style="height: 40px">
                        <asp:DropDownList ID="ddlMajor" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMajor_SelectedIndexChanged" BorderColor="#E4E4E4" Height="30px" Width="220px" BorderStyle="Solid">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="text-center" style="width: 108px; height: 60px">Track:</td>
                    <td style="height: 40px">
                        <asp:DropDownList ID="ddlTrack" runat="server" BorderColor="#E4E4E4" Height="30px" Width="220px" BorderStyle="Solid">
                        </asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td colspan="4"; style="text-align: center ;width: 108px; height: 60px" >
                        <p>You need to follow this format YYYY-MM-DD</p> 
                    </td>
                </tr>

                <tr>
                    <td class="text-center" style="width: 108px; height: 60px">Start Date :</td>
                    <td style="height: 40px">
                        <asp:TextBox ID="txtSDate" runat="server" BorderColor="#E4E4E4" Height="30px" Width="220px" BorderStyle="Solid"></asp:TextBox>
                    </td>
                    <td class="text-center" style="width: 108px; height: 60px">End Date :</td>
                    <td style="height: 40px">
                        <asp:TextBox ID="txtEDate" runat="server" BorderColor="#E4E4E4" Height="30px" Width="220px" BorderStyle="Solid"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="text-center" colspan="2">&nbsp;</td>
                    <td class="text-center" colspan="2" >&nbsp;</td>
                </tr>
            </table>


            <br />
            <asp:Button ID="btnUpdate" runat="server" BackColor="#2E5882" ForeColor="White" Height="42px" Text="Update" OnClick="btnUpdate_Click" Width="175px" BorderColor="#2E5882" CssClass="btn btn-primary btn-lg"/>
            <asp:Button ID="btnCancel" runat="server" BackColor="#2E5882" ForeColor="White" Height="42px" OnClick="btnCancel_Click" Text="Cancel" Width="175px" BorderColor="#2E5882" CssClass="btn btn-primary btn-lg" />
        </div>
    </div>
    <br />
    <br />
    <br />

</asp:Content>
