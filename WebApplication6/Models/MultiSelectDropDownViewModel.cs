using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WebApplication6.Models
{
    public class MultiSelectDropDownViewModel
{
        [Required]
        [Display(Name = "Choose Multiple Countries")]
        public List<int> SelectedMultiCountryId { get; set; }

        /// <summary>  
        /// Gets or sets selected countries property.  
        /// </summary>  
        public List<Country> SelectedCountryLst { get; set; }
    }
}