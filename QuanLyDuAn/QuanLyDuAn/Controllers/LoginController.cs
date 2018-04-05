using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using QuanLyDuAn.Models;
using Common;

namespace QuanLyDuAn.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var Dao = new NhanVienDAO();
                var result = Dao.Login(model.Username, model.Password);
                if (result)
                {
                    Session.Add(CommonConstants.USER_SESSION);
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không thành công");
                }
            }
            return View("Index");
        }
    }
}