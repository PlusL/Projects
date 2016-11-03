namespace DataManageBDC
{
    partial class FormGT
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Button_DeleteMethod = new System.Windows.Forms.Button();
            this.Button_SaveMethod = new System.Windows.Forms.Button();
            this.Button_QueryMethod = new System.Windows.Forms.Button();
            this.Button_LoadAllSet = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.comboBox_FZ_FZRY_V = new System.Windows.Forms.ComboBox();
            this.comboBox_FZ_FZRY = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_FZ_YSDM = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_FZ_YWH = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_FZ_BSM = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(640, 349);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Button_DeleteMethod);
            this.tabPage1.Controls.Add(this.Button_SaveMethod);
            this.tabPage1.Controls.Add(this.Button_QueryMethod);
            this.tabPage1.Controls.Add(this.Button_LoadAllSet);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.dateTimePicker1);
            this.tabPage1.Controls.Add(this.comboBox_FZ_FZRY_V);
            this.tabPage1.Controls.Add(this.comboBox_FZ_FZRY);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.textBox_FZ_YSDM);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.textBox_FZ_YWH);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.textBox_FZ_BSM);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(632, 323);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "发证";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // Button_DeleteMethod
            // 
            this.Button_DeleteMethod.Location = new System.Drawing.Point(409, 155);
            this.Button_DeleteMethod.Name = "Button_DeleteMethod";
            this.Button_DeleteMethod.Size = new System.Drawing.Size(75, 23);
            this.Button_DeleteMethod.TabIndex = 14;
            this.Button_DeleteMethod.Text = "删除";
            this.Button_DeleteMethod.UseVisualStyleBackColor = true;
            // 
            // Button_SaveMethod
            // 
            this.Button_SaveMethod.Location = new System.Drawing.Point(409, 110);
            this.Button_SaveMethod.Name = "Button_SaveMethod";
            this.Button_SaveMethod.Size = new System.Drawing.Size(75, 23);
            this.Button_SaveMethod.TabIndex = 13;
            this.Button_SaveMethod.Text = "修正";
            this.Button_SaveMethod.UseVisualStyleBackColor = true;
            this.Button_SaveMethod.Click += new System.EventHandler(this.Button_SaveMethod_Click);
            // 
            // Button_QueryMethod
            // 
            this.Button_QueryMethod.Location = new System.Drawing.Point(409, 70);
            this.Button_QueryMethod.Name = "Button_QueryMethod";
            this.Button_QueryMethod.Size = new System.Drawing.Size(75, 23);
            this.Button_QueryMethod.TabIndex = 12;
            this.Button_QueryMethod.Text = "查询";
            this.Button_QueryMethod.UseVisualStyleBackColor = true;
            this.Button_QueryMethod.Click += new System.EventHandler(this.Button_QueryMethod_Click_1);
            // 
            // Button_LoadAllSet
            // 
            this.Button_LoadAllSet.Location = new System.Drawing.Point(409, 30);
            this.Button_LoadAllSet.Name = "Button_LoadAllSet";
            this.Button_LoadAllSet.Size = new System.Drawing.Size(75, 23);
            this.Button_LoadAllSet.TabIndex = 11;
            this.Button_LoadAllSet.Text = "添加";
            this.Button_LoadAllSet.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "发证时间";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(55, 129);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(142, 21);
            this.dateTimePicker1.TabIndex = 9;
            // 
            // comboBox_FZ_FZRY_V
            // 
            this.comboBox_FZ_FZRY_V.FormattingEnabled = true;
            this.comboBox_FZ_FZRY_V.Location = new System.Drawing.Point(179, 98);
            this.comboBox_FZ_FZRY_V.Name = "comboBox_FZ_FZRY_V";
            this.comboBox_FZ_FZRY_V.Size = new System.Drawing.Size(18, 20);
            this.comboBox_FZ_FZRY_V.TabIndex = 8;
            this.comboBox_FZ_FZRY_V.Visible = false;
            // 
            // comboBox_FZ_FZRY
            // 
            this.comboBox_FZ_FZRY.FormattingEnabled = true;
            this.comboBox_FZ_FZRY.Location = new System.Drawing.Point(55, 98);
            this.comboBox_FZ_FZRY.Name = "comboBox_FZ_FZRY";
            this.comboBox_FZ_FZRY.Size = new System.Drawing.Size(121, 20);
            this.comboBox_FZ_FZRY.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "发证人员";
            // 
            // textBox_FZ_YSDM
            // 
            this.textBox_FZ_YSDM.Location = new System.Drawing.Point(55, 66);
            this.textBox_FZ_YSDM.Name = "textBox_FZ_YSDM";
            this.textBox_FZ_YSDM.Size = new System.Drawing.Size(100, 21);
            this.textBox_FZ_YSDM.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "要素代码";
            // 
            // textBox_FZ_YWH
            // 
            this.textBox_FZ_YWH.Location = new System.Drawing.Point(55, 39);
            this.textBox_FZ_YWH.Name = "textBox_FZ_YWH";
            this.textBox_FZ_YWH.Size = new System.Drawing.Size(100, 21);
            this.textBox_FZ_YWH.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "业务号";
            // 
            // textBox_FZ_BSM
            // 
            this.textBox_FZ_BSM.Location = new System.Drawing.Point(55, 12);
            this.textBox_FZ_BSM.Name = "textBox_FZ_BSM";
            this.textBox_FZ_BSM.Size = new System.Drawing.Size(100, 21);
            this.textBox_FZ_BSM.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "标识码";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(632, 323);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "归档";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // FormGT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 349);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormGT";
            this.Text = "国土数据";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox textBox_FZ_BSM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBox_FZ_YSDM;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_FZ_YWH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_FZ_FZRY;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_FZ_FZRY_V;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Button_SaveMethod;
        private System.Windows.Forms.Button Button_QueryMethod;
        private System.Windows.Forms.Button Button_LoadAllSet;
        private System.Windows.Forms.Button Button_DeleteMethod;
    }
}

