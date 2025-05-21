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
            this.dtp_Start_Date = new System.Windows.Forms.DateTimePicker();
            this.dtp_End_Date = new System.Windows.Forms.DateTimePicker();
            this.cmb_Venue_Or_Equipment = new System.Windows.Forms.ComboBox();
            this.cmb_Payment_Status = new System.Windows.Forms.ComboBox();
            this.btn_Generate_Report = new System.Windows.Forms.Button();
            this.cmb_Choose_Report = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtp_Start_Date
            // 
            this.dtp_Start_Date.CalendarMonthBackground = System.Drawing.SystemColors.Control;
            this.dtp_Start_Date.CalendarTitleBackColor = System.Drawing.SystemColors.Control;
            this.dtp_Start_Date.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_Start_Date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_Start_Date.Location = new System.Drawing.Point(223, 65);
            this.dtp_Start_Date.Name = "dtp_Start_Date";
            this.dtp_Start_Date.Size = new System.Drawing.Size(161, 23);
            this.dtp_Start_Date.TabIndex = 0;
            // 
            // dtp_End_Date
            // 
            this.dtp_End_Date.CalendarMonthBackground = System.Drawing.SystemColors.Control;
            this.dtp_End_Date.CalendarTitleBackColor = System.Drawing.SystemColors.Control;
            this.dtp_End_Date.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_End_Date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_End_Date.Location = new System.Drawing.Point(223, 104);
            this.dtp_End_Date.Name = "dtp_End_Date";
            this.dtp_End_Date.Size = new System.Drawing.Size(161, 23);
            this.dtp_End_Date.TabIndex = 1;
            // 
            // cmb_Venue_Or_Equipment
            // 
            this.cmb_Venue_Or_Equipment.BackColor = System.Drawing.SystemColors.Control;
            this.cmb_Venue_Or_Equipment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Venue_Or_Equipment.FormattingEnabled = true;
            this.cmb_Venue_Or_Equipment.Items.AddRange(new object[] {
            "ALL",
            "Venue",
            "Equipment"});
            this.cmb_Venue_Or_Equipment.Location = new System.Drawing.Point(223, 195);
            this.cmb_Venue_Or_Equipment.Name = "cmb_Venue_Or_Equipment";
            this.cmb_Venue_Or_Equipment.Size = new System.Drawing.Size(161, 24);
            this.cmb_Venue_Or_Equipment.TabIndex = 4;
            // 
            // cmb_Payment_Status
            // 
            this.cmb_Payment_Status.BackColor = System.Drawing.SystemColors.Control;
            this.cmb_Payment_Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Payment_Status.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmb_Payment_Status.FormattingEnabled = true;
            this.cmb_Payment_Status.Items.AddRange(new object[] {
            "ALL",
            "Confirmed",
            "Pending",
            "Cancelled"});
            this.cmb_Payment_Status.Location = new System.Drawing.Point(223, 164);
            this.cmb_Payment_Status.Name = "cmb_Payment_Status";
            this.cmb_Payment_Status.Size = new System.Drawing.Size(161, 24);
            this.cmb_Payment_Status.TabIndex = 7;
            // 
            // btn_Generate_Report
            // 
            this.btn_Generate_Report.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(166)))), ((int)(((byte)(167)))));
            this.btn_Generate_Report.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Generate_Report.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.btn_Generate_Report.Location = new System.Drawing.Point(145, 255);
            this.btn_Generate_Report.Name = "btn_Generate_Report";
            this.btn_Generate_Report.Size = new System.Drawing.Size(110, 50);
            this.btn_Generate_Report.TabIndex = 10;
            this.btn_Generate_Report.Text = "GENERATE";
            this.btn_Generate_Report.UseVisualStyleBackColor = false;
            this.btn_Generate_Report.Click += new System.EventHandler(this.btn_Generate_Report_Click);
            // 
            // cmb_Choose_Report
            // 
            this.cmb_Choose_Report.BackColor = System.Drawing.SystemColors.Control;
            this.cmb_Choose_Report.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Choose_Report.FormattingEnabled = true;
            this.cmb_Choose_Report.Items.AddRange(new object[] {
            "Revenue Report"});
            this.cmb_Choose_Report.Location = new System.Drawing.Point(223, 134);
            this.cmb_Choose_Report.Name = "cmb_Choose_Report";
            this.cmb_Choose_Report.Size = new System.Drawing.Size(161, 24);
            this.cmb_Choose_Report.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.btn_Cancel);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmb_Choose_Report);
            this.panel1.Controls.Add(this.dtp_Start_Date);
            this.panel1.Controls.Add(this.dtp_End_Date);
            this.panel1.Controls.Add(this.btn_Generate_Report);
            this.panel1.Controls.Add(this.cmb_Venue_Or_Equipment);
            this.panel1.Controls.Add(this.cmb_Payment_Status);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(409, 329);
            this.panel1.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(88, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "START DATE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(105, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "END DATE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(77, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "REPORT TYPE";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(50, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "PAYMENT STATUS";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(37, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "RESERVATION TYPE\r\n";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(166)))), ((int)(((byte)(167)))));
            this.btn_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.btn_Cancel.Location = new System.Drawing.Point(274, 255);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(110, 50);
            this.btn_Cancel.TabIndex = 18;
            this.btn_Cancel.Text = "CANCEL";
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(35, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(289, 25);
            this.label6.TabIndex = 19;
            this.label6.Text = "GENERATE REPORT FORM";
            // 
            // frm_Report_Billing_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(203)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(409, 329);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Report_Billing_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GENERATE REPORT FORM";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtp_Start_Date;
        private System.Windows.Forms.DateTimePicker dtp_End_Date;
        private System.Windows.Forms.ComboBox cmb_Venue_Or_Equipment;
        private System.Windows.Forms.ComboBox cmb_Payment_Status;
        private System.Windows.Forms.Button btn_Generate_Report;
        private System.Windows.Forms.ComboBox cmb_Choose_Report;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label label6;
    }
}