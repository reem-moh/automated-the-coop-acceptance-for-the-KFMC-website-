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
        public string sendEmailViaGmail() // worked 100%, this is a nice one use it with  properties
        {
            string myFrom = "kfmcintern@gmail.com"; // put your email account (from )
            string myTo = "kfmcintern@gmail.com"; // put your email account (to )
            string mySubject = "test sending email ";
            string myBody = " email message content";

            string myHostsmtpAddress = "smtp.gmail.com";//"smtp.mail.yahoo.com";  //mail.wdbcs.com 
            int myPortNumber = 587;
            bool myEnableSSL = true;
            string myUserName = "kfmcintern@gmail.com";//;
            string myPassword = "KFMCIntern1234";//;

            //string visitorUserName = Page.User.Identity.Name;
            using (MailMessage m = new MailMessage(myFrom, myTo, mySubject, myBody)) // .............................1
            {
                SmtpClient sc = new SmtpClient(myHostsmtpAddress, myPortNumber); //..................................2
                try
                {
                    sc.Credentials = new System.Net.NetworkCredential(myUserName, myPassword);  //.................3
                    sc.EnableSsl = true;
                    sc.Send(m);
                    return "Email Send successfully";
                    //lblMsg.Text = ("Email Send successfully");
                    //lblMsg.ForeColor = Color.Green; // using System.Drawing above 2/2018
                }
                catch (SmtpFailedRecipientException ex)
                {
                    SmtpStatusCode statusCode = ex.StatusCode;
                    if (statusCode == SmtpStatusCode.MailboxBusy || statusCode == SmtpStatusCode.MailboxUnavailable || statusCode == SmtpStatusCode.TransactionFailed)
                    {   // wait 5 seconds, try a second time
                        Thread.Sleep(5000);
                        sc.Send(m);
                        return ex.Message.ToString();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (Exception ex)
                {
                    return ex.Message.ToString();
                }
                finally
                {
                    m.Dispose();
                }
            }// end using 
        }


        protected void btnSendEmail_Click(object sender, EventArgs e)
        {
            string msg = sendEmailViaGmail();
            lblOutput.Text = msg;
        }
    }
}