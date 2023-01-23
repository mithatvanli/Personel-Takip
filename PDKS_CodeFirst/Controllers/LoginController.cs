using PDKS_CodeFirst.DAL;
using PDKS_CodeFirst.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PDKS_CodeFirst.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        PDKSContext a = new PDKSContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Kullanicilar ad)
        {
            var bilgiler = a.Kullanicilars.FirstOrDefault(x => x.KullaniciAdi == ad.KullaniciAdi && x.KullaniciParola == ad.KullaniciParola);


            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KullaniciAdi, false);
                Session["KullaniciAdi"] = bilgiler.KullaniciAdi.ToString();
                return RedirectToAction("Index", "Belgelers");
            }
            else
            {
                return View();
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }
    }
}