using Blog.Models;
using BlogBusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class PostController : Controller
    {
        BlogManager blogManager = new BlogManager();
        // GET: Post
        public ActionResult Index()
        {
            var posts = blogManager.GetPost().Select(post =>
            new PostViewModel
            {
                Author = post.Author,
                Content = post.Content,
                ID = post.ID,
                CreateDate = post.CreateDate,
                Title = post.Title,
                ModifyDate = post.ModifyDate,
            }).ToList();
            var postListViewModel = new PostListViewModel()
            {
                Posts = posts,
                Count = posts.Count,
                PageCount = 1,
                Pages = 1
            };
            return View(postListViewModel);
        }
        public ActionResult Get(int id)
        {
            var post = blogManager.GetPostByID(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            var postViewModel = new PostViewModel()
            {
                Author = post.Author,
                Content = post.Content,
                CreateDate = post.CreateDate,
                ID = post.ID,
                Title = post.Title,
                ModifyDate = post.ModifyDate,
            };
            return View(postViewModel);
        }

    }
}