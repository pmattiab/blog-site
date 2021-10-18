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

            foreach (Post post in new PostService().GetAll())
            {
                User user = new UserService().GetAll().FirstOrDefault(x => x.Id == post.UserId);

                PostModel tmpModel = new PostModel();

                tmpModel.PostId = post.Id;
                tmpModel.Titolo = post.Title;
                tmpModel.Contenuto = post.Body;
                tmpModel.UserId = post.UserId;

                model.Posts.Add(tmpModel);

            }

            model.Posts = new PostService().GetAll().Select(oldModel => new PostModel()
            {
                PostId = oldModel.Id,
                Titolo = oldModel.Title,
                Contenuto = oldModel.Body,
                PostUser = new UserService().GetAll().Where(x => x.Id == oldModel.Id).Select(tmpUser => new UserModel()
                {
                    UserId = tmpUser.Id,
                    Nome = tmpUser.Name,

                }).FirstOrDefault()}).ToList();

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