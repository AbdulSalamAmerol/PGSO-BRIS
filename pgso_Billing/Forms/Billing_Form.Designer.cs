namespace pgso
{
    partial class Billing_Form
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
            this.dgv_Venue_Billing_Records = new System.Windows.Forms.DataGridView();
            this.fld_Control_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Venue_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Full_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Start_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Amount_Due = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Payment_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Venue_Search_Bar = new System.Windows.Forms.TextBox();
            this.dgv_Equipment_Billing_Records = new System.Windows.Forms.DataGridView();
            this._BRIS_EXPERIMENT_3_0DataSet1 = new pgso._BRIS_EXPERIMENT_3_0DataSet();
            this.Equipment_Search_Bar = new System.Windows.Forms.TextBox();
            this.fld_Control_Number_Equipment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Equipment_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Full_Name_Equipment_Reservation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Venue_Billing_Records)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Equipment_Billing_Records)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._BRIS_EXPERIMENT_3_0DataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Venue_Billing_Records
            // 
            this.dgv_Venue_Billing_Records.AllowUserToAddRows = false;
            this.dgv_Venue_Billing_Records.AllowUserToDeleteRows = false;
            this.dgv_Venue_Billing_Records.AllowUserToOrderColumns = true;
            this.dgv_Venue_Billing_Records.AllowUserToResizeColumns = false;
            this.dgv_Venue_Billing_Records.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgv_Venue_Billing_Records.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Venue_Billing_Records.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Venue_Billing_Records.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Venue_Billing_Records.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_Venue_Billing_Records.ColumnHeadersHeight = 40;
            this.dgv_Venue_Billing_Records.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_Venue_Billing_Records.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fld_Control_Number,
            this.fld_Venue_Name,
            this.fld_Full_Name,
            this.fld_Start_Date,
            this.fld_Amount_Due,
            this.fld_Payment_Status});
            this.dgv_Venue_Billing_Records.Location = new System.Drawing.Point(12, 161);
            this.dgv_Venue_Billing_Records.Name = "dgv_Venue_Billing_Records";
            this.dgv_Venue_Billing_Records.Size = new System.Drawing.Size(1064, 298);
            this.dgv_Venue_Billing_Records.TabIndex = 0;
            // 
            // fld_Control_Number
            // 
            this.fld_Control_Number.DataPropertyName = "fld_Control_Number";
            this.fld_Control_Number.HeaderText = "CONTROL NUMBER";
            this.fld_Control_Number.Name = "fld_Control_Number";
            this.fld_Control_Number.ReadOnly = true;
            // 
            // fld_Venue_Name
            // 
            this.fld_Venue_Name.DataPropertyName = "fld_Venue_Name";
            this.fld_Venue_Name.HeaderText = "VENUE";
            this.fld_Venue_Name.Name = "fld_Venue_Name";
            this.fld_Venue_Name.ReadOnly = true;
            // 
            // fld_Full_Name
            // 
            this.fld_Full_Name.DataPropertyName = "fld_Full_Name";
            this.fld_Full_Name.HeaderText = "REQUESTING PERSON";
            this.fld_Full_Name.Name = "fld_Full_Name";
            this.fld_Full_Name.ReadOnly = true;
            // 
            // fld_Start_Date
            // 
            this.fld_Start_Date.DataPropertyName = "Formatted_Start_Date";
            this.fld_Start_Date.HeaderText = "DATE";
            this.fld_Start_Date.Name = "fld_Start_Date";
            this.fld_Start_Date.ReadOnly = true;
            // 
            // fld_Amount_Due
            // 
            this.fld_Amount_Due.DataPropertyName = "Formatted_Amount_Due";
            this.fld_Amount_Due.HeaderText = "AMOUNT DUE";
            this.fld_Amount_Due.Name = "fld_Amount_Due";
            this.fld_Amount_Due.ReadOnly = true;
            // 
            // fld_Payment_Status
            // 
            this.fld_Payment_Status.DataPropertyName = "fld_Payment_Status";
            this.fld_Payment_Status.HeaderText = "STATUS";
            this.fld_Payment_Status.Name = "fld_Payment_Status";
            this.fld_Payment_Status.ReadOnly = true;
            // 
            // Venue_Search_Bar
            // 
            this.Venue_Search_Bar.Location = new System.Drawing.Point(12, 123);
            this.Venue_Search_Bar.Multiline = true;
            this.Venue_Search_Bar.Name = "Venue_Search_Bar";
            this.Venue_Search_Bar.Size = new System.Drawing.Size(204, 20);
            this.Venue_Search_Bar.TabIndex = 1;
            // 
            // dgv_Equipment_Billing_Records
            // 
            this.dgv_Equipment_Billing_Records.AllowUserToAddRows = false;
            this.dgv_Equipment_Billing_Records.AllowUserToDeleteRows = false;
            this.dgv_Equipment_Billing_Records.AllowUserToOrderColumns = true;
            this.dgv_Equipment_Billing_Records.AllowUserToResizeColumns = false;
            this.dgv_Equipment_Billing_Records.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgv_Equipment_Billing_Records.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Equipment_Billing_Records.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.dgv_Equipment_Billing_Records.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Equipment_Billing_Records.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_Equipment_Billing_Records.ColumnHeadersHeight = 40;
            this.dgv_Equipment_Billing_Records.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_Equipment_Billing_Records.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fld_Control_Number_Equipment,
            this.fld_Equipment_Name,
            this.fld_Quantity,
            this.fld_Full_Name_Equipment_Reservation});
            this.dgv_Equipment_Billing_Records.Location = new System.Drawing.Point(12, 502);
            this.dgv_Equipment_Billing_Records.Name = "dgv_Equipment_Billing_Records";
            this.dgv_Equipment_Billing_Records.Size = new System.Drawing.Size(1064, 287);
            this.dgv_Equipment_Billing_Records.TabIndex = 2;
            // 
            // _BRIS_EXPERIMENT_3_0DataSet1
            // 
            this._BRIS_EXPERIMENT_3_0DataSet1.DataSetName = "_BRIS_EXPERIMENT_3_0DataSet";
            this._BRIS_EXPERIMENT_3_0DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Equipment_Search_Bar
            // 
            this.Equipment_Search_Bar.Location = new System.Drawing.Point(12, 476);
            this.Equipment_Search_Bar.Multiline = true;
            this.Equipment_Search_Bar.Name = "Equipment_Search_Bar";
            this.Equipment_Search_Bar.Size = new System.Drawing.Size(204, 20);
            this.Equipment_Search_Bar.TabIndex = 3;
            // 
            // fld_Control_Number_Equipment
            // 
            this.fld_Control_Number_Equipment.DataPropertyName = "fld_Control_Number";
            this.fld_Control_Number_Equipment.HeaderText = "CONTROL NUMBER";
            this.fld_Control_Number_Equipment.Name = "fld_Control_Number_Equipment";
            this.fld_Control_Number_Equipment.ReadOnly = true;
            // 
            // fld_Equipment_Name
            // 
            this.fld_Equipment_Name.DataPropertyName = "fld_Equipment_Name";
            this.fld_Equipment_Name.HeaderText = "EQUIPMENT";
            this.fld_Equipment_Name.Name = "fld_Equipment_Name";
            this.fld_Equipment_Name.ReadOnly = true;
            // 
            // fld_Quantity
            // 
            this.fld_Quantity.DataPropertyName = "fld_Quantity";
            this.fld_Quantity.HeaderText = "QUANTITY";
            this.fld_Quantity.Name = "fld_Quantity";
            this.fld_Quantity.ReadOnly = true;
            // 
            // fld_Full_Name_Equipment_Reservation
            // 
            this.fld_Full_Name_Equipment_Reservation.DataPropertyName = "fld_Full_Name";
            this.fld_Full_Name_Equipment_Reservation.HeaderText = "REQUESTING PERSON";
            this.fld_Full_Name_Equipment_Reservation.Name = "fld_Full_Name_Equipment_Reservation";
            this.fld_Full_Name_Equipment_Reservation.ReadOnly = true;
            // 
            // Billing_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 801);
            this.Controls.Add(this.Equipment_Search_Bar);
            this.Controls.Add(this.dgv_Equipment_Billing_Records);
            this.Controls.Add(this.Venue_Search_Bar);
            this.Controls.Add(this.dgv_Venue_Billing_Records);
            this.Name = "Billing_Form";
            this.Text = "Billing_Form";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Billing_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Venue_Billing_Records)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Equipment_Billing_Records)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._BRIS_EXPERIMENT_3_0DataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Venue_Billing_Records;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Control_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Venue_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Full_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Start_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Amount_Due;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Payment_Status;
        private System.Windows.Forms.TextBox Venue_Search_Bar;
        private System.Windows.Forms.DataGridView dgv_Equipment_Billing_Records;
        private _BRIS_EXPERIMENT_3_0DataSet _BRIS_EXPERIMENT_3_0DataSet1;
        private System.Windows.Forms.TextBox Equipment_Search_Bar;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Control_Number_Equipment;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Equipment_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Full_Name_Equipment_Reservation;
    }
}