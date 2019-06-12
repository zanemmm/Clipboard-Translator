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
        private const int EM_GETLINECOUNT = 0xBA;

        public Translation()
        {
            InitializeComponent();
        }

        private void Translation_Deactivate(object sender, EventArgs e)
        {
            Hide();
            // 重置译文窗口大小
            Translation_Text.Text = "";
            Translation_SizeLabel.Text = "";
            Translation_Text.Size = Translation_Text.MinimumSize;
            Translation_SizeLabel.Size = Translation_SizeLabel.MinimumSize;
            Translation_Text.ScrollBars = ScrollBars.None;
            Size = MinimumSize;
            // 关闭定时器
            timer.Enabled = false;
        }

        public void PopupTranslation(string translation)
        {
            Translation_SizeLabel.Text = translation;
            Translation_Text.Text = translation;
            // 通过标签的自适应宽度，设置文本框的宽度
            Size textSize = new Size();
            if (Translation_SizeLabel.Size.Width > MaximumSize.Width) {
                textSize.Width = MaximumSize.Width - 10;
            } else {
                textSize.Width = Translation_SizeLabel.Size.Width;
            }
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
            Show();
            timer.Enabled = true;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Activate();
            Focus();
        }
    }
}
