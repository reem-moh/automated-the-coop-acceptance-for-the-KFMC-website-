<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="KsuTemplate.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="CSS/AboutStyleSheet1.css" rel="stylesheet" />
    <script src="https://kit.fontawesome.com/dbed6b6114.js" crossorigin="anonymous"></script>

    <body>
        <div class="contact-form">
            <div class="first-container">
                <div class="info">
                    <div>
                        <div class="info">
                            <div>
                                <h3><strong>Address</strong></h3>
                                <p>Prince Abdulaziz Ibn Jalwi St, As</p>
                            </div>
                            <div>
                                <h3><strong>Email</strong></h3>
                                <p>KFMCIntern@gmail.com</p>
                            </div>
                            <div>
                                <h3><strong>Phone</strong></h3>
                                <p>+966 546787841</p>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
            <div class="sec-container">
                <h2>ABOUT US</h2>
                <br /> <br />
                <form>
                    <p><strong>KFMC Interns</strong><br />
                        The website that receives the information of KSU trainees. To make it easier for King Fahad Medical City to fill out forms for trainees.</p>
                    <br /> <strong>Our Team</strong><br/>
                    <p>902 MH-I Norah Almaneea <br />1096 SD-I Reem Algabani <br /> 1114 Meaad</p>
<!-- Meaad information need to be updated-->

                </form>
                <ul class="icons">
                    <li>
                        <i class="fa fa-twitter"></i>

                    </li>
                    <li>
                        <i class="fa fa-facebook"></i>
                    </li>
                </ul>
            </div>
        </div>
    </body>
</asp:Content>
