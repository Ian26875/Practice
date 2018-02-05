using MoneyTemplateMVC.CustomResults;
using MoneyTemplateMVC.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;
using System.Web.Mvc;

namespace MoneyTemplateMVC.Controllers
{
    public class FeedsController : Controller
    {
        private IRSSService _rssService;

        public FeedsController(IRSSService rssService)
        {
            this._rssService = rssService;
        }

        // GET: Feeds
        public ActionResult Index()
        {
            var feed = _rssService.GetFeedData();
            return new RssResult(feed);
        }

    }
}