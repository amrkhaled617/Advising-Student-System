using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace WebApplication1
{
    public partial class LinkInstructorToCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void linkInstructorToCourse(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System_11"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            String courseId = CourseID.Text;
            String instructorId = InstructorID.Text;
            String slotId = SlotID.Text;
            SqlCommand command = new SqlCommand("Procedures_AdminLinkInstructor", conn);
            SqlCommand check1 = new SqlCommand("Select * From Course where course_id=@cours_id",conn);
            SqlCommand check2 = new SqlCommand("Select * From Instructor where instructor_id=@instructor_id", conn);
            SqlCommand check3 = new SqlCommand("Select * From Slot where slot_id=@slot_id", conn);
            check1.CommandType= CommandType.Text;
            check2.CommandType = CommandType.Text;
            check3.CommandType = CommandType.Text;
            check1.Parameters.AddWithValue("@cours_id", courseId);
            check2.Parameters.AddWithValue("@instructor_id", instructorId);
            check3.Parameters.AddWithValue("@slot_id", slotId);
            conn.Open();
            SqlDataReader rdrcheck1 = check1.ExecuteReader(CommandBehavior.CloseConnection);
            if (rdrcheck1.HasRows==false)
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
            conn.Open();
            SqlDataReader rdrcheck3 = check3.ExecuteReader(CommandBehavior.CloseConnection);
            if (rdrcheck3.HasRows == false)
            {
                Label label = new Label();
                label.Text = "Invalid Slot ID Input";
                form1.Controls.Add(label);
                return;
            }
            conn.Close();
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@cours_id", courseId));
            command.Parameters.Add(new SqlParameter("@instructor_id", instructorId));
            command.Parameters.Add(new SqlParameter("@slot_id", slotId));

            SqlCommand slots = new SqlCommand("Select * From Slot", conn);
            slots.CommandType = CommandType.Text;
            conn.Open();
            SqlDataReader rdr = command.ExecuteReader(CommandBehavior.CloseConnection);
            conn.Close();
            conn.Open();
            SqlDataReader rdr2 = slots.ExecuteReader(CommandBehavior.CloseConnection);
            Table table = new Table();
            table.CssClass = "table";


            TableHeaderRow headerRow = new TableHeaderRow();
            headerRow.Cells.Add(CreateTableCell("Slot ID"));
            headerRow.Cells.Add(CreateTableCell("Day"));
            headerRow.Cells.Add(CreateTableCell("Time"));
            headerRow.Cells.Add(CreateTableCell("Location"));
            headerRow.Cells.Add(CreateTableCell("Course ID"));
            headerRow.Cells.Add(CreateTableCell("Instructor ID"));
            table.Rows.Add(headerRow);

            while (rdr2.Read())
            {
                TableRow row = new TableRow();
                row.Cells.Add(CreateTableCell((rdr2.IsDBNull(rdr2.GetOrdinal("slot_id"))) ? "NULL" : (rdr2.GetInt32(rdr2.GetOrdinal("slot_id")).ToString())));
                row.Cells.Add(CreateTableCell((rdr2.IsDBNull(rdr2.GetOrdinal("day"))) ? "NULL" : (rdr2.GetString(rdr2.GetOrdinal("day")))));
                row.Cells.Add(CreateTableCell((rdr2.IsDBNull(rdr2.GetOrdinal("time"))) ? "NULL" : (rdr2.GetString(rdr2.GetOrdinal("time")))));
                row.Cells.Add(CreateTableCell((rdr2.IsDBNull(rdr2.GetOrdinal("location"))) ? "NULL" : (rdr2.GetString(rdr2.GetOrdinal("location")))));
                row.Cells.Add(CreateTableCell((rdr2.IsDBNull(rdr2.GetOrdinal("course_id"))) ? "NULL" : (rdr2.GetInt32(rdr2.GetOrdinal("course_id")).ToString())));
                row.Cells.Add(CreateTableCell((rdr2.IsDBNull(rdr2.GetOrdinal("instructor_id"))) ? "NULL" : (rdr2.GetInt32(rdr2.GetOrdinal("instructor_id")).ToString())));


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