using ExamProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProject
{
    public interface IQuestionsTableManager
    {
        List<QuestionsTable> Respond();
    }
}
