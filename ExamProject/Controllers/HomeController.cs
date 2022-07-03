using ExamProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult MainPage()
        {
            
            if (Session["Active"] == null)
            {
                return RedirectToAction("SignIn", "Sign");
            }
            
            
            return View();
        }
        [HttpPost]
        public JsonResult Exit()
        {
            bool x = true;
            Session["Active"] = null;


                x = true;
            
                
           



            return Json(new {code = x});

        }
    }
}