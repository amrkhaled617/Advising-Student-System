using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace WebApplication11
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Login(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Advising_System_11"].ToString();


            using (SqlConnection conn = new SqlConnection(connStr))
            {
                int id = Int32.Parse(Username.Text);
                string pass = Password.Text;

                using (SqlCommand loginproc = new SqlCommand("SELECT dbo.FN_StudentLogin(@Student_id, @password)", conn))
                {
                    loginproc.Parameters.Add(new SqlParameter("@Student_id", SqlDbType.Int)).Value = id;
                    loginproc.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar)).Value = pass;


                    conn.Open();
                    bool success = (bool)loginproc.ExecuteScalar();

                    if (success)
                    {
                        Session["Username"] = Username.Text;
                        Response.Write("Hello");
                        Response.Redirect("services.aspx");
                    }
                    else
                    {
                        Response.Write("incorrect id or password please try again");
                    }

                    conn.Close();

                }
            }
        }

        protected void register_Click(object sender, EventArgs e)
        {
            Response.Redirect("register.aspx");
        }
    }
}

