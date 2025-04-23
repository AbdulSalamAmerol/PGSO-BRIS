namespace pgso.pgso_Billing.Forms
{
    partial class frm_Print_Billing
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
            this.Print_Billing_Report_Viewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // Print_Billing_Report_Viewer
            // 
            this.Print_Billing_Report_Viewer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.Print_Billing_Report_Viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Print_Billing_Report_Viewer.LocalReport.ReportEmbeddedResource = "pgso.pgso_Billing.Forms.Print_Billing.rdlc";
            this.Print_Billing_Report_Viewer.Location = new System.Drawing.Point(0, 0);
            this.Print_Billing_Report_Viewer.Name = "Print_Billing_Report_Viewer";
            this.Print_Billing_Report_Viewer.ServerReport.BearerToken = null;
            this.Print_Billing_Report_Viewer.Size = new System.Drawing.Size(984, 961);
            this.Print_Billing_Report_Viewer.TabIndex = 0;
            this.Print_Billing_Report_Viewer.Load += new System.EventHandler(this.Print_Billing_Report_Viewer_Load);
            // 
            // frm_Print_Billing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(203)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(984, 961);
            this.Controls.Add(this.Print_Billing_Report_Viewer);
            this.Name = "frm_Print_Billing";
            this.Text = "frm_Print_Billing";
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer Print_Billing_Report_Viewer;
    }
}