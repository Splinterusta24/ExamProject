using ExamProject.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ExamProject.Models
{
    public class ConnectionMethods
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Answers { get; set; }
        public int Correct { get; set; }

        readonly SqlProcess sql = new SqlProcess();
        DataTable dt = new DataTable();

        public void Registery()
        {
            sql.SetExecuteNonQuery(@"Insert into Students (Name,SurName,Email,Password) values (@name,@surname,@email,@password)", new SqlParameter("@name", Name),
                       new SqlParameter("@surname", SurName),
                       new SqlParameter("@email", Email),
                       new SqlParameter("@password", Password)
                   );
        }
        public bool Enter()
        {

            dt = sql.SetExecuteReader(@"Select * from Students where Email=@email and Password=@password",
                        new SqlParameter("@email", Email),
                        new SqlParameter("@password", Password)
                 );
            if (dt.Rows.Count > 0)
            {

                return true;

            }
            else
            {
                return false;
            }
        }
        public List<ConnectionMethods> ExamCorrect()
        {

            dt = sql.SetExecuteReader("select S.Name, S.SurName, S.Email, COALESCE(CT.Correct,0) as Correct  from Students as S left outer join CorrectTable as CT on S.Id = Ct.StudentId");
            List<ConnectionMethods> list = new List<ConnectionMethods>();
            foreach (DataRow data in dt.Rows)
            {
                
                list.Add(new ConnectionMethods
                {
                    Name = (string)data["Name"],
                   SurName = (string)data["SurName"],
                    Email = (string)data["Email"],
                   Correct = (int)data["Correct"]
                });
            }

            return list;

        }




    }

}
