using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MedicationsShortagesDashboard.Services;

namespace MedicationsShortagesDashboard.Controllers
{
    public abstract class BaseController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Username"] = Authentication.Username;
            return View();
        }

    }
}
