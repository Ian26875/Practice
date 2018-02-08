using Microsoft.AspNet.Identity;
using MoneyTemplateMVC.Areas.Background.Models.ViewModels;
using MoneyTemplateMVC.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace MoneyTemplateMVC.Areas.Background.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IMemberService _memberService;

        public AccountController(IMemberService memberService)
        {
            this._memberService = memberService;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel loginView)
        {
            if (ModelState.IsValid == false)
            {
                return View("Index", loginView);
            }
            bool isLogin = _memberService.Login(loginView.Account,loginView.Password);
            if (isLogin)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,loginView.Account),
                  
                    new Claim(ClaimTypes.Role, "Admin")
                };
                var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
                var ctx = Request.GetOwinContext();
                var authenticationManager = ctx.Authentication;
                authenticationManager.SignIn(identity);
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            else
            {
                ModelState.AddModelError("", "請申請會員！");
                return View("Index", loginView);
            }
        }

    }
}