﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoneyTemplateMVC.Controllers
{
    public class FeedsController : Controller
    {
        // GET: Feeds
        public ActionResult Index()
        {
            return View();
        }
    }
}