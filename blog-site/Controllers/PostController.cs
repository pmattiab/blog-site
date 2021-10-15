using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using blog_site.Models;
using blog_site.BusinessLogic;

namespace blog_site.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult List()
        {
            List<PostModel> postList = new PostService().ListFromJson();

            return View(postList)
        }
    }
}