using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDuAn.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project

        // ~ mục danh sách dự án
        public ActionResult Index()
        {
            return View();
        }

        // ứng với "chi tiết công việc" ở trên giao diện
        public ActionResult Statistic()
        {
            return View();
        }
    }
}