using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Manager
{
    public class DatabaseConnection
    {
        public SqlConnection sqlConn; //Doi tuong ket noi CSDL
        SqlDataAdapter da;//Bo dieu phoi du lieu
        DataTable dt; //Doi tuong chhua CSDL khi giao tiep
        public DatabaseConnection()
        {
            string strCnn = global::Library_Manager.Properties.Settings.Default.LIBRARYConnectionString;
            sqlConn = new SqlConnection(strCnn);
        }
        public bool verifyConnection()
        {
            try
            {
                sqlConn.Open();
                sqlConn.Close();
                sqlConn.Open();
            }
            catch (SqlException)
            {
                return false;
            }
            return true;
        }
        //Phuong thuc de thuc hien cau lenh strSQL truy vân du lieu
        public DataTable Execute(string sqlStr)
        {
            da = new SqlDataAdapter(sqlStr, sqlConn);
            dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        ////Phuong thuc de thuc hien cac lenh Them, Xoa, Sua
        public void ExecuteNonQuery(string strSQL)
        {
            SqlCommand sqlcmd = new SqlCommand(strSQL, sqlConn);
            //if (sqlConn.State == ConnectionState.Closed)
            //    sqlConn.Open(); //Mo ket noi
            sqlcmd.ExecuteNonQuery();//Lenh hien lenh Them/Xoa/Sua
            //sqlConn.Close();//Dong ket noi
        }
    }
}
