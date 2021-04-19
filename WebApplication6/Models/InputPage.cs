using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
    public class InputPage
    {
        public DateTime CheckOut { get; set; }
        public DateTime Return { get; set; }
        public MultiSelectDropDownViewModel Countries { get; set; }

        public List<Result> Results { get; set; }
    }
}