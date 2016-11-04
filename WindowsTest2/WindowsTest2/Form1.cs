using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Windows.Forms.DataVisualization;

namespace WindowsTest2
{
    public partial class Form1 : Form
    {
        private string connString = "Provider=OraOLEDB.Oracle.1;User ID=MGIS;Password=MGIS;Data Source=(DESCRIPTION = (ADDRESS_LIST= (ADDRESS = (PROTOCOL = TCP)(HOST = 172.17.10.216)(PORT = 1521))) (CONNECT_DATA = (SERVICE_NAME = MGISDB)))";
            
        public Form1()
        {
            InitializeComponent();
        }


        //display
        private void button1_display_Click(object sender, EventArgs e)
        {
            //string connString = "Provider=OraOLEDB.Oracle.1;User ID=MGIS;Password=MGIS;Data Source=(DESCRIPTION = (ADDRESS_LIST= (ADDRESS = (PROTOCOL = TCP)(HOST = 172.17.10.216)(PORT = 1521))) (CONNECT_DATA = (SERVICE_NAME = MGISDB)))";
            OleDbConnection conn = new OleDbConnection(connString);
            try
            {
                conn.Open();
                OleDbCommand comm = new OleDbCommand("select * from GTZY where FZRY between 'qian' and 'zhao' order by FZRY", conn);
                OleDbDataAdapter da = new OleDbDataAdapter();
                da.SelectCommand = comm;

                DataSet ds = new DataSet();
                da.Fill(ds);

                this.dataGridView1.DataSource = ds.Tables[0];
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

        //delete
        private void button2_delete_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(connString);
            try
            {
                conn.Open();
                string sql = string.Format("delete from MAXBSM where BSM = ('{0}')", this.textBox1.Text);
                OleDbCommand comm = new OleDbCommand(sql, conn);
                OleDbDataAdapter da = new OleDbDataAdapter();
                da.SelectCommand = comm;

                DataSet ds = new DataSet();
                da.Fill(ds);

                //this.dataGridView2.DataSource = ds.Tables[0];
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

        //add
        private void button3_add_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(connString);
            try
            {
                conn.Open();
                string sql = string.Format("insert into MAXBSM (BSM) values ('{0}')", this.textBox1.Text);
                OleDbCommand comm = new OleDbCommand(sql, conn);
                OleDbDataAdapter da = new OleDbDataAdapter();
                da.SelectCommand = comm;

                DataSet ds = new DataSet();
                da.Fill(ds);

                //this.dataGridView2.DataSource = ds.Tables[0];
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

        //query
        private void button4_query_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(connString);
            try
            {
                conn.Open();
                string sql = "select * from MAXBSM";
                OleDbCommand comm = new OleDbCommand(sql, conn);
                OleDbDataAdapter da = new OleDbDataAdapter();
                da.SelectCommand = comm;

                DataSet ds = new DataSet();
                da.Fill(ds);

                this.dataGridView2.DataSource = ds.Tables[0];
                this.dataGridView2.Columns[0].HeaderText = "bsm";
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

        private void button5_Click(object sender, EventArgs e)
        {
            FileTestForm formchild = new FileTestForm();
            formchild.Show();
        }
    }
}
