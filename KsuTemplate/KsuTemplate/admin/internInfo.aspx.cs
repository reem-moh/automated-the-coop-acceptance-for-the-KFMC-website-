using Aspose.Words;
using KsuTemplate.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
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
        DataTable dr = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)  // means do it only once for each user session 
            {
                populateUniversityComb();
                populateUniversityTemplateComb();
                showInternData();
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
            //CRUD myCrud = new CRUD();
            //string mySql = @"select internId, intern, id, internMobile, university, major, internEmail from intern i
            //inner join university u on i.universityId = u.universityId inner join major m on i.majorId = m.majorId";
            //SqlDataReader dr = myCrud.getDrPassSql(mySql);
            //gvInternInfo.DataSource = dr;
            //gvInternInfo.DataBind();
            CRUD myCrud = new CRUD();
            string mySql = @"select internId, intern, id, internMobile, university, major, internEmail from intern i
            inner join university u on i.universityId = u.universityId inner join major m on i.majorId = m.majorId";
            dr = myCrud.getDT(mySql);
            gvInternInfo.DataSource = dr;
            gvInternInfo.DataBind();
        }
        
       // protected void btnShow_Click(object sender, EventArgs e)
       // {
            /*
            CRUD myCrud = new CRUD();
            string mySql = @"select internId, intern, id, internMobile, university, major, internEmail from intern i 
            inner join university u on i.universityId= u.universityId inner join major m on i.majorId = m.majorId";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            gvInternInfo.DataSource = dr;
            gvInternInfo.DataBind(); */
           // showInternData();

      //  }
                

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

        public void ExportGridToExcel(GridView grd)
        {


            TableCell Cell;
            
            for (int Index = 0; Index < grd.HeaderRow.Cells.Count; Index++)
            {
                Cell = grd.HeaderRow.Cells[Index];
                if (Cell.Text.ToString() == "Export to")
                    grd.Columns[Index].Visible = false;
            }




            Response.Clear();
            GridView g=grd;
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            g.AllowPaging = false;
            showInternData();
            g.RenderControl(hw);
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }


        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            ExportGridToExcel(gvInternInfo);
        }

        protected Document mailMergeEffect(int internId)
        {
            String dataDir = "~\\template\\";
            String fileName = "effective.docx";
            // Open an existing document.
            Document doc = new Document(Server.MapPath(dataDir + fileName));

            // Trim trailing and leading whitespaces mail merge values
            doc.MailMerge.TrimWhitespaces = false;

            // Fill the fields in the document with template data.
            String[] effectTemplate = new string[] { "Intern", "Id", "Mobile", "Telephone", "Email",
                                 "IT", "CS", "SWE", "IS",
                                 "NS", "DM", "WM", "CyberS", "DS", "NIOT",
                                 "Institution", "Address", "Department", "TrainingSupervisor",
                                 "Position", "InstitutionTelephone", "InstitutionMobile",
                                 "InstitutionEmail", "StartingDate"};

            object[] effectData = effectNoticeData(internId);

            doc.MailMerge.Execute(effectTemplate, effectData);

            return doc;

        }

        protected object[] effectNoticeData(int internId)
        {


            //intern info
            CRUD myCrud = new CRUD();
            string mySql = @"SELECT internId, intern, majorId
                             , trackId, id, internMobile, telephone
                            , internEmail, startDate, endDate
                             FROM intern
                             WHERE internId = @internId AND universityId = 1";

            Dictionary<String, object> myPara = new Dictionary<String, object>();
            myPara.Add("@internId", internId);
            SqlDataReader dr = myCrud.getDrPassSql(mySql, myPara);
            String intern = "";
            String id = "";
            String internMobile = "";
            String telephone = "";
            String internEmail = "";
            int majorId = -1;
            int trackId = -1;
            String endDate = "";
            String startDate = "";

            //major
            String IT = "False";
            String CS = "False";
            String SWE = "False";
            String IS = "False";

            //Track
            String NS = "False";
            String DM = "False";
            String WM = "False";
            String CyberS = "False";
            String DS = "False";
            String NIOT = "False";

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    intern = dr["intern"].ToString();
                    id = dr["id"].ToString();
                    internMobile = dr["internMobile"].ToString();
                    telephone = dr["telephone"].ToString();
                    internEmail = dr["internEmail"].ToString();
                    majorId = int.Parse(dr["majorId"].ToString());

                    if (majorId == 1)
                    {
                        IT = "True";
                        trackId = int.Parse(dr["trackId"].ToString());
                        switch (trackId)
                        {
                            case 4:
                                NS = "True";
                                break;

                            case 5:
                                DM = "True";
                                break;

                            case 6:
                                WM = "True";
                                break;

                            case 7:
                                CyberS = "True";
                                break;
                            case 8:
                                DS = "True";
                                break;

                            case 9:
                                NIOT = "True";
                                break;
                        }
                    }
                    else
                    {
                        switch (majorId)
                        {
                            case 2:
                                CS = "True";
                                break;

                            case 3:
                                SWE = "True";
                                break;

                            case 4:
                                IS = "True";
                                break;
                        }
                    }

                    endDate = Convert.ToDateTime(dr["endDate"]).ToString("MM-dd-yyyy");
                    startDate = Convert.ToDateTime(dr["startDate"]).ToString("MM-dd-yyyy");
                    break;
                }
            }


            //institution info
            CRUD instituationCrud = new CRUD();
            string instituationSql = @"SELECT institution,address,departmentId,supervisorName,
                                        supervisorPosition,supervisorTelephone 
                                        ,supervisorEmail,supervisorMobile
                                          FROM institution
                                          WHERE institutionId=@institutionId";

            Dictionary<String, object> instituationPara = new Dictionary<String, object>();
            instituationPara.Add("@institutionId", 4);
            SqlDataReader instituationDr = instituationCrud.getDrPassSql(instituationSql, instituationPara);
            String institution = "";
            String address = "";
            int departmentId = 1;
            String supervisorName = "";
            String supervisorPosition = "";
            String supervisorTelephone = "";
            String supervisorEmail = "";
            String supervisorMobile = "";

            if (instituationDr.HasRows)
            {
                while (instituationDr.Read())
                {
                    institution = instituationDr["institution"].ToString();
                    address = instituationDr["address"].ToString();
                    departmentId = int.Parse(instituationDr["departmentId"].ToString());
                    supervisorName = instituationDr["supervisorName"].ToString();
                    supervisorPosition = instituationDr["supervisorPosition"].ToString();
                    supervisorTelephone = instituationDr["supervisorTelephone"].ToString();
                    supervisorEmail = instituationDr["supervisorEmail"].ToString();
                    supervisorMobile = instituationDr["supervisorMobile"].ToString();
                    break;
                }
            }

            CRUD departmentCrud = new CRUD();
            string departmentSql = @"SELECT department
                                      FROM department
                                      WHERE departmentId=@departmentId";

            Dictionary<String, object> departmentPara = new Dictionary<String, object>();
            departmentPara.Add("@departmentId", 1);
            SqlDataReader departmentDr = departmentCrud.getDrPassSql(departmentSql, departmentPara);
            String department = "";

            if (departmentDr.HasRows)
            {
                while (departmentDr.Read())
                {
                    department = departmentDr["department"].ToString();
                    break;
                }
            }

            object[] effectData = new object[]{
                intern, id, internMobile, telephone, internEmail,
                              IT, CS, SWE, IS,
                               NS, DM, WM, CyberS, DS, NIOT,
                               institution,address, department, supervisorName,
                                 supervisorPosition, supervisorTelephone, supervisorMobile,
                                 supervisorEmail, startDate };
            return effectData;
        }

        protected Document mailMergeptPlan(int internId)
        {
            String dataDir = "~\\template\\";
            String fileName = "new_pt_plan_form.docx";
            // Open an existing document.
            Document doc = new Document(Server.MapPath(dataDir + fileName));

            // Trim trailing and leading whitespaces mail merge values
            doc.MailMerge.TrimWhitespaces = false;

            // Fill the fields in the document with template data.
            String[] ptPlaneTemplate = new string[]
            {
               "Intern", "Id", "Mobile", "Email",
               "IT", "CS", "SWE", "IS",
               "NS", "DM", "WM", "CyberS", "DS", "NIOT",
               "Institution", "Address", "Department", "TrainingSupervisor",
               "Position", "InstitutionTelephone", "InstitutionMobile",
               "InstitutionEmail", "StartingDate",
               "Summary", "Outcomes", "From", "To"
            };

            object[] pt = ptPlan(internId);

            doc.MailMerge.Execute(ptPlaneTemplate, pt);

            return doc;

        }

        protected object[] ptPlan(int internId)
        {
            //intern info
            CRUD myCrud = new CRUD();
            string mySql = @"SELECT internId, intern, majorId
                             , trackId, id, internMobile
                            , internEmail, startDate
                             FROM intern
                             WHERE internId = @internId AND universityId = 1";

            Dictionary<String, object> myPara = new Dictionary<String, object>();
            myPara.Add("@internId", internId);
            SqlDataReader dr = myCrud.getDrPassSql(mySql, myPara);
            String intern = "";
            String id = "";
            String internMobile = "";
            String internEmail = "";
            int majorId = -1;
            int trackId = -1;
            String startDate = "";

            //major
            String IT = "False";
            String CS = "False";
            String SWE = "False";
            String IS = "False";

            //Track
            String NS = "False";
            String DM = "False";
            String WM = "False";
            String CyberS = "False";
            String DS = "False";
            String NIOT = "False";

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    intern = dr["intern"].ToString();
                    id = dr["id"].ToString();
                    internMobile = dr["internMobile"].ToString();
                    internEmail = dr["internEmail"].ToString();
                    majorId = int.Parse(dr["majorId"].ToString());

                    if (majorId == 1)
                    {
                        IT = "True";
                        trackId = int.Parse(dr["trackId"].ToString());
                        switch (trackId)
                        {
                            case 4:
                                NS = "True";
                                break;

                            case 5:
                                DM = "True";
                                break;

                            case 6:
                                WM = "True";
                                break;

                            case 7:
                                CyberS = "True";
                                break;
                            case 8:
                                DS = "True";
                                break;

                            case 9:
                                NIOT = "True";
                                break;
                        }
                    }
                    else
                    {
                        switch (majorId)
                        {
                            case 2:
                                CS = "True";
                                break;

                            case 3:
                                SWE = "True";
                                break;

                            case 4:
                                IS = "True";
                                break;
                        }
                    }

                    startDate = Convert.ToDateTime(dr["startDate"]).ToString("MM-dd-yyyy");
                    break;
                }
            }


            //institution info
            CRUD instituationCrud = new CRUD();
            string instituationSql = @"SELECT institution,address,departmentId,supervisorName,
                                        supervisorPosition,supervisorTelephone 
                                        ,supervisorEmail,supervisorMobile
                                          FROM institution
                                          WHERE institutionId=@institutionId";

            Dictionary<String, object> instituationPara = new Dictionary<String, object>();
            //4 = Kfmc
            instituationPara.Add("@institutionId", 4);
            SqlDataReader instituationDr = instituationCrud.getDrPassSql(instituationSql, instituationPara);
            String institution = "";
            String address = "";
            int departmentId = 1;
            String supervisorName = "";
            String supervisorPosition = "";
            String supervisorTelephone = "";
            String supervisorEmail = "";
            String supervisorMobile = "";

            if (instituationDr.HasRows)
            {
                while (instituationDr.Read())
                {
                    institution = instituationDr["institution"].ToString();
                    address = instituationDr["address"].ToString();
                    departmentId = int.Parse(instituationDr["departmentId"].ToString());
                    supervisorName = instituationDr["supervisorName"].ToString();
                    supervisorPosition = instituationDr["supervisorPosition"].ToString();
                    supervisorTelephone = instituationDr["supervisorTelephone"].ToString();
                    supervisorEmail = instituationDr["supervisorEmail"].ToString();
                    supervisorMobile = instituationDr["supervisorMobile"].ToString();
                    break;
                }
            }

            //department
            CRUD departmentCrud = new CRUD();
            string departmentSql = @"SELECT department
                                      FROM department
                                      WHERE departmentId=@departmentId";

            Dictionary<String, object> departmentPara = new Dictionary<String, object>();
            //1 = IT
            departmentPara.Add("@departmentId", 1);
            SqlDataReader departmentDr = departmentCrud.getDrPassSql(departmentSql, departmentPara);
            String department = "";

            if (departmentDr.HasRows)
            {
                while (departmentDr.Read())
                {
                    department = departmentDr["department"].ToString();
                    break;
                }
            }

            //training plan
            CRUD trainingPlaneCrud = new CRUD();
            string trainingPlaneSql = @"SELECT summary, outcomes, timeFrom, timeTo
                                      FROM trainingPlan
                                      WHERE trainingPlanId = 1";

            SqlDataReader trainingPlaneDr = trainingPlaneCrud.getDrPassSql(trainingPlaneSql);
            String summary = "";
            String outcomes = "";
            int timeFrom = 0;
            int timeTo = 0;

            if (trainingPlaneDr.HasRows)
            {
                while (trainingPlaneDr.Read())
                {
                    summary = trainingPlaneDr["summary"].ToString();
                    outcomes = trainingPlaneDr["outcomes"].ToString();
                    timeFrom = int.Parse(trainingPlaneDr["timeFrom"].ToString());
                    timeTo = int.Parse(trainingPlaneDr["timeTo"].ToString());
                    break;
                }
            }

            object[] pt = new object[]
            {
                intern, id, internMobile, internEmail,
                IT, CS, SWE, IS,
                NS, DM, WM, CyberS, DS, NIOT,
                institution,address, department, supervisorName,
                supervisorPosition, supervisorTelephone, supervisorMobile,
                supervisorEmail, startDate,
                summary, outcomes, timeFrom ,timeTo
            };
            return pt;
        }

        protected void btnExportToWord_Click(object sender, EventArgs e)
        {
            String selectedTemplate = ddlTemplate.SelectedValue;
            showInternData();
           
            GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
            int index = gvRow.RowIndex;

            int internId = int.Parse(dr.Rows[index][0].ToString());

                if (ddlTemplate.SelectedValue == "1")
                {
                    Document doc = mailMergeEffect(internId);
                    
                    save(doc, "effectNoticeData_internId_" + internId + "_.docx");
                }
                else if (ddlTemplate.SelectedValue == "3")
                {
                    Document doc = mailMergeptPlan(internId);
                    save(doc, "pt_plan_form_internId_" + internId + "_.docx");
                }
            

        }

        protected void btnExportToPdf_Click(object sender, EventArgs e)
        {

            String selectedTemplate = ddlTemplate.SelectedValue;
            showInternData();

            GridViewRow gvRow = (GridViewRow)(sender as Control).Parent.Parent;
            int index = gvRow.RowIndex;

            int internId = int.Parse(dr.Rows[index][0].ToString());

                if (ddlTemplate.SelectedValue == "1")
                {
                    Document doc = mailMergeEffect(internId);

                    save(doc, "effectNoticeData_internId_" + internId + "_.Pdf");
                }
                else if (ddlTemplate.SelectedValue == "3")
                {
                    Document doc = mailMergeptPlan(internId);

                    save(doc, "pt_plan_form_internId_" + internId + "_.Pdf");
                }
            
        }

        protected void save(Document doc, String fileName)
        {
           
            HttpResponse Response = HttpContext.Current.Response;

            if (Response != null)
            {
                Response.Clear();
                Response.Buffer = true;
                doc.Save(Response, fileName, ContentDisposition.Attachment, null);
                Response.Flush();
                Response.End();
                
            }
          
        }

    }
}