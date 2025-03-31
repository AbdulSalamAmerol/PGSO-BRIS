namespace pgso.pgso_Billing.Forms
{
    partial class frm_Report_Billing
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
            this.SuspendLayout();
            // 
            // dtp_Start_Date
            // 
            this.dtp_Start_Date.CalendarMonthBackground = System.Drawing.SystemColors.Control;
            this.dtp_Start_Date.CalendarTitleBackColor = System.Drawing.SystemColors.Control;
            this.dtp_Start_Date.Location = new System.Drawing.Point(169, 33);
            this.dtp_Start_Date.Name = "dtp_Start_Date";
            this.dtp_Start_Date.Size = new System.Drawing.Size(200, 20);
            this.dtp_Start_Date.TabIndex = 0;
            // 
            // dtp_End_Date
            // 
            this.dtp_End_Date.CalendarMonthBackground = System.Drawing.SystemColors.Control;
            this.dtp_End_Date.CalendarTitleBackColor = System.Drawing.SystemColors.Control;
            this.dtp_End_Date.Location = new System.Drawing.Point(169, 72);
            this.dtp_End_Date.Name = "dtp_End_Date";
            this.dtp_End_Date.Size = new System.Drawing.Size(200, 20);
            this.dtp_End_Date.TabIndex = 1;
            // 
            // tb_Start_Date
            // 
            this.tb_Start_Date.BackColor = System.Drawing.SystemColors.Control;
            this.tb_Start_Date.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Start_Date.Location = new System.Drawing.Point(26, 33);
            this.tb_Start_Date.Name = "tb_Start_Date";
            this.tb_Start_Date.Size = new System.Drawing.Size(137, 13);
            this.tb_Start_Date.TabIndex = 2;
            this.tb_Start_Date.Text = "Select Start Date";
            this.tb_Start_Date.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tb_End_Date
            // 
            this.tb_End_Date.BackColor = System.Drawing.SystemColors.Control;
            this.tb_End_Date.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_End_Date.Location = new System.Drawing.Point(26, 72);
            this.tb_End_Date.Name = "tb_End_Date";
            this.tb_End_Date.Size = new System.Drawing.Size(137, 13);
            this.tb_End_Date.TabIndex = 3;
            this.tb_End_Date.Text = "Select End Date";
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
            this.cmb_Venue_Or_Equipment.Location = new System.Drawing.Point(169, 153);
            this.cmb_Venue_Or_Equipment.Name = "cmb_Venue_Or_Equipment";
            this.cmb_Venue_Or_Equipment.Size = new System.Drawing.Size(200, 21);
            this.cmb_Venue_Or_Equipment.TabIndex = 4;
            // 
            // tb_Venue_Or_Equipment
            // 
            this.tb_Venue_Or_Equipment.BackColor = System.Drawing.SystemColors.Control;
            this.tb_Venue_Or_Equipment.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Venue_Or_Equipment.Location = new System.Drawing.Point(23, 153);
            this.tb_Venue_Or_Equipment.Name = "tb_Venue_Or_Equipment";
            this.tb_Venue_Or_Equipment.Size = new System.Drawing.Size(137, 13);
            this.tb_Venue_Or_Equipment.TabIndex = 5;
            this.tb_Venue_Or_Equipment.Text = "Choose Venue/Equipment";
            this.tb_Venue_Or_Equipment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tb_Payment_Status
            // 
            this.tb_Payment_Status.BackColor = System.Drawing.SystemColors.Control;
            this.tb_Payment_Status.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Payment_Status.Location = new System.Drawing.Point(26, 114);
            this.tb_Payment_Status.Name = "tb_Payment_Status";
            this.tb_Payment_Status.Size = new System.Drawing.Size(137, 13);
            this.tb_Payment_Status.TabIndex = 6;
            this.tb_Payment_Status.Text = "Payment Status";
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
            this.cmb_Payment_Status.Location = new System.Drawing.Point(169, 114);
            this.cmb_Payment_Status.Name = "cmb_Payment_Status";
            this.cmb_Payment_Status.Size = new System.Drawing.Size(200, 21);
            this.cmb_Payment_Status.TabIndex = 7;
            // 
            // btn_Generate_Report
            // 
            this.btn_Generate_Report.Location = new System.Drawing.Point(271, 215);
            this.btn_Generate_Report.Name = "btn_Generate_Report";
            this.btn_Generate_Report.Size = new System.Drawing.Size(98, 33);
            this.btn_Generate_Report.TabIndex = 10;
            this.btn_Generate_Report.Text = "Generate Report";
            this.btn_Generate_Report.UseVisualStyleBackColor = true;
            this.btn_Generate_Report.Click += new System.EventHandler(this.btn_Generate_Report_Click);
            // 
            // tb_Choose_Report
            // 
            this.tb_Choose_Report.BackColor = System.Drawing.SystemColors.Control;
            this.tb_Choose_Report.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Choose_Report.Location = new System.Drawing.Point(26, 188);
            this.tb_Choose_Report.Name = "tb_Choose_Report";
            this.tb_Choose_Report.Size = new System.Drawing.Size(137, 13);
            this.tb_Choose_Report.TabIndex = 11;
            this.tb_Choose_Report.Text = "Choose Report";
            this.tb_Choose_Report.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cmb_Choose_Report
            // 
            this.cmb_Choose_Report.BackColor = System.Drawing.SystemColors.Control;
            this.cmb_Choose_Report.FormattingEnabled = true;
            this.cmb_Choose_Report.Items.AddRange(new object[] {
            "Revenue By Reservation Type"});
            this.cmb_Choose_Report.Location = new System.Drawing.Point(169, 188);
            this.cmb_Choose_Report.Name = "cmb_Choose_Report";
            this.cmb_Choose_Report.Size = new System.Drawing.Size(200, 21);
            this.cmb_Choose_Report.TabIndex = 12;
            // 
            // frm_Report_Billing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 260);
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
            this.Name = "frm_Report_Billing";
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
    }
}