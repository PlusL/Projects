namespace WindowsTest2
{
    partial class FileTestForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FileLocationGroup = new System.Windows.Forms.GroupBox();
            this.ScanButton = new System.Windows.Forms.Button();
            this.FilePath = new System.Windows.Forms.TextBox();
            this.FileOperationGroup = new System.Windows.Forms.GroupBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();
            this.TextArea = new System.Windows.Forms.TextBox();
            this.FileLocationGroup.SuspendLayout();
            this.FileOperationGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // FileLocationGroup
            // 
            this.FileLocationGroup.Controls.Add(this.ScanButton);
            this.FileLocationGroup.Controls.Add(this.FilePath);
            this.FileLocationGroup.Location = new System.Drawing.Point(21, 360);
            this.FileLocationGroup.Name = "FileLocationGroup";
            this.FileLocationGroup.Size = new System.Drawing.Size(245, 100);
            this.FileLocationGroup.TabIndex = 0;
            this.FileLocationGroup.TabStop = false;
            this.FileLocationGroup.Text = "File Location";
            // 
            // ScanButton
            // 
            this.ScanButton.Location = new System.Drawing.Point(82, 57);
            this.ScanButton.Name = "ScanButton";
            this.ScanButton.Size = new System.Drawing.Size(75, 23);
            this.ScanButton.TabIndex = 1;
            this.ScanButton.Text = "scan";
            this.ScanButton.UseVisualStyleBackColor = true;
            this.ScanButton.Click += new System.EventHandler(this.ScanButton_Click);
            // 
            // FilePath
            // 
            this.FilePath.Location = new System.Drawing.Point(6, 20);
            this.FilePath.Name = "FilePath";
            this.FilePath.Size = new System.Drawing.Size(232, 21);
            this.FilePath.TabIndex = 0;
            // 
            // FileOperationGroup
            // 
            this.FileOperationGroup.Controls.Add(this.SaveButton);
            this.FileOperationGroup.Controls.Add(this.LoadButton);
            this.FileOperationGroup.Location = new System.Drawing.Point(328, 360);
            this.FileOperationGroup.Name = "FileOperationGroup";
            this.FileOperationGroup.Size = new System.Drawing.Size(259, 100);
            this.FileOperationGroup.TabIndex = 1;
            this.FileOperationGroup.TabStop = false;
            this.FileOperationGroup.Text = "FIle operation";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(167, 53);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 1;
            this.SaveButton.Text = "save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(30, 54);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(75, 23);
            this.LoadButton.TabIndex = 0;
            this.LoadButton.Text = "load";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // TextArea
            // 
            this.TextArea.Location = new System.Drawing.Point(21, 32);
            this.TextArea.Multiline = true;
            this.TextArea.Name = "TextArea";
            this.TextArea.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TextArea.Size = new System.Drawing.Size(566, 273);
            this.TextArea.TabIndex = 2;
            // 
            // FileTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 495);
            this.Controls.Add(this.TextArea);
            this.Controls.Add(this.FileOperationGroup);
            this.Controls.Add(this.FileLocationGroup);
            this.Name = "FileTestForm";
            this.Text = "MyApplication2";
            this.FileLocationGroup.ResumeLayout(false);
            this.FileLocationGroup.PerformLayout();
            this.FileOperationGroup.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox FileLocationGroup;
        private System.Windows.Forms.Button ScanButton;
        private System.Windows.Forms.TextBox FilePath;
        private System.Windows.Forms.GroupBox FileOperationGroup;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.TextBox TextArea;
    }
}