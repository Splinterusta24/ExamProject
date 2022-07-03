using ExamProject.DAL;
using ExamProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ExamProject
{
    public class QuestionsTableManager//: IQuestionsTableManager
    {
        public List<QuestionsTable> Respond()
        {
            DataTable dt = new DataTable();
            SqlProcess sql = new SqlProcess();
            dt = sql.SetExecuteReader(@"Select * from QuestionsTable");
            List<QuestionsTable> answer = new List<QuestionsTable>();
            
            foreach (DataRow dr in dt.Rows)
            {

                QuestionsTable questionsTable = new QuestionsTable();
                questionsTable.AnswerKey = dr["AnswerKey"].ToString();
                questionsTable.QuestionsNumber = Convert.ToInt32(dr["QuestionNumber"]);
                answer.Add(questionsTable);

            }
            return answer;
        }

    }
}