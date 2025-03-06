using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace pgso
{
    partial class frm_dashboard
    {
        private IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new Container();
            this.SuspendLayout();

            // frm_dashboard
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Name = "frm_dashboard";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "frm_dashboard_admin";
            this.WindowState = FormWindowState.Maximized;

            this.ResumeLayout(false);
        }

        #endregion
    }
}
