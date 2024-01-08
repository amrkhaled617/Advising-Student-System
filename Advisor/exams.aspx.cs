    using System.Data.SqlClient;
using System.Data;
using System.Web.Configuration;
using System.Web.UI.WebControls;
using System;

namespace WebApplication2
{
    public partial class exams : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Advising_System_11"].ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT * FROM Courses_MakeupExams";

                conn.Open();

                using (SqlCommand viewQuery = new SqlCommand(query, conn))
                {
                    using (SqlDataReader rdr = viewQuery.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        Table table = new Table();
                        table.CssClass = "table"; 

                        TableHeaderRow headerRow = new TableHeaderRow();
                        headerRow.Cells.Add(CreateTableCell("Course ID"));
                        headerRow.Cells.Add(CreateTableCell("Exam ID"));
                        headerRow.Cells.Add(CreateTableCell("Exam Date"));
                        headerRow.Cells.Add(CreateTableCell("Exam Type"));

                        headerRow.Cells.Add(CreateTableCell("Course Name"));
                        headerRow.Cells.Add(CreateTableCell("Semester"));

                        table.Rows.Add(headerRow);

                        if (rdr.HasRows)
                        {
                            while (rdr.Read())
                            {
                                TableRow dataRow = new TableRow();
                                dataRow.Cells.Add(CreateTableCell((rdr.IsDBNull(rdr.GetOrdinal("course_id"))) ? "NULL" : (rdr.GetInt32(rdr.GetOrdinal("course_id")).ToString())));
                                dataRow.Cells.Add(CreateTableCell((rdr.IsDBNull(rdr.GetOrdinal("exam_id"))) ? "NULL" : (rdr.GetInt32(rdr.GetOrdinal("exam_id")).ToString())));
                                dataRow.Cells.Add(CreateTableCell((rdr.IsDBNull(rdr.GetOrdinal("date"))) ? "NULL" : (rdr.GetDateTime(rdr.GetOrdinal("date")).ToString())));
                                dataRow.Cells.Add(CreateTableCell((rdr.IsDBNull(rdr.GetOrdinal("type"))) ? "NULL" : (rdr.GetString(rdr.GetOrdinal("type")).ToString())));
                                dataRow.Cells.Add(CreateTableCell((rdr.IsDBNull(rdr.GetOrdinal("name"))) ? "NULL" : (rdr.GetString(rdr.GetOrdinal("name")).ToString())));
                                dataRow.Cells.Add(CreateTableCell((rdr.IsDBNull(rdr.GetOrdinal("semester"))) ? "NULL" : (rdr.GetInt32(rdr.GetOrdinal("semester")).ToString())));

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
