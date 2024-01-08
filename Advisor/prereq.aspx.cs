using System;
using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class prereq : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System_11"].ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT * FROM view_Course_prerequisites";

                conn.Open();

                using (SqlCommand viewQuery = new SqlCommand(query, conn))
                {
                    using (SqlDataReader rdr = viewQuery.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        Table table = new Table();
                        table.CssClass = "table"; 

                        TableHeaderRow headerRow = new TableHeaderRow();
                        headerRow.Cells.Add(CreateTableCell("Course ID"));
                        headerRow.Cells.Add(CreateTableCell("Course"));
                        headerRow.Cells.Add(CreateTableCell("Major"));
                        headerRow.Cells.Add(CreateTableCell("is_offered"));
                        headerRow.Cells.Add(CreateTableCell("Credit Hours"));
                        headerRow.Cells.Add(CreateTableCell("Semester"));
                        headerRow.Cells.Add(CreateTableCell("Prerequisite Course ID"));
                        headerRow.Cells.Add(CreateTableCell("Prerequisite Course Name"));

                        table.Rows.Add(headerRow);

                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                TableRow dataRow = new TableRow();
                                dataRow.Cells.Add(CreateTableCell((rdr.IsDBNull(rdr.GetOrdinal("course_id"))) ? "NULL" : (rdr.GetInt32(rdr.GetOrdinal("course_id")).ToString())));
                                dataRow.Cells.Add(CreateTableCell((rdr.IsDBNull(rdr.GetOrdinal("name"))) ? "NULL" : (rdr.GetString(rdr.GetOrdinal("name")).ToString())));
                                dataRow.Cells.Add(CreateTableCell((rdr.IsDBNull(rdr.GetOrdinal("major"))) ? "NULL" : (rdr.GetString(rdr.GetOrdinal("major")).ToString())));
                                dataRow.Cells.Add(CreateTableCell((rdr.IsDBNull(rdr.GetOrdinal("is_offered"))) ? "NULL" : (rdr.GetBoolean(rdr.GetOrdinal("is_offered")).ToString())));
                                dataRow.Cells.Add(CreateTableCell((rdr.IsDBNull(rdr.GetOrdinal("credit_hours"))) ? "NULL" : (rdr.GetInt32(rdr.GetOrdinal("credit_hours")).ToString())));
                                dataRow.Cells.Add(CreateTableCell((rdr.IsDBNull(rdr.GetOrdinal("semester"))) ? "NULL" : (rdr.GetInt32(rdr.GetOrdinal("semester")).ToString())));
                                dataRow.Cells.Add(CreateTableCell((rdr.IsDBNull(rdr.GetOrdinal("preRequsite_course_id"))) ? "NULL" : (rdr.GetInt32(rdr.GetOrdinal("preRequsite_course_id")).ToString())));
                                dataRow.Cells.Add(CreateTableCell((rdr.IsDBNull(rdr.GetOrdinal("preRequsite_course_name"))) ? "NULL" : (rdr.GetString(rdr.GetOrdinal("preRequsite_course_name")).ToString())));

                                table.Rows.Add(dataRow);
                            }

                            form1.Controls.Add(table);
                        }
                        else
                        {
                            Label noDataLabel = new Label();
                            noDataLabel.Text = "No data available.";
                            form1.Controls.Add(noDataLabel);
                        }
                    }
                }
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
