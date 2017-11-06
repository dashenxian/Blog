using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Blog.Areas.Admin.Models;
using BlogModel;
using BlogBusinessLogic;

namespace Blog.Areas.Admin.Controllers
{
    public class PostManagerController : Controller
    {
        BlogManager blogManager = new BlogManager();
        // GET: Admin/PostManager
        public ActionResult Index()
        {
            var posts = blogManager.GetPost().Select(i => new PostMaintainViewModel
            {
                ID = i.ID,
                Content = i.Content,
                Title = i.Title,
            }).ToList();

            PostMaintainListViewModel postMaintainListViewModel = new PostMaintainListViewModel()
            {
                Posts = posts,
                Count = posts.Count,
                PageCount = 1,
                Pages = 1,
            };
            return View(postMaintainListViewModel);
        }
        public ActionResult Update(int id)
        {
            var post = blogManager.GetPostByID(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            PostMaintainViewModel postMaintainView = new PostMaintainViewModel
            {
                ID = post.ID,
                Title = post.Title,
                Content = post.Content,
            };
            return View(postMaintainView);
        }
        [HttpPost]
        public ActionResult Update(PostMaintainViewModel postMaintainView)
        {
            var post = blogManager.GetPostByID(postMaintainView.ID);
            if (post == null)
            {
                return HttpNotFound();
            }
            post.Title = postMaintainView.Title;
            post.Content = postMaintainView.Content;
            blogManager.Update(post);
            return RedirectToAction("Index");
        }
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(PostMaintainViewModel postMaintainView)
        {
            Post post = new Post()
            {
                Title = postMaintainView.Title,
                Content = postMaintainView.Content,
                CreateDate = DateTime.Now,
                ModifyDate = DateTime.Now,
                Author = "小贤",
                IsPublish = true,
            };
            blogManager.Insert(post);
            return RedirectToAction("Index");
        }
    }
}