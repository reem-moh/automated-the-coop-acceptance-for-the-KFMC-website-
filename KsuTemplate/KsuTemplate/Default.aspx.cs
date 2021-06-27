using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KsuTemplate
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                // Here i am checking from role based using Form Authentication
                // If you are not using Form Authentication then just get the role value from database and implement same logic for your functionality.
                btnTemplate.Visible = this.Page.User.IsInRole("intern");
                btnUserInfo.Visible = this.Page.User.IsInRole("intern");
            }

        }

        protected void btnUserInfo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~\\webpage\\userInfo.aspx");
        }

        protected void btnTemplate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~\\webpage\\template.aspx");
        }
    }
}