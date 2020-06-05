using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Manager
{
    public static class Data
    {
        public static DataTable ViewLog()
        {
            try
            {
                return Utility.DATABASECONNECTION.Execute("SELECT * FROM LOG ORDER BY TIME_CREATE");    
            }
            catch
            {
                return null;
            }
        }

        public static DataTable ViewBorrowOverTime()
        {
            try
            {
                return Utility.DATABASECONNECTION.Execute("SELECT * FROM VIEW_BORROW_OVER_TIME");
            }
            catch
            {
                return null;
            }
        }
        public static DataTable ViewAllBook()
        {
            try
            {
                return Utility.DATABASECONNECTION.Execute("SELECT * FROM VIEW_ALL_BOOK");
            }
            catch
            {
                return null;
            }
        }
        public static DataTable ViewAllStudent()
        {
            try
            {
                return Utility.DATABASECONNECTION.Execute("SELECT * FROM VIEW_ALL_STUDENT");
            }
            catch
            {
                return null;
            }
        }
        public static DataTable ViewAllBorrowCard()
        {
            try
            {
                return Utility.DATABASECONNECTION.Execute("SELECT * FROM VIEW_ALL_BORROW_CARD");
            }
            catch
            {
                return null;
            }
        }
    }
}
