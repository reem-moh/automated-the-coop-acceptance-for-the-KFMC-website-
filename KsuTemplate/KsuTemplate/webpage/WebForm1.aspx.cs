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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CRUD crud = new CRUD();
            string sql = @"SELECT test
                            FROM test";
            SqlDataReader dr = crud.getDrPassSql(sql);

            ddl.DataTextField = "test";
            ddl.DataSource = dr;
            ddl.DataBind();
        }
    }
}
