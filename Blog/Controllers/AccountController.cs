using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Register(RegisterViewMode model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.UserName };
                var userManager = new UserManager<IdentityUser, string>(new UserStore<IdentityUser>(new BlogIdentityDbContext()));
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }
    }
}