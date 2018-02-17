using MoneyTemplateMVC.Models.ViewModels;
using MoneyTemplateMVC.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Web.Helpers;

namespace MoneyTemplateMVC.Controllers
{
    public class HomeController : BaseController
    {
        private const string MoneyListCacheName = "MoneyList";
        private IAccountService _accountService;

        public HomeController(IAccountService accountService)
        {
            this._accountService = accountService;
        }

        [AllowAnonymous]
        public ActionResult Default()
        {
            return View();
        }
        [Route("skilltree/{year}/{month:range(1,12)}")]
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
        [Route("skilltree/{year}/{month:range(1,12)}")]
        [AllowAnonymous]
        [ChildActionOnly]
        public ActionResult List(int? year, int? month, int pageNumber = 1, int pageSize = 20)
        {

            var source = GetMoneyListSource(year, month);
            var pageList = source.ToPagedList(pageNumber, pageSize);
            return View(pageList);
        }

        private IList<MoneyViewModel> GetMoneyListSource(int? year, int? month)
        {
          
            IList<MoneyViewModel> source = WebCache.Get(MoneyListCacheName);
            if (source == null)
            {
                source = _accountService.GetPages(year, month);
                WebCache.Set(MoneyListCacheName, source);
            }
            return source;
        }
        private void ClearCache() => WebCache.Remove(MoneyListCacheName);

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MoneyCreateViewModel viewModel)
        {
            if (ModelState.IsValid == false)
            {
                return View("Index", viewModel);
            }
            this._accountService.CreateMoneyBilling(viewModel);

            this.ClearCache();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult IsTodayBefore(DateTime createTime)
        {
            bool isValidate = DateTime.Compare(DateTime.Today, createTime) >= 0;
            return Json(isValidate ? "true" : "輸入日期必須小於今天",
                JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(Guid id)
        {
            var viewModel = this._accountService.Get(id);
            if (viewModel == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MoneyEditViewModel viewModel)
        {
            this._accountService.UpdateMoneyBilling(viewModel);
            this.ClearCache();
            return RedirectToAction("Index");
        }
    }
}