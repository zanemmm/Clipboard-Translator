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
            this.Translation_Text = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Translation_Text
            // 
            this.Translation_Text.AutoSize = true;
            this.Translation_Text.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Translation_Text.Location = new System.Drawing.Point(12, 24);
            this.Translation_Text.MinimumSize = new System.Drawing.Size(454, 24);
            this.Translation_Text.Name = "Translation_Text";
            this.Translation_Text.Size = new System.Drawing.Size(454, 31);
            this.Translation_Text.TabIndex = 0;
            this.Translation_Text.Text = "译文";
            // 
            // Translation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(480, 240);
            this.Controls.Add(this.Translation_Text);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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

        private System.Windows.Forms.Label Translation_Text;
    }
}