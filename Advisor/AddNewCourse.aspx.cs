using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class AddNewCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void addNewCourse(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System_11"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            String major = Major.Text;
            if (major == "")
            {
                major = "NULL";
            }
            String semester = Semester.Text;
            String creditHours = CreditHours.Text;
            String name = Name.Text;
            if (name == "")
            {
                name = "NULL";
            }
            String isOffered = IsOffered.Text;
            SqlCommand command = new SqlCommand("Procedures_AdminAddingCourse", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@major", major));
            command.Parameters.Add(new SqlParameter("@semester", semester));
            command.Parameters.Add(new SqlParameter("@credit_hours", creditHours));
            command.Parameters.Add(new SqlParameter("@name", name));
            command.Parameters.Add(new SqlParameter("@is_offered", isOffered));

            SqlCommand courses = new SqlCommand("Select * From Course", conn);
            courses.CommandType = CommandType.Text;
            conn.Open();
            SqlDataReader rdr = command.ExecuteReader(CommandBehavior.CloseConnection);
            conn.Close();
            conn.Open();
            SqlDataReader rdr2 = courses.ExecuteReader(CommandBehavior.CloseConnection);
            Table table = new Table();
            table.CssClass = "table";


            TableHeaderRow headerRow = new TableHeaderRow();
            headerRow.Cells.Add(CreateTableCell("Course ID"));
            headerRow.Cells.Add(CreateTableCell("Name"));
            headerRow.Cells.Add(CreateTableCell("Major"));
            headerRow.Cells.Add(CreateTableCell("Is Offered"));
            headerRow.Cells.Add(CreateTableCell("Credit Hours"));
            headerRow.Cells.Add(CreateTableCell("Semester"));
            table.Rows.Add(headerRow);

            while (rdr2.Read())
            {
                TableRow row = new TableRow();
                row.Cells.Add(CreateTableCell((rdr2.IsDBNull(rdr2.GetOrdinal("course_id"))) ? "NULL" : (rdr2.GetInt32(rdr2.GetOrdinal("course_id")).ToString())));
                row.Cells.Add(CreateTableCell((rdr2.IsDBNull(rdr2.GetOrdinal("name"))) ? "NULL" : (rdr2.GetString(rdr2.GetOrdinal("name")))));
                row.Cells.Add(CreateTableCell((rdr2.IsDBNull(rdr2.GetOrdinal("major"))) ? "NULL" : (rdr2.GetString(rdr2.GetOrdinal("major")))));
                row.Cells.Add(CreateTableCell((rdr2.IsDBNull(rdr2.GetOrdinal("is_offered"))) ? "NULL" : (rdr2.GetBoolean(rdr2.GetOrdinal("is_offered"))).ToString()));
                row.Cells.Add(CreateTableCell((rdr2.IsDBNull(rdr2.GetOrdinal("credit_hours"))) ? "NULL" : (rdr2.GetInt32(rdr2.GetOrdinal("credit_hours")).ToString())));
                row.Cells.Add(CreateTableCell((rdr2.IsDBNull(rdr2.GetOrdinal("semester"))) ? "NULL" : (rdr2.GetInt32(rdr2.GetOrdinal("semester")).ToString())));

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