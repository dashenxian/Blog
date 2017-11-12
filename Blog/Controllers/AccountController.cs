using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;

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

        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model, string returnnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var userManager = new UserManager<IdentityUser, string>(new UserStore<IdentityUser>(new BlogIdentityDbContext()));
            var sigInManager = new SignInManager<IdentityUser, string>(userManager, this.HttpContext.GetOwinContext().Authentication);
            var result = await sigInManager.PasswordSignInAsync(model.UserName, model.Password, false, shouldLockout: false);
            if (result == SignInStatus.Success)
            {
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            return View(model);
        }
    }
}