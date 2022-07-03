using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamProject.DAL
{
    public class SqlCon
    {
        private string _connectionString = @"Server = DESKTOP-63E5VH2; Database=Exam;Trusted_Connection=True;";

        public string ConnectionString { get { return _connectionString;}}



    }
}