﻿using System;
using System.Web;
using System.Web.Mvc;

namespace AspNetFrameworkMVC.Controllers
{
    public class MVC10CookieController : Controller
    {
        // GET: MVC10Cookie
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CookieOlustur()
        {
            HttpCookie cookie = new HttpCookie("username", "Admin")
            {
                Expires = DateTime.Now.AddMinutes(10) // cookie ye 1 dk lık bitiş süresi tanımladık     
            };

            HttpContext.Response.Cookies.Add(cookie); // .net freamework de HttpContext ile oluşturuyoruz
            return View();
        }
        public ActionResult CookieOku()
        {
            if (HttpContext.Request.Cookies["username"] != null)
            {
                TempData["kullaniciadi"] = HttpContext.Request.Cookies["username"].Value; // yukardaki action da oluşturduğumuz cookie yi başka bir sayfada yakalama 
            }
            return View();
        }
        public ActionResult CookieSil()
        {
            if (HttpContext.Request.Cookies["username"] != null) // Request = İstek
                HttpContext.Response.Cookies["username"].Expires = DateTime.Now.AddSeconds(-1); // Response = Cevap
            return RedirectToAction("CookieOku");
        }
    }
}