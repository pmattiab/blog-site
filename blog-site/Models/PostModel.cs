using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace blog_site.Models
{
    public class PostModel
    {
        public int UserId { get; set; }

        public int PostId { get; set; }
        
        [Required(ErrorMessage = "Il titolo è richiesto"), Display(Name = "Titolo del Post")]
        public string Titolo { get; set; }

        [Required(ErrorMessage = "Il contenuto è richiesto"), Display(Name = "Contenuto del Post")]
        public string Contenuto { get; set; }
        
        public UserModel PostUser { get; set; }
    }
}