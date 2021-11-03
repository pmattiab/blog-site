using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace blog_site.Models
{
    public class BackendPostDetailModel
    {
        public PostModel Post { get; set; } = new PostModel();
        public UserModel User { get; set; } = new UserModel();
    }
}