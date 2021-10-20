using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebSockets;
using BlogBusinessLogic.Models;

namespace blog_site.Models
{
    public class PostDetailModel
    {
        public PostModel Post { get; set; } = new PostModel();
        public UserModel User { get; set; } = new UserModel();
        public List<Comment> Comments { get; set; }

    }
}