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

        /* *
         * Base64编码表
         * base64EncodeChars 使用的64个编码字符
         * base64DecodeChars 使用的64个编码字符ASCII序
         * 调整需谨慎
         * */
        private static char[] base64EncodeChars = new char[]{
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H',
            'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P',
            'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X',
            'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f',
            'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n',
            'o', 'p', 'q', 'r', 's', 't', 'u', 'v',
            'w', 'x', 'y', 'z', '0', '1', '2', '3',
            '4', '5', '6', '7', '8', '9', '+', '/'};

        private static byte[] base64DecodeChars = new byte[]{
            255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
            255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255,
            255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 62, 255, 255, 255, 63,
            52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 255, 255, 255, 255, 255, 255,
            255, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14,
            15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 255, 255, 255, 255, 255,
            255, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40,
            41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 255, 255, 255, 255, 255};

        /* *
         * 加密算法
         * 第一个字符通过右移2位获得第一个目标字符的Base64表位置，根据这个数值取到表上相应的字符，就是第一个目标字符。
         * 然后将第一个字符与0x03(00000011)进行与(&)操作并左移4位,接着第二个字符右移4位与前者相或(|)，即获得第二个目标字符。
         * 再将第二个字符与0x0f(00001111)进行与(&)操作并左移2位,接着第三个字符右移6位与前者相或(|)，获得第三个目标字符。
         * 最后将第三个字符与0x3f(00111111)进行与(&)操作即获得第四个目标字符。
         * 在以上的每一个步骤之后，再把结果与 0x3F 进行 AND 位操作，就可以得到编码后的字符了。
         * */
        public String encode(byte[] data)
        {
            StringBuilder sb = new StringBuilder();
            int len = data.Length;
            int i = 0;
            int b1, b2, b3;

            while (i < len)
            {
                b1 = data[i++] & 0xff;
                if (i == len)
                {
                    sb.Append(base64EncodeChars[b1 >> 2]);
                    sb.Append(base64EncodeChars[(b1 & 0x3) << 4]);
                    sb.Append("==");
                    break;
                }
                b2 = data[i++] & 0xff;
                if (i == len)
                {
                    sb.Append(base64EncodeChars[b1 >> 2]);
                    sb.Append(
                            base64EncodeChars[((b1 & 0x03) << 4) | ((b2 & 0xf0) >> 4)]);
                    sb.Append(base64EncodeChars[(b2 & 0x0f) << 2]);
                    sb.Append("=");
                    break;
                }
                b3 = data[i++] & 0xff;
                sb.Append(base64EncodeChars[b1 >> 2]);
                sb.Append(
                        base64EncodeChars[((b1 & 0x03) << 4) | ((b2 & 0xf0) >> 4)]);
                sb.Append(
                        base64EncodeChars[((b2 & 0x0f) << 2) | ((b3 & 0xc0) >> 6)]);
                sb.Append(base64EncodeChars[b3 & 0x3f]);
            }
            return sb.ToString();
        }

        public byte[] decode(String str)
        {
            byte[] data = System.Text.Encoding.Default.GetBytes(str);
            int len = data.Length;
            MemoryStream buf = new MemoryStream(len);
            int i = 0;
            int b1, b2, b3, b4;

            while (i < len)
            {

                /* b1 */
                do
                {
                    b1 = base64DecodeChars[data[i++]];
                } while (i < len && b1 == 255);
                if (b1 == 255)
                {
                    break;
                }

                /* b2 */
                do
                {
                    b2 = base64DecodeChars[data[i++]];
                } while (i < len && b2 == 255);
                if (b2 == 255)
                {
                    break;
                }
                buf.WriteByte((byte)((b1 << 2) | ((b2 & 0x30) >> 4)));

                /* b3 */
                do
                {
                    b3 = data[i++];
                    if (b3 == 61)
                    {
                        return buf.ToArray();
                    }
                    b3 = base64DecodeChars[b3];
                } while (i < len && b3 == 255);
                if (b3 == 255)
                {
                    break;
                }
                buf.WriteByte((byte)(((b2 & 0x0f) << 4) | ((b3 & 0x3c) >> 2)));

                /* b4 */
                do
                {
                    b4 = data[i++];
                    if (b4 == 61)
                    {
                        return buf.ToArray();
                    }
                    b4 = base64DecodeChars[b4];
                } while (i < len && b4 == 255);
                if (b4 == 255)
                {
                    break;
                }
                buf.WriteByte((byte)(((b3 & 0x03) << 6) | b4));
            }
            return buf.ToArray();
        }

        /* *
         * C#.net中Base64的编码解码方法
         * */
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
                    //string Decodes = DecodeBase64(Encoding.UTF8, Encodes);
                    byte[] decodes = decode(Encodes);
                    string Decodes = System.Text.Encoding.UTF8.GetString(decodes);
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

                byte[] encodes = System.Text.Encoding.UTF8.GetBytes(Decodes);
                string Encodes = encode(encodes);

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
