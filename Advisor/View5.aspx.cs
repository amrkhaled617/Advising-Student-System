using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Milestone3
{
    public partial class View5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Connection string from Web.config
            string connstr = WebConfigurationManager.ConnectionStrings["Advising_System_11"].ToString();

            // Create a SqlConnection using the connection string
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                // SQL query to select data from the Student_Payment view
                string query = "SELECT * FROM Semster_offered_Courses";

                // Create a SqlCommand to execute the query
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Open the connection
                    conn.Open();

                    // Create a SqlDataAdapter to retrieve the data from the database
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        // Create a DataTable to store the results
                        DataTable dataTable = new DataTable();

                        // Fill the DataTable with the results from the query
                        adapter.Fill(dataTable);

                        // Now, you have the data in the 'dataTable' variable
                        // You can use this data to update your web form as needed

                        // For example, assuming you have a GridView control in your web form:
                        GridView1.DataSource = dataTable;
                        GridView1.DataBind();
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Main_Page.aspx");
        }
    }
}