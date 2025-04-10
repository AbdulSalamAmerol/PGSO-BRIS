﻿namespace pgso
{
    partial class frm_Equipment_Cancelled
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dt_cancelled = new System.Windows.Forms.DataGridView();
            this.fld_Control_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_First_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Surname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Contact_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Activity_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Requesting_Person_Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Start_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Number_Of_Days = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Equipment_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Reservation_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Total_Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt_cancelled)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dt_cancelled);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(2, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1151, 524);
            this.panel2.TabIndex = 6;
            // 
            // dt_cancelled
            // 
            this.dt_cancelled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dt_cancelled.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dt_cancelled.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dt_cancelled.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt_cancelled.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fld_Control_Number,
            this.fld_First_Name,
            this.fld_Surname,
            this.fld_Contact_Number,
            this.fld_Activity_Name,
            this.fld_Requesting_Person_Address,
            this.fld_Start_Date,
            this.fld_Number_Of_Days,
            this.fld_Quantity,
            this.fld_Equipment_Name,
            this.fld_Reservation_Status,
            this.fld_Total_Amount});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dt_cancelled.DefaultCellStyle = dataGridViewCellStyle2;
            this.dt_cancelled.Location = new System.Drawing.Point(3, 23);
            this.dt_cancelled.Name = "dt_cancelled";
            this.dt_cancelled.ReadOnly = true;
            this.dt_cancelled.Size = new System.Drawing.Size(1145, 494);
            this.dt_cancelled.TabIndex = 1;
            // 
            // fld_Control_Number
            // 
            this.fld_Control_Number.DataPropertyName = "fld_Control_Number";
            this.fld_Control_Number.HeaderText = "Control Number";
            this.fld_Control_Number.Name = "fld_Control_Number";
            this.fld_Control_Number.ReadOnly = true;
            // 
            // fld_First_Name
            // 
            this.fld_First_Name.DataPropertyName = "fld_First_Name";
            this.fld_First_Name.HeaderText = "First Name";
            this.fld_First_Name.Name = "fld_First_Name";
            this.fld_First_Name.ReadOnly = true;
            // 
            // fld_Surname
            // 
            this.fld_Surname.DataPropertyName = "fld_Surname";
            this.fld_Surname.HeaderText = "Surname";
            this.fld_Surname.Name = "fld_Surname";
            this.fld_Surname.ReadOnly = true;
            // 
            // fld_Contact_Number
            // 
            this.fld_Contact_Number.DataPropertyName = "fld_Contact_Number";
            this.fld_Contact_Number.HeaderText = "Contact";
            this.fld_Contact_Number.Name = "fld_Contact_Number";
            this.fld_Contact_Number.ReadOnly = true;
            // 
            // fld_Activity_Name
            // 
            this.fld_Activity_Name.DataPropertyName = "fld_Activity_Name";
            this.fld_Activity_Name.HeaderText = "Activity";
            this.fld_Activity_Name.Name = "fld_Activity_Name";
            this.fld_Activity_Name.ReadOnly = true;
            // 
            // fld_Requesting_Person_Address
            // 
            this.fld_Requesting_Person_Address.DataPropertyName = "fld_Requesting_Person_Address";
            this.fld_Requesting_Person_Address.HeaderText = "Address";
            this.fld_Requesting_Person_Address.Name = "fld_Requesting_Person_Address";
            this.fld_Requesting_Person_Address.ReadOnly = true;
            // 
            // fld_Start_Date
            // 
            this.fld_Start_Date.DataPropertyName = "fld_Start_Date";
            this.fld_Start_Date.HeaderText = "Date";
            this.fld_Start_Date.Name = "fld_Start_Date";
            this.fld_Start_Date.ReadOnly = true;
            // 
            // fld_Number_Of_Days
            // 
            this.fld_Number_Of_Days.DataPropertyName = "fld_Number_Of_Days";
            this.fld_Number_Of_Days.HeaderText = "Days";
            this.fld_Number_Of_Days.Name = "fld_Number_Of_Days";
            this.fld_Number_Of_Days.ReadOnly = true;
            // 
            // fld_Quantity
            // 
            this.fld_Quantity.DataPropertyName = "fld_Quantity";
            this.fld_Quantity.HeaderText = "Quantity";
            this.fld_Quantity.Name = "fld_Quantity";
            this.fld_Quantity.ReadOnly = true;
            // 
            // fld_Equipment_Name
            // 
            this.fld_Equipment_Name.DataPropertyName = "fld_Equipment_Name";
            this.fld_Equipment_Name.HeaderText = "Equipment";
            this.fld_Equipment_Name.Name = "fld_Equipment_Name";
            this.fld_Equipment_Name.ReadOnly = true;
            // 
            // fld_Reservation_Status
            // 
            this.fld_Reservation_Status.DataPropertyName = "fld_Reservation_Status";
            this.fld_Reservation_Status.HeaderText = "Status";
            this.fld_Reservation_Status.Name = "fld_Reservation_Status";
            this.fld_Reservation_Status.ReadOnly = true;
            // 
            // fld_Total_Amount
            // 
            this.fld_Total_Amount.DataPropertyName = "fld_Total_Amount";
            this.fld_Total_Amount.HeaderText = "Total";
            this.fld_Total_Amount.Name = "fld_Total_Amount";
            this.fld_Total_Amount.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cancelled";
            // 
            // frm_Equipment_Cancelled
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1156, 638);
            this.Controls.Add(this.panel2);
            this.Name = "frm_Equipment_Cancelled";
            this.Text = "frm_Equipment_Cancelled";
            this.Load += new System.EventHandler(this.frm_Equipment_Cancelled_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt_cancelled)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dt_cancelled;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Control_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_First_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Surname;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Contact_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Activity_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Requesting_Person_Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Start_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Number_Of_Days;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Equipment_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Reservation_Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Total_Amount;
        private System.Windows.Forms.Label label1;
    }
}