using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamProject.Controllers
{
    public class LessonsController : Controller
    {
        // GET: Lessons
        public ActionResult LessonText()
        {
            if (Session["Active"] == null)
            {
                return RedirectToAction("SignIn", "Sign");
            }
            return View();
        }
        public ActionResult LessonVideos()
        {
            if (Session["Active"] == null)
            {
                return RedirectToAction("SignIn", "Sign");
            }
            return View();
        }
    }
}