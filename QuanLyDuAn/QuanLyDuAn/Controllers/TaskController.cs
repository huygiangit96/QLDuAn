using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDuAn.Controllers
{
    public class TaskController : Controller
    {
        // GET: Task
        public ActionResult Index()
        {
            return View();
        }

        // tin nhắn
        public ActionResult Message()
        {
            return View();
        }

        // lịch làm việc
        public ActionResult Assignment()
        {
            return View();
        }

        // chấm công
        public ActionResult Time_keeping()
        {
            return View();
        }
    }
}