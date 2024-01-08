using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Configuration;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Milestone3
{
    public partial class Main_Page : Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Delete_Course_Click(object sender, EventArgs e)
        {
            String connstr = WebConfigurationManager.ConnectionStrings["Advising_System_11"].ToString();

            SqlConnection conn = new SqlConnection(connstr);

            try
            {
                int id = Int16.Parse(CourseIDtoDelete.Text);
                if (!CourseExists(id))
                {
                    Response.Write("<script>alert('Course does not exist')</script>");
                    return;
                }
                SqlCommand Del = new SqlCommand("Procedures_AdminDeleteCourse", conn);
                Del.CommandType = System.Data.CommandType.StoredProcedure;
                Del.Parameters.Add(new SqlParameter("@courseID", id));
                conn.Open();
                Del.ExecuteNonQuery();

                Response.Write("<script>alert('Course has been deleted successfully')</script>");

                conn.Close();
            }
            catch (System.FormatException e1)
            {
                Response.Write("<script>alert('Invalid Course ID')</script>");
            }





        }
        

        protected void DeleteSlots_Click(object sender, EventArgs e)
        {
            try { 
            String connstr = WebConfigurationManager.ConnectionStrings["Advising_System_11"].ToString();

            SqlConnection conn = new SqlConnection(connstr);

            String input = DeleteSlots.Text;
                if (!Semster_Exists(input))
                {
                    Response.Write("<script>alert('Wrong Semster ID')</script>");
                    return;
                }

            SqlCommand Del = new SqlCommand("Procedures_AdminDeleteSlots", conn);
            Del.CommandType = System.Data.CommandType.StoredProcedure;
            Del.Parameters.Add(new SqlParameter("@current_semester", input));
            conn.Open();
            Del.ExecuteNonQuery();

            Response.Write("<script>alert('Slot has been deleted successfully')</script>");

            conn.Close();
        }
            catch (System.FormatException e1)
            {
                Response.Write("<script>alert('Invalid Semster ID')</script>");
            }
}

        //--------------------ADD MAKE UP EXAM BUTTON---------------------------------------------
        protected void Button1_Click(object sender, EventArgs e)
        {
            String connstr = WebConfigurationManager.ConnectionStrings["Advising_System_11"].ToString();

            SqlConnection conn = new SqlConnection(connstr);
            try
            {
                int id = Int16.Parse(TextBox6.Text);
                if (!CourseExists(id))
                {
                    Response.Write("<script>alert('Course does not exist')</script>");
                    return;
                }
                DateTime date = Convert.ToDateTime(TextBox3.Text);
                String type = TextBox7.Text;
                SqlCommand Add_Exam = new SqlCommand("Procedures_AdminAddExam", conn);
                Add_Exam.CommandType = System.Data.CommandType.StoredProcedure;
                Add_Exam.Parameters.Add(new SqlParameter("@courseID", id));
                Add_Exam.Parameters.Add(new SqlParameter("@date", date));
                Add_Exam.Parameters.Add(new SqlParameter("@Type", type));

                conn.Open();
                Add_Exam.ExecuteNonQuery();

                Response.Write("<script>alert('Exam has been added successfully')</script>");

                conn.Close();
            }
            catch (System.FormatException e1)
            {
                Response.Write("<script>alert('Invalid Values Entered')</script>");
            }
            catch (System.Data.SqlClient.SqlException e2)
            {
                Response.Write("<script>alert('Course Does not Exist')</script>");
            }
        }

        //-------------------------------VIEW details for all payments along with their corresponding students-----------------------------
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("View1.aspx");
        }
        //-------------------------------Issue installments as per the number of installments for a certain payment------------------------------
        protected void Button5_Click(object sender, EventArgs e)
        {
            try { 
            String connstr = WebConfigurationManager.ConnectionStrings["Advising_System_11"].ToString();

            SqlConnection conn = new SqlConnection(connstr);

            int id = Int16.Parse(TextBox4.Text);
                if (!PaymentIDExists(id))
                {
                    Response.Write("<script>alert('Payment ID does not exist')</script>");
                    return;
                }

                SqlCommand issue = new SqlCommand("Procedures_AdminIssueInstallment", conn);
            issue.CommandType = System.Data.CommandType.StoredProcedure;
            issue.Parameters.Add(new SqlParameter("@payment_id", id));
            conn.Open();
            issue.ExecuteNonQuery();
            Response.Write("<script>alert('Installments Issued Successfully')</script>");
            conn.Close();
        }
            catch (System.FormatException e1)
            {
                Response.Write("<script>alert('Invalid Course ID')</script>");
            }
}
        ///-------------------------------------------Update a student status based on his/her financial status---------------------
        protected void Button4_Click(object sender, EventArgs e)
        {
            try { 
            String connstr = WebConfigurationManager.ConnectionStrings["Advising_System_11"].ToString();

            SqlConnection conn = new SqlConnection(connstr);

            int id = Int16.Parse(TextBox5.Text);
                if (!StudentIDExists(id))
                {
                    Response.Write("<script>alert('Student ID does not exist')</script>");
                    return;
                }

                SqlCommand Update_Status = new SqlCommand("FN_AdminCheckStudentStatus", conn);
            Update_Status.CommandType = System.Data.CommandType.StoredProcedure;
            Update_Status.Parameters.Add(new SqlParameter("@Student_id", id));
            conn.Open();
            Update_Status.ExecuteNonQuery();
            Response.Write("<script>alert('Status Updated Successfully')</script>");
            conn.Close();
        }
            catch (System.FormatException e1)
            {
                Response.Write("<script>alert('Invalid Course ID')</script>");
            }


}
        //--------------------------------------Fetch all details of active students------------------------------
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("View2.aspx");
        }
        //----------------------------View all graduation plans along with their initiated advisors----------------------------

        protected void Button7_Click(object sender, EventArgs e)
        {
            Response.Redirect("View3.aspx");
        }
        //-------------------View all students transcript details------------------------------------
        protected void Button8_Click(object sender, EventArgs e)
        {
            Response.Redirect("View4.aspx");
        }
        //---------------------------------------------Fetch all semesters along with their offered courses-------------------------------
        protected void Button9_Click(object sender, EventArgs e)
        {
            Response.Redirect("View5.aspx");
        }

        //---------------------------------------Helper Methods ----------------------------------------------------------------------------

        private bool CourseExists(int courseId)
        {
            string connstr = WebConfigurationManager.ConnectionStrings["Advising_System_11"].ToString(); ;

            using (SqlConnection connection = new SqlConnection(connstr))
            {
                connection.Open();

                string query = $"SELECT 1 FROM Course WHERE course_ID = {courseId}";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    return command.ExecuteScalar() != null;
                }
            }
        }

        private bool PaymentIDExists(int payId)
        {
            string connstr = WebConfigurationManager.ConnectionStrings["Advising_System_11"].ToString(); ;

            using (SqlConnection connection = new SqlConnection(connstr))
            {
                connection.Open();

                string query = $"SELECT 1 FROM Payment WHERE payment_id = {payId}";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    return command.ExecuteScalar() != null;
                }
            }
        }

        private bool StudentIDExists(int id)
        {
            string connstr = WebConfigurationManager.ConnectionStrings["Advising_System_11"].ToString(); ;

            using (SqlConnection connection = new SqlConnection(connstr))
            {
                connection.Open();

                string query = $"SELECT 1 FROM Student WHERE student_id = {id}";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    return command.ExecuteScalar() != null;
                }
            }
        }

        private bool Semster_Exists(String input)
        {
            string connstr = WebConfigurationManager.ConnectionStrings["Advising_System_11"].ToString(); ;

            using (SqlConnection connection = new SqlConnection(connstr))
            {
                connection.Open();

                string query = $"SELECT 1 FROM Course_Semester WHERE semester_code = '{input}'";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    return command.ExecuteScalar() != null;
                }
            }
        }
    }
}
