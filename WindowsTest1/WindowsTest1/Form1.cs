using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
namespace WindowsTest1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connString = "Provider=OraOLEDB.Oracle.1;User ID=MGIS;Password=MGIS;Data Source=(DESCRIPTION = (ADDRESS_LIST= (ADDRESS = (PROTOCOL = TCP)(HOST = 172.17.10.216)(PORT = 1521))) (CONNECT_DATA = (SERVICE_NAME = MGISDB)))";
            OleDbConnection conn = new OleDbConnection(connString);
            try
            {
                conn.Open();
                OleDbCommand comm = new OleDbCommand("select * from WFDK_GZQK", conn);
                OleDbDataReader dr = comm.ExecuteReader();

                
                while (dr.Read())
                {
                    
                    MessageBox.Show(dr.GetString(1)+" "+dr.GetString(2));
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
