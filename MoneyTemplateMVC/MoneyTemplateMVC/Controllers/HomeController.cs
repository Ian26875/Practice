﻿using MoneyTemplateMVC.Models.ViewModels;
using MoneyTemplateMVC.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoneyTemplateMVC.Controllers
{
    public class HomeController : Controller
    {


        private IAccountService _accountService;

        public HomeController(IAccountService accountService)
        {
            this._accountService = accountService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [ChildActionOnly]
        public ActionResult List()
        {
            var source = _accountService.GetAll();
            return View(source);
        }
     
    }
}