using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignalR_Group.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Chat()
        {
            var token = Request.Cookies["token"];
            if (token == null) return Redirect("~/User/Login");
            var username = JWThelper.Decrypt(token.Value);
            if (string.IsNullOrEmpty(username) && username == "yuezhang")
                return Redirect("~/User/Login");
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string userName, string password)
        {
            string token = JWThelper.Encrypt(userName);
            Response.SetCookie(new HttpCookie("token", token));
            return Redirect("~/User/Chat");
        }
    }
}