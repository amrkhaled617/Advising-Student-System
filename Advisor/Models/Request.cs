using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Advisor.Models
{
    public class Request
    {
        public int request_id {  get; set; }
        public string type { get; set;}
        public string comment { get; set; }
        public string status { get; set;}
        public int credit_hours { get; set; }
        public Student student_id { get; set; }
        public Advisor advisor_id { get; set; }
        public Course course_id { get; set; }
        public Request(int request_id, string type, string comment, string status, int credit_hours, Student student, Course course)
        {
            this.request_id = request_id;
            this.type = type;
            this.comment = comment;
            this.status = status;
                
            this.credit_hours = credit_hours;
            this.student_id = student;
            this.course_id = course;

        }
        public Request(int request_id)
        {
            this.request_id= request_id;
        }

    }
}