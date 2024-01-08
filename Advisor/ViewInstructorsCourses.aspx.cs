using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class ViewInstructorsCourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System_11"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand InstructorsCourses = new SqlCommand("Select * From Instructors_AssignedCourses", conn);
            InstructorsCourses.CommandType = CommandType.Text;//View

            conn.Open();
            SqlDataReader rdr = InstructorsCourses.ExecuteReader(CommandBehavior.CloseConnection);
            Table table = new Table();
            table.CssClass = "table";
            //Instructor.name as Instructor
            //Course.name As Course
            //Two columns have name 
            TableHeaderRow headerRow = new TableHeaderRow();
            headerRow.Cells.Add(CreateTableCell("Instructor ID"));
            headerRow.Cells.Add(CreateTableCell("Instructor Name"));
            headerRow.Cells.Add(CreateTableCell("Course ID"));
            headerRow.Cells.Add(CreateTableCell("Course Name"));
            table.Rows.Add(headerRow);

            while (rdr.Read())
            {
                TableRow row = new TableRow();
                row.Cells.Add(CreateTableCell((rdr.IsDBNull(rdr.GetOrdinal("instructor_id"))) ? "NULL" : (rdr.GetInt32(rdr.GetOrdinal("instructor_id")).ToString())));
                row.Cells.Add(CreateTableCell((rdr.IsDBNull(rdr.GetOrdinal("Instructor"))) ? "NULL" : (rdr.GetString(rdr.GetOrdinal("Instructor")))));
                row.Cells.Add(CreateTableCell((rdr.IsDBNull(rdr.GetOrdinal("course_id"))) ? "NULL" : (rdr.GetInt32(rdr.GetOrdinal("course_id")).ToString())));
                row.Cells.Add(CreateTableCell((rdr.IsDBNull(rdr.GetOrdinal("Course"))) ? "NULL" : (rdr.GetString(rdr.GetOrdinal("Course")))));

                // Add the row to the table
                table.Rows.Add(row);
            }
            form1.Controls.Add(table);
        }
            private TableCell CreateTableCell(string text)
            {
                TableCell cell = new TableCell();
                cell.Text = text;
                return cell;
            }
    }
}