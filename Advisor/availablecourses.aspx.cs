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
    public partial class availablecourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void doneoc_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Advising_System_11"].ToString();


            using (SqlConnection conn = new SqlConnection(connStr))
            {
                
                
                string csc = availablecoursesid.Text;
                using (SqlCommand viewac = new SqlCommand("SELECT * FROM dbo.FN_SemsterAvailableCourses(@semstercode)", conn))
                {


                    
                
                    viewac.Parameters.Add(new SqlParameter("@semstercode", SqlDbType.VarChar)).Value = csc;



                    conn.Open();


                    SqlDataAdapter adapter = new SqlDataAdapter(viewac);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    GridView2.DataSource = dataTable;
                    GridView2.DataBind();

                    if (dataTable.Rows.Count == 0) {
                        Response.Write("There are no  available courses in the current semester");
                    }






                }
            }


        }
    }
}

        
        
  