using ExamProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamProject.Controllers
{
    public class ExamController : Controller
    {

        // GET: Exam

        public ActionResult Exams()
        {
            if (Session["Active"] == null)
            {
                return RedirectToAction("MainPage", "Home");
            }
            return View();
        }
        public ActionResult ExamResults()
        {
            if (Session["Active"] == null)
            {
                return RedirectToAction("MainPage", "Home");
            }

            ConnectionMethods connectionMethods = new ConnectionMethods();
            connectionMethods.ExamCorrect();

            return View(connectionMethods.ExamCorrect());
        }

      
        [HttpPost]
        public JsonResult Answer(List<QuestionsTable> questionsTables)
        {
            QuestionsTableManager questionsTableManager = new QuestionsTableManager();
            QuestionsTable questionsTable = new QuestionsTable();
            var questions = questionsTableManager.Respond();
            int num = 0;            

            for (int i = 0; i < questions.Count; i++)
            {
                var gelen = questionsTables.Where(x => x.QuestionsNumber == questions[i].QuestionsNumber).FirstOrDefault();

                if (questions[i].AnswerKey == gelen.AnswerKey)
                {
                    num++;
                }

            }
            ConnectionMethods connectionMethods = new ConnectionMethods();
            connectionMethods.Correct = num;

            //questionsTable.Correct = num;   


            return Json(num);

        }
    }
}