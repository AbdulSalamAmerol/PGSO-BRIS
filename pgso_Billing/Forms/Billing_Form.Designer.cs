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
            this._BRIS_EXPERIMENT_3_0DataSet1 = new pgso._BRIS_EXPERIMENT_3_0DataSet();
            this.tlp_Venue_Billing_UControls = new System.Windows.Forms.TableLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.Equipment_Search_Bar = new System.Windows.Forms.TextBox();
            this.dgv_Equipment_Billing_Records = new System.Windows.Forms.DataGridView();
            this.fld_Control_Number_Equipment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Formatted_Total_Equipment_Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Equipment_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Full_Name_Equipment_Reservation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Venue_Search_Bar = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dgv_Venue_Billing_Records = new System.Windows.Forms.DataGridView();
            this.fld_Control_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Venue_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Full_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Start_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Amount_Due = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Payment_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this._BRIS_EXPERIMENT_3_0DataSet1)).BeginInit();
            this.tlp_Venue_Billing_UControls.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Equipment_Billing_Records)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Venue_Billing_Records)).BeginInit();
            this.SuspendLayout();
            // 
            // _BRIS_EXPERIMENT_3_0DataSet1
            // 
            this._BRIS_EXPERIMENT_3_0DataSet1.DataSetName = "_BRIS_EXPERIMENT_3_0DataSet";
            this._BRIS_EXPERIMENT_3_0DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tlp_Venue_Billing_UControls
            // 
            this.tlp_Venue_Billing_UControls.ColumnCount = 1;
            this.tlp_Venue_Billing_UControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Venue_Billing_UControls.Controls.Add(this.dgv_Equipment_Billing_Records, 0, 3);
            this.tlp_Venue_Billing_UControls.Controls.Add(this.panel4, 0, 0);
            this.tlp_Venue_Billing_UControls.Controls.Add(this.panel5, 0, 2);
            this.tlp_Venue_Billing_UControls.Controls.Add(this.dgv_Venue_Billing_Records, 0, 1);
            this.tlp_Venue_Billing_UControls.Location = new System.Drawing.Point(274, 60);
            this.tlp_Venue_Billing_UControls.Name = "tlp_Venue_Billing_UControls";
            this.tlp_Venue_Billing_UControls.RowCount = 4;
            this.tlp_Venue_Billing_UControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.5F));
            this.tlp_Venue_Billing_UControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.5F));
            this.tlp_Venue_Billing_UControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.5F));
            this.tlp_Venue_Billing_UControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.5F));
            this.tlp_Venue_Billing_UControls.Size = new System.Drawing.Size(742, 763);
            this.tlp_Venue_Billing_UControls.TabIndex = 4;
            this.tlp_Venue_Billing_UControls.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.Equipment_Search_Bar);
            this.panel5.Controls.Add(this.comboBox2);
            this.panel5.Location = new System.Drawing.Point(0, 380);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(742, 26);
            this.panel5.TabIndex = 3;
            this.panel5.Paint += new System.Windows.Forms.PaintEventHandler(this.panel5_Paint);
            // 
            // comboBox2
            // 
            this.comboBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(209, 3);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(200, 21);
            this.comboBox2.TabIndex = 0;
            // 
            // Equipment_Search_Bar
            // 
            this.Equipment_Search_Bar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Equipment_Search_Bar.BackColor = System.Drawing.SystemColors.HotTrack;
            this.Equipment_Search_Bar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Equipment_Search_Bar.Location = new System.Drawing.Point(3, 3);
            this.Equipment_Search_Bar.Name = "Equipment_Search_Bar";
            this.Equipment_Search_Bar.Size = new System.Drawing.Size(200, 20);
            this.Equipment_Search_Bar.TabIndex = 3;
            // 
            // dgv_Equipment_Billing_Records
            // 
            this.dgv_Equipment_Billing_Records.AllowUserToAddRows = false;
            this.dgv_Equipment_Billing_Records.AllowUserToDeleteRows = false;
            this.dgv_Equipment_Billing_Records.AllowUserToOrderColumns = true;
            this.dgv_Equipment_Billing_Records.AllowUserToResizeColumns = false;
            this.dgv_Equipment_Billing_Records.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgv_Equipment_Billing_Records.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Equipment_Billing_Records.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Equipment_Billing_Records.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Equipment_Billing_Records.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgv_Equipment_Billing_Records.ColumnHeadersHeight = 40;
            this.dgv_Equipment_Billing_Records.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_Equipment_Billing_Records.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fld_Control_Number_Equipment,
            this.fld_Formatted_Total_Equipment_Cost,
            this.fld_Equipment_Name,
            this.fld_Quantity,
            this.fld_Full_Name_Equipment_Reservation});
            this.dgv_Equipment_Billing_Records.Location = new System.Drawing.Point(3, 409);
            this.dgv_Equipment_Billing_Records.MultiSelect = false;
            this.dgv_Equipment_Billing_Records.Name = "dgv_Equipment_Billing_Records";
            this.dgv_Equipment_Billing_Records.Size = new System.Drawing.Size(736, 351);
            this.dgv_Equipment_Billing_Records.TabIndex = 2;
            // 
            // fld_Control_Number_Equipment
            // 
            this.fld_Control_Number_Equipment.DataPropertyName = "fld_Control_Number";
            this.fld_Control_Number_Equipment.HeaderText = "CONTROL NUMBER";
            this.fld_Control_Number_Equipment.Name = "fld_Control_Number_Equipment";
            this.fld_Control_Number_Equipment.ReadOnly = true;
            // 
            // fld_Formatted_Total_Equipment_Cost
            // 
            this.fld_Formatted_Total_Equipment_Cost.DataPropertyName = "Formatted_Total_Equipment_Cost";
            this.fld_Formatted_Total_Equipment_Cost.HeaderText = "TOTAL";
            this.fld_Formatted_Total_Equipment_Cost.Name = "fld_Formatted_Total_Equipment_Cost";
            this.fld_Formatted_Total_Equipment_Cost.ReadOnly = true;
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
            // panel4
            // 
            this.panel4.Controls.Add(this.Venue_Search_Bar);
            this.panel4.Controls.Add(this.comboBox1);
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(742, 26);
            this.panel4.TabIndex = 2;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // Venue_Search_Bar
            // 
            this.Venue_Search_Bar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Venue_Search_Bar.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Venue_Search_Bar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Venue_Search_Bar.Location = new System.Drawing.Point(3, 2);
            this.Venue_Search_Bar.Name = "Venue_Search_Bar";
            this.Venue_Search_Bar.Size = new System.Drawing.Size(200, 20);
            this.Venue_Search_Bar.TabIndex = 1;
            this.Venue_Search_Bar.TextChanged += new System.EventHandler(this.Venue_Search_Bar_TextChanged_1);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(209, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(200, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // dgv_Venue_Billing_Records
            // 
            this.dgv_Venue_Billing_Records.AllowUserToAddRows = false;
            this.dgv_Venue_Billing_Records.AllowUserToDeleteRows = false;
            this.dgv_Venue_Billing_Records.AllowUserToOrderColumns = true;
            this.dgv_Venue_Billing_Records.AllowUserToResizeColumns = false;
            this.dgv_Venue_Billing_Records.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgv_Venue_Billing_Records.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Venue_Billing_Records.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Venue_Billing_Records.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Venue_Billing_Records.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgv_Venue_Billing_Records.ColumnHeadersHeight = 40;
            this.dgv_Venue_Billing_Records.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_Venue_Billing_Records.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fld_Control_Number,
            this.fld_Venue_Name,
            this.fld_Full_Name,
            this.fld_Start_Date,
            this.fld_Amount_Due,
            this.fld_Payment_Status});
            this.dgv_Venue_Billing_Records.Location = new System.Drawing.Point(3, 29);
            this.dgv_Venue_Billing_Records.MultiSelect = false;
            this.dgv_Venue_Billing_Records.Name = "dgv_Venue_Billing_Records";
            this.dgv_Venue_Billing_Records.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Venue_Billing_Records.Size = new System.Drawing.Size(736, 348);
            this.dgv_Venue_Billing_Records.TabIndex = 0;
            this.dgv_Venue_Billing_Records.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Venue_Billing_Records_CellContentClick);
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
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(34, 89);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.flowLayoutPanel1.TabIndex = 5;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint_1);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Location = new System.Drawing.Point(34, 218);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(200, 100);
            this.flowLayoutPanel2.TabIndex = 6;
            this.flowLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel2_Paint);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Location = new System.Drawing.Point(34, 337);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(200, 100);
            this.flowLayoutPanel3.TabIndex = 7;
            this.flowLayoutPanel3.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel3_Paint);
            // 
            // Billing_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1296, 904);
            this.Controls.Add(this.flowLayoutPanel3);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.tlp_Venue_Billing_UControls);
            this.Name = "Billing_Form";
            this.Text = "Billing_Form";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Billing_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this._BRIS_EXPERIMENT_3_0DataSet1)).EndInit();
            this.tlp_Venue_Billing_UControls.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Equipment_Billing_Records)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Venue_Billing_Records)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private _BRIS_EXPERIMENT_3_0DataSet _BRIS_EXPERIMENT_3_0DataSet1;
        private System.Windows.Forms.TableLayoutPanel tlp_Venue_Billing_UControls;
        private System.Windows.Forms.TextBox Venue_Search_Bar;
        private System.Windows.Forms.DataGridView dgv_Equipment_Billing_Records;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Control_Number_Equipment;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Formatted_Total_Equipment_Cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Equipment_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Full_Name_Equipment_Reservation;
        private System.Windows.Forms.TextBox Equipment_Search_Bar;
        private System.Windows.Forms.DataGridView dgv_Venue_Billing_Records;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Control_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Venue_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Full_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Start_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Amount_Due;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Payment_Status;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
    }
}