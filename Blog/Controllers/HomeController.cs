using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "关于本站";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "联系我们";

            return View();
        }
    }
}