﻿using System;
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
            //
            // CON SELECT
            //
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

            // ----------------------------------------------------------------------------------------
            //
            // CON IL FOREACH
            //
            // PostListModel model = new PostListModel();
            //
            //foreach (Post post in new PostService().GetAll())
            //{
            //    User user = new UserService().GetAll().FirstOrDefault(x => x.Id == post.UserId);

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

            model.Comments = new CommentService().GetAll().FindAll(z => z.PostId == id);

            return View(model);
        }
    }
}