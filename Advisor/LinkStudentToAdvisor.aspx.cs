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
    public partial class LinkStudentToAdvisor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void linkStudentToAdvisor(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System_11"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            String studentId = StudentID.Text;
            String advisorId = AdvisorID.Text;
            SqlCommand command = new SqlCommand("Procedures_AdminLinkStudentToAdvisor", conn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@studentID", studentId));
            command.Parameters.Add(new SqlParameter("@advisorID", advisorId));

            SqlCommand students = new SqlCommand("Select * From Student", conn);
            SqlCommand check1 = new SqlCommand("Select * From Student where student_id=@studentID", conn);
            SqlCommand check2 = new SqlCommand("Select * From Advisor where advisor_id=@advisorID", conn);
            check1.CommandType = CommandType.Text;
            check2.CommandType = CommandType.Text;
            check1.Parameters.AddWithValue("@studentID", studentId);
            check2.Parameters.AddWithValue("@advisorID", advisorId);
            conn.Open();
            SqlDataReader rdrcheck1 = check1.ExecuteReader(CommandBehavior.CloseConnection);
            if (rdrcheck1.HasRows == false)
            {
                Label label = new Label();
                label.Text = "Invalid Student ID Input";
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
            students.CommandType = CommandType.Text;
            conn.Open();
            SqlDataReader rdr = command.ExecuteReader(CommandBehavior.CloseConnection);
            conn.Close();
            conn.Open();
            SqlDataReader rdr2 = students.ExecuteReader(CommandBehavior.CloseConnection);
            Table table = new Table();
            table.CssClass = "table";


            TableHeaderRow headerRow = new TableHeaderRow();
            headerRow.Cells.Add(CreateTableCell("Student ID"));

            headerRow.Cells.Add(CreateTableCell("Advisor ID"));

            table.Rows.Add(headerRow);

            while (rdr2.Read())
            {
                TableRow row = new TableRow();
                row.Cells.Add(CreateTableCell((rdr2.IsDBNull(rdr2.GetOrdinal("student_id"))) ? "NULL" : (rdr2.GetInt32(rdr2.GetOrdinal("student_id")).ToString())));
                row.Cells.Add(CreateTableCell((rdr2.IsDBNull(rdr2.GetOrdinal("advisor_id"))) ? "NULL" : (rdr2.GetInt32(rdr2.GetOrdinal("advisor_id")).ToString())));


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