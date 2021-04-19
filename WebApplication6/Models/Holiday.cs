using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
    public class Holiday
    {
        public String DayName { get; set; }
        public String Name { get; set; }
        public DateTime Date
        {
            get; set;
        }
    }
}