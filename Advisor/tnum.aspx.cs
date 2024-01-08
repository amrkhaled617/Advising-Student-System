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
    public partial class tnum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addnum_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Advising_System_11"].ToString();


            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string username = Session["Username"].ToString();
                int id = Int32.Parse(username);
                string number = tnumber.Text;
                using (SqlCommand addnum = new SqlCommand("Procedures_StudentaddMobile", conn))
                {


                    addnum.CommandType = System.Data.CommandType.StoredProcedure;
                    addnum.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.Int)).Value = id;
                    addnum.Parameters.Add(new SqlParameter("@mobile_number", SqlDbType.VarChar)).Value = number;


                    conn.Open();
                    int rowsaffected = addnum.ExecuteNonQuery();

                    if (rowsaffected > 0)
                    {
                        Response.Write("Successfully added number");
                    }
                    else
                    {
                        Response.Write("Failed to add number please try again");
                    }







                }
            }


        }
    }
}
