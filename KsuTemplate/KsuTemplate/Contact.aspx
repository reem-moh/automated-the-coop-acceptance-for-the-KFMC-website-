<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="KsuTemplate.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="CSS/contactStyleSheet1.css" rel="stylesheet" />

     <body>


	<div class="container-contact100">
		<div class="wrap-contact100" style="text-align: center">
                   <h3>
                       <asp:Label ID="lblOutput" runat="server"></asp:Label>
                   </h3>
                   <p>
                       &nbsp;</p>
                   <h2>Get in Touch</h2>
                   <div class="text-center">
                       <br />

					
                      </div>
                   <table align="center" cellpadding="2" class="nav-justified" style="height: 241px">
                       <tr>
                           <td class="text-center" style="width: 132px; height: 46px">Name</td>
                           <td style="height: 46px">
                               <asp:TextBox ID="txtName" runat="server" BorderColor="Silver" Height="30px" Width="190px"></asp:TextBox>
                           </td>
                       </tr>
                       <tr>
                           <td class="text-center" style="width: 132px; height: 45px">Email</td>
                           <td style="height: 45px">
                               <asp:TextBox ID="txtEmail" runat="server" Height="30px" Width="190px"></asp:TextBox>
                           </td>
                       </tr>
                       <tr>
                           <td class="text-center" style="width: 132px; height: 45px">Subject</td>
                           <td style="height: 45px">
                               <asp:TextBox ID="txtSubject" runat="server" Height="30px" Width="190px"></asp:TextBox>
                           </td>
                       </tr>
                       <tr>
                           <td class="text-center" style="width: 132px; height: 45px">Message</td>
                           <td class="text-center" style="height: 45px">
                               <asp:TextBox ID="txtMessage" runat="server" Height="70px" TextMode="MultiLine" Width="190px"></asp:TextBox>
                           </td>
                       </tr>
                       <tr>
                           <td class="text-center" colspan="2">
                               <br />
                               <br />
                               <asp:Button ID="btnSubmit" runat="server" BackColor="#2E5882" ForeColor="White" Height="42px" OnClick="btnSubmit_Click1" Text="Submit" Width="175px" />
                               <br />
      
				           </td>
                       </tr>
                   </table>
      
				</div>
		</div>
	

</body>


</asp:Content>
