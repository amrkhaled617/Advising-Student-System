using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class ListAdvisors : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           string connStr = WebConfigurationManager.ConnectionStrings["Advising_System_11"].ToString();
           SqlConnection conn = new SqlConnection(connStr);

            SqlCommand advisors = new SqlCommand("[Procedures_AdminListAdvisors]", conn);
            advisors.CommandType = CommandType.StoredProcedure;

            conn.Open();
            SqlDataReader rdr = advisors.ExecuteReader(CommandBehavior.CloseConnection);
        
            Table table = new Table();
            table.CssClass = "table";

           
            TableHeaderRow headerRow = new TableHeaderRow();
            headerRow.Cells.Add(CreateTableCell("Advisor ID"));
            headerRow.Cells.Add(CreateTableCell("Advisor Name"));
            headerRow.Cells.Add(CreateTableCell("Email"));
            headerRow.Cells.Add(CreateTableCell("Office"));
            headerRow.Cells.Add(CreateTableCell("Password"));
            table.Rows.Add(headerRow);
            
            while (rdr.Read())
            {
                TableRow row = new TableRow();
                row.Cells.Add(CreateTableCell((rdr.IsDBNull(rdr.GetOrdinal("advisor_id"))) ? "NULL" : (rdr.GetInt32(rdr.GetOrdinal("advisor_id")).ToString())));
                row.Cells.Add(CreateTableCell((rdr.IsDBNull(rdr.GetOrdinal("advisor_name"))) ? "NULL" : (rdr.GetString(rdr.GetOrdinal("advisor_name")))));
                row.Cells.Add(CreateTableCell((rdr.IsDBNull(rdr.GetOrdinal("email"))) ? "NULL" : (rdr.GetString(rdr.GetOrdinal("email")))));
                row.Cells.Add(CreateTableCell((rdr.IsDBNull(rdr.GetOrdinal("office"))) ? "NULL" : (rdr.GetString(rdr.GetOrdinal("office")))));
                row.Cells.Add(CreateTableCell((rdr.IsDBNull(rdr.GetOrdinal("password"))) ? "NULL" : (rdr.GetString(rdr.GetOrdinal("password")))));

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