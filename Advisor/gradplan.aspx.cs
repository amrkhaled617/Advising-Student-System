using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
using System;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class gradplan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string username = Session["Username"].ToString();
            int id = Int32.Parse(username);
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System_11"].ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand gradplan = new SqlCommand("SELECT * FROM FN_StudentViewGP(@student_id)", conn);
                gradplan.CommandType = CommandType.Text;
                gradplan.Parameters.Add(new SqlParameter("@student_id", id));  

                conn.Open();
                SqlDataReader rdr = gradplan.ExecuteReader(CommandBehavior.CloseConnection);
                Table table = new Table();
                table.CssClass = "table";

                TableHeaderRow headerRow = new TableHeaderRow();
                headerRow.Cells.Add(CreateTableCell("Student Name"));
                headerRow.Cells.Add(CreateTableCell("ID"));
                headerRow.Cells.Add(CreateTableCell("GradPlan ID"));
                headerRow.Cells.Add(CreateTableCell("Course ID"));
                headerRow.Cells.Add(CreateTableCell("Course Name"));
                headerRow.Cells.Add(CreateTableCell("Semester"));
                headerRow.Cells.Add(CreateTableCell("Expected Grad Date"));
                headerRow.Cells.Add(CreateTableCell("Credit Hours"));
                headerRow.Cells.Add(CreateTableCell("Advisor ID"));

                table.Rows.Add(headerRow);

                while (rdr.Read())
                {
                    TableRow row = new TableRow();
                    row.Cells.Add(CreateTableCell((rdr.IsDBNull(rdr.GetOrdinal("Student_name"))) ? "NULL" : (rdr.GetString(rdr.GetOrdinal("Student_name")).ToString())));
                    row.Cells.Add(CreateTableCell((rdr.IsDBNull(rdr.GetOrdinal("student_id"))) ? "NULL" : (rdr.GetInt32(rdr.GetOrdinal("student_id")).ToString())));
                    row.Cells.Add(CreateTableCell((rdr.IsDBNull(rdr.GetOrdinal("plan_id"))) ? "NULL" : (rdr.GetInt32(rdr.GetOrdinal("plan_id")).ToString())));
                    row.Cells.Add(CreateTableCell((rdr.IsDBNull(rdr.GetOrdinal("course_id"))) ? "NULL" : (rdr.GetInt32(rdr.GetOrdinal("course_id")).ToString())));
                    row.Cells.Add(CreateTableCell((rdr.IsDBNull(rdr.GetOrdinal("name"))) ? "NULL" : (rdr.GetString(rdr.GetOrdinal("name")).ToString())));
                    row.Cells.Add(CreateTableCell((rdr.IsDBNull(rdr.GetOrdinal("semester_code"))) ? "NULL" : (rdr.GetString(rdr.GetOrdinal("semester_code")).ToString())));
                    row.Cells.Add(CreateTableCell((rdr.IsDBNull(rdr.GetOrdinal("expected_grad_date"))) ? "NULL" : (rdr.GetDateTime(rdr.GetOrdinal("expected_grad_date")).ToString())));
                    row.Cells.Add(CreateTableCell((rdr.IsDBNull(rdr.GetOrdinal("semester_credit_hours"))) ? "NULL" : (rdr.GetInt32(rdr.GetOrdinal("semester_credit_hours")).ToString())));
                    row.Cells.Add(CreateTableCell((rdr.IsDBNull(rdr.GetOrdinal("advisor_id"))) ? "NULL" : (rdr.GetInt32(rdr.GetOrdinal("advisor_id")).ToString())));

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
