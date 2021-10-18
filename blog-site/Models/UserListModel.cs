using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlogBusinessLogic.Models;

namespace blog_site.Models
{
    public class UserListModel
    {
        public List<UserModel> Users { get; set; } = new List<UserModel>();
    }
}