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
    public partial class sendcourserequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void send_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Advising_System_11"].ToString();


            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string username = Session["Username"].ToString();
                int id = Int32.Parse(username);
                string typ = type.Text;
                int cd = Int32.Parse(cid.Text);
                string cmnt = comment.Text;






                using (SqlCommand addnum = new SqlCommand("Procedures_StudentSendingCourseRequest", conn))
                {


                    addnum.CommandType = System.Data.CommandType.StoredProcedure;
                    addnum.Parameters.Add(new SqlParameter("@courseID ", SqlDbType.Int)).Value = cd;
                    addnum.Parameters.Add(new SqlParameter("@StudentID", SqlDbType.Int)).Value = id;
                    addnum.Parameters.Add(new SqlParameter("@type ", SqlDbType.VarChar)).Value = typ;
                    addnum.Parameters.Add(new SqlParameter("@comment", SqlDbType.VarChar)).Value = cmnt;


                    conn.Open();
                    int rowsaffected = addnum.ExecuteNonQuery();

                    if (rowsaffected > 0)
                    {
                        Response.Write("Successfully added course");
                    }
                    else
                    {
                        Response.Write("Failed to add course please try again");
                    }







                }
            }
        }
    }
}