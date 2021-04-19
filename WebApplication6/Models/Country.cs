using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
    public class Country
    {

        /// <summary>  
        /// Gets or sets country ID property.  
        /// </summary>  
        public int Country_Id { get; set; }

        /// <summary>  
        /// Gets or sets country name property.  
        /// </summary>  
        public string Country_Name { get; set; }
        public String currency { get; set; }
        public float perDayFine { get; set; }
        public List<Holiday> Holidays { get; set; }

    }
}