using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Advisor
{
    public partial class services : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("tnum.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Advising_System_11"].ToString();


            using (SqlConnection conn = new SqlConnection(connStr))
            {
                Response.Redirect("optionalcourses.aspx");





            }
        }

        protected void vavc_Click(object sender, EventArgs e)
        {
            Response.Redirect("availablecourses.aspx");
        }

        protected void vmc_Click(object sender, EventArgs e)
        {
            Response.Redirect("missingcourses.aspx");

        }

        protected void register_Click(object sender, EventArgs e)
        {
            Response.Redirect("requiredcourses.aspx");

        }

        protected void np_Click(object sender, EventArgs e)
        {
            Response.Redirect("buttons.aspx");

        }

        protected void scr_Click(object sender, EventArgs e)
        {
            Response.Redirect("sendcourserequest.aspx");

        }

        protected void schr_Click(object sender, EventArgs e)
        {
            Response.Redirect("sendchrequest.aspx");

        }
    }
}


