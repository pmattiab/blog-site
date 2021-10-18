using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlogBusinessLogic.Models;

namespace blog_site.Models
{
    public class PostListModel
    {
        public List<PostModel> Posts { get; set; } = new List<PostModel>();
    }
}