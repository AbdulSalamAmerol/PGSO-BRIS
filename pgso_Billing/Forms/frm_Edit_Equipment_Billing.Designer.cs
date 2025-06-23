namespace pgso.pgso_Billing.Forms
{
    partial class frm_Edit_Equipment_Billing
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.dgv_Equipment_Inventory = new System.Windows.Forms.DataGridView();
            this.tblEquipmentBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this._BRIS_EXPERIMENT_3_0DataSet1 = new pgso._BRIS_EXPERIMENT_3_0DataSet1();
            this.dtp_End_Date_Eq = new System.Windows.Forms.DateTimePicker();
            this.dtp_Start_Date_Eq = new System.Windows.Forms.DateTimePicker();
            this.lbl_Subsequent_Price = new System.Windows.Forms.TextBox();
            this.lbl_Standard_Price = new System.Windows.Forms.TextBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.num_Quantity = new System.Windows.Forms.NumericUpDown();
            this.cmb_Equipment = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbl_EquipmentTableAdapter1 = new pgso._BRIS_EXPERIMENT_3_0DataSet1TableAdapters.tbl_EquipmentTableAdapter();
            this.tbl_EquipmentTableAdapter = new pgso._BRIS_EXPERIMENT_3_0DataSetTableAdapters.tbl_EquipmentTableAdapter();
            this.tblEquipmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._BRIS_EXPERIMENT_3_0DataSet = new pgso._BRIS_EXPERIMENT_3_0DataSet();
            this.billingDataSet = new pgso.BillingDataSet();
            this.billingDataTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fldRemainingStockDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fldTotalStockDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pkEquipmentIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fldEquipmentNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Equipment_Inventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblEquipmentBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._BRIS_EXPERIMENT_3_0DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Quantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblEquipmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._BRIS_EXPERIMENT_3_0DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.billingDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.billingDataTableBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn_Cancel);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.dgv_Equipment_Inventory);
            this.panel1.Controls.Add(this.dtp_End_Date_Eq);
            this.panel1.Controls.Add(this.dtp_Start_Date_Eq);
            this.panel1.Controls.Add(this.lbl_Subsequent_Price);
            this.panel1.Controls.Add(this.lbl_Standard_Price);
            this.panel1.Controls.Add(this.btn_Save);
            this.panel1.Controls.Add(this.num_Quantity);
            this.panel1.Controls.Add(this.cmb_Equipment);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(584, 604);
            this.panel1.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(203)))), ((int)(((byte)(208)))));
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(25, 179);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(269, 25);
            this.label8.TabIndex = 92;
            this.label8.Text = "EQUIPMENT INVENTORY";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(203)))), ((int)(((byte)(208)))));
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(294, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 32);
            this.label6.TabIndex = 90;
            this.label6.Text = "SUBSEQUENT\r\nDAYS RATE\r\n";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(203)))), ((int)(((byte)(208)))));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(294, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 16);
            this.label5.TabIndex = 89;
            this.label5.Text = "QUANTITY";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(203)))), ((int)(((byte)(208)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(294, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 16);
            this.label4.TabIndex = 88;
            this.label4.Text = "END DATE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(203)))), ((int)(((byte)(208)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 17);
            this.label3.TabIndex = 87;
            this.label3.Text = "RATE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(203)))), ((int)(((byte)(208)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 17);
            this.label2.TabIndex = 86;
            this.label2.Text = "EQUIPMENT";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(203)))), ((int)(((byte)(208)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 16);
            this.label1.TabIndex = 85;
            this.label1.Text = "START DATE";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(166)))), ((int)(((byte)(167)))));
            this.btn_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.btn_Cancel.Location = new System.Drawing.Point(440, 540);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(110, 50);
            this.btn_Cancel.TabIndex = 84;
            this.btn_Cancel.Text = "CANCEL";
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(203)))), ((int)(((byte)(208)))));
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(25, 7);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.label7.Size = new System.Drawing.Size(421, 40);
            this.label7.TabIndex = 91;
            this.label7.Text = "EDIT EQUIPMENT RESERVATION FORM";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgv_Equipment_Inventory
            // 
            this.dgv_Equipment_Inventory.AllowUserToAddRows = false;
            this.dgv_Equipment_Inventory.AllowUserToDeleteRows = false;
            this.dgv_Equipment_Inventory.AllowUserToResizeColumns = false;
            this.dgv_Equipment_Inventory.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(203)))), ((int)(((byte)(208)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(106)))), ((int)(((byte)(113)))));
            this.dgv_Equipment_Inventory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Equipment_Inventory.AutoGenerateColumns = false;
            this.dgv_Equipment_Inventory.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.dgv_Equipment_Inventory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_Equipment_Inventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Equipment_Inventory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fldEquipmentNameDataGridViewTextBoxColumn,
            this.pkEquipmentIDDataGridViewTextBoxColumn,
            this.fldTotalStockDataGridViewTextBoxColumn,
            this.fldRemainingStockDataGridViewTextBoxColumn});
            this.dgv_Equipment_Inventory.DataSource = this.tblEquipmentBindingSource1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(203)))), ((int)(((byte)(208)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(106)))), ((int)(((byte)(113)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Equipment_Inventory.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Equipment_Inventory.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(106)))), ((int)(((byte)(113)))));
            this.dgv_Equipment_Inventory.Location = new System.Drawing.Point(30, 207);
            this.dgv_Equipment_Inventory.MultiSelect = false;
            this.dgv_Equipment_Inventory.Name = "dgv_Equipment_Inventory";
            this.dgv_Equipment_Inventory.ReadOnly = true;
            this.dgv_Equipment_Inventory.RowHeadersVisible = false;
            this.dgv_Equipment_Inventory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Equipment_Inventory.Size = new System.Drawing.Size(520, 321);
            this.dgv_Equipment_Inventory.StandardTab = true;
            this.dgv_Equipment_Inventory.TabIndex = 83;
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
            // dtp_End_Date_Eq
            // 
            this.dtp_End_Date_Eq.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.dtp_End_Date_Eq.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dtp_End_Date_Eq.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.dtp_End_Date_Eq.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_End_Date_Eq.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_End_Date_Eq.Location = new System.Drawing.Point(399, 58);
            this.dtp_End_Date_Eq.Name = "dtp_End_Date_Eq";
            this.dtp_End_Date_Eq.Size = new System.Drawing.Size(150, 23);
            this.dtp_End_Date_Eq.TabIndex = 82;
            // 
            // dtp_Start_Date_Eq
            // 
            this.dtp_Start_Date_Eq.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.dtp_Start_Date_Eq.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dtp_Start_Date_Eq.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.dtp_Start_Date_Eq.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.dtp_Start_Date_Eq.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_Start_Date_Eq.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_Start_Date_Eq.Location = new System.Drawing.Point(130, 60);
            this.dtp_Start_Date_Eq.MaximumSize = new System.Drawing.Size(183, 20);
            this.dtp_Start_Date_Eq.Name = "dtp_Start_Date_Eq";
            this.dtp_Start_Date_Eq.Size = new System.Drawing.Size(150, 20);
            this.dtp_Start_Date_Eq.TabIndex = 81;
            // 
            // lbl_Subsequent_Price
            // 
            this.lbl_Subsequent_Price.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_Subsequent_Price.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Subsequent_Price.Location = new System.Drawing.Point(399, 128);
            this.lbl_Subsequent_Price.Name = "lbl_Subsequent_Price";
            this.lbl_Subsequent_Price.Size = new System.Drawing.Size(150, 23);
            this.lbl_Subsequent_Price.TabIndex = 80;
            // 
            // lbl_Standard_Price
            // 
            this.lbl_Standard_Price.BackColor = System.Drawing.SystemColors.Window;
            this.lbl_Standard_Price.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Standard_Price.Location = new System.Drawing.Point(130, 127);
            this.lbl_Standard_Price.Name = "lbl_Standard_Price";
            this.lbl_Standard_Price.Size = new System.Drawing.Size(150, 23);
            this.lbl_Standard_Price.TabIndex = 79;
            // 
            // btn_Save
            // 
            this.btn_Save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(166)))), ((int)(((byte)(167)))));
            this.btn_Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.btn_Save.Location = new System.Drawing.Point(296, 540);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(110, 50);
            this.btn_Save.TabIndex = 78;
            this.btn_Save.Text = "SAVE";
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // num_Quantity
            // 
            this.num_Quantity.BackColor = System.Drawing.SystemColors.Window;
            this.num_Quantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_Quantity.Location = new System.Drawing.Point(399, 94);
            this.num_Quantity.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.num_Quantity.Name = "num_Quantity";
            this.num_Quantity.Size = new System.Drawing.Size(150, 23);
            this.num_Quantity.TabIndex = 77;
            this.num_Quantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmb_Equipment
            // 
            this.cmb_Equipment.BackColor = System.Drawing.SystemColors.Window;
            this.cmb_Equipment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Equipment.FormattingEnabled = true;
            this.cmb_Equipment.Location = new System.Drawing.Point(130, 92);
            this.cmb_Equipment.Name = "cmb_Equipment";
            this.cmb_Equipment.Size = new System.Drawing.Size(150, 24);
            this.cmb_Equipment.TabIndex = 76;
            this.cmb_Equipment.SelectedIndexChanged += new System.EventHandler(this.cmb_Equipment_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(203)))), ((int)(((byte)(208)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(584, 604);
            this.panel2.TabIndex = 93;
            // 
            // tbl_EquipmentTableAdapter1
            // 
            this.tbl_EquipmentTableAdapter1.ClearBeforeFill = true;
            // 
            // tbl_EquipmentTableAdapter
            // 
            this.tbl_EquipmentTableAdapter.ClearBeforeFill = true;
            // 
            // tblEquipmentBindingSource
            // 
            this.tblEquipmentBindingSource.DataMember = "tbl_Equipment";
            this.tblEquipmentBindingSource.DataSource = this._BRIS_EXPERIMENT_3_0DataSet;
            // 
            // _BRIS_EXPERIMENT_3_0DataSet
            // 
            this._BRIS_EXPERIMENT_3_0DataSet.DataSetName = "_BRIS_EXPERIMENT_3_0DataSet";
            this._BRIS_EXPERIMENT_3_0DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // billingDataSet
            // 
            this.billingDataSet.DataSetName = "BillingDataSet";
            this.billingDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // billingDataTableBindingSource
            // 
            this.billingDataTableBindingSource.DataMember = "BillingDataTable";
            this.billingDataTableBindingSource.DataSource = this.billingDataSet;
            // 
            // fldRemainingStockDataGridViewTextBoxColumn
            // 
            this.fldRemainingStockDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.fldRemainingStockDataGridViewTextBoxColumn.DataPropertyName = "fld_Remaining_Stock";
            this.fldRemainingStockDataGridViewTextBoxColumn.HeaderText = "REMAINING EQUIPMENTS";
            this.fldRemainingStockDataGridViewTextBoxColumn.Name = "fldRemainingStockDataGridViewTextBoxColumn";
            this.fldRemainingStockDataGridViewTextBoxColumn.ReadOnly = true;
            this.fldRemainingStockDataGridViewTextBoxColumn.Width = 152;
            // 
            // fldTotalStockDataGridViewTextBoxColumn
            // 
            this.fldTotalStockDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.fldTotalStockDataGridViewTextBoxColumn.DataPropertyName = "fld_Total_Stock";
            this.fldTotalStockDataGridViewTextBoxColumn.HeaderText = "TOTAL EQUIPMENTS";
            this.fldTotalStockDataGridViewTextBoxColumn.Name = "fldTotalStockDataGridViewTextBoxColumn";
            this.fldTotalStockDataGridViewTextBoxColumn.ReadOnly = true;
            this.fldTotalStockDataGridViewTextBoxColumn.Width = 129;
            // 
            // pkEquipmentIDDataGridViewTextBoxColumn
            // 
            this.pkEquipmentIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.pkEquipmentIDDataGridViewTextBoxColumn.DataPropertyName = "pk_EquipmentID";
            this.pkEquipmentIDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.pkEquipmentIDDataGridViewTextBoxColumn.Name = "pkEquipmentIDDataGridViewTextBoxColumn";
            this.pkEquipmentIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.pkEquipmentIDDataGridViewTextBoxColumn.Visible = false;
            this.pkEquipmentIDDataGridViewTextBoxColumn.Width = 43;
            // 
            // fldEquipmentNameDataGridViewTextBoxColumn
            // 
            this.fldEquipmentNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fldEquipmentNameDataGridViewTextBoxColumn.DataPropertyName = "fld_Equipment_Name";
            this.fldEquipmentNameDataGridViewTextBoxColumn.HeaderText = "EQUIPMENT LIST";
            this.fldEquipmentNameDataGridViewTextBoxColumn.Name = "fldEquipmentNameDataGridViewTextBoxColumn";
            this.fldEquipmentNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // frm_Edit_Equipment_Billing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 604);
            this.Controls.Add(this.panel1);
            this.Name = "frm_Edit_Equipment_Billing";
            this.Text = "frm_Edit_Equipment_Billing";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Equipment_Inventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblEquipmentBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._BRIS_EXPERIMENT_3_0DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Quantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblEquipmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._BRIS_EXPERIMENT_3_0DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.billingDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.billingDataTableBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgv_Equipment_Inventory;
        private System.Windows.Forms.BindingSource tblEquipmentBindingSource1;
        private _BRIS_EXPERIMENT_3_0DataSet1 _BRIS_EXPERIMENT_3_0DataSet1;
        private System.Windows.Forms.DateTimePicker dtp_End_Date_Eq;
        private System.Windows.Forms.DateTimePicker dtp_Start_Date_Eq;
        private System.Windows.Forms.TextBox lbl_Subsequent_Price;
        private System.Windows.Forms.TextBox lbl_Standard_Price;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.NumericUpDown num_Quantity;
        private System.Windows.Forms.ComboBox cmb_Equipment;
        private System.Windows.Forms.Panel panel2;
        private _BRIS_EXPERIMENT_3_0DataSet1TableAdapters.tbl_EquipmentTableAdapter tbl_EquipmentTableAdapter1;
        private _BRIS_EXPERIMENT_3_0DataSetTableAdapters.tbl_EquipmentTableAdapter tbl_EquipmentTableAdapter;
        private System.Windows.Forms.BindingSource tblEquipmentBindingSource;
        private _BRIS_EXPERIMENT_3_0DataSet _BRIS_EXPERIMENT_3_0DataSet;
        private BillingDataSet billingDataSet;
        private System.Windows.Forms.BindingSource billingDataTableBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn fldEquipmentNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pkEquipmentIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fldTotalStockDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fldRemainingStockDataGridViewTextBoxColumn;
    }
}