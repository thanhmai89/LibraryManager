using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Library_Manager
{
    public static class SysAccount
    {
        public static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static bool CheckOldPass(string username, string oldPass)
        {
            username = username.ToUpper();
            string cmd = string.Format("SELECT PASSWORD FROM ACCOUNT WHERE USER_NAME = '{0}'", username);
            return (ComputeSha256Hash(oldPass) == Utility.DATABASECONNECTION.Execute(cmd).Rows[0][0].ToString()) ? true : false;
        }
        public static bool CreateAccount(string username, string password)
        {
            username = username.ToUpper();
            string cmd = string.Format("SELECT USER_NAME FROM ACCOUNT WHERE USER_NAME = '{0}'", username);
            int rowsCount = Utility.DATABASECONNECTION.Execute(cmd).Rows.Count;
            if (rowsCount > 0)
            {
                return false;
            }
            else
            {
                cmd = string.Format("DECLARE @SUCC INT " +
                                   "EXEC PROC_INSERT_ACCOUNT '{0}', '{1}', @SUCC OUTPUT" +
                                   " SELECT STR(@SUCC, 10)", username, ComputeSha256Hash(password));
                rowsCount = int.Parse(Utility.DATABASECONNECTION.Execute(cmd).Rows[0][0].ToString());
                if (rowsCount <= 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool UpdateAccount(string username, string password)
        {
            username = username.ToUpper();
            string cmd = string.Format("SELECT USER_NAME FROM ACCOUNT WHERE USER_NAME = '{0}'", username);
            int rowsCount = Utility.DATABASECONNECTION.Execute(cmd).Rows.Count;
            if (rowsCount == 0)
            {
                return false;
            }
            else
            {
                cmd = string.Format("DECLARE @SUCC INT " +
                                   "EXEC PROC_UPDATE_ACCOUNT '{0}', '{1}', @SUCC OUTPUT" +
                                   " SELECT STR(@SUCC, 10)", username, ComputeSha256Hash(password));
                rowsCount = int.Parse(Utility.DATABASECONNECTION.Execute(cmd).Rows[0][0].ToString());
                if (rowsCount <= 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool LoginAccount(string username, string password)
        {
            username = username.ToUpper();
            string cmd;
            try
            {
                cmd = string.Format("SELECT * FROM FUNCTION_LOGIN_ACCOUNT('{0}','{1}')", username,ComputeSha256Hash(password));
                Utility.ACCOUNT = Utility.DATABASECONNECTION.Execute(cmd).Rows[0][0].ToString();
            } 
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            cmd = string.Format("EXEC PROC_LOGIN_EVENT '{0}'", username);
            Utility.DATABASECONNECTION.ExecuteNonQuery(cmd);
            return true;
        }

        public static void LogOutAccount(string username)
        {
            string cmd = string.Format("EXEC PROC_LOGOUT_EVENT '{0}'", username);
            Utility.ACCOUNT = "#";
            Utility.DATABASECONNECTION.ExecuteNonQuery(cmd);
        }
    }
}
