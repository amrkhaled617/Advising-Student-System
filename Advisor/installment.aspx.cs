using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class installment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string username = Session["Username"].ToString();
            int id = Int32.Parse(username);
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System_11"].ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT dbo.FN_StudentUpcoming_installment(@student_ID)", conn);
                cmd.Parameters.Add(new SqlParameter("@student_ID", id));
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    if (result is DateTime installDeadline)
                    {
                        Label lblInstallDeadline = new Label();
                        lblInstallDeadline.Text = "Upcoming Installment Deadline: " + installDeadline.ToShortDateString();
                        form1.Controls.Add(lblInstallDeadline);
                    }
                  
                }
                else
                {
                    Label lblNoDeadline = new Label();
                    lblNoDeadline.Text = "No upcoming installment deadline available";
                    form1.Controls.Add(lblNoDeadline);
                }
            }
        }
    }
}
