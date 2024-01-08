using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication11
{
    public partial class buttons : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void gradplan(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System_11"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            Response.Redirect("gradplan.aspx");
        }
        protected void inst(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System_11"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            Response.Redirect("installment.aspx");
        }
        protected void exams(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System_11"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            Response.Redirect("exams.aspx");
        }
        protected void firstm(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System_11"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            Response.Redirect("firstm.aspx");
        }
        protected void secondm(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System_11"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            Response.Redirect("secondm.aspx");
        }
        protected void allcoursesslots(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System_11"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            Response.Redirect("allcoursesslots.aspx");
        }

        protected void slotsinstructors(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System_11"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            Response.Redirect("slotsinstructors.aspx");
        }
        protected void chooseinstructor(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System_11"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            Response.Redirect("chooseinstructor.aspx");
        }
        protected void prereq(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System_11"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            Response.Redirect("prereq.aspx");
        }

    }
}