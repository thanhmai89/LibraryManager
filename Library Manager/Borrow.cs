using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Manager
{
    public static class Borrow
    {
        public static string[] getBorrowId()
        {
            DataTable dataTable = Utility.DATABASECONNECTION.Execute("SELECT * FROM FUNCTION_GET_ALL_BORROW_ID()");
            string[] res = new string[dataTable.Rows.Count];
            for (int i = 0; i < dataTable.Rows.Count; i++)
                res[i] = dataTable.Rows[i][0].ToString();
            return res;
        }

        public static DataTable findBorrowById(string id)
        {
            string cmd = "";
            if (id.Length > 0)
            {
                cmd = string.Format("SELECT * FROM FUNCTION_GET_BORROW('{0}')", id);
                return Utility.DATABASECONNECTION.Execute(cmd);
            }
            return null;
        }

        public static DataTable findBorrowByIdStudent(string id)
        {
            string cmd = "";
            if (id.Length > 0)
            {
                cmd = string.Format("SELECT * FROM FUNCTION_GET_STUDENT_BORROW('{0}')", id);
                return Utility.DATABASECONNECTION.Execute(cmd);
            }
            return null;
        }

        public static int numOfBorrowCard(string id)
        {
            try
            {
                string cmd = string.Format("SELECT COUNT(*) FROM BORROW WHERE ID_STUDENT = '{0}'", id);
                return int.Parse(Utility.DATABASECONNECTION.Execute(cmd).Rows[0][0].ToString());
            }
            catch
            {
                return -1;
            }
        }
        public static int getId()
        {
            try
            {
                string cmd = "SELECT TOP 1 ID FROM BORROW ORDER BY ID DESC";
                return int.Parse(Utility.DATABASECONNECTION.Execute(cmd).Rows[0][0].ToString());
            }
            catch
            {
                return 0;
            }
        }
        public static int insertBorrow(string idStudent)
        {
            try
            {
                string cmd = string.Format("EXEC PROC_INSERT_BORROW '{0}'", idStudent);
                Utility.DATABASECONNECTION.ExecuteNonQuery(cmd);
                cmd = "SELECT TOP 1 ID FROM BORROW ORDER BY ID DESC";
                return int.Parse(Utility.DATABASECONNECTION.Execute(cmd).Rows[0][0].ToString());
            }
            catch
            {
                return -1;
            }

        }
        public static bool insertBorrow(string id, string serial, int quantum, DateTime timecreate, int borrowTime, string comment)
        {
            try
            {
                SqlCommand sqlCommand;
                string cmd = string.Format("EXEC PROC_INSERT_BORROW_DETAIL " +
                                        "{0}, '{1}', '{2}', @time, '{3}', N'{4}'", id, serial, quantum, borrowTime, comment);
                //Utility.DATABASECONNECTION.ExecuteNonQuery(cmd);
                sqlCommand = new SqlCommand(cmd, Utility.DATABASECONNECTION.sqlConn);
                sqlCommand.Parameters.Add("@time", timecreate);
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
            return true;
        }

        public static bool deleteBorrow(string id)
        {
            string cmd = "";
            try
            {
                cmd = string.Format("EXEC PROC_DELETE_BORROW {0}", id);
                Utility.DATABASECONNECTION.ExecuteNonQuery(cmd);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }
}
