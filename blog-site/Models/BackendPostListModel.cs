using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace blog_site.Models
{
    public class BackendPostListModel
    {
        public List<PostModel> Posts { get; set; } = new List<PostModel>();
    }
}