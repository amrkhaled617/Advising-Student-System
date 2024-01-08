using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Student1
{
    public partial class requiredcourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void doneoc_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Advising_System_11"].ToString();


            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string username = Session["Username"].ToString();
                int id = Int32.Parse(username);
                string csc = requiredcoursesid.Text;
                using (SqlCommand viewrc = new SqlCommand("Procedures_ViewRequiredCourses", conn))
                {


                    viewrc.CommandType = System.Data.CommandType.StoredProcedure;
                    viewrc.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.Int)).Value = id;
                    viewrc.Parameters.Add(new SqlParameter("@current_semester_code", SqlDbType.VarChar)).Value = csc;



                    conn.Open();


                    SqlDataAdapter adapter = new SqlDataAdapter(viewrc);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);


                    GridView3.DataSource = dataTable;
                    GridView3.DataBind();

                    if (dataTable.Rows.Count == 0)
                    {
                        Response.Write("There are no  required courses within the current semester");
                    }






                }
            }
        }
    }
}
