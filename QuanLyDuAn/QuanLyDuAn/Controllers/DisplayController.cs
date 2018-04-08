using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDuAn.Controllers
{
    public class DisplayController : Controller
    {
        // GET: Display
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Slider()
        {
            return View();
        }
        public ActionResult Footer()
        {
            return View();
        }
    }
}