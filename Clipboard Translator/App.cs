using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clipboard_Translator
{

    public partial class App : Form
    {
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);

        private const int WM_DRAWCLIPBOARD = 0x0308;        // WM_DRAWCLIPBOARD message
        private IntPtr _clipboardViewerNext;
        private Translation _translationForm;
        private Boolean _start = true;


        public App()
        {
            InitializeComponent();
        }

        private void App_Load(object sender, EventArgs e)
        {
            _clipboardViewerNext = SetClipboardViewer(this.Handle);
            _translationForm = new Translation();
            
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
            base.WndProc(ref m);    // Process the message 
            if (m.Msg == WM_DRAWCLIPBOARD) {
                IDataObject iData = Clipboard.GetDataObject();      // Clipboard's data
                if (iData.GetDataPresent(DataFormats.Text)) {
                    string text = (string)iData.GetData(DataFormats.Text);      // Clipboard text
                    label1.Text = text + DateTime.Now.ToString();
                    if (_translationForm != null && _start && text.Length > 0) {
                        Activate();
                        string translation = Program.GetWordTranslation(text);
                        _translationForm.popupTranslation(translation);
                          
                    }
                }
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
