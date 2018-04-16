using Model.DAO;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyDuAn.Common;
using Model.EF;

namespace QuanLyDuAn.Controllers
{
    public class ProjectController : SecurityController
    {
        // GET: Project

        // ~ mục danh sách dự án
        public ActionResult Index()
        {
            List<DuAnViewModel> model = new DuAnDAO().ListAll();
            ViewBag.Khachhang = new KhachHangDAO().ListAll();
            ViewBag.NhanVien = new NhanVienDAO().ListAll();
            return View(model);
        }

        // xóa 1 dự án
        [HasCredential(RoleID ="DELETE_CHITIETLICHLAMVIEC")]
        [HasCredential(RoleID ="DELETE_CONGVIEC")]
        public JsonResult Delete(long id /* ma cong viec*/)
        {
            bool result = new DuAnDAO().Delete(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // ứng với "chi tiết công việc" ở trên giao diện
        public ActionResult Statistic(long id)
        {

            DuAnViewModel model = new DuAnDAO().GetProjectByID(id);

            DateTime now = DateTime.Now;

            ViewBag.hours = Convert.ToInt64((now - model.NgayBatDau).Value.TotalHours);

            ViewBag.total_hours = (model.NgayKetThuc - model.NgayBatDau).Value.TotalHours;

            ViewBag.percent = ((now - model.NgayBatDau).Value.TotalHours) / ((model.NgayKetThuc - model.NgayBatDau).Value.TotalHours);


            ViewBag.NhanVien = new NhanVienDAO().ListAll();

            return View(model);
        }
        [HasCredential(RoleID = "CREATE_CHITIETLICHLAMVIEC")]
        public JsonResult AddEmpInProject(long emp_id, long pro_id)
        {
            //bool result = new ChiTietLichLamViecDAO().Insert_EmpID_ProID(emp_id, pro_id);

            return Json(true, JsonRequestBehavior.AllowGet);
        }
        [HasCredential(RoleID = "CREATE_CONGVIEC")]
        public JsonResult Insert(string name, long emp_id, long cus_id, DateTime time_start, DateTime time_end, string desc )
        {
            DuAn item = new DuAn();
            item.Ten = name;
            item.MaKH = cus_id;
            item.TruongDuAn = emp_id;
            item.NgayTao = DateTime.Today;
            item.ThoiGianBD = time_start;
            item.ThoiGianKT = time_end;
            item.MoTa = desc;
            item.TienDo = 0;
            bool result = new DuAnDAO().Insert_project(item);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}