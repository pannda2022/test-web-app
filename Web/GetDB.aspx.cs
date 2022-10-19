using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class GetDB : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("select * from testtable", conn);
            DataSet ds = new DataSet();
            new SqlDataAdapter(cmd).Fill(ds, "ds");
            dg_test.DataSource = ds;
            dg_test.DataBind();

            cmd.Cancel();
            cmd.Dispose();

            conn.Dispose();
            conn.Close();
        }
    }
}