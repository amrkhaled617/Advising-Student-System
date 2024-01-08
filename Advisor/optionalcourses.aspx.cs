using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication11
{
    public partial class optionalcourses : System.Web.UI.Page
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
                string csc = cscc.Text;
                using (SqlCommand viewoc = new SqlCommand("Procedures_ViewOptionalCourse", conn))
                {


                    viewoc.CommandType = System.Data.CommandType.StoredProcedure;
                    viewoc.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.Int)).Value = id;
                    viewoc.Parameters.Add(new SqlParameter("@current_semester_code", SqlDbType.VarChar)).Value = csc;



                    conn.Open();


                    SqlDataAdapter adapter = new SqlDataAdapter(viewoc);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    
                    GridView1.DataSource = dataTable;
                    GridView1.DataBind();

                    if (dataTable.Rows.Count == 0)
                    {
                        Response.Write("There are no  optional courses in the current semester");
                    }





                }
            }


        }
    }
}

