using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsStockTool
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        /// <summary>
        /// 
        /// </summary>
        public static readonly string MyStockXmlPath = Application.StartupPath + "\\myStocks.xml";


        bool beginMove = false;//初始化鼠标位置
        int currentXPosition;
        int currentYPosition;

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            ShowMyStockInfo();
        }

        private void tsmiConfig_Click(object sender, EventArgs e)
        {
            FrmConfig frm = new FrmConfig();
            frm.ShowDialog(this);
        }

        /// <summary>
        /// 
        /// </summary>
        private void ShowMyStockInfo()
        {
            List<MyStock> myStocks = Bonn.Helper.XmlHelper.XmlDeserializeFromFile<List<MyStock>>(MyStockXmlPath);
            string stockStrings = "";
            foreach (MyStock MyStock in myStocks)
            {
                stockStrings += $"{MyStock.type}{MyStock.code},";
            }
            stockStrings = stockStrings.Remove(stockStrings.Length - 1, 1);
            Dictionary<string, StockInfo> valuePairs = SinaApi.CodeInspector(stockStrings);
            lvMyStock.Items.Clear();
            foreach (var ValuePair in valuePairs)
            {
                ListViewItem Item = new ListViewItem();
                Item.SubItems[0].Text = ValuePair.Value.Code;
                Item.SubItems.Add(ValuePair.Value.Name);
                Item.SubItems.Add(ValuePair.Value.Price);
                Item.SubItems.Add(ValuePair.Value.IncreaseRate);
                lvMyStock.Items.Add(Item);//显示  
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                ShowMyStockInfo();

                Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                int x = Convert.ToInt32(cfa.AppSettings.Settings["LastLocationX"].Value);
                int y = Convert.ToInt32(cfa.AppSettings.Settings["LastLocationY"].Value);
                this.Location = new Point(x, y);
                timerRefresh.Interval = Convert.ToInt32(cfa.AppSettings.Settings["SyncInterval"].Value) * 1000;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), "出错啦", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        /// <summary>
        /// 保存最后位置
        /// </summary>
        private void SaveLastLocation()
        {
            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            cfa.AppSettings.Settings["LastLocationX"].Value = Location.X.ToString();
            cfa.AppSettings.Settings["LastLocationY"].Value = Location.Y.ToString();
            cfa.Save();
        }

        private void tsmiClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private int lvMyStockHeight;

        private void tsmiHide_Click(object sender, EventArgs e)
        {
            if (lvMyStock.Visible)
            {
                lvMyStockHeight = lvMyStock.Height;
                lvMyStock.Visible = false;
                this.Height -= lvMyStockHeight;
            }
            else
            {
                lvMyStock.Visible = true;
                this.Height += lvMyStockHeight;
            }
        }

        private void pbxMove_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //获取鼠标按下时的位置
                beginMove = true;
                currentXPosition = MousePosition.X; //鼠标的x坐标为当前窗体左上角x坐标
                currentYPosition = MousePosition.Y; //鼠标的y坐标为当前窗体左上角y坐标

                this.Cursor = Cursors.SizeAll;
            }
        }

        private void pbxMove_MouseMove(object sender, MouseEventArgs e)
        {
            if (beginMove)
            {
                this.Left += MousePosition.X - currentXPosition; //根据鼠标x坐标确定窗体的左边坐标x
                this.Top += MousePosition.Y - currentYPosition; //根据鼠标的y坐标窗体的顶部，即Y坐标
                currentXPosition = MousePosition.X;
                currentYPosition = MousePosition.Y;
            }
        }

        private void pbxMove_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                currentXPosition = 0; //设置初始状态
                currentYPosition = 0;
                beginMove = false;

                SaveLastLocation();

                this.Cursor = Cursors.Default;
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(this, "确认要退出吗？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
            {

            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
