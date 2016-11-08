using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using MybatisDemo.Domain.Books;
using IBatisNet.Common;
using IBatisNet.DataAccess;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using MybatisDemo.Domain.Exceptions;

namespace MybatisDemo.Presentation
{
    public class frmBookDetail : System.Windows.Forms.Form
    {
        //获取log4net的实例
        private static readonly log4net.ILog _logger =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static string baseDir = Path.GetFullPath(@"../../");
        private static DomSqlMapBuilder builder = new DomSqlMapBuilder();
        private static ISqlMapper mapper = builder.Configure(baseDir + @"Resources\SqlMap.config");


        private string _userIsbn = null;
        private String _crudStatus = null;
        private System.Windows.Forms.Label lblIsbn;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSaleDate;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtIsbn;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.DateTimePicker dtpBirthday;
        private System.Windows.Forms.Button btnOk;

        private System.ComponentModel.Container components = null;

        public frmBookDetail()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtIsbn = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.dtpBirthday = new System.Windows.Forms.DateTimePicker();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblIsbn = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSaleDate = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtIsbn
            // 
            this.txtIsbn.Location = new System.Drawing.Point(147, 24);
            this.txtIsbn.MaxLength = 10;
            this.txtIsbn.Name = "txtIsbn";
            this.txtIsbn.Size = new System.Drawing.Size(115, 25);
            this.txtIsbn.TabIndex = 1;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(147, 68);
            this.txtTitle.MaxLength = 50;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(224, 25);
            this.txtTitle.TabIndex = 3;
            // 
            // dtpBirthday
            // 
            this.dtpBirthday.Location = new System.Drawing.Point(147, 149);
            this.dtpBirthday.Name = "dtpBirthday";
            this.dtpBirthday.Size = new System.Drawing.Size(173, 25);
            this.dtpBirthday.TabIndex = 9;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(147, 111);
            this.txtPrice.MaxLength = 8;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(103, 25);
            this.txtPrice.TabIndex = 5;
            this.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(61, 216);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(120, 34);
            this.btnOk.TabIndex = 10;
            this.btnOk.Text = "OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(251, 216);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 34);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "返回";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblIsbn
            // 
            this.lblIsbn.Location = new System.Drawing.Point(58, 30);
            this.lblIsbn.Name = "lblIsbn";
            this.lblIsbn.Size = new System.Drawing.Size(83, 30);
            this.lblIsbn.TabIndex = 0;
            this.lblIsbn.Text = "ISBN";
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(58, 72);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(83, 21);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "标题";
            // 
            // lblSaleDate
            // 
            this.lblSaleDate.Location = new System.Drawing.Point(58, 156);
            this.lblSaleDate.Name = "lblSaleDate";
            this.lblSaleDate.Size = new System.Drawing.Size(83, 30);
            this.lblSaleDate.TabIndex = 8;
            this.lblSaleDate.Text = "发布日期";
            // 
            // lblPrice
            // 
            this.lblPrice.Location = new System.Drawing.Point(58, 114);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(83, 30);
            this.lblPrice.TabIndex = 4;
            this.lblPrice.Text = "价格";
            // 
            // frmBookDetail
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 18);
            this.ClientSize = new System.Drawing.Size(608, 349);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblSaleDate);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblIsbn);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.txtIsbn);
            this.Controls.Add(this.dtpBirthday);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmBookDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "图书信息";
            this.Load += new System.EventHandler(this.frmBookDetail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        public String CrudStatus
        {
            get { return _crudStatus; }
            set { _crudStatus = value; }
        }

        public string BookIsbn
        {
            get { return _userIsbn; }
            set { _userIsbn = value; }
        }

        private void frmBookDetail_Load(object sender, System.EventArgs e)
        {
            System.Diagnostics.Debug.Assert(_crudStatus != null, "状态未设置");

            SetUpInputLock();

            SetUpOkButtunTitle();

            LoadBookInfo();
        }

        private void LoadBookInfo()
        {
            try
            {
                if (_crudStatus.Equals("READ") || _crudStatus.Equals("DELETE") || _crudStatus.Equals("UPDATE"))
                {
                    Book book = (Book)mapper.QueryForObject("GetBookByIsbn", _userIsbn);
                    this.txtIsbn.Text = book.Isbn;
                    this.txtTitle.Text = book.Title;
                    this.txtPrice.Text = book.Price.ToString();
                    this.dtpBirthday.Value = book.SaleDate;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void SetUpInputLock()
        {
            if (_crudStatus.Equals("READ") || _crudStatus.Equals("DELETE"))
            {
                this.txtTitle.Enabled = false;
                this.txtPrice.Enabled = false;
                this.dtpBirthday.Enabled = false;
            }

            if (_crudStatus.Equals("READ") || _crudStatus.Equals("DELETE") || _crudStatus.Equals("UPDATE"))
            {
                this.txtIsbn.Enabled = false;
            }
        }

        private void SetUpOkButtunTitle()
        {
            if (_crudStatus.Equals("CREATE"))
            {
                this.btnOk.Text = "添加新数据";
            }
            else if (_crudStatus.Equals("UPDATE"))
            {
                this.btnOk.Text = "更新";
            }
            else if (_crudStatus.Equals("READ"))
            {
                this.btnOk.Text = "OK";
            }
            else if (_crudStatus.Equals("DELETE"))
            {
                this.btnOk.Text = "删除";
            }
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            try
            {
                Book book = new Book();
                if (_crudStatus.Equals("CREATE") || (_crudStatus.Equals("UPDATE")))
                {
                    book.Isbn = this.txtIsbn.Text;
                    book.Title = this.txtTitle.Text;
                    book.Price = int.Parse(this.txtPrice.Text);
                    book.SaleDate = new DateTime(this.dtpBirthday.Value.Year, this.dtpBirthday.Value.Month,
                        this.dtpBirthday.Value.Day);
                }

                if (_crudStatus.Equals("CREATE"))
                {
                    mapper.Insert("InsertBook", book);
                }
                if (_crudStatus.Equals("UPDATE"))
                {
                    mapper.Update("UpdateBook", book);
                }
                if (_crudStatus.Equals("DELETE"))
                {
                    mapper.Delete("DeleteBook", this.txtIsbn.Text);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (DomainException ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(),
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString(),
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                _logger.Error("在数据库更新时发生意外的错误!", ex);


                MessageBox.Show("发生意外的错误!" + "\r\r" + ex.Message,
                    ex.GetType().ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
