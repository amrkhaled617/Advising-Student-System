using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.Configuration;
using System.Web.UI.WebControls;


namespace WebApplication1
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void login(object sender, EventArgs e)
        {
          //  string connStr = WebConfigurationManager.ConnectionStrings["Advising_System_11"].ToString();
          //  SqlConnection conn = new SqlConnection(connStr);

            String id = username.Text;
            String pass = password.Text;
           // SqlCommand loginproc = new SqlCommand("userLogin", conn);
           // loginproc.Parameters.Add(new SqlParameter("@id", id));
           // loginproc.Parameters.Add(new SqlParameter("@password", pass));
           // SqlParameter success = loginproc.Parameters.Add("@success", SqlDbType.Int);
            
            if (id == "1" && pass == "123")
            {
                Response.Redirect("queries.aspx");
            }
            else
            {
                Label myLabel = new Label();
                myLabel.Text = "Invalid username or password";
                form1.Controls.Add(myLabel);
            }

        }
    }
}