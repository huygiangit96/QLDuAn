using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyDuAn.Common;

namespace QuanLyDuAn.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            List<KhachHang> model = new List<KhachHang>();
            model = new KhachHangDAO().ListAll();
            return View(model);
        }
        // get current customer show on modal
        public JsonResult Get(string id)
        {
            KhachHang item = new KhachHangDAO().GetByID(id);
            return Json(item, JsonRequestBehavior.AllowGet);
        }
        [HasCredential(RoleID ="DELETE_KHACHHANG")]
        public JsonResult Delete(string id)
        {
            bool status = new KhachHangDAO().Delete(id);
            return Json(status, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Insert(string code, string name, string address, string bank, string phone)
        {
            KhachHang item = new KhachHang();
            item.MaKH = code;
            item.Ten = name;
            item.DiaChi = address;
            item.SoTK = bank;
            item.SoDT = phone;
            bool result = new KhachHangDAO().Insert(item);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Edit(string code, string name, string address, string bank, string phone)
        {
            KhachHang item = new KhachHang();
            item.MaKH = code;
            item.Ten = name;
            item.DiaChi = address;
            item.SoTK = bank;
            item.SoDT = phone;
            bool result = new KhachHangDAO().Update(item);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}