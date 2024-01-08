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
    public partial class ListStudentwithAdvisors : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System_11"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand studentsadvisors = new SqlCommand("[AdminListStudentsWithAdvisors]", conn);
            studentsadvisors.CommandType = CommandType.StoredProcedure;

            conn.Open();
            SqlDataReader rdr = studentsadvisors.ExecuteReader(CommandBehavior.CloseConnection);
            Table table = new Table();
            table.CssClass = "table";


            TableHeaderRow headerRow = new TableHeaderRow();
            headerRow.Cells.Add(CreateTableCell("Student ID"));
            headerRow.Cells.Add(CreateTableCell("First Name"));
            headerRow.Cells.Add(CreateTableCell("Last Name"));
            headerRow.Cells.Add(CreateTableCell("Advisor ID"));
            headerRow.Cells.Add(CreateTableCell("Advisor Name"));
            table.Rows.Add(headerRow);

            while (rdr.Read())
            {
                TableRow row = new TableRow();
                row.Cells.Add(CreateTableCell((rdr.IsDBNull(rdr.GetOrdinal("student_id"))) ? "NULL" : (rdr.GetInt32(rdr.GetOrdinal("student_id")).ToString())));
                row.Cells.Add(CreateTableCell((rdr.IsDBNull(rdr.GetOrdinal("f_name"))) ? "NULL" : (rdr.GetString(rdr.GetOrdinal("f_name")))));
                row.Cells.Add(CreateTableCell((rdr.IsDBNull(rdr.GetOrdinal("l_name"))) ? "NULL" : (rdr.GetString(rdr.GetOrdinal("l_name")))));
                row.Cells.Add(CreateTableCell((rdr.IsDBNull(rdr.GetOrdinal("advisor_id"))) ? "NULL" : (rdr.GetInt32(rdr.GetOrdinal("advisor_id")).ToString())));
                row.Cells.Add(CreateTableCell((rdr.IsDBNull(rdr.GetOrdinal("advisor_name"))) ? "NULL" : (rdr.GetString(rdr.GetOrdinal("advisor_name")))));

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