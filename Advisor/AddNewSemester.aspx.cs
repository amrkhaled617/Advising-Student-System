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
    public partial class AddNewSemester : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void addNewSemester(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System_11"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            String semesterCode = SemesterCode.Text;
            if (semesterCode == "")
            {
                Label label = new Label();
                label.Text = "Insert in Semester Code";
                form1.Controls.Add(label);
                return;
            }
            String startDate = StartDate.Text;
            String endDate = EndDate.Text;
            SqlCommand semesterCourses = new SqlCommand("AdminAddingSemester", conn);
            semesterCourses.CommandType = CommandType.StoredProcedure;
            semesterCourses.Parameters.Add(new SqlParameter("@semester_code",semesterCode));
            semesterCourses.Parameters.Add(new SqlParameter("@start_date", startDate));
            semesterCourses.Parameters.Add(new SqlParameter("@end_date", endDate));
            SqlCommand semesters = new SqlCommand("Select * From Semester", conn);
            SqlCommand checkDuplicate = new SqlCommand("Select * From Semester where semester_code=@semester_code", conn);
            semesters.CommandType = CommandType.Text;
            checkDuplicate.CommandType = CommandType.Text;
            checkDuplicate.Parameters.AddWithValue("@semester_code",semesterCode);
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
            SqlDataReader rdr = semesterCourses.ExecuteReader(CommandBehavior.CloseConnection);
            conn.Close();
            conn.Open();
            SqlDataReader rdr2= semesters.ExecuteReader(CommandBehavior.CloseConnection);
            Table table = new Table();
            table.CssClass = "table";


            TableHeaderRow headerRow = new TableHeaderRow();
            headerRow.Cells.Add(CreateTableCell("Semester Code"));
            headerRow.Cells.Add(CreateTableCell("Start Date"));
            headerRow.Cells.Add(CreateTableCell("End Date"));
            table.Rows.Add(headerRow);

            while (rdr2.Read())
            {
                TableRow row = new TableRow();

                row.Cells.Add(CreateTableCell((rdr2.IsDBNull(rdr2.GetOrdinal("semester_code"))) ? "NULL" : (rdr2.GetString(rdr2.GetOrdinal("semester_code")))));
                row.Cells.Add(CreateTableCell((rdr2.IsDBNull(rdr2.GetOrdinal("start_date"))) ? "NULL" : (rdr2.GetDateTime(rdr2.GetOrdinal("start_date")).ToString())));
                row.Cells.Add(CreateTableCell((rdr2.IsDBNull(rdr2.GetOrdinal("end_date"))) ? "NULL" : (rdr2.GetDateTime(rdr2.GetOrdinal("end_date")).ToString())));

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