using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogBusinessLogic.Models;
using BlogBusinessLogic.Service;

namespace blog_site.Controllers
{
    public class CommentController : Controller
    {
        // GET: Comment
        public ActionResult List()
        {
            List<Comment> commentList = new CommentService().GetAll();

            return View(commentList);
        }
    }
}