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

        private PostService servicePost;
        private UserService serviceUser;

        public PostController()
        {
            servicePost = new PostService(BlogBusinessLogic.Types.EnumFonte.WebService);
            serviceUser = new UserService(BlogBusinessLogic.Types.EnumFonte.WebService);
        }

        public ActionResult List()
        {
            //
            // CON SELECT
            //
            PostListModel model = new PostListModel();

            model.Posts = servicePost.GetAll().Select(oldModel => new PostModel()
            {
                PostId = oldModel.id,
                Titolo = oldModel.Title,
                Contenuto = oldModel.Body,
                PostUser = serviceUser.GetAll().Where(x => x.Id == oldModel.UserId).Select(tmpUser => new UserModel()
                {
                    UserId = tmpUser.Id,
                    Nome = tmpUser.Name,
                    Username = tmpUser.Username,

                }).FirstOrDefault()

            }).ToList();

            return View(model);

            // ----------------------------------------------------------------------------------------
            //
            // CON IL FOREACH
            //
            // PostListModel model = new PostListModel();
            //
            //foreach (Post post in servicePost)
            //{
            //    User user = serviceUser.GetAll().FirstOrDefault(x => x.Id == post.UserId);

            //    PostModel tmpModel = new PostModel();

            //    tmpModel.PostId = post.Id;
            //    tmpModel.Titolo = post.Title;
            //    tmpModel.Contenuto = post.Body;
            //    tmpModel.UserId = post.UserId;

            //    model.Posts.Add(tmpModel);

            //}
            //
            // return View(model);
        }

        public ActionResult Detail(int id)
        {
            PostDetailModel model = new PostDetailModel();

            model.Post = servicePost.GetAll().Where(x => x.id == id).Select(tmpPost => new PostModel()
            {
                PostId = tmpPost.id,
                Titolo = tmpPost.Title,
                Contenuto = tmpPost.Body,
                PostUser = serviceUser.GetAll().Where(x => x.Id == tmpPost.UserId).Select(tmpUser => new UserModel()
                {
                    UserId = tmpUser.Id,
                    Nome = tmpUser.Name

                }).FirstOrDefault()

            }).FirstOrDefault();

            model.Comments = new CommentService().GetAll().FindAll(z => z.PostId == id);

            return View(model);
        }
    }
}