using Model.DAO;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyDuAn.Common;

namespace QuanLyDuAn.Controllers
{
    public class ProjectController : SecurityController
    {
        // GET: Project

        // ~ mục danh sách dự án
        public ActionResult Index()
        {
            List<DuAnViewModel> model = new CongViecDAO().ListAll();
            return View(model);
        }

        // xóa 1 dự án
        [HasCredential(RoleID ="DELETE_CHITIETLICHLAMVIEC")]
        [HasCredential(RoleID ="DELETE_CONGVIEC")]
        public JsonResult Delete(string id /* ma cong viec*/)
        {
            bool result = new CongViecDAO().Delete(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // ứng với "chi tiết công việc" ở trên giao diện
        public ActionResult Statistic(string id)
        {
            DuAnViewModel model = new CongViecDAO().GetProjectByID(id);

            DateTime now = DateTime.Now;

            ViewBag.hours = Convert.ToInt64((now - model.NgayBatDau).Value.TotalHours);

            ViewBag.total_hours = (model.NgayKetThuc - model.NgayBatDau).Value.TotalHours;

            ViewBag.percent = ((now - model.NgayBatDau).Value.TotalHours) / ((model.NgayKetThuc - model.NgayBatDau).Value.TotalHours);

            ViewBag.Note = new CongViecDAO().GetNoteByProID(id);

            return View(model);
        }
    }
}