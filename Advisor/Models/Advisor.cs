using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Advisor.Models
{
    public class Advisor
    {
        public int advisor_id { get; set; }
        public string advisor_name { get; set; }
        public string email { get; set; }
        public string office { get; set; }
        public string password { get; set; }

        public Advisor(int advisor_id) { 
            this.advisor_id = advisor_id;
        }
    }
}