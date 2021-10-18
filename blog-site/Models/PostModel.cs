using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace blog_site.Models
{
    public class PostModel
    {
        public int UserId { get; set; }
        public int PostId { get; set; }
        public string Titolo { get; set; }
        public string Contenuto { get; set; }
        public UserModel PostUser { get; set; }
    }
}