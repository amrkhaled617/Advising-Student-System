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
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void register1_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Advising_System_11"].ToString();


            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string fname = firstname.Text;
                string lname = lastname.Text;
                string rpass = rpassword.Text;
                string fac = faculty.Text;
                string em = email.Text;
                string maj = major.Text;
                int sem = Int32.Parse(semster.Text);



                using (SqlCommand reg = new SqlCommand("Procedures_StudentRegistration", conn))
                {


                    reg.CommandType = System.Data.CommandType.StoredProcedure;
                    reg.Parameters.Add(new SqlParameter("@first_name", SqlDbType.VarChar)).Value = fname;
                    reg.Parameters.Add(new SqlParameter("@last_name", SqlDbType.VarChar)).Value = lname;
                    reg.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar)).Value = rpass;
                    reg.Parameters.Add(new SqlParameter("@faculty", SqlDbType.VarChar)).Value = fac;
                    reg.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar)).Value = em;
                    reg.Parameters.Add(new SqlParameter("@major", SqlDbType.VarChar)).Value = maj;
                    reg.Parameters.Add(new SqlParameter("@Semester", SqlDbType.Int)).Value = sem;

                    SqlParameter sidd = reg.Parameters.Add("@Student_id", SqlDbType.Int);
                    sidd.Direction = ParameterDirection.Output;


                    conn.Open();
                    int rowsaffected = reg.ExecuteNonQuery();

                    if (rowsaffected > 0)
                    {
                        Response.Write("Successfully registerd");
                        Response.Write("your student id is " + sidd.Value.ToString());

                    }
                    else
                    {
                        Response.Write("Failed to register please try again");
                    }







                }
            }


        }
    }
}

