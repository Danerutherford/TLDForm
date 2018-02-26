using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TLDForm.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OrderHistory()
        {
            

            return View();
        }

        public ActionResult PastVersions()
        {
           

            return View();
        }
    }
}