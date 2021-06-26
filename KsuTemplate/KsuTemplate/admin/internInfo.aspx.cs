using KsuTemplate.App_Code;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
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
            if (!Page.IsPostBack)  // means do it only once for each user session 
            {
                populateUniversityComb();
            }

        }
        protected void populateUniversityComb()
        {
            // code to connect to db  and pull university information 
            CRUD myCrud = new CRUD();
            string mySql = "select universityId, university from university ";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            ddlUniversity.DataValueField = "universityId";
            ddlUniversity.DataTextField = "university";
            ddlUniversity.DataSource = dr;
            ddlUniversity.DataBind();
        }
        protected void populateUniversityTemplateComb()
        {
            // code to connect to db  and pull university information 
            CRUD myCrud = new CRUD();
            string mySql = "select templateId, template from template ";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            ddlTemplate.DataValueField = "templateId";
            ddlTemplate.DataTextField = "template";
            ddlTemplate.DataSource = dr;
            ddlTemplate.DataBind();
        }
        protected void showInternData()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select internId, intern, id, internMobile, university, major, internEmail from intern i
            inner join university u on i.universityId = u.universityId inner join major m on i.majorId = m.majorId";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            gvInternInfo.DataSource = dr;
            gvInternInfo.DataBind();
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            /*
            CRUD myCrud = new CRUD();
            string mySql = @"select internId, intern, id, internMobile, university, major, internEmail from intern i 
            inner join university u on i.universityId= u.universityId inner join major m on i.majorId = m.majorId";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            gvInternInfo.DataSource = dr;
            gvInternInfo.DataBind(); */
            showInternData();

        }

        protected void ddlUniversity_SelectedIndexChanged(object sender, EventArgs e)
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select * from template 
                            where universityId = @universityId ";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@universityId", ddlUniversity.SelectedValue);
            SqlDataReader dr = myCrud.getDrPassSql(mySql, myPara);
            ddlTemplate.DataValueField = "templateId";
            ddlTemplate.DataTextField = "template";
            ddlTemplate.DataSource = dr;
            ddlTemplate.DataBind();
        }

        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
          //  ExportGridToExcel(gvInternInfo);
        }
      
        
    }
}