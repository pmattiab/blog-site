using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace blog_site.Models
{
    public class ContactModel
    {
        [Required, Display(Name = "Sender Name")]
        public string SenderName { get; set; }


        [Required, Display(Name = "Sender Email"), EmailAddress]
        public string SenderEmail { get; set; }


        [Required]
        public string Message { get; set; }
    }
}