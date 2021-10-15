﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using blog_site.Models;

namespace blog_site.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //List<PostModel> postList = new PostController().List();

            //ViewBag.PostList = postList;

            return RedirectToAction("List", "Post");
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult SamplePost()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}