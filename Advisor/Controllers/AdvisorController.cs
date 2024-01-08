using Advisor.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Provider;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Xml.Linq;

namespace Advisor.Controllers
{
    public class AdvisorController : Controller
    {
        public ActionResult Advisor_Home()
        {
            return View();
        }
        public ActionResult AdvisorHomePage() {
            return View();
        }
        // GET: Advisor
        public ActionResult Logout()
        {
            HttpCookie authCookie = new HttpCookie("advisorData");
            authCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(authCookie);
            return RedirectToAction("./Login");
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Register_Helper(FormCollection form)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["Advising_System_11"].ToString();
            SqlConnection con = new SqlConnection(connStr);
            using (con)
            {
                SqlCommand cmd = new SqlCommand("dbo.Procedures_AdvisorRegistration", con);
                cmd.CommandType = CommandType.StoredProcedure;
                using (cmd)
                {
                    if (String.IsNullOrEmpty(form["advisor_name"]) || String.IsNullOrEmpty(form["password"]) || String.IsNullOrEmpty(form["email"]) || String.IsNullOrEmpty(form["office"]))
                    {
                        TempData["ErrorMessage"] = "Please fill in all the boxes.";
                        return RedirectToAction("./Register");
                    }
                    cmd.Parameters.AddWithValue("@advisor_name", form["advisor_name"]);
                    cmd.Parameters.AddWithValue("@password", form["password"]);
                    cmd.Parameters.AddWithValue("@email", form["email"]);
                    cmd.Parameters.AddWithValue("@office", form["office"]);
                    SqlParameter advisor_id = cmd.Parameters.AddWithValue("@Advisor_id", SqlDbType.Int);
                    advisor_id.Direction = ParameterDirection.Output;

                    con.Open();
                    cmd.ExecuteNonQuery();
                    TempData["SuccessMessage"] = "Done! Your ID is " + Convert.ToInt16(advisor_id.Value);
                    con.Close();
                    return RedirectToAction("./Login");
                }

            }

        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Login_Helper(FormCollection form)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Advising_System_11"].ConnectionString);
            using (con)
            {
                SqlCommand cmd = new SqlCommand("SELECT dbo.FN_AdvisorLogin(@advisor_Id,@password) AS bit ", con);
                cmd.CommandType = CommandType.Text;
                using (cmd)
                {
                    cmd.Parameters.AddWithValue("@advisor_Id", form["advisor_id"]);
                    cmd.Parameters.AddWithValue("@password", form["password"]);
                    con.Open();
                    cmd.ExecuteNonQuery();
                   /* if (String.IsNullOrEmpty(form["advisor_name"]) || String.IsNullOrEmpty(form["password"]) || String.IsNullOrEmpty(form["email"]) || String.IsNullOrEmpty(form["office"]))
                    {
                        TempData["ErrorMessage"] = "Please fill in all the boxes.";
                        return RedirectToAction("./Login");
                    }*/
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            bool x = Convert.ToBoolean(reader["bit"]);


                            if (x)
                            {
                                HttpCookie loginCookie = new HttpCookie("advisorCookie");
                                loginCookie["advisorId"] = form["advisor_id"];
                                Response.Cookies.Add(loginCookie);
                                con.Close();
                                return RedirectToAction("./AdvisorHomePage");

                            }
                            else
                            {
                                TempData["ErrorMessage"] = "Invalid Id or Password.";
                                con.Close();
                                return RedirectToAction("./Login");

                            }
                        }
                    }
                    return RedirectToAction("./Login");


                }
            }
        }

        //C
        public ActionResult Assigned_Students()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Advising_System_11"].ConnectionString);
            using (con)
            {
                HttpCookie advisorInfo = Request.Cookies["advisorCookie"];

                SqlCommand cmd = new SqlCommand("SELECT * FROM Student WHERE advisor_id=" + Convert.ToInt32(advisorInfo["advisorId"]), con);
                cmd.CommandType = CommandType.Text;
                using (cmd)
                {

                    con.Open();
                    cmd.ExecuteNonQuery();
                    List<Student> students = new List<Student>();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read() && reader.HasRows)
                        {
                            int student_id = Convert.ToInt32(reader["student_id"]);
                            String student_name = Convert.ToString(reader["f_name"]);
                            String student_major = Convert.ToString(reader["major"]);
                            Student student = new Student(student_id, student_name);
                            students.Add(student);

                        }
                    }
                    con.Close();
                    return View("Assigned_Students", students);
                }
            }
        }
        //D
        public ActionResult Insert_Graduation_Plan()
        {
            return View();

        }
        public ActionResult Insert_Graduation_Plan_Helper(FormCollection form)
        {
            if (String.IsNullOrEmpty(form["semester_code"]) ||
                String.IsNullOrEmpty(form["expected_grad_date"]) ||
                String.IsNullOrEmpty(form["semester_credit_hours"]) || String.IsNullOrEmpty(form["student_id.student_id"]))
            {
                TempData["ErrorMessage"] = "Please fill in all the boxes.";
                return RedirectToAction("./Insert_Graduation_Plan_View");
            }

            try
            {
                if (!int.TryParse(form["student_id.student_id"], out int studentId))
                {
                    throw new ArgumentException("Invalid student_id");
                }
                if (!int.TryParse(form["semester_credit_hours"], out int semester_credit_hours))
                {
                    throw new ArgumentException("Invalid semester_credit_hours ");
                }
                if (!DateTime.TryParse(form["expected_grad_date"], out DateTime expected_grad_date))
                {
                    throw new ArgumentException("Invalid expected_grad_date");
                }
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Advising_System_11"].ConnectionString);
                SqlCommand studentCheck = new SqlCommand("SELECT dbo.FN_CheckStudentExists(@Student_id) AS bit ", con);
                studentCheck.CommandType = CommandType.Text;
                studentCheck.Parameters.AddWithValue("@Student_id", studentId);

                SqlCommand semesterCheck = new SqlCommand("SELECT dbo.FN_CheckSemesterCodeExists(@semester_code) AS bit ", con);
                semesterCheck.CommandType = CommandType.Text;
                semesterCheck.Parameters.AddWithValue("@semester_code", form["semester_code"]);


                SqlCommand cmd = new SqlCommand("dbo.[Procedures_AdvisorCreateGP]", con);
                cmd.CommandType = CommandType.StoredProcedure;

                
                    con.Open();
                    studentCheck.ExecuteNonQuery();
                    SqlDataReader reader = studentCheck.ExecuteReader();
 
                    while (reader.Read())
                    {
                        bool x = Convert.ToBoolean(reader["bit"]);
                        if (!x)
                        {
                            TempData["ErrorMessage"] = "Student does not exist.";
                            con.Close();
                            return RedirectToAction("./Insert_Graduation_Plan");
                        }
                    }
                    con.Close();
                    con.Open();

                    semesterCheck.ExecuteNonQuery();
                    SqlDataReader rdr = semesterCheck.ExecuteReader();

                    while (rdr.Read())
                    {
                        bool y = Convert.ToBoolean(rdr["bit"]);
                        if (!y)
                        {
                            TempData["ErrorMessage"] = "Semester_Code does not exist.";
                            con.Close();
                            return RedirectToAction("./Insert_Graduation_Plan");
                        }
                    }
                    con.Close();



                        cmd.Parameters.AddWithValue("@student_id", studentId);
                        cmd.Parameters.AddWithValue("@Semester_code", form["semester_code"]);
                        cmd.Parameters.AddWithValue("@expected_graduation_date", expected_grad_date);

                        cmd.Parameters.AddWithValue("@sem_credit_hours", semester_credit_hours);
                        HttpCookie advisorInfo = Request.Cookies["advisorCookie"];
                        cmd.Parameters.AddWithValue("@advisor_id", Convert.ToInt32(advisorInfo["advisorId"]));

                        con.Open();
                        int success = cmd.ExecuteNonQuery();
                        con.Close();
                        if (success <= 0)
                        {
                            TempData["ErrorMessage"] = "Graduation Plan already exists!!";
                            return RedirectToAction("./Insert_Graduation_Plan");

                        }
                    

                
                TempData["SuccessMessage"] = "Graduation plan successfully created!";
                return RedirectToAction("./Insert_Graduation_Plan");


            }
            catch (ArgumentException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("./Insert_Graduation_Plan");
            }
        }

        //E
        public ActionResult Insert_Course_for_Graduation_Plan()
        {
            return View();
        }
        public ActionResult Insert_Course_for_Graduation_Plan_Helper(FormCollection form)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Advising_System_11"].ConnectionString);
            SqlCommand cmd = new SqlCommand("dbo.[Procedures_AdvisorAddCourseGP]", con);
            try
            {
                if (!int.TryParse(form["student_id.student_id"], out int student_id))
                {
                    throw new ArgumentException("Invalid student_id");
                }

                using (con)
                {

                    using (cmd)
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        if (String.IsNullOrEmpty(form["semester_code.semester_code"]) ||
                            String.IsNullOrEmpty(form["student_id.student_id"]) ||
                            String.IsNullOrEmpty(form["course_name.course_name"]))
                        {
                            TempData["ErrorMessage"] = "Please fill in all the boxes.";
                            return RedirectToAction("./Insert_Course_for_Graduation_Plan");
                        }
                        cmd.Parameters.AddWithValue("@student_id", student_id);
                        cmd.Parameters.AddWithValue("@Semester_code", form["semester_code.semester_code"]);
                        cmd.Parameters.AddWithValue("@course_name", form["course_name.course_name"]);
                        con.Open();
                        int success = cmd.ExecuteNonQuery();
                        con.Close();
                        if (success <= 0)
                        {
                            TempData["ErrorMessage"] = "Course Already Exist in this student's Graduation Plan!!";
                            return RedirectToAction("./Insert_Course_for_Graduation_Plan");

                        }
                    }

                }
                TempData["SuccessMessage"] = "Course inserted successfully!";
                return RedirectToAction("./Insert_Course_for_Graduation_Plan");


            }
            catch (ArgumentException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("./Insert_Course_for_Graduation_Plan");
            }
        }
        //F
        public ActionResult Update_GP()
        {
            return View();
        }
        public ActionResult Update_GP_Helper(FormCollection form)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Advising_System_11"].ConnectionString);
            SqlCommand cmd = new SqlCommand("dbo.[Procedures_AdvisorUpdateGP]", con);
            try
            {
                if (!int.TryParse(form["student_id.student_id"], out int studentId))
                {
                    throw new ArgumentException("Invalid student_id");
                }
                if (!DateTime.TryParse(form["expected_grad_date"], out DateTime expected_grad_date))
                {
                    throw new ArgumentException("Invalid expected_grad_date");
                }

                using (con)
                {

                    using (cmd)
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        if (String.IsNullOrEmpty(form["expected_grad_date"]) ||
                            String.IsNullOrEmpty(form["student_id.student_id"]))
                        {
                            TempData["ErrorMessage"] = "Please fill in all the boxes.";
                            return RedirectToAction("./Update_GP");
                        }
                        cmd.Parameters.AddWithValue("@studentID", studentId);
                        cmd.Parameters.AddWithValue("@expected_grad_date", expected_grad_date);
                        con.Open();
                        int success = cmd.ExecuteNonQuery();
                        con.Close();
                        if (success <= 0)
                        {
                            TempData["ErrorMessage"] = "No need for update!";
                            return RedirectToAction("./Update_GP");

                        }
                    }

                }
                TempData["SuccessMessage"] = "Done!";
                return RedirectToAction("./Update_GP");


            }
            catch (ArgumentException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("./Update_GP");
            }
        }
        //G
        public ActionResult Delete_Course_GP()
        {
            return View();
        }
        public ActionResult Delete_Course_GP_Helper(FormCollection form)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Advising_System_11"].ConnectionString);
            SqlCommand cmd = new SqlCommand("dbo.[Procedures_AdvisorDeleteFromGP]", con);
            try
            {
                if (!int.TryParse(form["student_id.student_id"], out int studentId))
                {
                    throw new ArgumentException("Invalid student_id");
                }
                if (!int.TryParse(form["course_id.course_id"], out int course_id))
                {
                    throw new ArgumentException("Invalid course_id");
                }


                using (con)
                {

                    using (cmd)
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        if (String.IsNullOrEmpty(form["course_id.course_id"]) ||
                            String.IsNullOrEmpty(form["student_id.student_id"]) || String.IsNullOrEmpty(form["semester_code"]))
                        {
                            TempData["ErrorMessage"] = "Please fill in all the boxes.";
                            return RedirectToAction("./Delete_Course_GP");
                        }
                        cmd.Parameters.AddWithValue("@studentID", studentId);
                        cmd.Parameters.AddWithValue("@courseID", course_id);
                        cmd.Parameters.AddWithValue("@sem_code", form["semester_code"]);

                        con.Open();
                        int success = cmd.ExecuteNonQuery();
                        con.Close();
                        if (success <= 0)
                        {
                            TempData["ErrorMessage"] = "Could not find course in graduation plan to delete," +
                                                         " please check that the student has a course in that graduation plan";
                            return RedirectToAction("./Delete_Course_GP");

                        }
                    }

                }
                TempData["SuccessMessage"] = "Done!";
                return RedirectToAction("./Delete_Course_GP");


            }
            catch (ArgumentException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("./Delete_Course_GP");
            }
        }

        //H
        public ActionResult Assigned_Students_with_their_Majors()
        {
            return View();
        }
        public ActionResult StudentsMajor()
        {
            return View();
        }
        public ActionResult Assigned_Students_with_their_Majors_Helper(FormCollection form)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Advising_System_11"].ConnectionString);
            using (con)
            {
                SqlCommand cmd = new SqlCommand("dbo.[Procedures_AdvisorViewAssignedStudents]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                using (cmd)
                {
                    cmd.Parameters.AddWithValue("@major", form["major"]);
                    HttpCookie advisorInfo = Request.Cookies["advisorCookie"];
                    cmd.Parameters.AddWithValue("@AdvisorID", Convert.ToInt32(advisorInfo["advisorId"]));
                    con.Open();
                    cmd.ExecuteNonQuery();
                    List<Student_Course> student_Courses = new List<Student_Course>();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int student_id = Convert.ToInt32(reader["student_id"]);
                            String student_name = Convert.ToString(reader["f_name"]);
                            String student_major = Convert.ToString(reader["major"]);
                            String course_name = Convert.ToString(reader["Course_name"]);
                            Student student = new Student(student_id, student_name, student_major);
                            Course course = new Course(course_name);
                            Student_Course student_Course = new Student_Course(course, student);
                            student_Courses.Add(student_Course);

                        }
                    }
                    con.Close();
                    return View("StudentsMajor", student_Courses);

                }


            }



        }
        //I
        public ActionResult View_Requests()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Advising_System_11"].ConnectionString);
            using (con)
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.[FN_Advisors_Requests](@advisor_id)", con);
                cmd.CommandType = CommandType.Text;
                using (cmd)
                {
                    HttpCookie advisorInfo = Request.Cookies["advisorCookie"];
                    cmd.Parameters.AddWithValue("@advisor_id", Convert.ToInt32(advisorInfo["advisorId"]));
                    con.Open();
                    List<Request> requests = new List<Request>();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int request_id = Convert.ToInt32(reader["request_id"]);
                            String type = Convert.ToString(reader["type"]);
                            String comment = Convert.ToString(reader["comment"]);
                            String status = Convert.ToString(reader["status"]);
                            int creditHours = 0;
                            if (!reader.IsDBNull(reader.GetOrdinal("credit_hours")))
                            {
                                creditHours = Convert.ToInt32(reader["credit_hours"]);
                            }
                            int student_id = Convert.ToInt32(reader["student_id"]);
                            int course_id = 0;
                            if (!reader.IsDBNull(reader.GetOrdinal("course_id")))
                            {
                                course_id = Convert.ToInt32(reader["course_id"]);
                            }
                            Student student = new Student(student_id);
                            Course course = new Course(course_id);
                            Request request = new Request(request_id, type, comment, status, creditHours, student, course);
                            requests.Add(request);

                        }
                    }
                    con.Close();
                    return View("View_Requests", requests);
                }
            }
        }
        //J
        public ActionResult View_Pending_Requests()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Advising_System_11"].ConnectionString);
            using (con)
            {
                SqlCommand cmd = new SqlCommand("dbo.Procedures_AdvisorViewPendingRequests", con);
                cmd.CommandType = CommandType.StoredProcedure;
                using (cmd)
                {
                    HttpCookie advisorInfo = Request.Cookies["advisorCookie"];
                    cmd.Parameters.AddWithValue("@Advisor_ID", Convert.ToInt32(advisorInfo["advisorId"]));
                    con.Open();
                    cmd.ExecuteNonQuery();
                    List<Request> requests = new List<Request>();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int request_id = Convert.ToInt32(reader["request_id"]);
                            String type = Convert.ToString(reader["type"]);
                            String comment = Convert.ToString(reader["comment"]);
                            String status = Convert.ToString(reader["status"]);
                            int creditHours = 0;
                            if (!reader.IsDBNull(reader.GetOrdinal("credit_hours")))
                            {
                                creditHours = Convert.ToInt32(reader["credit_hours"]);
                            }
                            int student_id = Convert.ToInt32(reader["student_id"]);
                            int course_id = 0;
                            if (!reader.IsDBNull(reader.GetOrdinal("course_id")))
                            {
                                course_id = Convert.ToInt32(reader["course_id"]);
                            }
                            Student student = new Student(student_id);
                            Course course = new Course(course_id);
                            Request request = new Request(request_id, type, comment, status, creditHours, student, course);
                            requests.Add(request);

                        }
                    }
                    con.Close();
                    return View("View_Pending_Requests", requests);
                }
            }

        }
        //K
         public ActionResult A_R_extra_credit_hours()
        {
            return View();
        }
        public ActionResult A_R_extra_credit_hours_Helper(FormCollection form)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Advising_System_11"].ConnectionString);
            SqlCommand cmd = new SqlCommand("dbo.[Procedures_AdvisorApproveRejectCHRequest]", con);
            try
            {
                if (!int.TryParse(form["request_id.request_id"], out int request_id))
                {
                    throw new ArgumentException("Invalid request_id");
                }
                using (con)
                {

                    using (cmd)
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        if (String.IsNullOrEmpty(form["semester_code"]) ||
                            String.IsNullOrEmpty(form["request_id.request_id"]))
                        {
                            TempData["ErrorMessage"] = "Please fill in all the boxes.";
                            return RedirectToAction("./A_R_extra_credit_hours");
                        }
                        cmd.Parameters.AddWithValue("@requestID", request_id);
                        cmd.Parameters.AddWithValue("@current_sem_code", form["semester_code"]);
                        con.Open();
                        int success = cmd.ExecuteNonQuery();
                        con.Close();
                        if (success <= 0)
                        {
                            TempData["ErrorMessage"] = "There is no request with the given request_id and semester_code";
                            return RedirectToAction("./A_R_extra_credit_hours");

                        }
                    }

                }
                TempData["SuccessMessage"] = "Done";
                return RedirectToAction("./A_R_extra_credit_hours");


            }
            catch (ArgumentException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("./A_R_extra_credit_hours");
            }
        
    }
        //L
        public ActionResult A_R_extra_course()
        {
            return View();
        }
        public ActionResult A_R_extra_course_Helper(FormCollection form)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Advising_System_11"].ConnectionString);
            SqlCommand cmd = new SqlCommand("dbo.[Procedures_AdvisorApproveRejectCourseRequest]", con);
            try
            {
                if (!int.TryParse(form["request_id.request_id"], out int request_id))
                {
                    throw new ArgumentException("Invalid request_id");
                }
                using (con)
                {

                    using (cmd)
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        if (String.IsNullOrEmpty(form["semester_code"]) ||
                            String.IsNullOrEmpty(form["request_id.request_id"]))
                        {
                            TempData["ErrorMessage"] = "Please fill in all the boxes.";
                            return RedirectToAction("./A_R_extra_course");
                        }
                        cmd.Parameters.AddWithValue("@requestID", request_id);
                        cmd.Parameters.AddWithValue("@current_semester_code", form["semester_code"]);
                        con.Open();
                        int success = cmd.ExecuteNonQuery();
                        con.Close();
                        if (success <= 0)
                        {
                            TempData["ErrorMessage"] = "There is no request with the given request_id and semester_code";
                            return RedirectToAction("./A_R_extra_course");

                        }
                    }

                }
                TempData["SuccessMessage"] = "Done";
                return RedirectToAction("./A_R_extra_course");


            }
            catch (ArgumentException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("./A_R_extra_course");
            }
        }


    }
}