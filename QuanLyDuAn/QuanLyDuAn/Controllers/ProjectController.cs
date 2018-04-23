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
            
            // lấy ra danh sách nhân viên
            ViewBag.NhanVien = new NhanVienDAO().ListAll();

            // lấy ra trưởng dự án ( trưởng nhóm to nhất )
            ViewBag.Leader = new NhanVienDAO().GetByID(model.TruongDuAn);

            // lấy ra danh sách công việc của dự án được chọn
            ViewBag.CongViec = new CongViecDAO().GetByProID(model.ID);

            // lấy ra những trưởng nhóm công việc ( chỉ show ra nhưng thành viên chủ chốt )
            ViewBag.ThanhVien = new NhanVienDAO().GetByProjectID(model.ID);

            // tính số giờ làm, số giờ dự kiến
            DateTime now = DateTime.Now;

            ViewBag.hours = Convert.ToInt64((now - model.NgayBatDau).Value.TotalHours);

            ViewBag.total_hours = (model.NgayKetThuc - model.NgayBatDau).Value.TotalHours;

            double percent = ((now - model.NgayBatDau).Value.TotalHours) / ((model.NgayKetThuc - model.NgayBatDau).Value.TotalHours);

            return View(model);
        }
        [HasCredential(RoleID = "CREATE_CHITIETLICHLAMVIEC")]
        public JsonResult AddEmpInProject(long emp_id, long pro_id)
        {
            //bool result = new ChiTietLichLamViecDAO().Insert_EmpID_ProID(emp_id, pro_id);

            return Json(true, JsonRequestBehavior.AllowGet);
        }
        [HasCredential(RoleID = "CREATE_DUAN")]
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

        public JsonResult Insert_CV(string name, string content, long emp_id, long pro_id, DateTime time_start, DateTime time_end, int cong)
        {
            // tạo biến tạm công việc;
            CongViec temp = new CongViec();
            temp.MaDA = pro_id;
            temp.Ten = name;
            temp.NoiDung = content;
            temp.Cong = cong;
            temp.ThoiGianBD = time_start;
            temp.ThoiGianKT = time_end;
            long cv_id = new CongViecDAO().Insert_CV(temp);
            bool result = new ChiTietLichLamViecDAO().Insert_CTLLV(cv_id, emp_id);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [HasCredential(RoleID = "DELETE_CONGVIEC, DELETE_CHITIETLICHLAMVIEC")]
        public JsonResult Delete_CV(long id)
        {
            bool result = new CongViecDAO().Delete_CV(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // truyền vào id của công việc, sửa đổi trạng thái của công việc đã xong hay chưa
        [HasCredential(RoleID = "UPDATE_CONGVIEC")]
        public JsonResult Change_status_cv(long id)
        {
            bool result = new CongViecDAO().Change_status(id);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}