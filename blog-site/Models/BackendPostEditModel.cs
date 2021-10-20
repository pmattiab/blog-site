using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace blog_site.Models
{
    public class BackendPostEditModel
    {
        //public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}