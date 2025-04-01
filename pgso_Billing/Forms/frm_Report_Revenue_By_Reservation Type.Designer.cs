namespace pgso.pgso_Billing.Forms
{
    partial class frm_Report_Revenue_By_Reservation_Type
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
            this.Revenu_Report_Viewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // Revenu_Report_Viewer
            // 
            this.Revenu_Report_Viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Revenu_Report_Viewer.LocalReport.ReportEmbeddedResource = "pgso.Report_Revenue_By_Reservation_Type.rdlc";
            this.Revenu_Report_Viewer.Location = new System.Drawing.Point(0, 0);
            this.Revenu_Report_Viewer.Name = "Revenu_Report_Viewer";
            this.Revenu_Report_Viewer.ServerReport.BearerToken = null;
            this.Revenu_Report_Viewer.Size = new System.Drawing.Size(965, 772);
            this.Revenu_Report_Viewer.TabIndex = 0;
            // 
            // frm_Report_Revenue_By_Reservation_Type
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 772);
            this.Controls.Add(this.Revenu_Report_Viewer);
            this.Name = "frm_Report_Revenue_By_Reservation_Type";
            this.Text = "frm_Report_Revenue_By_Reservation_Type";
            this.Load += new System.EventHandler(this.frm_Report_Revenue_By_Reservation_Type_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer Revenu_Report_Viewer;
    }
}