<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="KsuTemplate.Account.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
    <br />
</p>
    <br />
    

    <asp:Label ID="lblOutput" runat="server" Text=""></asp:Label>

    <div>

        <table class="style1">
    
            <tr>
                <td class="style2">User Name</td>
                <td>
                    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">Password</td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">&nbsp;</td>
                <td>
                    <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click"
                        Text="Login" />
                    <%--<asp:Button ID="btnCreateAdmin" runat="server" OnClick="btnCreateAdmin_Click" Text="Admin" Visible="False" />--%>
                </td>
            </tr>
            <tr>
                <td class="style2">&nbsp;</td>
                <td>
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </td>
            </tr>
        </table>

    </div>

    <asp:Label ID="lblReg" runat="server" Text="Don't have an account?"></asp:Label>
    <asp:Label ID="lblReg1" runat="server" Text=""><a runat="server" href="~/Account/Registration">Register</a></asp:Label>
    <br />
    <br />
</asp:Content>
