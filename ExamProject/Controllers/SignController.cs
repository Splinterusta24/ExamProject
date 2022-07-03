using ExamProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamProject.Controllers
{
    public class SignController : Controller
    {
        // GET: Sign
        public bool Access { get; set; }
        public ActionResult SignUp()
        {
            if (Session["Active"] != null)
            {
                return RedirectToAction("MainPage", "Home");
            }

            return View();
        }

        public ActionResult SignIn()
        {
            if (Session["Active"] != null)
            {
                return RedirectToAction("MainPage", "Home");
            }

            return View();
        }
        [HttpPost]
        public JsonResult SignUpPost(string txtCreateName, string txtCreateSurName, string txtCreateEmail, string txtCreatePassword)
        {
            ConnectionMethods connectionMethods = new ConnectionMethods
            {
                Name = txtCreateName,
                SurName = txtCreateSurName,
                Email = txtCreateEmail,
                Password = txtCreatePassword
            };

            connectionMethods.Registery();

            return Json(null);

        }
        [HttpPost]
        public JsonResult Enter(string txtEmail, string txtPassword)
        {
            ConnectionMethods connectionMethods = new ConnectionMethods();
            bool x;
            connectionMethods.Email = txtEmail;
            connectionMethods.Password = txtPassword;
            Session["Kullanici"] = txtEmail;

            if (connectionMethods.Enter() == true)
            {
                Session["Active"] = true;

                x = true;
            }
            else
            {
                x = false;
            }

            return Json(new { code = x, msg = "başarılı", msg2 = "kullanıcı adı veya şifre yanlış" });
        }
    }
}