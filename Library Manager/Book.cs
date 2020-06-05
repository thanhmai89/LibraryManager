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
    public static class Book
    {
        public static string[] getBookName()
        {
            DataTable dataTable = Utility.DATABASECONNECTION.Execute("SELECT * FROM FUNCTION_GET_ALL_BOOK_NAME()");
            string[] res = new string[dataTable.Rows.Count];
            for (int i = 0; i < dataTable.Rows.Count; i++)
                res[i] = dataTable.Rows[i][0].ToString();
            return res;
        }
        public static bool haveBook(string id)
        {
            string cmd = "";
            if (id.Length > 0)
            {
                cmd = string.Format("SELECT SERIAL FROM BOOK WHERE SERIAL = '{0}'", id);
                return Utility.DATABASECONNECTION.Execute(cmd).Rows.Count > 0 ? true : false;
            }
            return false;
        }
        public static string[] getBookSerial()
        {
            DataTable dataTable = Utility.DATABASECONNECTION.Execute("SELECT * FROM FUNCTION_GET_ALL_BOOK_SERIAL()");
            string[] res = new string[dataTable.Rows.Count];
            for (int i = 0; i < dataTable.Rows.Count; i++)
                res[i] = dataTable.Rows[i][0].ToString();
            return res;
        }

        public static DataTable findBookByName(string name)
        {
            string cmd = "";
            if (name.Length > 0)
            {
                cmd = string.Format("SELECT * FROM BOOK WHERE NAME LIKE N'{0}'", name);
                return Utility.DATABASECONNECTION.Execute(cmd);
            }
            return null;
        }

        public static DataTable findBookBySerial(string serial)
        {
            string cmd = "";
            if (serial.Length > 0)
            {
                cmd = string.Format("SELECT * FROM BOOK WHERE SERIAL = '{0}'", serial);
                return Utility.DATABASECONNECTION.Execute(cmd);
            }
            return null;
        }

        public static bool insertBook(string serial, string name, string author, string ph, int quantum, string imageLoc, string tag)
        {
            string cmd = string.Format("SELECT SERIAL FROM BOOK WHERE SERIAL = '{0}'", serial);
            string cmd2 = string.Format("SELECT NAME FROM BOOK WHERE NAME LIKE N'{0}'", name);
            int rowsCount = Utility.DATABASECONNECTION.Execute(cmd).Rows.Count + Utility.DATABASECONNECTION.Execute(cmd2).Rows.Count;
            if (rowsCount > 0)
            {
                return false;
            }
            else
            {
                try
                {
                    Image image = Utility.FixedSize(Image.FromFile(imageLoc), 200, 200);

                    byte[] img = Utility.ImageToByteArray(image);
                    //FileStream fileStream = new FileStream(imageLoc, FileMode.Open, FileAccess.Read);
                    //BinaryReader binaryReader = new BinaryReader(fileStream);
                    //img = binaryReader.ReadBytes((int)fileStream.Length);
                    SqlCommand sqlCommand;
                    cmd = string.Format("EXEC PROC_INSERT_BOOK " +
                                        "'{0}', N'{1}', N'{2}', N'{3}', {4}, @img, '{5}'", serial, name, author, ph, quantum, tag);
                    sqlCommand = new SqlCommand(cmd, Utility.DATABASECONNECTION.sqlConn);
                    sqlCommand.Parameters.Add("@img", img);
                    sqlCommand.ExecuteNonQuery();
                } 
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return true;
        }

        public static bool updateBook(string serial, string name, string author, string ph, int quantum, string imageLoc, string tag)
        {
            string cmd = string.Format("SELECT SERIAL FROM BOOK WHERE SERIAL = '{0}'", serial);
            int rowsCount = Utility.DATABASECONNECTION.Execute(cmd).Rows.Count;
            if (rowsCount == 0)
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
                    cmd = string.Format("EXEC PROC_UPDATE_BOOK " +
                                        "'{0}', N'{1}', N'{2}', N'{3}', {4}, @img, '{5}'", serial, name, author, ph, quantum, tag);
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

        public static bool updateBook(string serial, string name, string author, string ph, int quantum, byte[] img, string tag)
        {
            string cmd = string.Format("SELECT SERIAL FROM BOOK WHERE SERIAL = '{0}'", serial);
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
                    cmd = string.Format("EXEC PROC_UPDATE_BOOK " +
                                        "'{0}', N'{1}', N'{2}', N'{3}', {4}, @img, '{5}'", serial, name, author, ph, quantum, tag);
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

        public static bool deleteBook(string serial)
        {
            string cmd = "";
            try
            {
                cmd = string.Format("EXEC PROC_DELETE_BOOK {0}", serial);
                Utility.DATABASECONNECTION.ExecuteNonQuery(cmd);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static string getBookNameBySerial(string serial)
        {
            string cmd = "";
            if (serial.Length > 0)
            {
                cmd = string.Format("SELECT NAME FROM BOOK WHERE SERIAL = '{0}'", serial);
                return Utility.DATABASECONNECTION.Execute(cmd).Rows[0][0].ToString();
            }
            return null;
        }

        public static string getBookQuantumBySerial(string serial)
        {
            string cmd = "";
            if (serial.Length > 0)
            {
                try
                {
                    cmd = string.Format("SELECT QUANTUM FROM BOOK WHERE SERIAL = '{0}'", serial);
                    return Utility.DATABASECONNECTION.Execute(cmd).Rows[0][0].ToString();
                } catch
                {

                }
            }
            return null;
        }
    }
}
