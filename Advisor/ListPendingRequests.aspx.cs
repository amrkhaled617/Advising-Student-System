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
    public partial class ListPendingRequests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System_11"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand requests = new SqlCommand("Select * From all_Pending_Requests", conn);
            requests.CommandType = CommandType.Text;

            conn.Open();
            SqlDataReader rdr = requests.ExecuteReader(CommandBehavior.CloseConnection);
            Table table = new Table();
            table.CssClass = "table";


            TableHeaderRow headerRow = new TableHeaderRow();
            headerRow.Cells.Add(CreateTableCell("Request ID"));
            headerRow.Cells.Add(CreateTableCell("Type"));
            headerRow.Cells.Add(CreateTableCell("Comment"));
            headerRow.Cells.Add(CreateTableCell("Status"));
            headerRow.Cells.Add(CreateTableCell("Credit Hours"));
            headerRow.Cells.Add(CreateTableCell("Course ID"));
            headerRow.Cells.Add(CreateTableCell("Student ID"));
            headerRow.Cells.Add(CreateTableCell("Advisor ID"));
            table.Rows.Add(headerRow);


            while (rdr.Read())
            {
                TableRow row = new TableRow();
                row.Cells.Add(CreateTableCell((rdr.GetInt32(rdr.GetOrdinal("request_id")).ToString())));
                row.Cells.Add(CreateTableCell((rdr.IsDBNull(rdr.GetOrdinal("type"))) ? "NULL" : (rdr.GetString(rdr.GetOrdinal("type")))));
                row.Cells.Add(CreateTableCell((rdr.IsDBNull(rdr.GetOrdinal("comment"))) ? "NULL" : (rdr.GetString(rdr.GetOrdinal("comment")))));
                row.Cells.Add(CreateTableCell((rdr.IsDBNull(rdr.GetOrdinal("status"))) ? "NULL" : (rdr.GetString(rdr.GetOrdinal("status")))));
                row.Cells.Add(CreateTableCell((rdr.IsDBNull(rdr.GetOrdinal("credit_hours"))) ? "NULL" : (rdr.GetInt32(rdr.GetOrdinal("credit_hours")).ToString())));
                row.Cells.Add(CreateTableCell((rdr.IsDBNull(rdr.GetOrdinal("course_id"))) ? "NULL" : (rdr.GetInt32(rdr.GetOrdinal("course_id")).ToString())));
                row.Cells.Add(CreateTableCell((rdr.IsDBNull(rdr.GetOrdinal("student_id"))) ? "NULL" : (rdr.GetInt32(rdr.GetOrdinal("student_id")).ToString())));
                row.Cells.Add(CreateTableCell((rdr.IsDBNull(rdr.GetOrdinal("advisor_id"))) ? "NULL" : (rdr.GetInt32(rdr.GetOrdinal("advisor_id")).ToString())));

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
