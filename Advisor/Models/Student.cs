using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Advisor.Models
{
    public class Student
    {

    public int student_id { get; set; }
    public string f_name { get; set; }
    public string l_name { get; set; }
    public string s_name { get; set; }
    public string m_name { get; set; }
    public decimal gpa { get; set; }

    public string faculty { get; set;}
    public string email { get; set; }
    public string major { get; set; }
    public bool financial_status { get; set; }
        public int semester { get; set; }
        public int acquired_hours { get; set; }

        public int assigned_hours { get; set; }
    public Advisor advisor_id { get; set; }

    public Student(int student_id, string f_name, string major)
        {
            this.student_id= student_id;
            this.f_name= f_name;
            this.major= major;
        }
        public Student(int student_id, string f_name)
        {
            this.student_id = student_id;
            this.f_name = f_name;
        }
        public Student(int student_id)
        {
            this.student_id = student_id;
        }


    }
}
