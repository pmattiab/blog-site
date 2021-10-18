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
            UserListModel model = new UserListModel();

            model.Users = new UserService().GetAll();

            return View(model);
        }

        public ActionResult Detail(int id)
        {
            UserDetailModel model = new UserDetailModel();

            model.User = new UserService().GetAll().FirstOrDefault(x => x.Id == id);

            model.Posts = new PostService().GetAll().FindAll(y => y.UserId == id);

            return View(model);
        }
    }
}