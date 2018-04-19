using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using QuanLyDuAn.Models;
using QuanLyDuAn.Common;

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
            if (ModelState.IsValid)
            {
                var Dao = new NhanVienDAO();
                long result = Dao.Login(username, password);
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
                    ModelState.AddModelError("LoginError", "Đăng nhập không thành công");
                }
            }
            return View("Index");
        }
        public ActionResult LogOut()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return RedirectToAction("Index", "Home");

        }
    }
}