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
            this.cmb_Equipment.FormattingEnabled = true;
            this.cmb_Equipment.Location = new System.Drawing.Point(128, 64);
            this.cmb_Equipment.Name = "cmb_Equipment";
            this.cmb_Equipment.Size = new System.Drawing.Size(199, 21);
            this.cmb_Equipment.TabIndex = 0;
            this.cmb_Equipment.SelectedIndexChanged += new System.EventHandler(this.cmb_Equipment_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 64);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "Equipment";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(13, 145);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 3;
            this.textBox3.Text = "Quantity";
            // 
            // num_Quantity
            // 
            this.num_Quantity.Location = new System.Drawing.Point(129, 145);
            this.num_Quantity.Name = "num_Quantity";
            this.num_Quantity.Size = new System.Drawing.Size(199, 20);
            this.num_Quantity.TabIndex = 8;
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(348, 12);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(190, 153);
            this.btn_Save.TabIndex = 10;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // lbl_Standard_Price
            // 
            this.lbl_Standard_Price.Location = new System.Drawing.Point(129, 93);
            this.lbl_Standard_Price.Name = "lbl_Standard_Price";
            this.lbl_Standard_Price.Size = new System.Drawing.Size(198, 20);
            this.lbl_Standard_Price.TabIndex = 11;
            // 
            // lbl_Subsequent_Price
            // 
            this.lbl_Subsequent_Price.Location = new System.Drawing.Point(129, 120);
            this.lbl_Subsequent_Price.Name = "lbl_Subsequent_Price";
            this.lbl_Subsequent_Price.Size = new System.Drawing.Size(200, 20);
            this.lbl_Subsequent_Price.TabIndex = 12;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 38);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 13;
            this.textBox2.Text = "End Date";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(12, 12);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 20);
            this.textBox5.TabIndex = 14;
            this.textBox5.Text = "Start Date";
            // 
            // dtp_Start_Date_Eq
            // 
            this.dtp_Start_Date_Eq.Location = new System.Drawing.Point(128, 12);
            this.dtp_Start_Date_Eq.Name = "dtp_Start_Date_Eq";
            this.dtp_Start_Date_Eq.Size = new System.Drawing.Size(200, 20);
            this.dtp_Start_Date_Eq.TabIndex = 15;
            // 
            // dtp_End_Date_Eq
            // 
            this.dtp_End_Date_Eq.Location = new System.Drawing.Point(128, 38);
            this.dtp_End_Date_Eq.Name = "dtp_End_Date_Eq";
            this.dtp_End_Date_Eq.Size = new System.Drawing.Size(200, 20);
            this.dtp_End_Date_Eq.TabIndex = 16;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pkEquipmentIDDataGridViewTextBoxColumn,
            this.fldEquipmentNameDataGridViewTextBoxColumn,
            this.fldTotalStockDataGridViewTextBoxColumn,
            this.fldRemainingStockDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.tblEquipmentBindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(12, 171);
            this.dataGridView1.MaximumSize = new System.Drawing.Size(526, 326);
            this.dataGridView1.MinimumSize = new System.Drawing.Size(526, 326);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(526, 326);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 17;
            // 
            // pkEquipmentIDDataGridViewTextBoxColumn
            // 
            this.pkEquipmentIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.pkEquipmentIDDataGridViewTextBoxColumn.DataPropertyName = "pk_EquipmentID";
            this.pkEquipmentIDDataGridViewTextBoxColumn.HeaderText = "pk_EquipmentID";
            this.pkEquipmentIDDataGridViewTextBoxColumn.Name = "pkEquipmentIDDataGridViewTextBoxColumn";
            this.pkEquipmentIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.pkEquipmentIDDataGridViewTextBoxColumn.Width = 111;
            // 
            // fldEquipmentNameDataGridViewTextBoxColumn
            // 
            this.fldEquipmentNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.fldEquipmentNameDataGridViewTextBoxColumn.DataPropertyName = "fld_Equipment_Name";
            this.fldEquipmentNameDataGridViewTextBoxColumn.HeaderText = "fld_Equipment_Name";
            this.fldEquipmentNameDataGridViewTextBoxColumn.Name = "fldEquipmentNameDataGridViewTextBoxColumn";
            this.fldEquipmentNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.fldEquipmentNameDataGridViewTextBoxColumn.Width = 133;
            // 
            // fldTotalStockDataGridViewTextBoxColumn
            // 
            this.fldTotalStockDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.fldTotalStockDataGridViewTextBoxColumn.DataPropertyName = "fld_Total_Stock";
            this.fldTotalStockDataGridViewTextBoxColumn.HeaderText = "fld_Total_Stock";
            this.fldTotalStockDataGridViewTextBoxColumn.Name = "fldTotalStockDataGridViewTextBoxColumn";
            this.fldTotalStockDataGridViewTextBoxColumn.ReadOnly = true;
            this.fldTotalStockDataGridViewTextBoxColumn.Width = 107;
            // 
            // fldRemainingStockDataGridViewTextBoxColumn
            // 
            this.fldRemainingStockDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.fldRemainingStockDataGridViewTextBoxColumn.DataPropertyName = "fld_Remaining_Stock";
            this.fldRemainingStockDataGridViewTextBoxColumn.HeaderText = "fld_Remaining_Stock";
            this.fldRemainingStockDataGridViewTextBoxColumn.Name = "fldRemainingStockDataGridViewTextBoxColumn";
            this.fldRemainingStockDataGridViewTextBoxColumn.ReadOnly = true;
            this.fldRemainingStockDataGridViewTextBoxColumn.Width = 133;
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
            this.textBox4.Location = new System.Drawing.Point(13, 93);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 18;
            this.textBox4.Text = "Price";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(12, 120);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 20);
            this.textBox6.TabIndex = 19;
            this.textBox6.Text = "Subsequent Price ";
            // 
            // frm_Add_Equipment_Billing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 501);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn pkEquipmentIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fldEquipmentNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fldTotalStockDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fldRemainingStockDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox6;
    }
}