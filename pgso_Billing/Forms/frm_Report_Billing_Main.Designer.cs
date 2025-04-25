namespace pgso.pgso_Billing.Forms
{
    partial class frm_Report_Billing_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Report_Billing_Main));
            this.dtp_Start_Date = new System.Windows.Forms.DateTimePicker();
            this.dtp_End_Date = new System.Windows.Forms.DateTimePicker();
            this.tb_Start_Date = new System.Windows.Forms.TextBox();
            this.tb_End_Date = new System.Windows.Forms.TextBox();
            this.cmb_Venue_Or_Equipment = new System.Windows.Forms.ComboBox();
            this.tb_Venue_Or_Equipment = new System.Windows.Forms.TextBox();
            this.tb_Payment_Status = new System.Windows.Forms.TextBox();
            this.cmb_Payment_Status = new System.Windows.Forms.ComboBox();
            this.btn_Generate_Report = new System.Windows.Forms.Button();
            this.tb_Choose_Report = new System.Windows.Forms.TextBox();
            this.cmb_Choose_Report = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // dtp_Start_Date
            // 
            this.dtp_Start_Date.CalendarMonthBackground = System.Drawing.SystemColors.Control;
            this.dtp_Start_Date.CalendarTitleBackColor = System.Drawing.SystemColors.Control;
            this.dtp_Start_Date.Location = new System.Drawing.Point(112, 106);
            this.dtp_Start_Date.Name = "dtp_Start_Date";
            this.dtp_Start_Date.Size = new System.Drawing.Size(200, 20);
            this.dtp_Start_Date.TabIndex = 0;
            // 
            // dtp_End_Date
            // 
            this.dtp_End_Date.CalendarMonthBackground = System.Drawing.SystemColors.Control;
            this.dtp_End_Date.CalendarTitleBackColor = System.Drawing.SystemColors.Control;
            this.dtp_End_Date.Location = new System.Drawing.Point(112, 145);
            this.dtp_End_Date.Name = "dtp_End_Date";
            this.dtp_End_Date.Size = new System.Drawing.Size(200, 20);
            this.dtp_End_Date.TabIndex = 1;
            // 
            // tb_Start_Date
            // 
            this.tb_Start_Date.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(203)))), ((int)(((byte)(208)))));
            this.tb_Start_Date.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Start_Date.Location = new System.Drawing.Point(12, 106);
            this.tb_Start_Date.Name = "tb_Start_Date";
            this.tb_Start_Date.Size = new System.Drawing.Size(94, 13);
            this.tb_Start_Date.TabIndex = 2;
            this.tb_Start_Date.Text = "START DATE";
            this.tb_Start_Date.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tb_End_Date
            // 
            this.tb_End_Date.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(203)))), ((int)(((byte)(208)))));
            this.tb_End_Date.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_End_Date.Location = new System.Drawing.Point(12, 145);
            this.tb_End_Date.Name = "tb_End_Date";
            this.tb_End_Date.Size = new System.Drawing.Size(94, 13);
            this.tb_End_Date.TabIndex = 3;
            this.tb_End_Date.Text = "END DATE";
            this.tb_End_Date.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmb_Venue_Or_Equipment
            // 
            this.cmb_Venue_Or_Equipment.BackColor = System.Drawing.SystemColors.Control;
            this.cmb_Venue_Or_Equipment.FormattingEnabled = true;
            this.cmb_Venue_Or_Equipment.Items.AddRange(new object[] {
            "ALL",
            "Venue",
            "Equipment"});
            this.cmb_Venue_Or_Equipment.Location = new System.Drawing.Point(112, 236);
            this.cmb_Venue_Or_Equipment.Name = "cmb_Venue_Or_Equipment";
            this.cmb_Venue_Or_Equipment.Size = new System.Drawing.Size(200, 21);
            this.cmb_Venue_Or_Equipment.TabIndex = 4;
            // 
            // tb_Venue_Or_Equipment
            // 
            this.tb_Venue_Or_Equipment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(203)))), ((int)(((byte)(208)))));
            this.tb_Venue_Or_Equipment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Venue_Or_Equipment.Location = new System.Drawing.Point(9, 236);
            this.tb_Venue_Or_Equipment.Multiline = true;
            this.tb_Venue_Or_Equipment.Name = "tb_Venue_Or_Equipment";
            this.tb_Venue_Or_Equipment.Size = new System.Drawing.Size(94, 30);
            this.tb_Venue_Or_Equipment.TabIndex = 5;
            this.tb_Venue_Or_Equipment.Text = "VENUE / \r\nEQUIPMENT\r\n";
            this.tb_Venue_Or_Equipment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tb_Payment_Status
            // 
            this.tb_Payment_Status.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(203)))), ((int)(((byte)(208)))));
            this.tb_Payment_Status.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Payment_Status.Location = new System.Drawing.Point(0, 205);
            this.tb_Payment_Status.Name = "tb_Payment_Status";
            this.tb_Payment_Status.Size = new System.Drawing.Size(106, 13);
            this.tb_Payment_Status.TabIndex = 6;
            this.tb_Payment_Status.Text = "PAYMENT STATUS";
            this.tb_Payment_Status.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmb_Payment_Status
            // 
            this.cmb_Payment_Status.BackColor = System.Drawing.SystemColors.Control;
            this.cmb_Payment_Status.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmb_Payment_Status.FormattingEnabled = true;
            this.cmb_Payment_Status.Items.AddRange(new object[] {
            "ALL",
            "Confirmed",
            "Pending",
            "Cancelled"});
            this.cmb_Payment_Status.Location = new System.Drawing.Point(112, 205);
            this.cmb_Payment_Status.Name = "cmb_Payment_Status";
            this.cmb_Payment_Status.Size = new System.Drawing.Size(200, 21);
            this.cmb_Payment_Status.TabIndex = 7;
            // 
            // btn_Generate_Report
            // 
            this.btn_Generate_Report.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(166)))), ((int)(((byte)(167)))));
            this.btn_Generate_Report.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Generate_Report.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.btn_Generate_Report.Location = new System.Drawing.Point(214, 263);
            this.btn_Generate_Report.Name = "btn_Generate_Report";
            this.btn_Generate_Report.Size = new System.Drawing.Size(98, 33);
            this.btn_Generate_Report.TabIndex = 10;
            this.btn_Generate_Report.Text = "GENERATE";
            this.btn_Generate_Report.UseVisualStyleBackColor = false;
            this.btn_Generate_Report.Click += new System.EventHandler(this.btn_Generate_Report_Click);
            // 
            // tb_Choose_Report
            // 
            this.tb_Choose_Report.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(203)))), ((int)(((byte)(208)))));
            this.tb_Choose_Report.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Choose_Report.Location = new System.Drawing.Point(12, 175);
            this.tb_Choose_Report.Name = "tb_Choose_Report";
            this.tb_Choose_Report.Size = new System.Drawing.Size(94, 13);
            this.tb_Choose_Report.TabIndex = 11;
            this.tb_Choose_Report.Text = "REPORT TYPE";
            this.tb_Choose_Report.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmb_Choose_Report
            // 
            this.cmb_Choose_Report.BackColor = System.Drawing.SystemColors.Control;
            this.cmb_Choose_Report.FormattingEnabled = true;
            this.cmb_Choose_Report.Items.AddRange(new object[] {
            "Revenue Report"});
            this.cmb_Choose_Report.Location = new System.Drawing.Point(112, 175);
            this.cmb_Choose_Report.Name = "cmb_Choose_Report";
            this.cmb_Choose_Report.Size = new System.Drawing.Size(200, 21);
            this.cmb_Choose_Report.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(328, 100);
            this.panel1.TabIndex = 13;
            // 
            // frm_Report_Billing_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(203)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(328, 300);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmb_Choose_Report);
            this.Controls.Add(this.tb_Choose_Report);
            this.Controls.Add(this.btn_Generate_Report);
            this.Controls.Add(this.cmb_Payment_Status);
            this.Controls.Add(this.tb_Payment_Status);
            this.Controls.Add(this.tb_Venue_Or_Equipment);
            this.Controls.Add(this.cmb_Venue_Or_Equipment);
            this.Controls.Add(this.tb_End_Date);
            this.Controls.Add(this.tb_Start_Date);
            this.Controls.Add(this.dtp_End_Date);
            this.Controls.Add(this.dtp_Start_Date);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Report_Billing_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frm_Report_Billing";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtp_Start_Date;
        private System.Windows.Forms.DateTimePicker dtp_End_Date;
        private System.Windows.Forms.TextBox tb_Start_Date;
        private System.Windows.Forms.TextBox tb_End_Date;
        private System.Windows.Forms.ComboBox cmb_Venue_Or_Equipment;
        private System.Windows.Forms.TextBox tb_Venue_Or_Equipment;
        private System.Windows.Forms.TextBox tb_Payment_Status;
        private System.Windows.Forms.ComboBox cmb_Payment_Status;
        private System.Windows.Forms.Button btn_Generate_Report;
        private System.Windows.Forms.TextBox tb_Choose_Report;
        private System.Windows.Forms.ComboBox cmb_Choose_Report;
        private System.Windows.Forms.Panel panel1;
    }
}