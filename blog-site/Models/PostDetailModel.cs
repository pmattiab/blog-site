﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebSockets;
using BlogBusinessLogic.Models;

namespace blog_site.Models
{
    public class PostDetailModel
    {
        public Post Post { get; set; } = new Post();
        public User User { get; set; } = new User();
        public List<Comment> Comments { get; set; }

    }
}