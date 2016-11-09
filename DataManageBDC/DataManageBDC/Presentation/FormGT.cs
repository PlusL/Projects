using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Web;
using IBatisNet.Common;
using IBatisNet.DataAccess;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using DataManageBDC.Domain.GTZYs;
using DataManageBDC.Domain.Exceptions;
using System.Data.OleDb;

namespace DataManageBDC.Presentation
{
    partial class FormGT : Form
    {
       
        
        private DataTable _datatable = new DataTable ();
        private DataRow _datarow = null;


        string tb_fz = "";
        Dictionary<string, TextBox> fz_txt_Dictionary = new Dictionary<string, TextBox>();
        Dictionary<string, ComboBox> fz_cmb_Dictionary = new Dictionary<string, ComboBox>();
        Dictionary<string, ComboBox> fz_cmb_v_Dictionary = new Dictionary<string, ComboBox>();

        private string connString = "Provider=OraOLEDB.Oracle.1;User ID=MGIS;Password=MGIS;Data Source=(DESCRIPTION = (ADDRESS_LIST= (ADDRESS = (PROTOCOL = TCP)(HOST = 172.17.10.216)(PORT = 1521))) (CONNECT_DATA = (SERVICE_NAME = MGISDB)))";

        public FormGT()
        {
            InitializeComponent();
        }
        private static string baseDir = Path.GetFullPath(@"../../");
        private static DomSqlMapBuilder builder = new DomSqlMapBuilder();
        private static ISqlMapper mapper = builder.Configure(baseDir + @"Resourse\SqlMap.config");

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                //加载配置
                LoadAllSet();

                this.CenterToScreen();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Form1_Load()"+ex.Message,"错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        //加载
        private void LoadAllSet()
        {
            try
            {
                //发证表
                tb_fz = "FZ";
                fz_txt_Dictionary = new Dictionary<string, TextBox>();
                fz_txt_Dictionary.Add("BSM", textBox_FZ_BSM);
                fz_txt_Dictionary.Add("YWH", textBox_FZ_YWH);
                fz_txt_Dictionary.Add("YSDM", textBox_FZ_YSDM);

                //名称列表
                fz_cmb_Dictionary = new Dictionary<string, ComboBox>();
                fz_cmb_Dictionary.Add("FZRY", comboBox_FZ_FZRY);
                //数值的列表
                fz_cmb_v_Dictionary = new Dictionary<string, ComboBox>();
                fz_cmb_v_Dictionary.Add("FZRY", comboBox_FZ_FZRY_V);

                //每个表对应一个tab，配置关系全写在这里
                this.comboBox_FZ_FZRY.Items.Add("wang");
                this.comboBox_FZ_FZRY.Items.Add("zhao");
                this.comboBox_FZ_FZRY.Items.Add("li");
                this.comboBox_FZ_FZRY.Items.Add("qian");
                _datatable.Columns.Add("BSM");
                _datatable.Columns.Add("YWH");
                _datatable.Columns.Add("YSDM");
                _datatable.Columns.Add("FZRY");
            }
            catch (Exception ex)
            {
                MessageBox.Show("LoadAllSet()" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //查询方法
        private void QueryMethod(string tb_name, string q_clause, Dictionary<string, TextBox> txt_Dictionary, Dictionary<string, ComboBox> cmb_mc_Dictionary, Dictionary<string, ComboBox> cmb_sz_Dictionary)
        {
            try
            {
/*                //所有需要查询的字段
                string q_fields = "";
                foreach (KeyValuePair<string, TextBox> kvp in txt_Dictionary)
                {
                    string k_val = kvp.Key;
                    TextBox k_TextBox = kvp.Value;
                    k_TextBox.Text = "";
                    q_fields = q_fields + k_val + ",";
                }
                foreach (KeyValuePair<string, ComboBox> kvp in cmb_mc_Dictionary)
                {
                    string k_val = kvp.Key;
                    ComboBox k_mc_ComboBox = kvp.Value;
                    k_mc_ComboBox.SelectedIndex = 0; 
                    //The source code made the attribute to 0, but it crashed
                    //Crash fixed, but other error occured.The combobox could not show the correct text.
                    //Crash fixed, all is well. 2016.11.04

                    q_fields = q_fields + k_val + ",";
                }
                if (q_fields.EndsWith(","))
                    q_fields = q_fields.Remove(q_fields.Length - 1);

                //组成完整的查询语句
                string up_str = "";
                up_str = "select " + q_fields + " from " + tb_name + " where " + q_clause;
                //后面查询
                DataRow q_DataRow=null;

                //数据库连接
                OleDbConnection conn = new OleDbConnection(connString);
                try
                {
                    conn.Open();
                    OleDbCommand comm = new OleDbCommand(up_str,conn);
                    OleDbDataAdapter da = new OleDbDataAdapter();
                    da.SelectCommand = comm;

                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    q_DataRow = ds.Tables[0].Rows[0];
                }
                catch(Exception ex)
                {
                    MessageBox.Show("QueryMethod db " + ex.Message.ToString(),"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                }
*/
                //Mybatis select data
                IList gtzys = mapper.QueryForList("GetGTZYListByBSM", this.textBox_FZ_BSM.Text);
                
                //清除数据

                _datatable.Clear();
                //设置搜索结果的数据
                foreach (GTZY gtzy in gtzys)
                {
                    try
                    {
                        _datatable.Rows.Add(new Object[] { gtzy.Bsm, gtzy.Ywh, gtzy.Ysdm, gtzy.Fzry });
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                _datarow = _datatable.Rows[0];

                //把查到的值显示到界面上
                foreach (KeyValuePair<string, TextBox> kvp in txt_Dictionary)
                {
                    string k_val = kvp.Key;
                    TextBox k_TextBox = kvp.Value;

                    k_TextBox.Text = _datarow[k_val].ToString();
                }

                foreach (KeyValuePair<string, ComboBox> kvp in cmb_sz_Dictionary)
                {
                    string k_val = kvp.Key;
                    ComboBox k_sz_ComboBox = kvp.Value;
                    ComboBox k_mc_ComboBox=cmb_mc_Dictionary[k_val];
                    string q_val = _datarow[k_val].ToString();

                    int q_index = k_sz_ComboBox.Items.IndexOf(q_val);
                    if (q_index != -1)
                        k_mc_ComboBox.SelectedIndex = q_index;
                }


                //其他类型的空间继续扩充

            }
            catch (Exception ex)
            {
                MessageBox.Show("QueryMethod()" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //保存方法
        private void SaveMethod(string tb_name, string q_clause, Dictionary<string, TextBox> txt_Dictionary, Dictionary<string, ComboBox> cmb_mc_Dictionary, Dictionary<string, ComboBox> cmb_sz_Dictionary)
        {
            try
            {
/*                //保存也是循环那些控件的数据字典，根据主键字段，更新到对应表中
                string q_fields = "";
                foreach (KeyValuePair<string, TextBox> kvp in txt_Dictionary)
                {
                    string k_val = kvp.Key;
                    TextBox k_TextBox = kvp.Value;

                    q_fields = q_fields + k_val + "=" + k_TextBox.Text + ",";
 
                }
               foreach(KeyValuePair<string,ComboBox> kvp in cmb_mc_Dictionary)
                {
                    string k_val = kvp.Key;
                    ComboBox k_mc_ComboBox = kvp.Value;

                    q_fields = q_fields + k_val + "=" + "'" +k_mc_ComboBox.Text + "'" + ",";
                }
                if (q_fields.EndsWith(","))
                    q_fields = q_fields.Remove(q_fields.Length - 1);

                string up_str = "";
                up_str = "update " + tb_name + " set " + q_fields + " where " + q_clause;

                //数据库操作
                OleDbConnection conn = new OleDbConnection(connString);
                try
                {
                    conn.Open();
                    OleDbCommand comm = new OleDbCommand(up_str, conn);
                    OleDbDataAdapter da = new OleDbDataAdapter();
                    da.SelectCommand = comm;

                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    if (Convert.ToBoolean(comm.ExecuteNonQuery()))
                    {
                        MessageBox.Show("update!", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("SaveMethod db "+ex.Message.ToString(),"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                }
 */
                GTZY gtzy = new GTZY();
                gtzy.Bsm = this.textBox_FZ_BSM.Text;
                gtzy.Ywh = this.textBox_FZ_YWH.Text;
                gtzy.Ysdm = this.textBox_FZ_YSDM.Text;
                gtzy.Fzry = this.comboBox_FZ_FZRY.Text;
                mapper.Update("UpdateGTZY",gtzy);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("SaveMethod()" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //insert data
        private void InsertMethod(string tb_name, Dictionary<string, TextBox> txt_Dictionary, Dictionary<string, ComboBox> cmb_mc_Dictionary, Dictionary<string, ComboBox> cmb_sz_Dictionary)
        {
             try
            {
/*                //insertion start
                string q_fields = "";
                string v_fields = "";
                foreach (KeyValuePair<string, TextBox> kvp in txt_Dictionary)
                {
                    string k_val = kvp.Key;
                    TextBox k_TextBox = kvp.Value;

                    q_fields = q_fields + k_val + ",";
                    v_fields = v_fields + " '" + k_TextBox.Text + "' " + ",";
 
                }
               foreach(KeyValuePair<string,ComboBox> kvp in cmb_mc_Dictionary)
                {
                    string k_val = kvp.Key;
                    ComboBox k_mc_ComboBox = kvp.Value;
                     

                    q_fields = q_fields + k_val + ",";
                    v_fields = v_fields + " '" + k_mc_ComboBox.Text + "' " + ",";
                }
                if (q_fields.EndsWith(","))
                    q_fields = q_fields.Remove(q_fields.Length - 1);
                if (v_fields.EndsWith(","))
                    v_fields = v_fields.Remove(v_fields.Length - 1);

                string up_str = "";
                up_str = "insert into " + tb_name + " (" + q_fields + ") " + " values " + " (" + v_fields + ")";

                //数据库操作
                OleDbConnection conn = new OleDbConnection(connString);
                try
                {
                    conn.Open();
                    OleDbCommand comm = new OleDbCommand(up_str, conn);
                    OleDbDataAdapter da = new OleDbDataAdapter();
                    da.SelectCommand = comm;

                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    if (Convert.ToBoolean(comm.ExecuteNonQuery()))
                    MessageBox.Show("Insert!","Success",MessageBoxButtons.OK,MessageBoxIcon.None);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("SaveMethod db "+ex.Message.ToString(),"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                }
 */
                GTZY gtzy = new GTZY();
                gtzy.Bsm = this.textBox_FZ_BSM.Text;
                gtzy.Ywh = this.textBox_FZ_YWH.Text;
                gtzy.Ysdm = this.textBox_FZ_YSDM.Text;
                gtzy.Fzry = this.comboBox_FZ_FZRY.Text;
                mapper.Insert("InsertGTZY", gtzy);
            }
            catch (Exception ex)
            {
                MessageBox.Show("InsertMethod()" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        //delete data
        private void DeleteMethod(string tb_name, Dictionary<string, TextBox> txt_Dictionary, Dictionary<string, ComboBox> cmb_mc_Dictionary, Dictionary<string, ComboBox> cmb_sz_Dictionary)
        {
            try
            {
/*                //delete start
                string q_fields = "";
                
                foreach (KeyValuePair<string, TextBox> kvp in txt_Dictionary)
                {
                    string k_val = kvp.Key;
                    TextBox k_TextBox = kvp.Value;

                    q_fields = q_fields + k_val + "=" + "'" + k_TextBox.Text + "'" + ",";
                    break;

                }
//                foreach (KeyValuePair<string, ComboBox> kvp in cmb_mc_Dictionary)
//               {
//                    string k_val = kvp.Key;
//                    ComboBox k_mc_ComboBox = kvp.Value;
//                    
//
//                    q_fields = q_fields + k_val + "=" + k_mc_ComboBox.Text + ",";
//                }
                if (q_fields.EndsWith(","))
                    q_fields = q_fields.Remove(q_fields.Length - 1);

                string up_str = "";
                up_str = "delete from " + tb_name + " where " + q_fields;

                //数据库操作
                OleDbConnection conn = new OleDbConnection(connString);
                try
                {
                    conn.Open();
                    OleDbCommand comm = new OleDbCommand(up_str, conn);
                    OleDbDataAdapter da = new OleDbDataAdapter();
                    da.SelectCommand = comm;

                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    if (Convert.ToBoolean(comm.ExecuteNonQuery()))
                    MessageBox.Show("Delete!","Success",MessageBoxButtons.OK,MessageBoxIcon.None);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("SaveMethod db " + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                }
 */
                GTZY gtzy = new GTZY();
                gtzy.Bsm = this.textBox_FZ_BSM.Text;
                gtzy.Ywh = this.textBox_FZ_YWH.Text;
                gtzy.Ysdm = this.textBox_FZ_YSDM.Text;
                gtzy.Fzry = this.comboBox_FZ_FZRY.Text;
                mapper.Delete("DeleteGTZY",gtzy);
            }
            catch (Exception ex)
            {
                MessageBox.Show("DeleteMethod()" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //utilize the QueryMethod
        private void Button_QueryMethod_Click_1(object sender, EventArgs e)
        {
            string tb = "GTZY";
            string clause = "BSM = 1";
            QueryMethod(tb, clause, fz_txt_Dictionary, fz_cmb_Dictionary, fz_cmb_Dictionary);
        }

        //utilize the SaveMethod
        private void Button_SaveMethod_Click(object sender, EventArgs e)
        {
            string tb = "GTZY";
            string clause = "BSM = 1";
            SaveMethod(tb, clause, fz_txt_Dictionary, fz_cmb_Dictionary, fz_cmb_Dictionary);
        }

        //utilize the InsertMethod
        private void Button_InsertMethod_Click(object sender, EventArgs e)
        {
            string tb = "GTZY";
            InsertMethod(tb, fz_txt_Dictionary,fz_cmb_Dictionary,fz_cmb_v_Dictionary);
        }

        //utilize the DeleteMethod
        private void Button_DeleteMethod_Click(object sender, EventArgs e)
        {
            string tb = "GTZY";
            DeleteMethod(tb,fz_txt_Dictionary,fz_cmb_Dictionary,fz_cmb_v_Dictionary);
        }
        
    }
}
        