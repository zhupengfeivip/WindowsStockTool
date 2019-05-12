using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace WindowsStockTool
{
    public partial class FrmConfig : Form
    {
        public FrmConfig()
        {
            InitializeComponent();
        }

        private void FrmConfig_Load(object sender, EventArgs e)
        {
            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            cbxRunWithSystem.Checked = Convert.ToBoolean(cfa.AppSettings.Settings["RunWithSystem"].Value);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            cfa.AppSettings.Settings["RunWithSystem"].Value = cbxRunWithSystem.Checked.ToString();
            cfa.Save();

            string programName = Path.GetFileName(Application.ExecutablePath);
            if (cbxRunWithSystem.Checked)
            {
                // 添加到 当前登陆用户的 注册表启动项
                RegistryKey runKey = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                runKey.SetValue(programName, Application.ExecutablePath);
            }
            else
            {
                RegistryKey runKey = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                runKey.DeleteValue(programName);
            }

            MessageBox.Show(this, "设置成功。");
            this.Close();
        }
    }
}
