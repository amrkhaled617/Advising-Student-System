using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;

namespace WebApplication2
{
    public partial class chooseinstructor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnRegister_Click4(object sender, EventArgs e)
        {
            int studentID = 1;
            int instructorID, courseID;
            string currentSemesterCode;

            int.TryParse(txtInstructorID2.Text, out instructorID);
            int.TryParse(txtCourseID3.Text, out courseID);
            currentSemesterCode = txtSemester.Text;

            if (!IsCurrentSemester(currentSemesterCode))
            {
                lblSuccessMessage.Text = "Invalid semester code. Please enter the current semester.";
                return;
            }

            if (!IsCourseTaughtByInstructor(courseID, instructorID, currentSemesterCode))
            {
                lblSuccessMessage.Text = "The provided course is not taught by the provided instructor in the specified semester.";
                return;
            }

            ExecuteChooseInstructorProcedure(studentID, instructorID, courseID, currentSemesterCode);

            lblSuccessMessage.Text = "Instructor chosen successfully!";
        }

        private void ExecuteChooseInstructorProcedure(int studentID, int instructorID, int courseID, string currentSemesterCode)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System_11"].ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand("Procedures_Chooseinstructor", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@StudentID", studentID));
                    cmd.Parameters.Add(new SqlParameter("@instrucorID", instructorID));
                    cmd.Parameters.Add(new SqlParameter("@CourseID", courseID));
                    cmd.Parameters.Add(new SqlParameter("@current_semester_code", currentSemesterCode));

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private bool IsCurrentSemester(string semesterCode)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System_11"].ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT start_date, end_date FROM Semester WHERE semester_code = @semesterCode", conn))
                {
                    cmd.Parameters.AddWithValue("@semesterCode", semesterCode);

                    conn.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        DateTime startDate = rdr.GetDateTime(0);
                        DateTime endDate = rdr.GetDateTime(1);

                        return DateTime.Now >= startDate && DateTime.Now <= endDate;
                    }

                    return false;
                }
            }
        }

        private bool IsCourseTaughtByInstructor(int courseID, int instructorID, string semesterCode)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System_11"].ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT 1 FROM Course_Semester cs " +
                                                       "INNER JOIN Instructor_Course ic ON cs.course_id = ic.course_id " +
                                                       "WHERE cs.course_id = @courseID AND ic.instructor_id = @instructorID " +
                                                       "AND cs.semester_code = @semesterCode", conn))
                {
                    cmd.Parameters.AddWithValue("@courseID", courseID);
                    cmd.Parameters.AddWithValue("@instructorID", instructorID);
                    cmd.Parameters.AddWithValue("@semesterCode", semesterCode);

                    conn.Open();

                    return cmd.ExecuteScalar() != null;
                }
            }
        }
    }
}
