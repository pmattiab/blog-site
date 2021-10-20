using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using blog_site.Models;
using BlogBusinessLogic.Service;

namespace blog_site.Controllers
{
    public class BackendPostController : Controller
    {
        // GET: BackendPost

        public ActionResult List()
        {
            PostListModel model = new PostListModel();

            model.Posts = new PostService().GetAll().Select(oldModel => new PostModel()
            {
                PostId = oldModel.Id,
                Titolo = oldModel.Title,
                Contenuto = oldModel.Body,
                PostUser = new UserService().GetAll().Where(x => x.Id == oldModel.UserId).Select(tmpUser => new UserModel()
                {
                    UserId = tmpUser.Id,
                    Nome = tmpUser.Name,
                    Username = tmpUser.Username,

                }).FirstOrDefault()
            }).ToList();

            return View(model);
        }

        public ActionResult Detail(int id)
        {
            PostDetailModel model = new PostDetailModel();

            model.Post = new PostService().GetAll().Where(x => x.Id == id).Select(tmpPost => new PostModel()
            {
                PostId = tmpPost.Id,
                Titolo = tmpPost.Title,
                Contenuto = tmpPost.Body,
                PostUser = new UserService().GetAll().Where(x => x.Id == tmpPost.UserId).Select(tmpUser => new UserModel()
                {
                    UserId = tmpUser.Id,
                    Nome = tmpUser.Name,
                    Username = tmpUser.Username

                }).FirstOrDefault()

            }).FirstOrDefault();

            return View(model);
        }

        public ActionResult Add(int id = 0)
        {
            if (ModelState.IsValid)
            {

            }
            return View(new PostModel());
        }

        public ActionResult Edit(int id)
        {
            PostDetailModel model = new PostDetailModel();

            model.Post = new PostService().GetAll().Where(x => x.Id == id).Select(tmpPost => new PostModel()
            {
                PostId = tmpPost.Id,
                Titolo = tmpPost.Title,
                Contenuto = tmpPost.Body,
                PostUser = new UserService().GetAll().Where(x => x.Id == tmpPost.UserId).Select(tmpUser => new UserModel()
                {
                    UserId = tmpUser.Id,
                    Nome = tmpUser.Name

                }).FirstOrDefault()

            }).FirstOrDefault();

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}