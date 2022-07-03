using ExamProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ExamProject.DAL
{
    public class SqlProcess
    {
        SqlConnection _con;
        SqlCommand _command;
        readonly SqlCon conn = new SqlCon();


        private SqlConnection Connect()
        {
            
            _con = new SqlConnection(conn.ConnectionString);

            if (_con.State != ConnectionState.Open)
            {
                
            _con.Open();
                return _con;
            }
            else
            {
                return null;    
            }

        }
        private void Closed()
        {
            if (_con.State == ConnectionState.Open)
            {
                _con.Close();
            }
        }
        public bool SetExecuteNonQuery(string cmdText)
        {
            try
            {
                _command = new SqlCommand(cmdText, Connect());
                _command.ExecuteNonQuery();
                _command.Dispose();
                Closed();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool SetExecuteNonQuery(string cmdText,params SqlParameter[] sqlParameters)
        {
            try
            {
                _command = new SqlCommand(cmdText, Connect());
                _command.Parameters.AddRange(sqlParameters);
                _command.ExecuteNonQuery();
                _command.Dispose();
                Closed();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }
        
        public DataTable SetExecuteReader(string cmdText)
        {
          
                DataTable dt = new DataTable();
                _command = new SqlCommand(cmdText, Connect());
                dt.Load(_command.ExecuteReader());
                //_command.Dispose();
                Closed();
                return dt;
            
           
        }

        public DataTable SetExecuteReader(string cmdText,params SqlParameter[] sqlParameters)
        {
            try
            {
                DataTable dt = new DataTable();
                _command = new SqlCommand(cmdText, Connect());
                _command.Parameters.AddRange(sqlParameters);
                dt.Load(_command.ExecuteReader());
                _command.Dispose();
                Closed();
                return dt;
            }
            catch (Exception)
            {
                return null;
                
            }
        }

        
    }
}