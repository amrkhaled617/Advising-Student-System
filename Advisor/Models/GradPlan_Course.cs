using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Advisor.Models
{
    public class GradPlan_Course
    {
        public Student student_id {  get; set; }
        public Graduation_Plan semester_code { get; set; }
        public Course course_name { get; set; }

    }
}