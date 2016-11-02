using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsTest
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        
        static void Main(string[] argc)
        {
string connString = "Provider=OraOLEDB.Oracle.1;User ID=MGIS;Password=MGIS;Data Source=(DESCRIPTION = (ADDRESS_LIST= (ADDRESS = (PROTOCOL = TCP)(HOST = 172.17.10.216)(PORT = 1521))) (CONNECT_DATA = (SERVICE_NAME = MGISDB)))";
OleDbConnection conn = new OleDbConnection(connString);
try
{
    conn.Open();
    OleDbCommand comm = new OleDbCommand("select * from WFDK_GZQK",conn);
    OleDbDataReader dr = comm.ExecuteReader();

    Console.WriteLine("1st      2st");
    while (dr.Read())
    {
        Console.WriteLine(dr.GetString(1)+"     "+dr.GetString(2));
    }
    dr.Close();
}
catch (Exception ex)
{
    MessageBox.Show(ex.Message.ToString());
}
finally
{
    conn.Close();
}
        }
    }
}
