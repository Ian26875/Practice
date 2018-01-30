using MoneyTemplateMVC.Models.ViewModels;
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
            var source = _accountService.GetAll().OrderBy(x=>x.CreateTime);
            return View(source);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MoneyCreateViewModel viewModel)
        {
            if (ModelState.IsValid == false)
            {
                return View("Index",viewModel);
            }
            this._accountService.CreateMoneyBilling(viewModel);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult IsNowBefore(DateTime createTime)
        {
            bool isValidate = DateTime.Compare(DateTime.Now, createTime) >= 0;
            return Json(isValidate, JsonRequestBehavior.AllowGet);
        }
    }
}