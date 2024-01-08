using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class FirstPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Student(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }
        protected void Advisor(object sender, EventArgs e)
        {
            Response.Redirect("~/Advisor/Advisor_Home");
        }
        protected void Admin(object sender, EventArgs e)
        {
            Response.Redirect("LoginAdmin.aspx");
        }
    }
}