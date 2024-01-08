using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Advisor.Models
{
    public class Graduation_Plan
    {
        public int plan_id { get; set; }
        public string semester_code { get; set;}
        public int semester_credit_hours { get; set; }
        public string expected_grad_date { get; set; }
        public Advisor advisor_id { get; set; }
        public Student student_id { get;}
    }
}