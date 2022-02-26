using KsuTemplate.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KsuTemplate.Account
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Username"] = txtUserName.Text;

            if (!Page.IsPostBack)
            {
                Session["Username"] = txtUserName.Text;

            }
        }

        private void createInternUser()
        {
            try
            {
                string strExistingIntern = "";
                string strAppName = "/KsuTemplate";
                string strInternUserName = txtUserName.Text;  //txtUserName.Text;
                string strInternPassword = txtPassword.Text; //txtPassword.Text;
                string strRoleName = "intern";
                string strEmail = txtEmail.Text;
                strAppName = Membership.ApplicationName.ToString();
                CRUD myCrud = new CRUD();
                Dictionary<string, object> myPara = new Dictionary<string, object>();
                myPara.Add("@userName", strInternUserName);
                myPara.Add("@appName", strAppName);
                //
                strExistingIntern = myCrud.checkUserExist("p_doesUserExist", myPara);
                if (strExistingIntern.Length == 0)
                {
                    if (!Roles.RoleExists(strRoleName))
                        Roles.CreateRole(strRoleName);
                    if (!Membership.ValidateUser(strInternUserName, strInternPassword))
                    {
                        Membership.CreateUser(strInternUserName, strInternPassword, strEmail);
                        if (!Roles.IsUserInRole(strInternUserName, strRoleName))
                            Roles.AddUserToRole(strInternUserName, strRoleName);
                        lblOutput.Text = "successfully registeration";
                    }
                }
                else if (strExistingIntern.Length >= 0)
                {
                    lblOutput.Text = "this user name is used before try with different one";
                }
            }
            catch (Exception ex)
            {
                lblOutput.Text = ex.Message.ToString();
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtPassword.Text == txtConPass.Text)
            {
                createInternUser();
            }
            else
            {
                lblOutput.Text = "the password and the confirm password need to be the same";
            }
                
        }
    }
}