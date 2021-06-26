using KsuTemplate.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KsuTemplate.admin
{
    public partial class trainingPlan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
             
        }

        protected void btnSubmit_Click1(object sender, EventArgs e)
        {
            // I put all the code that inert information to the db
            CRUD myCrud = new CRUD();
            string mySql = @"insert into trainingPlan (summary,outcomes) 
                        values (@summary,@outcomes)";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@summary", txtSummary.Text);
            myPara.Add("@outcomes",txtOutcomes.Text); 
            int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
            if (rtn >= 1)
            { lblOutput.Text = "Success Operation!"; }
            else
            { lblOutput.Text = "Failed Operation"; }
        }
    }
}