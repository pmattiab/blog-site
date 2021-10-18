using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlogBusinessLogic.Models;

namespace blog_site.Models
{
    public class UserListModel
    {
        public List<User> Users { get; set; } = new List<User>();
    }
}