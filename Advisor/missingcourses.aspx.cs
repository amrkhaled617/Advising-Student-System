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
    public partial class missingcourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Advising_System_11"].ToString();


            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string username = Session["Username"].ToString();
                int id = Int32.Parse(username);

                using (SqlCommand viewms = new SqlCommand("Procedures_ViewMS", conn))
                {


                    viewms.CommandType = System.Data.CommandType.StoredProcedure;
                    viewms.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.Int)).Value = id;




                    conn.Open();


                    SqlDataAdapter adapter = new SqlDataAdapter(viewms);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);


                    GridView2.DataSource = dataTable;
                    GridView2.DataBind();


                    if (dataTable.Rows.Count == 0)
                    {
                        Response.Write("There are no  missing courses");
                    }






                }
            }


        }
    }
}
