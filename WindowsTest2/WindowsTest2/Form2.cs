using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsTest2
{
    public partial class FileTestForm : Form
    {
        public FileTestForm()
        {
            InitializeComponent();
        }

        private void ScanButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                string file = ofd.FileName;
                this.FilePath.Text = file;
            }
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            string Path = this.FilePath.Text;
            this.TextArea.Text = File.ReadAllText(Path, Encoding.UTF8);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "txt files (*.txt)|*.txt|All Files (*.*)|*.*";
            sfd.FilterIndex = 2;
            sfd.RestoreDirectory = true;

            if(sfd.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
            StreamWriter sw = new StreamWriter(sfd.FileName);
            sw.Write(this.TextArea.Text);
            sw.Dispose();
            this.TextArea.Clear();
            }

        }
    }
}
