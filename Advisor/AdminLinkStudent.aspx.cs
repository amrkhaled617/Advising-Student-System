using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace WebApplication1
{
    public partial class AdminLinkStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void linkStudentToCourseWithInstructor(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System_11"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            String courseId = CourseID.Text;
            String instructorId = InstructorID.Text;
            String semesterCode = SemesterCode.Text;
            String studentId = StudentID.Text;
            SqlCommand command = new SqlCommand("Procedures_AdminLinkStudent", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@cours_id", courseId));
            command.Parameters.Add(new SqlParameter("@instructor_id", instructorId));
            command.Parameters.Add(new SqlParameter("@studentID", studentId));
            command.Parameters.Add(new SqlParameter("@semester_code", semesterCode));


            SqlCommand takes = new SqlCommand("Select * From Student_Instructor_Course_take", conn);
            SqlCommand check1 = new SqlCommand("Select * From Course where course_id=@cours_id", conn);
            SqlCommand check2 = new SqlCommand("Select * From Instructor where instructor_id=@instructor_id", conn);
            SqlCommand checkDuplicate = new SqlCommand("Select * From Student_Instructor_Course_take where course_id=@cours_id and semester_code=@semester_code and student_id=@studentID",conn);
            check1.CommandType = CommandType.Text;
            check2.CommandType = CommandType.Text;
            checkDuplicate.CommandType = CommandType.Text;
            check1.Parameters.AddWithValue("@cours_id", courseId);
            check2.Parameters.AddWithValue("@instructor_id", instructorId);
            checkDuplicate.Parameters.AddWithValue("@cours_id", courseId);
            checkDuplicate.Parameters.AddWithValue("@semester_code", semesterCode);
            checkDuplicate.Parameters.AddWithValue("@studentID", studentId);
            conn.Open();
            SqlDataReader rdrCheckDuplicate = checkDuplicate.ExecuteReader(CommandBehavior.CloseConnection);
            if (rdrCheckDuplicate.HasRows == true)
            {
                Label label = new Label();
                label.Text = "Duplicate Values in the Primary Key";
                form1.Controls.Add(label);
                return;
            }
            conn.Close();
            conn.Open();
            SqlDataReader rdrcheck1 = check1.ExecuteReader(CommandBehavior.CloseConnection);
            if (rdrcheck1.HasRows == false)
            {
                Label label = new Label();
                label.Text = "Invalid Course ID Input";
                form1.Controls.Add(label);
                return;
            }
            conn.Close();
            conn.Open();
            SqlDataReader rdrcheck2 = check2.ExecuteReader(CommandBehavior.CloseConnection);
            if (rdrcheck2.HasRows == false)
            {
                Label label = new Label();
                label.Text = "Invalid Instrucor ID Input";
                form1.Controls.Add(label);
                return;
            }
            conn.Close();
            SqlCommand check3 = new SqlCommand("Select * From Semester where semester_code=@semester_code", conn);
            SqlCommand check4 = new SqlCommand("Select * From Student where student_id=@studentID", conn);
            check3.CommandType = CommandType.Text;
            check4.CommandType = CommandType.Text;
            check3.Parameters.AddWithValue("@semester_code", semesterCode);
            check4.Parameters.AddWithValue("@studentID", studentId);
            conn.Open();
            SqlDataReader rdrcheck3 = check3.ExecuteReader(CommandBehavior.CloseConnection);
            if (rdrcheck3.HasRows == false)
            {
                Label label = new Label();
                label.Text = "Invalid Semester Code Input";
                form1.Controls.Add(label);
                return;
            }
            conn.Close();
            conn.Open();
            SqlDataReader rdrcheck4 = check4.ExecuteReader(CommandBehavior.CloseConnection);
            if (rdrcheck4.HasRows == false)
            {
                Label label = new Label();
                label.Text = "Invalid Student ID Input";
                form1.Controls.Add(label);
                return;
            }
            conn.Close();
            takes.CommandType = CommandType.Text;
            conn.Open();
            SqlDataReader rdr = command.ExecuteReader(CommandBehavior.CloseConnection);
            conn.Close();
            conn.Open();
            SqlDataReader rdr2 = takes.ExecuteReader(CommandBehavior.CloseConnection);
            Table table = new Table();
            table.CssClass = "table";



            TableHeaderRow headerRow = new TableHeaderRow();
            headerRow.Cells.Add(CreateTableCell("Student ID"));
            headerRow.Cells.Add(CreateTableCell("Course ID"));
            headerRow.Cells.Add(CreateTableCell("Instructor ID"));
            headerRow.Cells.Add(CreateTableCell("Semester Code"));
            headerRow.Cells.Add(CreateTableCell("Exam Type"));
            headerRow.Cells.Add(CreateTableCell("Grade"));
            table.Rows.Add(headerRow);

            while (rdr2.Read())
            {
                TableRow row = new TableRow();
                row.Cells.Add(CreateTableCell((rdr2.IsDBNull(rdr2.GetOrdinal("student_id"))) ? "NULL" : (rdr2.GetInt32(rdr2.GetOrdinal("student_id")).ToString())));
                row.Cells.Add(CreateTableCell((rdr2.IsDBNull(rdr2.GetOrdinal("course_id"))) ? "NULL" : (rdr2.GetInt32(rdr2.GetOrdinal("course_id")).ToString())));
                row.Cells.Add(CreateTableCell((rdr2.IsDBNull(rdr2.GetOrdinal("instructor_id"))) ? "NULL" : (rdr2.GetInt32(rdr2.GetOrdinal("instructor_id")).ToString())));
                row.Cells.Add(CreateTableCell((rdr2.IsDBNull(rdr2.GetOrdinal("semester_code"))) ? "NULL" : (rdr2.GetString(rdr2.GetOrdinal("semester_code")))));
                row.Cells.Add(CreateTableCell((rdr2.IsDBNull(rdr2.GetOrdinal("exam_type"))) ? "NULL" : (rdr2.GetString(rdr2.GetOrdinal("exam_type")))));
                row.Cells.Add(CreateTableCell((rdr2.IsDBNull(rdr2.GetOrdinal("grade"))) ? "NULL" : (rdr2.GetString(rdr2.GetOrdinal("grade")))));

                // Add the row to the table
                table.Rows.Add(row);
            }
            form1.Controls.Add(table);
            conn.Close();
        }
        private TableCell CreateTableCell(string text)
        {
            TableCell cell = new TableCell();
            cell.Text = text;
            return cell;
        }
    
    }
}