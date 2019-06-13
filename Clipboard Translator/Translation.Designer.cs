namespace Clipboard_Translator
{
    partial class Translation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Translation_Text = new System.Windows.Forms.TextBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Translation_Text
            // 
            this.Translation_Text.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(79)))), ((int)(((byte)(107)))));
            this.Translation_Text.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Translation_Text.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Translation_Text.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Translation_Text.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Translation_Text.Location = new System.Drawing.Point(10, 20);
            this.Translation_Text.Margin = new System.Windows.Forms.Padding(10, 20, 10, 20);
            this.Translation_Text.MinimumSize = new System.Drawing.Size(500, 80);
            this.Translation_Text.Multiline = true;
            this.Translation_Text.Name = "Translation_Text";
            this.Translation_Text.ReadOnly = true;
            this.Translation_Text.Size = new System.Drawing.Size(500, 80);
            this.Translation_Text.TabIndex = 1;
            this.Translation_Text.TabStop = false;
            // 
            // timer
            // 
            this.timer.Interval = 200;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // Translation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(79)))), ((int)(((byte)(107)))));
            this.ClientSize = new System.Drawing.Size(520, 120);
            this.Controls.Add(this.Translation_Text);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(520, 360);
            this.Name = "Translation";
            this.Opacity = 0.9D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Translation";
            this.TopMost = true;
            this.Deactivate += new System.EventHandler(this.Translation_Deactivate);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox Translation_Text;
        private System.Windows.Forms.Timer timer;
    }
}