using ExamProject.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ExamProject.Models
{
    public interface IPropertiess
    {
        int Id { get; set; }
        string Name { get; set; }
        string SurName { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        char AnswerKey { get; set; }
    }
}


