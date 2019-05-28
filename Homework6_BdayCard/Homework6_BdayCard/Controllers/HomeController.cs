using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework6_BdayCard.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View("MainPage");
        }

        [HttpPost]
        public ActionResult Index(Models.BirthdayCard bdcard)
        {

            if (ModelState.IsValid)
            {
                return View("BdayCardSent", bdcard);
            }
            else
            {
                return View("MainPage", bdcard);
            }


        }
    }
}