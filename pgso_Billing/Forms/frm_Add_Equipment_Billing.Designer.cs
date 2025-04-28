namespace pgso.pgso_Billing.Forms
{
    partial class frm_Add_Equipment_Billing
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Add_Equipment_Billing));
            this.cmb_Equipment = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.num_Quantity = new System.Windows.Forms.NumericUpDown();
            this.btn_Save = new System.Windows.Forms.Button();
            this.lbl_Standard_Price = new System.Windows.Forms.TextBox();
            this.lbl_Subsequent_Price = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.dtp_Start_Date_Eq = new System.Windows.Forms.DateTimePicker();
            this.dtp_End_Date_Eq = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pkEquipmentIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fldEquipmentNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fldTotalStockDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fldRemainingStockDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblEquipmentBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this._BRIS_EXPERIMENT_3_0DataSet1 = new pgso._BRIS_EXPERIMENT_3_0DataSet1();
            this._BRIS_EXPERIMENT_3_0DataSet = new pgso._BRIS_EXPERIMENT_3_0DataSet();
            this.tblEquipmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbl_EquipmentTableAdapter = new pgso._BRIS_EXPERIMENT_3_0DataSetTableAdapters.tbl_EquipmentTableAdapter();
            this.tbl_EquipmentTableAdapter1 = new pgso._BRIS_EXPERIMENT_3_0DataSet1TableAdapters.tbl_EquipmentTableAdapter();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.num_Quantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblEquipmentBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._BRIS_EXPERIMENT_3_0DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._BRIS_EXPERIMENT_3_0DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblEquipmentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cmb_Equipment
            // 
            this.cmb_Equipment.BackColor = System.Drawing.SystemColors.Window;
            this.cmb_Equipment.FormattingEnabled = true;
            this.cmb_Equipment.Location = new System.Drawing.Point(86, 132);
            this.cmb_Equipment.Name = "cmb_Equipment";
            this.cmb_Equipment.Size = new System.Drawing.Size(150, 21);
            this.cmb_Equipment.TabIndex = 0;
            this.cmb_Equipment.SelectedIndexChanged += new System.EventHandler(this.cmb_Equipment_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(203)))), ((int)(((byte)(208)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(0, 139);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(80, 13);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "EQUIPMENT";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(203)))), ((int)(((byte)(208)))));
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Location = new System.Drawing.Point(239, 139);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(70, 13);
            this.textBox3.TabIndex = 3;
            this.textBox3.Text = "QUANTITY";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // num_Quantity
            // 
            this.num_Quantity.BackColor = System.Drawing.SystemColors.Window;
            this.num_Quantity.Location = new System.Drawing.Point(315, 131);
            this.num_Quantity.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.num_Quantity.Name = "num_Quantity";
            this.num_Quantity.Size = new System.Drawing.Size(150, 20);
            this.num_Quantity.TabIndex = 8;
            this.num_Quantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(166)))), ((int)(((byte)(167)))));
            this.btn_Save.Location = new System.Drawing.Point(220, 531);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(116, 36);
            this.btn_Save.TabIndex = 10;
            this.btn_Save.Text = "SAVE";
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // lbl_Standard_Price
            // 
            this.lbl_Standard_Price.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_Standard_Price.Location = new System.Drawing.Point(315, 156);
            this.lbl_Standard_Price.Name = "lbl_Standard_Price";
            this.lbl_Standard_Price.Size = new System.Drawing.Size(150, 20);
            this.lbl_Standard_Price.TabIndex = 11;
            // 
            // lbl_Subsequent_Price
            // 
            this.lbl_Subsequent_Price.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_Subsequent_Price.Location = new System.Drawing.Point(86, 158);
            this.lbl_Subsequent_Price.Name = "lbl_Subsequent_Price";
            this.lbl_Subsequent_Price.Size = new System.Drawing.Size(150, 20);
            this.lbl_Subsequent_Price.TabIndex = 12;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(203)))), ((int)(((byte)(208)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(239, 113);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(70, 13);
            this.textBox2.TabIndex = 13;
            this.textBox2.Text = "END DATE";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(203)))), ((int)(((byte)(208)))));
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Location = new System.Drawing.Point(0, 113);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(80, 13);
            this.textBox5.TabIndex = 14;
            this.textBox5.Text = "START DATE";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dtp_Start_Date_Eq
            // 
            this.dtp_Start_Date_Eq.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.dtp_Start_Date_Eq.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dtp_Start_Date_Eq.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.dtp_Start_Date_Eq.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.dtp_Start_Date_Eq.Location = new System.Drawing.Point(86, 107);
            this.dtp_Start_Date_Eq.MaximumSize = new System.Drawing.Size(183, 20);
            this.dtp_Start_Date_Eq.Name = "dtp_Start_Date_Eq";
            this.dtp_Start_Date_Eq.Size = new System.Drawing.Size(150, 20);
            this.dtp_Start_Date_Eq.TabIndex = 15;
            // 
            // dtp_End_Date_Eq
            // 
            this.dtp_End_Date_Eq.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.dtp_End_Date_Eq.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dtp_End_Date_Eq.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.dtp_End_Date_Eq.Location = new System.Drawing.Point(315, 106);
            this.dtp_End_Date_Eq.Name = "dtp_End_Date_Eq";
            this.dtp_End_Date_Eq.Size = new System.Drawing.Size(150, 20);
            this.dtp_End_Date_Eq.TabIndex = 16;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(203)))), ((int)(((byte)(208)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(106)))), ((int)(((byte)(113)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pkEquipmentIDDataGridViewTextBoxColumn,
            this.fldEquipmentNameDataGridViewTextBoxColumn,
            this.fldTotalStockDataGridViewTextBoxColumn,
            this.fldRemainingStockDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.tblEquipmentBindingSource1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(203)))), ((int)(((byte)(208)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(106)))), ((int)(((byte)(113)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(106)))), ((int)(((byte)(113)))));
            this.dataGridView1.Location = new System.Drawing.Point(0, 199);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(474, 326);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 17;
            // 
            // pkEquipmentIDDataGridViewTextBoxColumn
            // 
            this.pkEquipmentIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.pkEquipmentIDDataGridViewTextBoxColumn.DataPropertyName = "pk_EquipmentID";
            this.pkEquipmentIDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.pkEquipmentIDDataGridViewTextBoxColumn.Name = "pkEquipmentIDDataGridViewTextBoxColumn";
            this.pkEquipmentIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.pkEquipmentIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // fldEquipmentNameDataGridViewTextBoxColumn
            // 
            this.fldEquipmentNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fldEquipmentNameDataGridViewTextBoxColumn.DataPropertyName = "fld_Equipment_Name";
            this.fldEquipmentNameDataGridViewTextBoxColumn.HeaderText = "EQUIPMENT";
            this.fldEquipmentNameDataGridViewTextBoxColumn.Name = "fldEquipmentNameDataGridViewTextBoxColumn";
            this.fldEquipmentNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fldTotalStockDataGridViewTextBoxColumn
            // 
            this.fldTotalStockDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.fldTotalStockDataGridViewTextBoxColumn.DataPropertyName = "fld_Total_Stock";
            this.fldTotalStockDataGridViewTextBoxColumn.HeaderText = "INVENTORY";
            this.fldTotalStockDataGridViewTextBoxColumn.Name = "fldTotalStockDataGridViewTextBoxColumn";
            this.fldTotalStockDataGridViewTextBoxColumn.ReadOnly = true;
            this.fldTotalStockDataGridViewTextBoxColumn.Width = 95;
            // 
            // fldRemainingStockDataGridViewTextBoxColumn
            // 
            this.fldRemainingStockDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.fldRemainingStockDataGridViewTextBoxColumn.DataPropertyName = "fld_Remaining_Stock";
            this.fldRemainingStockDataGridViewTextBoxColumn.HeaderText = "REMAINING";
            this.fldRemainingStockDataGridViewTextBoxColumn.Name = "fldRemainingStockDataGridViewTextBoxColumn";
            this.fldRemainingStockDataGridViewTextBoxColumn.ReadOnly = true;
            this.fldRemainingStockDataGridViewTextBoxColumn.Width = 93;
            // 
            // tblEquipmentBindingSource1
            // 
            this.tblEquipmentBindingSource1.DataMember = "tbl_Equipment";
            this.tblEquipmentBindingSource1.DataSource = this._BRIS_EXPERIMENT_3_0DataSet1;
            // 
            // _BRIS_EXPERIMENT_3_0DataSet1
            // 
            this._BRIS_EXPERIMENT_3_0DataSet1.DataSetName = "_BRIS_EXPERIMENT_3_0DataSet1";
            this._BRIS_EXPERIMENT_3_0DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // _BRIS_EXPERIMENT_3_0DataSet
            // 
            this._BRIS_EXPERIMENT_3_0DataSet.DataSetName = "_BRIS_EXPERIMENT_3_0DataSet";
            this._BRIS_EXPERIMENT_3_0DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblEquipmentBindingSource
            // 
            this.tblEquipmentBindingSource.DataMember = "tbl_Equipment";
            this.tblEquipmentBindingSource.DataSource = this._BRIS_EXPERIMENT_3_0DataSet;
            // 
            // tbl_EquipmentTableAdapter
            // 
            this.tbl_EquipmentTableAdapter.ClearBeforeFill = true;
            // 
            // tbl_EquipmentTableAdapter1
            // 
            this.tbl_EquipmentTableAdapter1.ClearBeforeFill = true;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(203)))), ((int)(((byte)(208)))));
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Location = new System.Drawing.Point(259, 161);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(50, 13);
            this.textBox4.TabIndex = 18;
            this.textBox4.Text = "RATE";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(203)))), ((int)(((byte)(208)))));
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox6.Location = new System.Drawing.Point(0, 161);
            this.textBox6.Multiline = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(80, 32);
            this.textBox6.TabIndex = 19;
            this.textBox6.Text = "SUBSEQUENT\r\nDAYS RATE";
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(474, 101);
            this.panel1.TabIndex = 65;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(166)))), ((int)(((byte)(167)))));
            this.btn_Cancel.Location = new System.Drawing.Point(356, 531);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(116, 36);
            this.btn_Cancel.TabIndex = 66;
            this.btn_Cancel.Text = "CANCEL";
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // frm_Add_Equipment_Billing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(203)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(474, 568);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dtp_End_Date_Eq);
            this.Controls.Add(this.dtp_Start_Date_Eq);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.lbl_Subsequent_Price);
            this.Controls.Add(this.lbl_Standard_Price);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.num_Quantity);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.cmb_Equipment);
            this.Name = "frm_Add_Equipment_Billing";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frm_Add_Equipment_Billing";
            this.Load += new System.EventHandler(this.frm_Add_Equipment_Billing_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.num_Quantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblEquipmentBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._BRIS_EXPERIMENT_3_0DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._BRIS_EXPERIMENT_3_0DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblEquipmentBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_Equipment;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.NumericUpDown num_Quantity;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.TextBox lbl_Standard_Price;
        private System.Windows.Forms.TextBox lbl_Subsequent_Price;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.DateTimePicker dtp_Start_Date_Eq;
        private System.Windows.Forms.DateTimePicker dtp_End_Date_Eq;
        private System.Windows.Forms.DataGridView dataGridView1;
        private _BRIS_EXPERIMENT_3_0DataSet _BRIS_EXPERIMENT_3_0DataSet;
        private System.Windows.Forms.BindingSource tblEquipmentBindingSource;
        private _BRIS_EXPERIMENT_3_0DataSetTableAdapters.tbl_EquipmentTableAdapter tbl_EquipmentTableAdapter;
        private _BRIS_EXPERIMENT_3_0DataSet1 _BRIS_EXPERIMENT_3_0DataSet1;
        private System.Windows.Forms.BindingSource tblEquipmentBindingSource1;
        private _BRIS_EXPERIMENT_3_0DataSet1TableAdapters.tbl_EquipmentTableAdapter tbl_EquipmentTableAdapter1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pkEquipmentIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fldEquipmentNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fldTotalStockDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fldRemainingStockDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btn_Cancel;
    }
}