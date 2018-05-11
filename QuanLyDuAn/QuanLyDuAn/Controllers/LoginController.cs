using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using QuanLyDuAn.Models;
using QuanLyDuAn.Common;
using Model.EF;
using System.Text;
using System.Security.Cryptography;
using System.Configuration;

namespace QuanLyDuAn.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            ViewBag.Notif = null;
            if (ModelState.IsValid)
            {
               
                var Dao = new NhanVienDAO();
                long result = Dao.Login(username, GetMD5(password));
                if (result != 0)
                {
                    var user = Dao.GetByUserName(username);
                    var UserSession = new UserLogin();
                    UserSession.UserID = user.MaNV;
                    UserSession.Name = user.Ten;
                    UserSession.DuAn = new DuAnDAO().GetProjLead(user.MaNV);
                    UserSession.VaiTro = user.MaVT;
                    var ListCredentials = Dao.GetListCredential(username);
                    Session.Add(CommonConstants.SESSION_CREDENTIAL, ListCredentials);
                    Session.Add(CommonConstants.USER_SESSION, UserSession);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    var UserSession = new UserLogin();
                    ViewBag.Notif =  "Đăng nhập không thành công";
                }
            }
            return View("Index");
        }
        public ActionResult LogOut()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return RedirectToAction("Index", "Home");

        }

        public JsonResult Change_pass(long id, string old_pass, string new_pass)
        {
            int result = new NhanVienDAO().Change_pass(id, old_pass, new_pass);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        private String GetMD5(string txt)
        {
            String str = "";
            Byte[] buffer = System.Text.Encoding.UTF8.GetBytes(txt);
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            buffer = md5.ComputeHash(buffer);
            foreach (Byte b in buffer)
            {
                str += b.ToString("X2");
            }
            return str;
        }
    }
}