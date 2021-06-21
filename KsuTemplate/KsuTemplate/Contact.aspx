<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="KsuTemplate.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="CSS/contactStyleSheet1.css" rel="stylesheet" />

     <body>


	<div class="container-contact100">
		<div class="wrap-contact100">
                   <h3>
                       <asp:Label ID="lblOutput" runat="server" ForeColor="#339966"></asp:Label>
                   </h3>
                   <p>
                       &nbsp;</p>
                   <h2>Get in Touch</h2><br />

					<input class="input100" type="text" name="name" placeholder="Full Name">
					<input class="input100" type="text" name="email" placeholder="Email" />
					<textarea class="input100" name="message" placeholder="Your Message"></textarea>
			       <br />
                   <asp:Button ID="btnSendEmail" runat="server" BackColor="#2E5882" ForeColor="White" Height="39px" Text="Send Email" Width="139px" OnClick="btnSendEmail_Click" />
      
				</div>
		</div>



</body>


</asp:Content>
