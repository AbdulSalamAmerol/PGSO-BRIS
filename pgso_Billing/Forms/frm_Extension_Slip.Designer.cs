namespace pgso.pgso_Billing.Forms
{
    partial class frm_Extension_Slip
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
            this.Extension_Slip_Report_Viewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // Extension_Slip_Report_Viewer
            // 
            this.Extension_Slip_Report_Viewer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.Extension_Slip_Report_Viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Extension_Slip_Report_Viewer.Location = new System.Drawing.Point(0, 0);
            this.Extension_Slip_Report_Viewer.Name = "Extension_Slip_Report_Viewer";
            this.Extension_Slip_Report_Viewer.ServerReport.BearerToken = null;
            this.Extension_Slip_Report_Viewer.Size = new System.Drawing.Size(984, 961);
            this.Extension_Slip_Report_Viewer.TabIndex = 0;
            // 
            // frm_Extension_Slip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 961);
            this.Controls.Add(this.Extension_Slip_Report_Viewer);
            this.Name = "frm_Extension_Slip";
            this.Text = "frm_Extension_Slip";
            this.Load += new System.EventHandler(this.frm_Extension_Slip_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer Extension_Slip_Report_Viewer;
    }
}