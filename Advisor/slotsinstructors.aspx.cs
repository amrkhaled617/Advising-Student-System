using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
using System.Web.UI.WebControls;
using System;

namespace WebApplication2
{
    public partial class slotsinstructors : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnRegister_Click3(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System_11"].ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                int courseID, instructorID;
                int.TryParse(txtCourseID3.Text, out courseID);
                int.TryParse(txtInstructorID.Text, out instructorID);

                SqlCommand viewQuery = new SqlCommand("SELECT * FROM FN_StudentViewSlot(@CourseID, @InstructorID)", conn);
                viewQuery.CommandType = CommandType.Text;

                viewQuery.Parameters.Add(new SqlParameter("@CourseID", courseID));
                viewQuery.Parameters.Add(new SqlParameter("@InstructorID", instructorID));

                conn.Open();
                SqlDataReader rdr = viewQuery.ExecuteReader(CommandBehavior.CloseConnection);
                Table table = new Table();
                table.CssClass = "table";

                TableHeaderRow headerRow = new TableHeaderRow();
                headerRow.Cells.Add(CreateTableCell("Course ID"));
                headerRow.Cells.Add(CreateTableCell("Course"));
                headerRow.Cells.Add(CreateTableCell("Slot ID"));
                headerRow.Cells.Add(CreateTableCell("Day"));
                headerRow.Cells.Add(CreateTableCell("Time"));
                headerRow.Cells.Add(CreateTableCell("Location"));
                headerRow.Cells.Add(CreateTableCell("Instructor ID"));
                headerRow.Cells.Add(CreateTableCell("Instructor"));

                table.Rows.Add(headerRow);

                while (rdr.Read())
                {
                    TableRow row = new TableRow();
                    row.Cells.Add(CreateTableCell((rdr.IsDBNull(rdr.GetOrdinal("CourseID"))) ? "NULL" : (rdr.GetInt32(rdr.GetOrdinal("CourseID")).ToString())));
                    row.Cells.Add(CreateTableCell((rdr.IsDBNull(rdr.GetOrdinal("Course"))) ? "NULL" : (rdr.GetString(rdr.GetOrdinal("Course")).ToString())));
                    row.Cells.Add(CreateTableCell((rdr.IsDBNull(rdr.GetOrdinal("slot_id"))) ? "NULL" : (rdr.GetInt32(rdr.GetOrdinal("slot_id")).ToString())));
                    row.Cells.Add(CreateTableCell((rdr.IsDBNull(rdr.GetOrdinal("day"))) ? "NULL" : (rdr.GetString(rdr.GetOrdinal("day")).ToString())));
                    row.Cells.Add(CreateTableCell((rdr.IsDBNull(rdr.GetOrdinal("time"))) ? "NULL" : (rdr.GetString(rdr.GetOrdinal("time")).ToString())));
                    row.Cells.Add(CreateTableCell((rdr.IsDBNull(rdr.GetOrdinal("location"))) ? "NULL" : (rdr.GetString(rdr.GetOrdinal("location")).ToString())));
                    row.Cells.Add(CreateTableCell((rdr.IsDBNull(rdr.GetOrdinal("instructor_id"))) ? "NULL" : (rdr.GetInt32(rdr.GetOrdinal("instructor_id")).ToString())));
                    row.Cells.Add(CreateTableCell((rdr.IsDBNull(rdr.GetOrdinal("Instructor"))) ? "NULL" : (rdr.GetString(rdr.GetOrdinal("Instructor")).ToString())));

                    table.Rows.Add(row);
                }
                form1.Controls.Add(table);
            }
        }

      

        private TableCell CreateTableCell(string text)
        {
            TableCell cell = new TableCell();
            cell.Text = text;
            cell.Style.Add("padding", "10px"); 
            return cell;
        }
    }
}
