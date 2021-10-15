using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebSockets;

namespace blog_site.Models
{
    public class PostDetailModel
    {
        public PostModel Item { get; set; } = new PostModel();
    }
}