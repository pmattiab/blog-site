using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace blog_site.Models
{
    public class PostListModel
    {

        public List<PostModel> Items { get; set; } = new List<PostModel>();

    }
}