using MoneyTemplateMVC.Models.ViewModels;
using MoneyTemplateMVC.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoneyTemplateMVC.Controllers
{
    public class HomeController : BaseController
    {


        private IAccountService _accountService;
      

        public HomeController(IAccountService accountService)
        {
            this._accountService = accountService;
        }
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [AllowAnonymous]
        [ChildActionOnly]
        public ActionResult List()
        {
            var source = _accountService.GetAll();
            return View(source);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MoneyCreateViewModel viewModel)
        {
            if (ModelState.IsValid == false)
            {
                return View("Index", viewModel);
            }
            this._accountService.CreateMoneyBilling(viewModel);

            var source = this._accountService.GetAll();

            return PartialView("List", source);
        }

        [HttpGet]
        public ActionResult IsTodayBefore(DateTime createTime)
        {
            bool isValidate = DateTime.Compare(DateTime.Today, createTime) >= 0;
            return Json(isValidate ? "true" : "輸入日期必須小於今天",
                JsonRequestBehavior.AllowGet);
        }
    }
}