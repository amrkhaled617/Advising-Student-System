using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Advisor.Models
{
    public class Course
    {
        public int course_id { get; set; }
        public string course_name { get; set; }
        public string major { get; set; }
        public bool is_offered { get; set; }
        public int credit_hours { get; set; }
        public int semester { get; set; }
        public Course(string course_name)
        {
            this.course_name = course_name;
        }
        public Course(int course_id)
        {
            this.course_id = course_id;
        }
    }
}