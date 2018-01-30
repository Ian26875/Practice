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

        [HttpPost]
        public ActionResult Create(MoneyCreateViewModel viewModel)
        {
            if (ModelState.IsValid == false)
            {
                return View("Index",viewModel);
            }
            return View("Index");
        }

        public ActionResult IsNowAfter(DateTime dateTime)
        {
            bool isValidate = DateTime.Now.Year <= dateTime.Year
                    && DateTime.Now.DayOfYear <= dateTime.DayOfYear;
            return Json(isValidate, JsonRequestBehavior.AllowGet);
        }
    }
}