using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class secondm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRegister_Click2(object sender, EventArgs e)
        {
            string username = Session["Username"].ToString();
            int id = Int32.Parse(username);

            int courseID;
            string currentSemester;

            int.TryParse(txtCourseID2.Text, out courseID);
            currentSemester = txtCurrentSemester2.Text;

            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System_11"].ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                SqlCommand check1 = new SqlCommand("Select * From Course where course_id=@course_id", conn);
                check1.CommandType = CommandType.Text;
                check1.Parameters.AddWithValue("@course_id", courseID);

                SqlDataReader rdrcheck1 = check1.ExecuteReader(CommandBehavior.CloseConnection);

                if (!rdrcheck1.HasRows)
                {
                    Label label = new Label();
                    label.Text = "Invalid course ID Input";
                    form1.Controls.Add(label);
                    lblSuccessMessage.Text = "Registration failed. Please check your inputs.";
                }
                else
                {
                    rdrcheck1.Close();

                    using (SqlCommand cmd = new SqlCommand("Procedures_StudentRegisterSecondMakeup", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("@StudentID", id));
                        cmd.Parameters.Add(new SqlParameter("@courseID", courseID));
                        cmd.Parameters.Add(new SqlParameter("@studentCurr_sem", currentSemester));
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        lblSuccessMessage.Text = "Registration successful!";
                    }
                }
            }
        }
    }
}