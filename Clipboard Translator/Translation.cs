using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Clipboard_Translator
{
    public partial class Translation : Form
    {
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);

        private const int EM_GETLINECOUNT = 0xBA;
        private const int AW_HIDE = 0x10000;
        private const int AW_BLEND = 0x80000;

        public Translation()
        {
            InitializeComponent();
        }

        private void Translation_Deactivate(object sender, EventArgs e)
        {
            AnimateWindow(Handle, 300, AW_BLEND | AW_HIDE);
            // 重置译文窗口大小
            Translation_Text.Text = "";
            Translation_Text.Size = Translation_Text.MinimumSize;
            Translation_Text.ScrollBars = ScrollBars.None;
            Size = MinimumSize;
            // 关闭定时器
            timer.Enabled = false;
        }

        public void PopupTranslation(string translation)
        {
            Translation_Text.Text = translation;
            Translation_Text.Select(0, 0);
            // 设置文本框的宽度
            Size textSize = new Size();
            textSize.Width = Size.Width - 20;
            // 宽度确定后判断文本框高度，如果大于最大高度则出现滚动条
            int fontHeight = Translation_Text.Font.Height;
            int lineCount = SendMessage(Translation_Text.Handle, EM_GETLINECOUNT, 0, 0);
            int readyHeight = lineCount * fontHeight;
            if (readyHeight > MaximumSize.Height) {
                textSize.Height = MaximumSize.Height - 20;
                Translation_Text.ScrollBars = ScrollBars.Vertical;
            } else {
                textSize.Height = readyHeight;
            }
            Translation_Text.Size = textSize;
            AnimateWindow(Handle, 300, AW_BLEND);
            Show();
            timer.Enabled = true;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // 定时使译文窗口获得焦点，保证失去焦点事件能够触发
            Activate();
            Focus();
        }
    }
}
