using KsuTemplate.App_Code;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KsuTemplate.webpage
{
    public partial class userInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("~\\Account\\Login.aspx");
            }
            if (!Page.IsPostBack)
            {
                populateUserInfoCombo();
               
            }
        }
        
        protected void populateUserInfoCombo()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"SELECT internId, intern, majorId
                            , trackId, id, internMobile, telephone
                            , internEmail, startDate, endDate, userName,universityId
                                FROM intern
                                WHERE userName = @userName";

            Dictionary<String, object> myPara = new Dictionary<String, object>();
            
            myPara.Add("@userName", Session["Username"]);
            SqlDataReader dr = myCrud.getDrPassSql(mySql, myPara);

            if (dr.HasRows)
            {
                while(dr.Read())
                {
                    txtIntern.Text = dr["intern"].ToString();
                    txtId.Text = dr["id"].ToString();
                    txtMobileNum.Text = dr["internMobile"].ToString();
                    txtTelephone.Text = dr["telephone"].ToString();
                    txtEmail.Text = dr["internEmail"].ToString();
                    int uniId = int.Parse(dr["universityId"].ToString());
                    showUniversity(uniId);
                    int majorId = -1;
                     majorId = int.Parse(dr["majorId"].ToString());
                    
                    showMajor(majorId);
                    if (majorId == 1)
                    {
                        ddlTrack.Visible = true;
                        int trackId = int.Parse(dr["trackId"].ToString());
                        showTrack(trackId);
                    }
                    else
                    {
                        ddlTrack.Visible = false;
                    }

                    txtEDate.Text = Convert.ToDateTime(dr["endDate"]).ToString("MM-dd-yyyy");
                    txtSDate.Text = Convert.ToDateTime(dr["startDate"]).ToString("MM-dd-yyyy");
                    break;
                }
            }
            else
            {
                populateMajorCombo();
            }

        }

        //display intern University
        protected void showUniversity(int uniId)
        {

            CRUD myCrud = new CRUD();
            string mySql = @"SELECT university, universityId
                              FROM university
                              WHERE universityId=@uniId";
            Dictionary<String, object> myPara = new Dictionary<String, object>();

            myPara.Add("@uniId", uniId);
            SqlDataReader dr = myCrud.getDrPassSql(mySql, myPara);
            ddlUni.DataTextField = "university";
            ddlUni.DataValueField = "universityId";
            ddlUni.DataSource = dr;
            ddlUni.DataBind();
            ddlUni.SelectedValue = "" + uniId;
        }

        //display intern Major
        protected void showMajor(int majorId)
        {

            CRUD myCrud = new CRUD();
            string mySql = @"SELECT majorId ,major FROM major";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            ddlMajor.DataTextField = "major";
            ddlMajor.DataValueField = "majorId";
            ddlMajor.DataSource = dr;
            ddlMajor.DataBind();
            ddlMajor.SelectedValue = "" + majorId;
        }

        //display intern Track
        protected void showTrack(int trackId)
        {

            CRUD myCrud = new CRUD();
            string mySql = @"SELECT trackId,track
                                    FROM track";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            ddlTrack.DataTextField = "track";
            ddlTrack.DataValueField = "trackId";
            ddlTrack.DataSource = dr;
            ddlTrack.DataBind();

            ddlTrack.SelectedValue = ""+trackId;
        }

        protected void populateMajorCombo()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"SELECT majorId ,major FROM major";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            ddlMajor.DataTextField = "major";
            ddlMajor.DataValueField = "majorId";
            ddlMajor.DataSource = dr;
            ddlMajor.DataBind();
        }

        protected void ddlMajor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMajor.SelectedValue == "1")
            {
                ddlTrack.Visible = true;
                CRUD myCrud = new CRUD();
                string mySql = @"SELECT trackId,track FROM track";
                SqlDataReader dr = myCrud.getDrPassSql(mySql);
                ddlTrack.DataValueField = "trackId";
                ddlTrack.DataTextField = "track";
                ddlTrack.DataSource = dr;
                ddlTrack.DataBind();
            }
            else
            {
                ddlTrack.Visible = false;
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if(Authenticate())
            {
                updateData();
            }
            else
            {
                insertInfo();
            }
            
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

        protected void insertInfo()
        {
            if (!checkData()) {
                lblInfo.Text = "there is an emtyp field, fill it";
            }else
            {
                CRUD myCrud = new CRUD();
                string mySql = @"INSERT INTO intern (intern,majorId,trackId,id,internMobile,
                                                telephone,internEmail,startDate,endDate,userName)
                             VALUES (@intern, @majorId,@trackId,@id,@internMobile,@telephone,
                                      @internEmail,@startDate,@endDate,@userName)";

                Dictionary<String, object> myPara = new Dictionary<String, object>();
                myPara.Add("@intern", txtIntern.Text);
                myPara.Add("@majorId", ddlMajor.SelectedValue);
                myPara.Add("@trackId", ddlTrack.SelectedValue);
                myPara.Add("@id", txtId.Text);
                myPara.Add("@internMobile", txtMobileNum.Text);
                myPara.Add("@telephone", txtTelephone.Text);
                myPara.Add("@internEmail", txtEmail.Text);
                myPara.Add("@startDate", txtSDate.Text);
                myPara.Add("@endDate", txtEDate.Text);
                myPara.Add("@userName", Session["Username"]);

                int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
                if (rtn >= 1)
                {
                    lblInfo.Text = "Successfully update your profile";
                }
                else
                {
                    lblInfo.Text = "Sorry, try agian later";
                }
            }
            
        }

        protected bool checkData()
        {
            bool isOk = true;
            if (txtIntern.Text == "" || txtId.Text == "" || txtMobileNum.Text == "" || txtEmail.Text == "" || txtSDate.Text == "" || txtEDate.Text == "")
            {
                isOk = false;
            }

            return isOk;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~\\Default.aspx");
        }

        protected void updateData()
        {
            if (!checkData())
            {
                lblInfo.Text = "there is an emtyp field, fill it";
            }
            else
            {
                CRUD myCrud = new CRUD();
                string mySql = @"UPDATE intern
                                  SET intern=@intern,majorId=@majorId,trackId=@trackId,
                                  id=@id,internMobile=@internMobile,
                                  telephone=@telephone,internEmail= @internEmail,
                                  startDate=@startDate,endDate=@endDate
                                  WHERE userName = @userName";

                Dictionary<String, object> myPara = new Dictionary<String, object>();
                myPara.Add("@intern", txtIntern.Text);
                myPara.Add("@majorId", ddlMajor.SelectedValue);
                myPara.Add("@trackId", ddlTrack.SelectedValue);
                myPara.Add("@id", txtId.Text);
                myPara.Add("@internMobile", txtMobileNum.Text);
                myPara.Add("@telephone", txtTelephone.Text);
                myPara.Add("@internEmail", txtEmail.Text);
                myPara.Add("@startDate", txtSDate.Text);
                myPara.Add("@endDate", txtEDate.Text);
                myPara.Add("@userName", Session["Username"]);

                int rtn = myCrud.InsertUpdateDelete(mySql, myPara);

                if (rtn >= 1)
                {
                    lblInfo.Text = "Successfully update your profile";
                }
                else
                {
                    lblInfo.Text = "Sorry, try agian later";
                }
            }

        }

    }
}
