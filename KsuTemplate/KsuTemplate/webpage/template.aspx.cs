using Aspose.Words;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using Aspose.Words.MailMerging;
using KsuTemplate.App_Code;
using System.Data.SqlClient;

namespace KsuTemplate.webpage
{
    public partial class template : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Username"] != null)
            {
                if (!Authenticate())
                {
                    btnDoc.Visible = false;
                    btnPdf.Visible = false;
                    lblData.Text = "Please fill your profile information first!! ";
                }
                else
                {
                    btnDoc.Visible=true;
                    btnPdf.Visible = true;
                    if (!Page.IsPostBack)  
                    {
                        populateUniversityComb();
                        populateTemplateComb();
                    }

                }

                
            }
        }

        protected Document mailMergeEffect()
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

            object[] effectData = effectNoticeData();

            doc.MailMerge.Execute(effectTemplate, effectData);

            return doc;

        }

        protected object[] effectNoticeData()
        {


            //intern info
            CRUD myCrud = new CRUD();
            string mySql = @"SELECT internId, intern, majorId
                             , trackId, id, internMobile, telephone
                            , internEmail, startDate, endDate
                             FROM intern
                             WHERE userName = @userName AND universityId = 1";

            Dictionary<String, object> myPara = new Dictionary<String, object>();
            myPara.Add("@userName", Session["Username"]);
            SqlDataReader dr = myCrud.getDrPassSql(mySql, myPara);
            String intern="";
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
            String CS= "False";
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
                        IT= "True";
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
                    }else
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

        protected Document mailMergeptPlan()
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

            object[] pt = ptPlan();

            doc.MailMerge.Execute(ptPlaneTemplate, pt);

            return doc;

        }

        protected object[] ptPlan()
        {
            //intern info
            CRUD myCrud = new CRUD();
            string mySql = @"SELECT internId, intern, majorId
                             , trackId, id, internMobile
                            , internEmail, startDate
                             FROM intern
                             WHERE userName = @userName AND universityId = 1";

            Dictionary<String, object> myPara = new Dictionary<String, object>();
            myPara.Add("@userName", Session["Username"]);
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
            int timeFrom= 0;
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

        protected void saveAsDoc(Document doc, String fileName)
        {
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            // Send the document in Word format to the client browser with an option to save to disk or open inside the current browser.
            doc.Save(desktop + fileName);
            lblOutput.Text = "Successfuly saved form on Desktop";

        }

        protected void saveAsPdf(Document doc, String fileName)
        {
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            doc.Save(desktop+ fileName, SaveFormat.Pdf);
            lblOutput.Text = "Successfuly saved form on Desktop";
        }

        protected bool Authenticate()
        {
            string mySql = @"SELECT *
                              FROM intern
                              WHERE userName = @user";
            CRUD myCrud = new CRUD();
            Dictionary<String, object> myPara = new Dictionary<String, object>();
            myPara.Add("@user", Session["Username"]);
            bool userFound = myCrud.authenticateUser(mySql, myPara); // pass the sql and the dic para
            return userFound;
        }

        protected void btnDoc_Click(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("~\\Account\\Login.aspx");
            }

           
            if (ddlTemplate.SelectedValue == "1")
            {
                Document doc = mailMergeEffect();
                saveAsDoc(doc, "\\effectNoticeDate.docx");
            }
            else if (ddlTemplate.SelectedValue == "3")
            {
                Document doc = mailMergeptPlan();
                saveAsDoc(doc, "\\ptPlan.docx");
            }

            
        }

        protected void btnPdf_Click(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("~\\Account\\Login.aspx");
            }

            
            if (ddlTemplate.SelectedValue == "1")
            {
                Document doc = mailMergeEffect();
                saveAsPdf(doc, "\\effective.Pdf");
            }
            else if (ddlTemplate.SelectedValue == "3")
            {
                Document doc = mailMergeptPlan();
                saveAsPdf(doc, "\\ptPlan.Pdf");
            }

        }

        protected void populateTemplateComb()
        {
            // code to connect to db  and pull Template information 
            CRUD myCrud = new CRUD();
            string mySql = @"SELECT templateId,template
                              FROM template
                              WHERE universityId=1 ";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            ddlTemplate.DataValueField = "templateId";
            ddlTemplate.DataTextField = "template";
            ddlTemplate.DataSource = dr;
            ddlTemplate.DataBind();
        }

        protected void populateUniversityComb()
        {
            // code to connect to db  and pull Template information 
            CRUD myCrud = new CRUD();
            string mySql = @"SELECT universityId,university
                              FROM university";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            ddlUni.DataValueField = "universityId";
            ddlUni.DataTextField = "university";
            ddlUni.DataSource = dr;
            ddlUni.DataBind();
        }

        protected void ddlUni_SelectedIndexChanged(object sender, EventArgs e)
        {
            CRUD myCrud = new CRUD();
            string mySql = @"SELECT templateId,template
                              FROM template
                              WHERE universityId= @universityId ";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@universityId", ddlUni.SelectedValue);
            SqlDataReader dr = myCrud.getDrPassSql(mySql, myPara);
            ddlTemplate.DataValueField = "templateId";
            ddlTemplate.DataTextField = "template";
            ddlTemplate.DataSource = dr;
            ddlTemplate.DataBind();
        }
    }
}