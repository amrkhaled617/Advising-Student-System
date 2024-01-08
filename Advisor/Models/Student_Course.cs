using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Advisor.Models
{
    public class Student_Course
    {
        public Course course { get; set; }
        public Student student { get; set; }
        public Student_Course(Course course, Student student) { 
            this.course = course;
            this.student = student;
        }
    }
}