using MoneyTemplateMVC.Areas.Background.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoneyTemplateMVC.Areas.Background.Controllers
{
    public class AccountController : Controller
    {
        // GET: Background/Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginViewModel loginView)
        {
            if (ModelState.IsValid == false)
            {
                return View("Index", loginView);
            }
            return RedirectToAction("Index", "Home", new { area = "" });
        }

    }
}