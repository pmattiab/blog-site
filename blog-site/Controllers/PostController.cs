using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using blog_site.Models;
using BlogBusinessLogic.Service;

namespace blog_site.Controllers
{
    public class PostController : Controller
    {
        private PostService service;

        public PostController()
        {
            this.service = new PostService(BlogBusinessLogic.Types.EnumFonte.Json);
        }



        public ActionResult List()
        {
            PostListModel model = new PostListModel();


            model.Items = this.service
                                    .GetAll()
                                    .Select(x => new PostModel()
                                    {
                                        PostId = x.Id,
                                        UserId = x.UserId,
                                        Titolo = x.Title,
                                        Corpo = x.Body
                                    })
                                    .ToList();


            return View(model);
        }

        public ActionResult Detail(int id)
        {
            PostDetailModel model = new PostDetailModel();


            return View(model);
        }
    }
}