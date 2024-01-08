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
    public partial class FetchSemesterswithCourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System_11"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand semesterCourses = new SqlCommand("SELECT * FROM Semster_offered_Courses", conn);
            semesterCourses.CommandType = CommandType.Text;//View
            
            conn.Open();
            SqlDataReader rdr = semesterCourses.ExecuteReader(CommandBehavior.CloseConnection);
            Table table = new Table();
            table.CssClass = "table";


            TableHeaderRow headerRow = new TableHeaderRow();
            headerRow.Cells.Add(CreateTableCell("Course ID"));
            headerRow.Cells.Add(CreateTableCell("Course Name"));
            headerRow.Cells.Add(CreateTableCell("Semester Code"));
            table.Rows.Add(headerRow);

            while (rdr.Read())
            {
                TableRow row = new TableRow();
                row.Cells.Add(CreateTableCell((rdr.IsDBNull(rdr.GetOrdinal("course_id"))) ? "NULL" : (rdr.GetInt32(rdr.GetOrdinal("course_id")).ToString())));
      
                row.Cells.Add(CreateTableCell((rdr.IsDBNull(rdr.GetOrdinal("name"))) ? "NULL" : (rdr.GetString(rdr.GetOrdinal("name")))));
                row.Cells.Add(CreateTableCell((rdr.IsDBNull(rdr.GetOrdinal("semester_code"))) ? "NULL" : (rdr.GetString(rdr.GetOrdinal("semester_code")))));
         

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