namespace pgso.pgso_Billing.Forms
{
    partial class frm_Report_Billing_Venue
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
            this.Report_Viewer_Venue_Revenue = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // Report_Viewer_Venue_Revenue
            // 
            this.Report_Viewer_Venue_Revenue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.Report_Viewer_Venue_Revenue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Report_Viewer_Venue_Revenue.Location = new System.Drawing.Point(0, 0);
            this.Report_Viewer_Venue_Revenue.Name = "Report_Viewer_Venue_Revenue";
            this.Report_Viewer_Venue_Revenue.ServerReport.BearerToken = null;
            this.Report_Viewer_Venue_Revenue.Size = new System.Drawing.Size(996, 836);
            this.Report_Viewer_Venue_Revenue.TabIndex = 0;
            // 
            // frm_Report_Billing_Venue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 836);
            this.Controls.Add(this.Report_Viewer_Venue_Revenue);
            this.Name = "frm_Report_Billing_Venue";
            this.Text = "frm_Report_Billing_Venue";
            this.Load += new System.EventHandler(this.frm_Report_Billing_Venue_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer Report_Viewer_Venue_Revenue;
    }
}