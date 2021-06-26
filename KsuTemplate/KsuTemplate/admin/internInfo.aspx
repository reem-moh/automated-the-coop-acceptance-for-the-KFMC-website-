<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="internInfo.aspx.cs" Inherits="KsuTemplate.admin.internInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

        <div class="jumbotron" style="text-align: center">


            <h2>
                <br />
                Interns Information</h2>
            <p>
                &nbsp;</p>
            <table class="nav-justified">
                <tr>
                    <td colspan="2" style="height: 22px">
                        <asp:DropDownList ID="ddlUniversity" runat="server" Height="19px" OnSelectedIndexChanged="ddlUniversity_SelectedIndexChanged" Width="135px">
                        </asp:DropDownList>
&nbsp;<asp:DropDownList ID="ddlTemplate" runat="server" Height="19px" Width="135px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="height: 91px; width: 254px">
                        <asp:Button ID="btnShow" runat="server" BackColor="#2E5882" CssClass="btn btn-primary btn-lg" ForeColor="White" OnClick="btnShow_Click" Text="Show All Interns" Width="165px" />
                    </td>
                    <td rowspan="2">
                        <br />
                        <asp:GridView ID="gvInternInfo" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" style="margin-left: 55px" Width="487px">
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <RowStyle ForeColor="#000066" />
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td class="modal-sm" style="width: 254px">
                        <asp:Button ID="btnExportToExcel" runat="server" BackColor="#1C5085" CssClass="btn btn-primary btn-lg" ForeColor="White" Text="Export To Excel" Width="165px" OnClick="btnExportToExcel_Click" />
                    </td>
                </tr>
            </table>


</div>

</asp:Content>
