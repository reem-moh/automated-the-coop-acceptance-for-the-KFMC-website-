using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KsuTemplate
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSubmit_Click1(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress("kfmcintern@gmail.com");
                    mailMessage.To.Add("kfmcintern@gmail.com");
                    mailMessage.Subject = txtSubject.Text;
                    //Message Body
                    mailMessage.Body = "<b>Sender Name: </b>" + txtName.Text + "<br/>"
                        + "< b > Sender Email: </ b > " + txtEmail.Text + "<br/>"
                        + "< b > Message: </ b > " + txtMessage.Text;

                    //Tell mail message the mail contain HTML objects:
                    mailMessage.IsBodyHtml = true;

                    //Send Mail Message: 
                    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                    smtpClient.EnableSsl = true;
                    smtpClient.Credentials = new System.Net.NetworkCredential("kfmcintern@gmail.com", "KFMCIntern1234");

                    smtpClient.Send(mailMessage);

                    //Show Label message
                    lblOutput.ForeColor = System.Drawing.Color.Green;
                    lblOutput.Text = "Thank You For Contacting Us";

                    //Disables Controls
                    txtName.Enabled = false;
                    txtEmail.Enabled = false;
                    txtSubject.Enabled = false;
                    txtMessage.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                lblOutput.ForeColor = System.Drawing.Color.Green;
                lblOutput.ForeColor = System.Drawing.Color.DarkRed;
                lblOutput.Text = "There is a problem. Please Try later!";

            }

        }

    }
}
