using KsuTemplate.App_Code;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KsuTemplate.admin
{
    public partial class internInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnExportToWord_Click(object sender, EventArgs e)
        {

        }

        protected void btnShowAllIntern_Click(object sender, EventArgs e)
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select internId, intern, internMobile, university, major from intern i 
            inner join university u on i.universityId= u.universityId inner join major m on i.majorId = m.majorId"; 
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            gvInternInfo.DataSource = dr;
            gvInternInfo.DataBind();

        }

        protected void rbnForms_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}