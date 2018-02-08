using MoneyTemplateMVC.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoneyTemplateMVC.Controllers
{
    [AuthorizePlus]
    public abstract class BaseController : Controller
    {
       
    }
}