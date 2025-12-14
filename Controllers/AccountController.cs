using System;
using System.Linq;
using System.Web.Mvc;
using QuanLyKhachSan.Models;

namespace QuanLyKhachSan.Controllers
{
    public class AccountController : Controller
    {
        private QLKSEntities db = new QLKSEntities();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = db.TAI_KHOAN.FirstOrDefault(u => u.TEN_DANG_NHAP == model.Username && u.MAT_KHAU == model.Password);

                if (user != null)
                {
                    Session["MA_TK"] = user.MA_TK;
                    Session["USERNAME"] = user.TEN_DANG_NHAP;
                    Session["ROLE"] = user.VAI_TRO;
                    Session["USER"] = user; // Keeping object for convenience in layouts if compatible

                    if (user.VAI_TRO == "KHACHHANG")
                    {
                         // Using MA_TK FK in KHACH_HANG
                         var kh = db.KHACH_HANG.FirstOrDefault(k => k.MA_TK == user.MA_TK);
                         if (kh != null) Session["KHACH_HANG"] = kh;
                    }
                    else if (user.VAI_TRO == "NHANVIEN")
                    {
                         var nv = db.NHAN_VIEN.FirstOrDefault(n => n.MA_TK == user.MA_TK);
                         if (nv != null) Session["NHAN_VIEN"] = nv;
                    }

                    if (user.VAI_TRO == "QUANTRI")
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else if (user.VAI_TRO == "NHANVIEN")
                    {
                        return RedirectToAction("Bookings", "Staff");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng.");
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}
