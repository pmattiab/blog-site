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
    public class UserController : Controller
    {
        // GET: User
        public ActionResult List()
        {
            //
            // CON SELECT
            //
            UserListModel model = new UserListModel();

            model.Users = new UserService().GetAll().Select(oldModel => new UserModel()
            {
                UserId = oldModel.Id,
                Username = oldModel.Username,
                Nome = oldModel.Name

            }).ToList();

            return View(model);

            // ----------------------------------------------------------------------------------------
            //
            // CON IL FOREACH
            //
            // UserListModel model = new UserListModel();
            //
            //foreach (User user in new UserService().GetAll())
            //{
            //    List<Post> posts = new PostService().GetAll();

            //    UserModel tmpModel = new UserModel();

            //    tmpModel.UserId = user.Id;
            //    tmpModel.Nome = user.Name;
            //    tmpModel.Username = user.Username;
            //    tmpModel.Email = user.Email;
            //    tmpModel.Posts = posts.Where(x => x.UserId == user.Id).Select(tmpPost => new PostModel()
            //        {
            //            UserId = tmpPost.UserId,
            //            Titolo = tmpPost.Title
            //        }).ToList();

            //    model.Users.Add(tmpModel);

            //}
            //
            // return View(model);
        }

        public ActionResult Detail(int id)
        {
            UserDetailModel model = new UserDetailModel();

            model.User = new UserService().GetAll().Where(x => x.Id == id).Select(tmpUser => new UserModel()
            {
                UserId = tmpUser.Id,
                Nome = tmpUser.Name,
                Username = tmpUser.Username,
                Email = tmpUser.Email,
                Telefono = tmpUser.Phone,
                Sito = tmpUser.Website,
                Città = tmpUser.Address.City,
                Via = tmpUser.Address.Street,
                CodicePostale = tmpUser.Address.ZipCode

            }).FirstOrDefault();

            model.Posts = new PostService().GetAll().Where(x => x.UserId == id).Select(tmpPost => new PostModel()
            {
                PostId = tmpPost.Id,
                UserId = tmpPost.UserId,
                Titolo = tmpPost.Title,
                Contenuto = tmpPost.Body

            }).ToList();

            return View(model);
        }
    }
}