using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clipboard_Translator
{
    public partial class Translation : Form
    {
        public Translation()
        {
            InitializeComponent();
        }

        private void Translation_Deactivate(object sender, EventArgs e)
        {
            Hide();
        }

        public void popupTranslation(string translation)
        {
            Show();
            Translation_Text.Text = translation;
        }
    }
}
