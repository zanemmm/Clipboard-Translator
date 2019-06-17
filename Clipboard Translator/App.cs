using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Clipboard_Translator
{

    public partial class App : Form
    {
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);
        // WM_DRAWCLIPBOARD 消息
        private const int WM_DRAWCLIPBOARD = 0x0308;
        private IntPtr _clipboardViewerNext;
        private Translation _translationForm;
        private bool _start = true;

        public App()
        {
            InitializeComponent();
        }

        private void App_Load(object sender, EventArgs e)
        {
            _clipboardViewerNext = SetClipboardViewer(this.Handle);
            _translationForm = new Translation();
            WindowState = FormWindowState.Minimized;
        }

        private void App_Deactivate(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized) {
                NotifyIcon.Visible = true;
            }
        }

        private void App_FormClosing(object sender, FormClosingEventArgs e)
        {
            NotifyIcon.Visible = false;
            ChangeClipboardChain(this.Handle, _clipboardViewerNext);
        }

        protected override void WndProc(ref Message m)
        {
            // 处理消息
            base.WndProc(ref m);
            if (m.Msg == WM_DRAWCLIPBOARD) {
                // 剪切板文本
                string text = Clipboard.GetText();
                if (_translationForm != null && text != null && _start) {
                    ClipboardTextTranslate(text.Trim());
                }
            }
        }

        private void ClipboardTextTranslate(string text)
        {
            // 长度不符要求
            if (text.Length < 1 || text.Length > 500) {
                return;
            }
            // 存在不属于 ASCII 码的字符不译
            if(Regex.IsMatch(text, "[^\x00-\x7F]")) {
                return;
            }
            // 分割单词
            string[] words = text.Split(' ');
            if (words.Length == 1) {
                string translation = Program.GetWordTranslation(words.First());
                _translationForm.PopupTranslation(translation);
            } else {
                string translation = Program.GetSentenceTranslation(text);
                _translationForm.PopupTranslation(translation);
            }
        }

        private void StartMenuItem_Click(object sender, EventArgs e)
        {
            StartMenuItem.Checked = true;
            StopMenuItem.Checked = false;
            _start = true;
        }

        private void StopMenuItem_Click(object sender, EventArgs e)
        {
            StartMenuItem.Checked = false;
            StopMenuItem.Checked = true;
            _start = false;
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized) {
                NotifyIcon.Visible = false;
            }
        }
    }
}
