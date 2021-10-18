using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlogBusinessLogic.Models;

namespace blog_site.Models
{
    public class CommentListModel
    {
        public List<Comment> Items { get; set; } = new List<Comment>();
    }
}