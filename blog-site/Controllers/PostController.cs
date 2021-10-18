using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogBusinessLogic.Models;
using BlogBusinessLogic.Service;
using blog_site.Models;

namespace blog_site.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult List()
        {
            PostListModel model = new PostListModel();

            model.Posts = new PostService().GetAll();

            return View(model);
        }

        public ActionResult Detail(int id)
        {
            PostDetailModel model = new PostDetailModel();

            model.Post = new PostService().GetAll().FirstOrDefault(x => x.Id == id);

            model.User = new UserService().GetAll().FirstOrDefault(y => y.Id == model.Post.UserId);

            model.Comments = new CommentService().GetAll().FindAll(z => z.PostId == id);

            return View(model);
        }
    }
}