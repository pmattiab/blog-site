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
        private PostService servicePost;
        private UserService serviceUser;

        public BackendPostController()
        {
            servicePost = new PostService(BlogBusinessLogic.Types.EnumFonte.Json);
            serviceUser = new UserService(BlogBusinessLogic.Types.EnumFonte.Json);
        }

        // GET: BackendPost

        public ActionResult List()
        {
            PostListModel model = new PostListModel();

            model.Posts = servicePost.GetAll().Select(oldModel => new PostModel()
            {
                PostId = oldModel.Id,
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
        }

        public ActionResult Detail(int id)
        {
            PostDetailModel model = new PostDetailModel();

            model.Post = servicePost.GetAll().Where(x => x.Id == id).Select(tmpPost => new PostModel()
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

        public ActionResult Add()
        {
            BackendPostEditModel model = new BackendPostEditModel();


            return View("Edit",model);
        }

        public ActionResult Edit(int id)
        {
            BackendPostEditModel model = new BackendPostEditModel();

            var dbPost = servicePost.GetSinglePost(id);

            if (dbPost == null || dbPost.Id < 0) return RedirectToAction("List");

            model.Id = dbPost.Id;
            model.Title = dbPost.Title;
            model.Body = dbPost.Body;

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SalvaPost(BackendPostEditModel model)
        {
            if (ModelState.IsValid)
            {

                return RedirectToAction("List");
            }

            return View("Edit", model);

            //salvo
            // new PostService().InserOrUpdate()


        }




        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}