namespace pgso
{
    partial class frm_dashboard
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
            this.btn_reports = new System.Windows.Forms.Button();
            this.btn_rental = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_venues = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_reports
            // 
            this.btn_reports.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reports.Location = new System.Drawing.Point(319, 3);
            this.btn_reports.Name = "btn_reports";
            this.btn_reports.Size = new System.Drawing.Size(152, 32);
            this.btn_reports.TabIndex = 2;
            this.btn_reports.Text = "Reports";
            this.btn_reports.UseVisualStyleBackColor = true;
            // 
            // btn_rental
            // 
            this.btn_rental.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_rental.Location = new System.Drawing.Point(161, 3);
            this.btn_rental.Name = "btn_rental";
            this.btn_rental.Size = new System.Drawing.Size(152, 32);
            this.btn_rental.TabIndex = 1;
            this.btn_rental.Text = "Rental";
            this.btn_rental.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "Calendar of Ativities";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btn_venues);
            this.panel1.Controls.Add(this.btn_reports);
            this.panel1.Controls.Add(this.btn_rental);
            this.panel1.Location = new System.Drawing.Point(12, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(920, 41);
            this.panel1.TabIndex = 3;
            // 
            // btn_venues
            // 
            this.btn_venues.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_venues.Location = new System.Drawing.Point(3, 3);
            this.btn_venues.Name = "btn_venues";
            this.btn_venues.Size = new System.Drawing.Size(152, 32);
            this.btn_venues.TabIndex = 3;
            this.btn_venues.Text = "Venue";
            this.btn_venues.UseVisualStyleBackColor = true;
            this.btn_venues.Click += new System.EventHandler(this.btn_venues_Click);
            // 
            // frm_dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(944, 587);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "frm_dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmadmindashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_reports;
        private System.Windows.Forms.Button btn_rental;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_venues;
    }
}