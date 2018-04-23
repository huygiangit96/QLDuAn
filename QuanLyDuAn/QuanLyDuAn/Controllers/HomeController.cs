using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyDuAn.Common;
using Model.DAO;

namespace QuanLyDuAn.Controllers
{
    public class HomeController : SecurityController
    {
        // GET: Home
        public ActionResult Index()
        {
            var model = new DuAnDAO().List(4);
            List<double> t = new List<double>();
            t.Add(new NhanVienDAO().ListAll().Count());
            t.Add(new KhachHangDAO().ListAll().Count());
            t.Add(model.Sum(x => (x.ThoiGianKT - x.ThoiGianBD).Value.TotalHours));
            t.Add(model.Count());
            ViewBag.header = t;
            return View(model);
        }
    }
}