using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace WebApplication1
{
    public partial class queries : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void listAdvisors(object sender, EventArgs e)
        {
            Response.Redirect("ListAdvisors.aspx");
        }
        protected void listStudentsWithAdvisors(object sender, EventArgs e)
        {
            Response.Redirect("ListStudentwithAdvisors.aspx");
        }
        protected void listPendingRequests(object sender, EventArgs e)
        {
            Response.Redirect("ListPendingRequests.aspx");
        }
        protected void addNewSemester(object sender, EventArgs e)
        {
            Response.Redirect("AddNewSemester.aspx");
        }
        protected void addNewCourse(object sender, EventArgs e)
        {
            Response.Redirect("AddNewCourse.aspx");
        }
        protected void linkInstructorToCourse(object sender, EventArgs e)
        {
            Response.Redirect("LinkInstructorToCourse.aspx");
        }
        protected void linkStudentToAdvisor(object sender, EventArgs e)
        {
            Response.Redirect("LinkStudentToAdvisor.aspx");
        }
        protected void linkStudentToCourseWithInstructor(object sender, EventArgs e)
        {
            Response.Redirect("AdminLinkStudent.aspx");
        }
        protected void viewInstructorsWithCourses(object sender, EventArgs e)
        {
            Response.Redirect("ViewInstructorsCourses.aspx");
        }
        protected void fetchAllSemestersWithCourses(object sender, EventArgs e)
        {
            Response.Redirect("FetchSemesterswithCourses.aspx");
        }
        protected void NextPage(object sender,EventArgs e)
        {
            Response.Redirect("Main_Page.aspx");
        }

    }
}