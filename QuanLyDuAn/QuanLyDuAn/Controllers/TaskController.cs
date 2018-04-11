using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;

namespace QuanLyDuAn.Controllers
{
    public class TaskController : SecurityController
    {
        // GET: Task
        public ActionResult Index()
        {
            return View();
        }

        // tin nhắn
        public ActionResult Message()
        {
            var dao = new NhacNhoDAO();
            return View();
        }

        // lịch làm việc
        public ActionResult Assignment()
        {
            return View();
        }
        public JsonResult GetCalendar()
        {
            var item = new ChiTietLichLamViecDAO().ListAll();
            return Json(item, JsonRequestBehavior.AllowGet);
        }
        // chấm công
        public ActionResult Time_keeping()
        {
            return View();
        }
    }
}