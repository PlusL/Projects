using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MybatisDemo.Presentation;
namespace MybatisDemo
{
    internal static class Program
    {
        private static readonly log4net.ILog _logger =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            try
            {
                _logger.Info("●启动iBATIS.NET");
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmBookView());
            }
            catch (Exception ex)
            {
                _logger.Error("★iBATIS.NET示例应用程序错误★", ex);
                MessageBox.Show("一个意外的错误，并退出应用程序。\r了解更多信息，查看“log4net的”的日志。",
                    "iBatisSample", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            _logger.Info("●退出iBATIS.NET");
        }
    }
}
