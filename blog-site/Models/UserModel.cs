using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace blog_site.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string Nome { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Sito { get; set; }
        public string Città { get; set; }
        public string Via { get; set; }
        public string CodicePostale {get; set;}
        public List<PostModel> Posts { get; set; }
    }
}