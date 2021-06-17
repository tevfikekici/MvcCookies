using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cookies.Controllers
{
    public class CookieController : Controller
    {
        // GET: Cookie
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
          //HttpCookie cookieUser = new HttpCookie("key", "value");
            HttpCookie cookieUser = new HttpCookie("user", "john");
            HttpContext.Response.Cookies.Add(cookieUser);
            cookieUser.Expires = DateTime.Now.AddDays(15); //set time range for how long you want device to keep this cookie
            return View("Cookie");
        }

        public ActionResult Read()
        {        
            ViewBag.User = HttpContext.Request.Cookies["user"].Value;

            return View("Cookie");
        }

        public ActionResult Delete()
        {

            HttpContext.Request.Cookies.Remove("user");
            return View("Cookie");
        }

        public ActionResult Existence()
        {
            if (HttpContext.Request.Cookies["user"]==null)
            {
                ViewBag.Message = "Cookie Not Found!";
            }
            else
            {
                ViewBag.Message = "Cookie Found!";
            }
            return View("Cookie");
        }
    }
}