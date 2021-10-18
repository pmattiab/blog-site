using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebSockets;
using BlogBusinessLogic.Models;

namespace blog_site.Models
{
    public class UserDetailModel
    {
        public UserModel User { get; set; } = new UserModel();
        public List<PostModel> Posts { get; set; }
    }
}