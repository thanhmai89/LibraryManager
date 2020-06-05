using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Manager
{
    public static class Student
    {
        public static string[] getStudentName()
        {
            DataTable dataTable = Utility.DATABASECONNECTION.Execute("SELECT * FROM FUNCTION_GET_ALL_STUDENT_NAME()");
            string[] res = new string[dataTable.Rows.Count];
            for (int i = 0; i < dataTable.Rows.Count; i++)
                res[i] = dataTable.Rows[i][0].ToString();
            return res;
        }

        public static string[] getStudentId()
        {
            DataTable dataTable = Utility.DATABASECONNECTION.Execute("SELECT * FROM FUNCTION_GET_ALL_STUDENT_ID()");
            string[] res = new string[dataTable.Rows.Count];
            for (int i = 0; i < dataTable.Rows.Count; i++)
                res[i] = dataTable.Rows[i][0].ToString();
            return res;
        }

        public static DataTable findStudentById(string id)
        {
            string cmd = "";
            if (id.Length > 0)
            {
                cmd = string.Format("SELECT * FROM STUDENT WHERE ID LIKE '{0}'", id);
                return Utility.DATABASECONNECTION.Execute(cmd);
            }
            return null;
        }

        public static bool insertStudent(string id, string name, string phone, string email, string imageLoc)
        {
            string cmd = string.Format("SELECT ID FROM STUDENT WHERE ID = '{0}'", id);
            if (Utility.DATABASECONNECTION.Execute(cmd).Rows.Count > 0)
            {
                return false;
            }
            else
            {
                try
                {
                    Image image = Utility.FixedSize(Image.FromFile(imageLoc), 200, 200);

                    byte[] img = Utility.ImageToByteArray(image);
                    SqlCommand sqlCommand;
                    cmd = string.Format("EXEC PROC_INSERT_STUDENT " +
                                        "'{0}', N'{1}', '{2}', '{3}', @img", id, name, phone, email);
                    sqlCommand = new SqlCommand(cmd, Utility.DATABASECONNECTION.sqlConn);
                    sqlCommand.Parameters.Add("@img", img);
                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return true;
        }

        public static bool updateStudent(string id, string name, string phone, string email, string imageLoc)
        {
            string cmd = string.Format("SELECT ID FROM STUDENT WHERE ID = '{0}'", id);
            if (Utility.DATABASECONNECTION.Execute(cmd).Rows.Count == 0)
            {
                return false;
            }
            else
            {
                try
                {
                    Image image = Utility.FixedSize(Image.FromFile(imageLoc), 200, 200);

                    byte[] img = Utility.ImageToByteArray(image);
                    SqlCommand sqlCommand;
                    cmd = string.Format("EXEC PROC_UPDATE_STUDENT " +
                                        "'{0}', N'{1}', '{2}', '{3}', @img", id, name, phone, email);
                    sqlCommand = new SqlCommand(cmd, Utility.DATABASECONNECTION.sqlConn);
                    sqlCommand.Parameters.Add("@img", img);
                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
            return true;
        }
        public static bool updateStudent(string id, string name, string phone, string email, byte[] img)
        {
            string cmd = string.Format("SELECT ID FROM STUDENT WHERE ID = '{0}'", id);
            int rowsCount = Utility.DATABASECONNECTION.Execute(cmd).Rows.Count;
            if (rowsCount == 0)
            {
                return false;
            }
            else
            {
                try
                {
                    SqlCommand sqlCommand;
                    cmd = string.Format("EXEC PROC_UPDATE_STUDENT " +
                                        "'{0}', N'{1}', '{2}', '{3}', @img", id, name, phone, email);
                    sqlCommand = new SqlCommand(cmd, Utility.DATABASECONNECTION.sqlConn);
                    sqlCommand.Parameters.Add("@img", img);
                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
            return true;
        }
        public static bool deleteStudent(string id)
        {
            string cmd = "";
            try
            {
                cmd = string.Format("EXEC PROC_DELETE_STUDENT {0}", id);
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
