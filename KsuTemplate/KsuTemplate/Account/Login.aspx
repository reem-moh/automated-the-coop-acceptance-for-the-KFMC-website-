<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="KsuTemplate.Account.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <link href="CSS/contactStyleSheet1.css" rel="stylesheet" />
    <p>
        <br />
    </p>
    <br />
    
    <asp:Label ID="lblOutput" runat="server" Text=""></asp:Label>
   
    <div class="jumbotron">
        <div class="wrap-contact100" style="text-align: center">
            <table align="center" class="nav-justified" style="height: 316px; width: 86%;">
                <tr>
                    <td class="text-center" colspan="2">
                        <h2 style="text-align: center">Login</h2>
                    </td>
                </tr>


                <%-- Name --%>
                <tr>
                    <td class="text-center" style="width: 108px; height: 60px">User Name</td>
                    <td style="height: 60px">
                        <asp:TextBox ID="txtUserName" runat="server" BorderColor="#E4E4E4" Height="30px" Width="220px" BorderStyle="Solid"></asp:TextBox>
                    </td>
                </tr>
                <%-- Password --%>
                <tr>
                    <td class="text-center" style="width: 108px; height: 60px">Password</td>
                    <td style="height: 60px">
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" BorderColor="#E4E4E4" Height="30px" Width="220px" BorderStyle="Solid"></asp:TextBox>
                    </td>
                </tr>
                <%-- login --%>
                <tr>
                    <td class="text-center" colspan="2">
                        <br />
                        <br />
                        <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click"
                            Text="Login" BackColor="#2E5882" ForeColor="White" Height="42px" Width="175px" BorderColor="#2E5882" CssClass="btn btn-primary btn-lg" />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="style2">&nbsp;</td>
                    <td>
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>



            <asp:Label ID="lblReg" runat="server" Text="Don't have an account?"></asp:Label>
            <asp:Label ID="lblReg1" runat="server" Text=""><a runat="server" href="~/Account/Registration">Register</a></asp:Label>
        </div>

    </div>
    <br />
    <br />
</asp:Content>
