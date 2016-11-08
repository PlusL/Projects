using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Collections;
using IBatisNet.Common;
using IBatisNet.DataAccess;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using MybatisDemo.Domain.Books;

namespace MybatisDemo.Presentation
{
    public class frmBookView : System.Windows.Forms.Form
    {
        private static readonly log4net.ILog _logger =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //DomSqlMapBuilder，其作用是根据配置文件创建SqlMap实例。可以通过这个组件从Stream, Uri, FileInfo, or XmlDocument instance 来读取sqlMap.config文件。
        // SqlMap是线程安全的，也就是说，在一个应用中，可以共享一个SqlMap实例。
        private static string baseDir = Path.GetFullPath(@"../../");
        private static DomSqlMapBuilder builder = new DomSqlMapBuilder();
        private static ISqlMapper mapper = builder.Configure(baseDir + @"Resources\SqlMap.config");

        private DataSet _dataSet = null;
        private DataTable _dataTable = null;
        private System.Windows.Forms.DataGrid grdMain;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnSearchTitle;
        private System.Windows.Forms.ComboBox cmbPrice;
        private System.Windows.Forms.ComboBox cmbPrice2;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Button btnSearchPriceWeight;

        private System.ComponentModel.Container components = null;

        public frmBookView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 运行后释放正在使用的资源
        /// </summary>
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

        #region 由Windows窗体设计器生成的代码

        private void InitializeComponent()
        {
            this.grdMain = new System.Windows.Forms.DataGrid();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.btnSearchTitle = new System.Windows.Forms.Button();
            this.btnRead = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cmbPrice = new System.Windows.Forms.ComboBox();
            this.cmbPrice2 = new System.Windows.Forms.ComboBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.btnSearchPriceWeight = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).BeginInit();
            this.SuspendLayout();
            // 
            // grdMain
            // 
            this.grdMain.AlternatingBackColor = System.Drawing.Color.White;
            this.grdMain.BackColor = System.Drawing.Color.White;
            this.grdMain.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.grdMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grdMain.CaptionBackColor = System.Drawing.Color.Silver;
            this.grdMain.CaptionFont = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold);
            this.grdMain.CaptionForeColor = System.Drawing.Color.Black;
            this.grdMain.CaptionVisible = false;
            this.grdMain.DataMember = "";
            this.grdMain.FlatMode = true;
            this.grdMain.Font = new System.Drawing.Font("Courier New", 9F);
            this.grdMain.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.grdMain.GridLineColor = System.Drawing.Color.DarkGray;
            this.grdMain.HeaderBackColor = System.Drawing.Color.DarkGreen;
            this.grdMain.HeaderFont = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold);
            this.grdMain.HeaderForeColor = System.Drawing.Color.White;
            this.grdMain.LinkColor = System.Drawing.Color.DarkGreen;
            this.grdMain.Location = new System.Drawing.Point(26, 120);
            this.grdMain.Name = "grdMain";
            this.grdMain.ParentRowsBackColor = System.Drawing.Color.Gainsboro;
            this.grdMain.ParentRowsForeColor = System.Drawing.Color.Black;
            this.grdMain.ReadOnly = true;
            this.grdMain.SelectionBackColor = System.Drawing.Color.DarkSeaGreen;
            this.grdMain.SelectionForeColor = System.Drawing.Color.Black;
            this.grdMain.Size = new System.Drawing.Size(729, 348);
            this.grdMain.TabIndex = 10;
            this.grdMain.Paint += new System.Windows.Forms.PaintEventHandler(this.grdMain_Paint);
            // 
            // txtTitle
            // 
            this.txtTitle.Font = new System.Drawing.Font("MS UI Gothic", 11F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtTitle.Location = new System.Drawing.Point(115, 12);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(218, 26);
            this.txtTitle.TabIndex = 1;
            // 
            // btnSearchTitle
            // 
            this.btnSearchTitle.Location = new System.Drawing.Point(346, 12);
            this.btnSearchTitle.Name = "btnSearchTitle";
            this.btnSearchTitle.Size = new System.Drawing.Size(204, 36);
            this.btnSearchTitle.TabIndex = 2;
            this.btnSearchTitle.Text = "标题搜索(&T)";
            this.btnSearchTitle.Click += new System.EventHandler(this.btnSearchTitle_Click);
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(26, 480);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(179, 36);
            this.btnRead.TabIndex = 11;
            this.btnRead.Text = "查看(&R)";
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(384, 480);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(179, 36);
            this.btnUpdate.TabIndex = 13;
            this.btnUpdate.Text = "更新(&U)";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(205, 480);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(179, 36);
            this.btnCreate.TabIndex = 12;
            this.btnCreate.Text = "追加(&C)";
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(563, 480);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(179, 36);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "删除(&D)";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(51, 23);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(47, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "标题:";
            // 
            // cmbPrice
            // 
            this.cmbPrice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrice.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbPrice.Items.AddRange(new object[]
            {
                "1000",
                "2000",
                "3000",
                "4000",
                "5000"
            });
            this.cmbPrice.Location = new System.Drawing.Point(115, 75);
            this.cmbPrice.Name = "cmbPrice";
            this.cmbPrice.Size = new System.Drawing.Size(128, 27);
            this.cmbPrice.TabIndex = 4;
            // 
            // cmbPrice2
            // 
            this.cmbPrice2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrice2.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cmbPrice2.Items.AddRange(new object[]
            {
                "",
                "以上",
                "以下"
            });
            this.cmbPrice2.Location = new System.Drawing.Point(243, 75);
            this.cmbPrice2.Name = "cmbPrice2";
            this.cmbPrice2.Size = new System.Drawing.Size(90, 27);
            this.cmbPrice2.TabIndex = 5;
            // 
            // lblPrice
            // 
            this.lblPrice.Location = new System.Drawing.Point(51, 82);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(47, 26);
            this.lblPrice.TabIndex = 3;
            this.lblPrice.Text = "价格:";
            // 
            // btnSearchPriceWeight
            // 
            this.btnSearchPriceWeight.Location = new System.Drawing.Point(346, 66);
            this.btnSearchPriceWeight.Name = "btnSearchPriceWeight";
            this.btnSearchPriceWeight.Size = new System.Drawing.Size(204, 36);
            this.btnSearchPriceWeight.TabIndex = 9;
            this.btnSearchPriceWeight.Text = "价格查询(&S)";
            this.btnSearchPriceWeight.Click += new System.EventHandler(this.btnSearchPriceWeight_Click);
            // 
            // frmBookView
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 18);
            this.ClientSize = new System.Drawing.Size(790, 549);
            this.Controls.Add(this.btnSearchPriceWeight);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.cmbPrice);
            this.Controls.Add(this.cmbPrice2);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.btnSearchTitle);
            this.Controls.Add(this.grdMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmBookView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "书籍一览";
            this.Load += new System.EventHandler(this.frmBookView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        /// <summary>
        /// 当窗体加载的处理
        /// </summary>
        private void frmBookView_Load(object sender, System.EventArgs e)
        {
            //设置列名
            _dataSet = new DataSet();
            _dataTable = _dataSet.Tables.Add("");
            DataColumn dc1 = _dataTable.Columns.Add("ISBN-KEY(隐藏)");
            DataColumn dc2 = _dataTable.Columns.Add("ISBN");
            DataColumn dc3 = _dataTable.Columns.Add("标题");
            DataColumn dc4 = _dataTable.Columns.Add("价格", typeof(int));
            DataColumn dc5 = _dataTable.Columns.Add("发布日期", typeof(DateTime));
            //创建数据样式
            DataGridTableStyle tableStyle = new DataGridTableStyle();
            tableStyle.MappingName = _dataTable.TableName;
            this.grdMain.TableStyles.Add(tableStyle);
            //风格
            DataGridTextBoxColumn tbc1 = new DataGridTextBoxColumn();
            DataGridTextBoxColumn tbc2 = new DataGridTextBoxColumn();
            DataGridTextBoxColumn tbc3 = new DataGridTextBoxColumn();
            DataGridTextBoxColumn tbc4 = new DataGridTextBoxColumn();
            DataGridTextBoxColumn tbc5 = new DataGridTextBoxColumn();
            tbc1.MappingName = dc1.ColumnName;
            tbc2.MappingName = dc2.ColumnName;
            tbc3.MappingName = dc3.ColumnName;
            tbc4.MappingName = dc4.ColumnName;
            tbc5.MappingName = dc5.ColumnName;
            //列的标题设置
            tbc1.HeaderText = dc1.ColumnName;
            tbc2.HeaderText = dc2.ColumnName;
            tbc3.HeaderText = dc3.ColumnName;
            tbc4.HeaderText = dc4.ColumnName;
            tbc5.HeaderText = dc5.ColumnName;
            // 设置右对齐和居中左对齐
            tbc1.Alignment = HorizontalAlignment.Left;
            tbc2.Alignment = HorizontalAlignment.Left;
            tbc3.Alignment = HorizontalAlignment.Left;
            tbc4.Alignment = HorizontalAlignment.Right;
            tbc5.Alignment = HorizontalAlignment.Left;
            // 设置列宽
            tbc1.Width = 0;
            tbc2.Width = 100;
            tbc3.Width = 140;
            tbc4.Width = 80;
            tbc5.Width = 80;
            //风格样式
            tableStyle.GridColumnStyles.Add(tbc1);
            tableStyle.GridColumnStyles.Add(tbc2);
            tableStyle.GridColumnStyles.Add(tbc3);
            tableStyle.GridColumnStyles.Add(tbc4);
            tableStyle.GridColumnStyles.Add(tbc5);
            //禁止设置行添加，删除，编辑数据
            _dataTable.DefaultView.AllowNew = false;
            _dataTable.DefaultView.AllowDelete = false;
            _dataTable.DefaultView.AllowEdit = false;
            this.grdMain.SetDataBinding(_dataTable.DefaultView, "");

            //价格的初始设定
            this.cmbPrice.SelectedIndex = 0;
            //名字搜索的执行
            showBooksByTitle();
        }


        /// <summary>
        /// 名字搜索的执行
        /// </summary>
        private void btnSearchTitle_Click(object sender, System.EventArgs e)
        {
            showBooksByTitle();
        }

        /// <summary>
        /// 价格搜索的执行
        /// </summary>
        private void btnSearchPriceWeight_Click(object sender, System.EventArgs e)
        {
            showBooksByPrice();
        }

        /// <summary>
        /// 处理“浏览按钮”的时候
        /// </summary>
        private void btnRead_Click(object sender, System.EventArgs e)
        {
            //如果这本书书号是有效的，“查看”对话框显示
            if (getBookIsbnBySelcectedRow() != "")
            {
                frmBookDetail frmdetail = new frmBookDetail();
                frmdetail.BookIsbn = getBookIsbnBySelcectedRow();
                frmdetail.CrudStatus = "READ";
                frmdetail.ShowDialog();
            }
        }

        /// <summary>
        /// “添加”按钮被按下的时候处理
        /// </summary>
        private void btnCreate_Click(object sender, System.EventArgs e)
        {
            //"添加"的书籍对话框显示
            frmBookDetail frmdetail = new frmBookDetail();
            frmdetail.CrudStatus = "CREATE";
            frmdetail.ShowDialog();
            //如果有变化,重新显示，
            if (frmdetail.DialogResult == DialogResult.OK)
            {
                showBooksByTitle();
            }
        }

        /// <summary>
        /// 按“删除按钮”的时候处理
        /// </summary>
        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            //如果这本书书号是有效的“删除”对话框中显示
            if (getBookIsbnBySelcectedRow() != "")
            {
                frmBookDetail frmdetail = new frmBookDetail();
                frmdetail.BookIsbn = getBookIsbnBySelcectedRow();
                frmdetail.CrudStatus = "DELETE";
                frmdetail.ShowDialog();
                //刷新
                if (frmdetail.DialogResult == DialogResult.OK)
                {
                    showBooksByTitle();
                }
            }
        }

        /// <summary>
        /// 更新
        /// </summary>
        private void btnUpdate_Click(object sender, System.EventArgs e)
        {
            if (getBookIsbnBySelcectedRow() != "")
            {
                frmBookDetail frmdetail = new frmBookDetail();
                frmdetail.BookIsbn = getBookIsbnBySelcectedRow();
                frmdetail.CrudStatus = "UPDATE";
                frmdetail.ShowDialog();
                //刷新
                if (frmdetail.DialogResult == DialogResult.OK)
                {
                    showBooksByTitle();
                }
            }
        }

        /// <summary>
        /// 名字搜索的执行
        /// </summary>
        private void showBooksByTitle()
        {
            try
            {
                //LIKE搜索运行
                //IList books = Mapper.Instance().QueryForList("GetBookListByTitle", this.txtTitle.Text);
                IList books = mapper.QueryForList("GetBookListByTitle", this.txtTitle.Text);
                //清除数据
                _dataTable.Clear();
                //设置搜索结果的数据
                foreach (Book book in books)
                {
                    _dataTable.Rows.Add(new Object[] { book.Isbn, book.IsbnWithHyphen, book.Title, book.Price, book.SaleDate });
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// 价格搜索的执行
        /// </summary>
        private void showBooksByPrice()
        {
            //价格搜索运行
            Hashtable param = new Hashtable();
            param.Add("price", this.cmbPrice.Text); //价格
            param.Add("priceCompare", this.cmbPrice2.Text); //「以上」or「以下」
            IList books = mapper.QueryForList("GetBookListByPrice", param);
            //清除数据
            _dataTable.Clear();
            //将搜索结果的数据
            foreach (Book book in books)
            {
                _dataTable.Rows.Add(new Object[] { book.Isbn, book.IsbnWithHyphen, book.Title, book.Price, book.SaleDate });
            }
        }

        /// <summary>
        /// 获得所选择的行的书籍ISBN在数据
        /// </summary>
        private string getBookIsbnBySelcectedRow()
        {
            string result = "";
            try
            {
                result = (string)grdMain[grdMain.CurrentCell.RowNumber, 0];
            }
            catch (Exception e)
            {
                //如果图书列表一个按钮被点击一个空白的状态（可能）
                _logger.Debug(e.Message);
            }
            return result;
        }

        private void grdMain_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            //点击的时候选择一整行
            if (_dataTable.Rows.Count != 0)
            {
                this.grdMain.Select(this.grdMain.CurrentCell.RowNumber);
            }
        }
    }
}