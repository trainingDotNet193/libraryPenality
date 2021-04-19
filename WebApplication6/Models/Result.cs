using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
    public class Result
    {
        public Country   SelectedCountry { get; set; }
        public int BusinessDays { get; set; }
        public float Fine { get; set; }
    }
}