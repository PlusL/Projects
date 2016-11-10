using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.MemoryMappedFiles;


namespace EncriptTest
{
    public partial class Form1 : Form
    {
//        Dictionary<string, TextBox> tb_seqnum = new Dictionary<string, TextBox>();
//        Dictionary<string, TextBox> tb_proposer = new Dictionary<string, TextBox>();
//        Dictionary<string, TextBox> tb_company = new Dictionary<string, TextBox>();
//        Dictionary<string, TextBox> tb_phone = new Dictionary<string, TextBox>();

        public Form1()
        {
            InitializeComponent();
        }

/*       private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                
                LoadAllSet();

                this.CenterToScreen();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Form1_Load()" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
  */ 

/*        private void LoadAllSet()
        {
            try
            {
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("LoadAllSet() " + ex.Message, "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
 */ 

        public string EncodeBase64(Encoding code_type, string code)
        {
            string encode = "";
            byte[] bytes = code_type.GetBytes(code);
            try
            {
                encode = Convert.ToBase64String(bytes);
            }
            catch
            {
                encode = code;
            }
            return encode;
        }
        public string DecodeBase64(Encoding code_type, string code)
        {
            string decode = "";
            byte[] bytes = Convert.FromBase64String(code);
            try
            {
                decode = code_type.GetString(bytes);
            }
            catch
            {
                decode = code;
            }
            return decode;
        }

        private void Button_FilePath_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    string file = ofd.FileName;
                    this.TextBox_FilePath.Text = file;
                    string Path = this.TextBox_FilePath.Text;
                    string Encodes = File.ReadAllText(Path, Encoding.UTF8);
                    string Decodes = DecodeBase64(Encoding.UTF8, Encodes);
                    string[] Decodes_list = Decodes.Split(',');
                    TextBox_SeqNum.Text = Decodes_list[0];
                    TextBox_Proposer.Text = Decodes_list[1];
                    TextBox_Company.Text = Decodes_list[2];
                    TextBox_Phone.Text = Decodes_list[3];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void Button_Reg_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> codes = new List<string>();
                codes.Add(TextBox_SeqNum.Text);
                codes.Add(TextBox_Proposer.Text);
                codes.Add(TextBox_Company.Text);
                codes.Add(TextBox_Phone.Text);

                long NowTime = DateTime.Now.Millisecond;
                long time = NowTime + long.Parse(ComBox_RegTime.Text.ToString()) * 24L * 60L * 60L * 1000L + 8L * 60L * 60L * 1000L;
                codes.Add(time.ToString());

                string[] decodes = codes.ToArray();
                string Decodes = string.Join(",", decodes);

                string Encodes = EncodeBase64(Encoding.UTF8, Decodes);

                SaveFileDialog sfd = new SaveFileDialog();

                sfd.Filter = "key files (*.key)|*.txt|All Files (*.*)|*.*";
                sfd.FilterIndex = 2;
                sfd.RestoreDirectory = true;

                if (sfd.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    StreamWriter sw = new StreamWriter(sfd.FileName);
                    sw.Write(Encodes);
                    sw.Dispose();
                }
                this.Label_Result.Text = "注册成功！";
                this.Label_Result.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                this.Label_Result.Text = "注册失败!";
                this.Label_Result.ForeColor = Color.Red;
                throw ex;
            }

            
        }
        private void ComBox_RegTime_MouseEnter(object sender, EventArgs e)
        {
            ToolTip TipInput = new ToolTip();

            TipInput.AutoPopDelay = 5000;
            TipInput.InitialDelay = 1000;
            TipInput.ReshowDelay = 500;
            TipInput.ShowAlways = true;

            TipInput.SetToolTip(this.ComBox_RegTime, "请输入不小于0的整数，或从下方选择");
            
        }
        private void TextBox_FilePath_MouseHover(object sender, EventArgs e)
        {
            ToolTip TipShow = new ToolTip();

            TipShow.AutoPopDelay = 10000;
            TipShow.InitialDelay = 2000;
            TipShow.ReshowDelay = 1000;
            TipShow.ShowAlways = true;

            TipShow.SetToolTip(this.TextBox_FilePath, this.TextBox_FilePath.Text);
        }
    }
}
