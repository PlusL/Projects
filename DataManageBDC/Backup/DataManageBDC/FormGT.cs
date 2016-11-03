using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DataManageBDC
{
    public partial class FormGT : Form
    {
        string tb_fz = "";
        Dictionary<string, TextBox> fz_txt_Dictionary = new Dictionary<string, TextBox>();
        Dictionary<string, ComboBox> fz_cmb_Dictionary = new Dictionary<string, ComboBox>();
        Dictionary<string, ComboBox> fz_cmb_v_Dictionary = new Dictionary<string, ComboBox>();

        public FormGT()
        {
            InitializeComponent();
        }

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
                //所有需要查询的字段
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

                    q_fields = q_fields + k_val + ",";
                }
                if (q_fields.EndsWith(","))
                    q_fields = q_fields.Remove(q_fields.Length - 1);

                //组成完整的查询语句
                string up_str = "";
                up_str = "select " + q_fields + " from " + tb_name + " where " + q_clause;
                //后面查询
                DataRow q_DataRow=null;


                //把查到的值显示到界面上
                foreach (KeyValuePair<string, TextBox> kvp in txt_Dictionary)
                {
                    string k_val = kvp.Key;
                    TextBox k_TextBox = kvp.Value;

                    k_TextBox.Text = q_DataRow[k_val].ToString();
                }

                foreach (KeyValuePair<string, ComboBox> kvp in cmb_sz_Dictionary)
                {
                    string k_val = kvp.Key;
                    ComboBox k_sz_ComboBox = kvp.Value;
                    ComboBox k_mc_ComboBox=cmb_mc_Dictionary[k_val];
                    string q_val = q_DataRow[k_val].ToString();

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
                //保存也是循环那些控件的数据字典，根据主键字段，更新到对应表中

            }
            catch (Exception ex)
            {
                MessageBox.Show("SaveMethod()" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}