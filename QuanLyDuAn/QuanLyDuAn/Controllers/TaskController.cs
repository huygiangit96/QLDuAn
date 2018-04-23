using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using Model.EF;
using QuanLyDuAn.Common;

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
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            ViewBag.MessageList = dao.GetByNV(session.UserID);
            ViewBag.list_nv = new NhanVienDAO().ListAll();
            return View();
        }
        public JsonResult ViewMessage(long id)
        {
            var session = (UserLogin)Session[CommonConstants.USER_SESSION];
            var data = new NhacNhoDAO().GetByNV(session.UserID).SingleOrDefault(x => x.MaNN == id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SendMessage(long manv, string tieude, string noidung, long nguoinhan)
        {
            NhacNho item = new NhacNho();
            item.MaNV = manv;
            item.ThoiGian = DateTime.Now;
            item.TieuDe = tieude;
            item.NoiDung = noidung;
            item.NguoiNhanID = nguoinhan;
            item.NgayTao = DateTime.Now;
            return Json(new
            {
                status = new NhacNhoDAO().Insert(item)
            });
        }
        public JsonResult DelMessage(long mann)
        {
            return Json(new
            {
                status = new NhacNhoDAO().Delete(mann)
            });
        }
        public JsonResult ChangeMessStatus(long id)
        {
            new NhacNhoDAO().ChangeStatus(id);
            return Json(new
            {
                status = true
            });
        }
        // lịch làm việc
        public ActionResult Assignment()
        {
            ViewBag.list_nv = new NhanVienDAO().ListAll();
            ViewBag.list_da = new DuAnDAO().ListAll();
            ViewBag.list_vt = new ViTriDAO().ListAll();
            return View();
        }
        public JsonResult GetCalendar(long manv)
        {
            var item = new CongViecDAO().ListCV(manv);
            return Json(item, JsonRequestBehavior.AllowGet);
        }
        //Thêm Công việc vào lịch
        public JsonResult InsertCalendar(long manv, long mada, string ten, string noidung, int cong, DateTime start_time, DateTime end_time, long Vitri)
        {
            try
            {
                CongViec cv = new CongViec();
                cv.MaDA = mada;
                cv.Ten = ten;
                cv.NoiDung = noidung;
                cv.Cong = cong;
                cv.ThoiGianBD = start_time;
                cv.ThoiGianKT = end_time;
                CongViecDAO cv_dao = new CongViecDAO();
                cv_dao.Insert(cv);
                ChiTietLichLamViec ct = new ChiTietLichLamViec();
                ct.MaNV = manv;
                ct.MaCV = cv_dao.GetCvIDByNameAndDaID(mada, ten).MaCV;
                ct.MaVTri = Vitri;
                new ChiTietLichLamViecDAO().Insert(ct);
                return Json(new
                {
                    status = true
                });
            }
            catch
            {
                return Json(new {
                    status = false
                });
            }
        }
        //Lấy NV theo Công việc
        public JsonResult GetNV_CV_Vtri(long macv)
        {
            var data = new ChiTietLichLamViecDAO().GetNVByCV(macv);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        //Thêm nv vào công việc (Chi tiết lịch làm việc)
        public JsonResult Insert_NV_CV(long manv, long macv)
        {
            ChiTietLichLamViec item = new ChiTietLichLamViec();
            item.MaCV = macv;
            item.MaNV = manv;
            item.MaVTri = 2;
            var result = new ChiTietLichLamViecDAO().Insert(item);
            return Json(new
            {
                status = result
            });
        }
        public JsonResult Edit_VT(long manv, long macv, long mavtri)
        {
            var result = new ChiTietLichLamViecDAO().ChangeViTri(manv, macv, mavtri);
            string notif = "Sửa thành công";
            if (result == 1) notif = "Đã thay đổi vai trò thành LEADER !\nLEADER hiện tại thay đổi thành MEMBER";
            if (result == 2 || result == 3) notif = "Chọn LEADER mới trước !";
            return Json(notif, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Edit_CV(long macv, string ten, string noidung, int cong, DateTime start_time, DateTime end_time)
        {
            CongViec item = new CongViec();
            item.MaCV = macv;
            item.Ten = ten;
            item.NoiDung = noidung;
            item.Cong = cong;
            item.ThoiGianBD = start_time;
            item.ThoiGianKT = end_time;
            return Json(new
            {
                status = new CongViecDAO().Edit_CV(item)

            });
        }
        // chấm công
        public ActionResult Time_keeping()
        {
            ViewBag.list_da = new DuAnDAO().ListAll();
            var data = new NhanVienDAO().GetProj_CCNone_NV();
            ViewBag.FirstShow = data;
            return View();
        }
        public JsonResult ViewAll()
        {
            return Json(new NhanVienDAO().GetProj_CCNone_NV(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ViewByProject (long mada)
        {
            var data = new NhanVienDAO().GetProj_CC_NV(mada);
            return Json(new NhanVienDAO().GetProj_CC_NV(mada), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetNVProj(long mada)
        {
            return Json(new DuAnDAO().GetNVjoinProject(mada), JsonRequestBehavior.AllowGet);
        }
    }
}