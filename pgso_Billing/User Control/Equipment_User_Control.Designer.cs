namespace pgso.pgso_Billing.User_Control
{
    partial class Equipment_User_Control
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this._BRIS_EXPERIMENT_3_0DataSet = new pgso._BRIS_EXPERIMENT_3_0DataSet();
            this.tblReservationEquipmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbl_Reservation_EquipmentTableAdapter = new pgso._BRIS_EXPERIMENT_3_0DataSetTableAdapters.tbl_Reservation_EquipmentTableAdapter();
            this.dgv_Equipment_Billing_Records = new System.Windows.Forms.DataGridView();
            this.col_fld_Equipment_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Start_Date_Eq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_End_Date_Eq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Quantity_Returned = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Quantity_Damaged = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Unreturned = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_fld_Total_Equipment_Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_fld_Equipment_Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_fld_Equipment_Price_Subsequent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_fld_Number_Of_Days = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_OT_Days = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Reservation_EquipmentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_fk_EquipmentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_fk_Equipment_PricingID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_fk_Reservation_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Add_Equipment_Billing = new System.Windows.Forms.Button();
            this.lbl_fld_Total_Amount = new System.Windows.Forms.TextBox();
            this.btn_Delete_Equipment_Billing = new System.Windows.Forms.Button();
            this.btn_Return = new System.Windows.Forms.Button();
            this.textBox36 = new System.Windows.Forms.TextBox();
            this.textBox35 = new System.Windows.Forms.TextBox();
            this.lbl_Rate_Type = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pnl_Billing_Details = new System.Windows.Forms.Panel();
            this.btn_Cancel_Reservation = new System.Windows.Forms.Button();
            this.btn_Confirm_Reservation = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lbl_OR = new System.Windows.Forms.TextBox();
            this.tb_OR = new System.Windows.Forms.TextBox();
            this.lbl_Control_Number = new System.Windows.Forms.TextBox();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox42 = new System.Windows.Forms.TextBox();
            this.textBox26 = new System.Windows.Forms.TextBox();
            this.lbl_Reservation_Status = new System.Windows.Forms.TextBox();
            this.lbl_Activity_Name = new System.Windows.Forms.TextBox();
            this.lbl_Reservation_Dates = new System.Windows.Forms.TextBox();
            this.lbl_Address = new System.Windows.Forms.TextBox();
            this.lbl_Contact_Number = new System.Windows.Forms.TextBox();
            this.lbl_Origin_Request = new System.Windows.Forms.TextBox();
            this.lbl_Requesting_Office = new System.Windows.Forms.TextBox();
            this.lbl_Requesting_Person = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._BRIS_EXPERIMENT_3_0DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblReservationEquipmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Equipment_Billing_Records)).BeginInit();
            this.pnl_Billing_Details.SuspendLayout();
            this.SuspendLayout();
            // 
            // _BRIS_EXPERIMENT_3_0DataSet
            // 
            this._BRIS_EXPERIMENT_3_0DataSet.DataSetName = "_BRIS_EXPERIMENT_3_0DataSet";
            this._BRIS_EXPERIMENT_3_0DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblReservationEquipmentBindingSource
            // 
            this.tblReservationEquipmentBindingSource.DataMember = "tbl_Reservation_Equipment";
            this.tblReservationEquipmentBindingSource.DataSource = this._BRIS_EXPERIMENT_3_0DataSet;
            // 
            // tbl_Reservation_EquipmentTableAdapter
            // 
            this.tbl_Reservation_EquipmentTableAdapter.ClearBeforeFill = true;
            // 
            // dgv_Equipment_Billing_Records
            // 
            this.dgv_Equipment_Billing_Records.AllowUserToAddRows = false;
            this.dgv_Equipment_Billing_Records.AllowUserToDeleteRows = false;
            this.dgv_Equipment_Billing_Records.AllowUserToResizeColumns = false;
            this.dgv_Equipment_Billing_Records.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(203)))), ((int)(((byte)(208)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(106)))), ((int)(((byte)(113)))));
            this.dgv_Equipment_Billing_Records.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Equipment_Billing_Records.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgv_Equipment_Billing_Records.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(203)))), ((int)(((byte)(208)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(106)))), ((int)(((byte)(113)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Equipment_Billing_Records.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Equipment_Billing_Records.ColumnHeadersHeight = 40;
            this.dgv_Equipment_Billing_Records.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_Equipment_Billing_Records.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_fld_Equipment_Name,
            this.col_Start_Date_Eq,
            this.col_End_Date_Eq,
            this.col_Quantity,
            this.col_Quantity_Returned,
            this.col_Quantity_Damaged,
            this.col_Unreturned,
            this.col_fld_Total_Equipment_Cost,
            this.col_fld_Equipment_Price,
            this.col_fld_Equipment_Price_Subsequent,
            this.col_fld_Number_Of_Days,
            this.col_OT_Days,
            this.col_Reservation_EquipmentID,
            this.col_fk_EquipmentID,
            this.col_fk_Equipment_PricingID,
            this.col_Total,
            this.col_fk_Reservation_ID});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(203)))), ((int)(((byte)(208)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(106)))), ((int)(((byte)(113)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Equipment_Billing_Records.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_Equipment_Billing_Records.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(203)))), ((int)(((byte)(208)))));
            this.dgv_Equipment_Billing_Records.Location = new System.Drawing.Point(16, 534);
            this.dgv_Equipment_Billing_Records.Margin = new System.Windows.Forms.Padding(0);
            this.dgv_Equipment_Billing_Records.MultiSelect = false;
            this.dgv_Equipment_Billing_Records.Name = "dgv_Equipment_Billing_Records";
            this.dgv_Equipment_Billing_Records.ReadOnly = true;
            this.dgv_Equipment_Billing_Records.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(203)))), ((int)(((byte)(208)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(106)))), ((int)(((byte)(113)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Equipment_Billing_Records.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_Equipment_Billing_Records.RowHeadersVisible = false;
            this.dgv_Equipment_Billing_Records.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_Equipment_Billing_Records.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Equipment_Billing_Records.Size = new System.Drawing.Size(876, 575);
            this.dgv_Equipment_Billing_Records.TabIndex = 46;
            // 
            // col_fld_Equipment_Name
            // 
            this.col_fld_Equipment_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_fld_Equipment_Name.DataPropertyName = "fld_Equipment_Name";
            this.col_fld_Equipment_Name.HeaderText = "EQUIPMENT";
            this.col_fld_Equipment_Name.Name = "col_fld_Equipment_Name";
            this.col_fld_Equipment_Name.ReadOnly = true;
            this.col_fld_Equipment_Name.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.col_fld_Equipment_Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // col_Start_Date_Eq
            // 
            this.col_Start_Date_Eq.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_Start_Date_Eq.DataPropertyName = "fld_Start_Date_Eq";
            this.col_Start_Date_Eq.HeaderText = "START DATE";
            this.col_Start_Date_Eq.Name = "col_Start_Date_Eq";
            this.col_Start_Date_Eq.ReadOnly = true;
            this.col_Start_Date_Eq.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_Start_Date_Eq.Width = 91;
            // 
            // col_End_Date_Eq
            // 
            this.col_End_Date_Eq.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_End_Date_Eq.DataPropertyName = "fld_End_Date_Eq";
            this.col_End_Date_Eq.HeaderText = "RETURN DATE";
            this.col_End_Date_Eq.Name = "col_End_Date_Eq";
            this.col_End_Date_Eq.ReadOnly = true;
            this.col_End_Date_Eq.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.col_End_Date_Eq.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_End_Date_Eq.Width = 102;
            // 
            // col_Quantity
            // 
            this.col_Quantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_Quantity.DataPropertyName = "fld_Quantity";
            this.col_Quantity.HeaderText = "QUANTITY";
            this.col_Quantity.Name = "col_Quantity";
            this.col_Quantity.ReadOnly = true;
            this.col_Quantity.Width = 103;
            // 
            // col_Quantity_Returned
            // 
            this.col_Quantity_Returned.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_Quantity_Returned.DataPropertyName = "fld_Quantity_Returned";
            this.col_Quantity_Returned.HeaderText = "RETURNED";
            this.col_Quantity_Returned.Name = "col_Quantity_Returned";
            this.col_Quantity_Returned.ReadOnly = true;
            this.col_Quantity_Returned.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.col_Quantity_Returned.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_Quantity_Returned.Width = 91;
            // 
            // col_Quantity_Damaged
            // 
            this.col_Quantity_Damaged.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_Quantity_Damaged.DataPropertyName = "fld_Quantity_Damaged";
            this.col_Quantity_Damaged.HeaderText = "DAMAGED";
            this.col_Quantity_Damaged.Name = "col_Quantity_Damaged";
            this.col_Quantity_Damaged.ReadOnly = true;
            this.col_Quantity_Damaged.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.col_Quantity_Damaged.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_Quantity_Damaged.Width = 83;
            // 
            // col_Unreturned
            // 
            this.col_Unreturned.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_Unreturned.FillWeight = 50F;
            this.col_Unreturned.HeaderText = "NOT RETURNED";
            this.col_Unreturned.Name = "col_Unreturned";
            this.col_Unreturned.ReadOnly = true;
            this.col_Unreturned.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.col_Unreturned.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_Unreturned.Width = 113;
            // 
            // col_fld_Total_Equipment_Cost
            // 
            this.col_fld_Total_Equipment_Cost.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_fld_Total_Equipment_Cost.DataPropertyName = "fld_Total_Equipment_Cost";
            this.col_fld_Total_Equipment_Cost.HeaderText = "TOTAL";
            this.col_fld_Total_Equipment_Cost.Name = "col_fld_Total_Equipment_Cost";
            this.col_fld_Total_Equipment_Cost.ReadOnly = true;
            this.col_fld_Total_Equipment_Cost.Width = 79;
            // 
            // col_fld_Equipment_Price
            // 
            this.col_fld_Equipment_Price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_fld_Equipment_Price.DataPropertyName = "fld_Equipment_Price";
            this.col_fld_Equipment_Price.HeaderText = "BASE RATE";
            this.col_fld_Equipment_Price.Name = "col_fld_Equipment_Price";
            this.col_fld_Equipment_Price.ReadOnly = true;
            this.col_fld_Equipment_Price.Visible = false;
            this.col_fld_Equipment_Price.Width = 101;
            // 
            // col_fld_Equipment_Price_Subsequent
            // 
            this.col_fld_Equipment_Price_Subsequent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_fld_Equipment_Price_Subsequent.DataPropertyName = "fld_Equipment_Price_Subsequent";
            this.col_fld_Equipment_Price_Subsequent.HeaderText = "SUB RATE";
            this.col_fld_Equipment_Price_Subsequent.Name = "col_fld_Equipment_Price_Subsequent";
            this.col_fld_Equipment_Price_Subsequent.ReadOnly = true;
            this.col_fld_Equipment_Price_Subsequent.Visible = false;
            this.col_fld_Equipment_Price_Subsequent.Width = 94;
            // 
            // col_fld_Number_Of_Days
            // 
            this.col_fld_Number_Of_Days.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_fld_Number_Of_Days.DataPropertyName = "fld_Number_Of_Days";
            this.col_fld_Number_Of_Days.HeaderText = "DAYS";
            this.col_fld_Number_Of_Days.Name = "col_fld_Number_Of_Days";
            this.col_fld_Number_Of_Days.ReadOnly = true;
            this.col_fld_Number_Of_Days.Visible = false;
            this.col_fld_Number_Of_Days.Width = 70;
            // 
            // col_OT_Days
            // 
            this.col_OT_Days.DataPropertyName = "fld_OT_Days";
            this.col_OT_Days.HeaderText = "OT Days";
            this.col_OT_Days.Name = "col_OT_Days";
            this.col_OT_Days.ReadOnly = true;
            this.col_OT_Days.Visible = false;
            // 
            // col_Reservation_EquipmentID
            // 
            this.col_Reservation_EquipmentID.DataPropertyName = "pk_Reservation_EquipmentID";
            this.col_Reservation_EquipmentID.HeaderText = "Reservation Equipment ID";
            this.col_Reservation_EquipmentID.Name = "col_Reservation_EquipmentID";
            this.col_Reservation_EquipmentID.ReadOnly = true;
            this.col_Reservation_EquipmentID.Visible = false;
            // 
            // col_fk_EquipmentID
            // 
            this.col_fk_EquipmentID.DataPropertyName = "fk_EquipmentID";
            this.col_fk_EquipmentID.HeaderText = "Equipment ID";
            this.col_fk_EquipmentID.Name = "col_fk_EquipmentID";
            this.col_fk_EquipmentID.ReadOnly = true;
            this.col_fk_EquipmentID.Visible = false;
            // 
            // col_fk_Equipment_PricingID
            // 
            this.col_fk_Equipment_PricingID.DataPropertyName = "fk_Equipment_PricingID";
            this.col_fk_Equipment_PricingID.HeaderText = "Equipment Pricing ID";
            this.col_fk_Equipment_PricingID.Name = "col_fk_Equipment_PricingID";
            this.col_fk_Equipment_PricingID.ReadOnly = true;
            this.col_fk_Equipment_PricingID.Visible = false;
            // 
            // col_Total
            // 
            this.col_Total.HeaderText = "Total";
            this.col_Total.Name = "col_Total";
            this.col_Total.ReadOnly = true;
            this.col_Total.Visible = false;
            // 
            // col_fk_Reservation_ID
            // 
            this.col_fk_Reservation_ID.DataPropertyName = "pk_ReservationID";
            this.col_fk_Reservation_ID.HeaderText = "Reservation ID";
            this.col_fk_Reservation_ID.Name = "col_fk_Reservation_ID";
            this.col_fk_Reservation_ID.ReadOnly = true;
            this.col_fk_Reservation_ID.Visible = false;
            // 
            // btn_Add_Equipment_Billing
            // 
            this.btn_Add_Equipment_Billing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(166)))), ((int)(((byte)(167)))));
            this.btn_Add_Equipment_Billing.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btn_Add_Equipment_Billing.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.btn_Add_Equipment_Billing.Location = new System.Drawing.Point(557, 482);
            this.btn_Add_Equipment_Billing.Name = "btn_Add_Equipment_Billing";
            this.btn_Add_Equipment_Billing.Size = new System.Drawing.Size(106, 47);
            this.btn_Add_Equipment_Billing.TabIndex = 49;
            this.btn_Add_Equipment_Billing.Text = "ADD";
            this.btn_Add_Equipment_Billing.UseVisualStyleBackColor = false;
            this.btn_Add_Equipment_Billing.Click += new System.EventHandler(this.btn_Add_Equipment_Billing_Click);
            // 
            // lbl_fld_Total_Amount
            // 
            this.lbl_fld_Total_Amount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.lbl_fld_Total_Amount.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_fld_Total_Amount.Location = new System.Drawing.Point(777, 1110);
            this.lbl_fld_Total_Amount.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_fld_Total_Amount.MaximumSize = new System.Drawing.Size(115, 25);
            this.lbl_fld_Total_Amount.MinimumSize = new System.Drawing.Size(115, 25);
            this.lbl_fld_Total_Amount.Name = "lbl_fld_Total_Amount";
            this.lbl_fld_Total_Amount.Size = new System.Drawing.Size(115, 27);
            this.lbl_fld_Total_Amount.TabIndex = 51;
            this.lbl_fld_Total_Amount.Text = "Amount";
            this.lbl_fld_Total_Amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_Delete_Equipment_Billing
            // 
            this.btn_Delete_Equipment_Billing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(166)))), ((int)(((byte)(167)))));
            this.btn_Delete_Equipment_Billing.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btn_Delete_Equipment_Billing.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.btn_Delete_Equipment_Billing.Location = new System.Drawing.Point(671, 482);
            this.btn_Delete_Equipment_Billing.Name = "btn_Delete_Equipment_Billing";
            this.btn_Delete_Equipment_Billing.Size = new System.Drawing.Size(106, 47);
            this.btn_Delete_Equipment_Billing.TabIndex = 52;
            this.btn_Delete_Equipment_Billing.Text = "DELETE";
            this.btn_Delete_Equipment_Billing.UseVisualStyleBackColor = false;
            this.btn_Delete_Equipment_Billing.Click += new System.EventHandler(this.btn_Delete_Equipment_Billing_Click);
            // 
            // btn_Return
            // 
            this.btn_Return.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(166)))), ((int)(((byte)(167)))));
            this.btn_Return.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btn_Return.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.btn_Return.Location = new System.Drawing.Point(785, 483);
            this.btn_Return.Name = "btn_Return";
            this.btn_Return.Size = new System.Drawing.Size(106, 47);
            this.btn_Return.TabIndex = 53;
            this.btn_Return.Text = "RETURN";
            this.btn_Return.UseVisualStyleBackColor = false;
            this.btn_Return.Click += new System.EventHandler(this.btn_Return_Click);
            // 
            // textBox36
            // 
            this.textBox36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.textBox36.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox36.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox36.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.textBox36.Location = new System.Drawing.Point(16, 461);
            this.textBox36.Margin = new System.Windows.Forms.Padding(0);
            this.textBox36.MinimumSize = new System.Drawing.Size(0, 30);
            this.textBox36.Name = "textBox36";
            this.textBox36.ReadOnly = true;
            this.textBox36.Size = new System.Drawing.Size(309, 22);
            this.textBox36.TabIndex = 91;
            this.textBox36.Text = "BILLING DETAILS";
            // 
            // textBox35
            // 
            this.textBox35.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.textBox35.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox35.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox35.Font = new System.Drawing.Font("Arial", 12.75F);
            this.textBox35.Location = new System.Drawing.Point(18, 493);
            this.textBox35.Margin = new System.Windows.Forms.Padding(0);
            this.textBox35.MinimumSize = new System.Drawing.Size(0, 25);
            this.textBox35.Name = "textBox35";
            this.textBox35.ReadOnly = true;
            this.textBox35.Size = new System.Drawing.Size(103, 20);
            this.textBox35.TabIndex = 92;
            this.textBox35.Text = "Rate Type";
            // 
            // lbl_Rate_Type
            // 
            this.lbl_Rate_Type.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.lbl_Rate_Type.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbl_Rate_Type.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbl_Rate_Type.Font = new System.Drawing.Font("Arial", 12.75F);
            this.lbl_Rate_Type.Location = new System.Drawing.Point(147, 493);
            this.lbl_Rate_Type.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_Rate_Type.MinimumSize = new System.Drawing.Size(0, 25);
            this.lbl_Rate_Type.Name = "lbl_Rate_Type";
            this.lbl_Rate_Type.ReadOnly = true;
            this.lbl_Rate_Type.Size = new System.Drawing.Size(87, 20);
            this.lbl_Rate_Type.TabIndex = 93;
            this.lbl_Rate_Type.Text = "...";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(525, 1112);
            this.textBox1.Margin = new System.Windows.Forms.Padding(0);
            this.textBox1.MaximumSize = new System.Drawing.Size(115, 25);
            this.textBox1.MinimumSize = new System.Drawing.Size(250, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(250, 25);
            this.textBox1.TabIndex = 94;
            this.textBox1.Text = "OVERALL TOTAL AMOUNT";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pnl_Billing_Details
            // 
            this.pnl_Billing_Details.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.pnl_Billing_Details.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_Billing_Details.Controls.Add(this.button1);
            this.pnl_Billing_Details.Controls.Add(this.btn_Cancel_Reservation);
            this.pnl_Billing_Details.Controls.Add(this.btn_Confirm_Reservation);
            this.pnl_Billing_Details.Controls.Add(this.textBox2);
            this.pnl_Billing_Details.Controls.Add(this.lbl_OR);
            this.pnl_Billing_Details.Controls.Add(this.tb_OR);
            this.pnl_Billing_Details.Controls.Add(this.lbl_Control_Number);
            this.pnl_Billing_Details.Controls.Add(this.textBox15);
            this.pnl_Billing_Details.Controls.Add(this.textBox16);
            this.pnl_Billing_Details.Controls.Add(this.textBox5);
            this.pnl_Billing_Details.Controls.Add(this.textBox42);
            this.pnl_Billing_Details.Controls.Add(this.textBox26);
            this.pnl_Billing_Details.Controls.Add(this.lbl_Reservation_Status);
            this.pnl_Billing_Details.Controls.Add(this.lbl_Activity_Name);
            this.pnl_Billing_Details.Controls.Add(this.lbl_Reservation_Dates);
            this.pnl_Billing_Details.Controls.Add(this.lbl_Address);
            this.pnl_Billing_Details.Controls.Add(this.lbl_Contact_Number);
            this.pnl_Billing_Details.Controls.Add(this.lbl_Origin_Request);
            this.pnl_Billing_Details.Controls.Add(this.lbl_Requesting_Office);
            this.pnl_Billing_Details.Controls.Add(this.lbl_Requesting_Person);
            this.pnl_Billing_Details.Controls.Add(this.textBox13);
            this.pnl_Billing_Details.Controls.Add(this.textBox11);
            this.pnl_Billing_Details.Controls.Add(this.textBox9);
            this.pnl_Billing_Details.Controls.Add(this.textBox8);
            this.pnl_Billing_Details.Controls.Add(this.textBox6);
            this.pnl_Billing_Details.Controls.Add(this.textBox4);
            this.pnl_Billing_Details.Controls.Add(this.textBox3);
            this.pnl_Billing_Details.Controls.Add(this.textBox1);
            this.pnl_Billing_Details.Controls.Add(this.lbl_Rate_Type);
            this.pnl_Billing_Details.Controls.Add(this.textBox35);
            this.pnl_Billing_Details.Controls.Add(this.textBox36);
            this.pnl_Billing_Details.Controls.Add(this.btn_Return);
            this.pnl_Billing_Details.Controls.Add(this.btn_Delete_Equipment_Billing);
            this.pnl_Billing_Details.Controls.Add(this.lbl_fld_Total_Amount);
            this.pnl_Billing_Details.Controls.Add(this.btn_Add_Equipment_Billing);
            this.pnl_Billing_Details.Controls.Add(this.dgv_Equipment_Billing_Records);
            this.pnl_Billing_Details.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Billing_Details.Location = new System.Drawing.Point(0, 0);
            this.pnl_Billing_Details.MaximumSize = new System.Drawing.Size(700, 700);
            this.pnl_Billing_Details.MinimumSize = new System.Drawing.Size(912, 1150);
            this.pnl_Billing_Details.Name = "pnl_Billing_Details";
            this.pnl_Billing_Details.Size = new System.Drawing.Size(912, 1150);
            this.pnl_Billing_Details.TabIndex = 8;
            // 
            // btn_Cancel_Reservation
            // 
            this.btn_Cancel_Reservation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(166)))), ((int)(((byte)(167)))));
            this.btn_Cancel_Reservation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Cancel_Reservation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold);
            this.btn_Cancel_Reservation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.btn_Cancel_Reservation.Location = new System.Drawing.Point(662, 78);
            this.btn_Cancel_Reservation.Name = "btn_Cancel_Reservation";
            this.btn_Cancel_Reservation.Size = new System.Drawing.Size(230, 34);
            this.btn_Cancel_Reservation.TabIndex = 135;
            this.btn_Cancel_Reservation.Text = "Cancel Reservation";
            this.btn_Cancel_Reservation.UseVisualStyleBackColor = false;
            this.btn_Cancel_Reservation.Click += new System.EventHandler(this.btn_Cancel_Reservation_Click);
            // 
            // btn_Confirm_Reservation
            // 
            this.btn_Confirm_Reservation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(166)))), ((int)(((byte)(167)))));
            this.btn_Confirm_Reservation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Confirm_Reservation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold);
            this.btn_Confirm_Reservation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.btn_Confirm_Reservation.Location = new System.Drawing.Point(662, 43);
            this.btn_Confirm_Reservation.Name = "btn_Confirm_Reservation";
            this.btn_Confirm_Reservation.Size = new System.Drawing.Size(230, 34);
            this.btn_Confirm_Reservation.TabIndex = 134;
            this.btn_Confirm_Reservation.Text = "Confirm Reservation";
            this.btn_Confirm_Reservation.UseVisualStyleBackColor = false;
            this.btn_Confirm_Reservation.Click += new System.EventHandler(this.btn_Confirm_Reservation_Click);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(106)))), ((int)(((byte)(113)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(-2, 439);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(912, 8);
            this.textBox2.TabIndex = 133;
            // 
            // lbl_OR
            // 
            this.lbl_OR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.lbl_OR.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbl_OR.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbl_OR.Font = new System.Drawing.Font("Arial", 17F, System.Drawing.FontStyle.Italic);
            this.lbl_OR.ForeColor = System.Drawing.Color.Red;
            this.lbl_OR.Location = new System.Drawing.Point(328, 41);
            this.lbl_OR.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_OR.MinimumSize = new System.Drawing.Size(4, 25);
            this.lbl_OR.Name = "lbl_OR";
            this.lbl_OR.ReadOnly = true;
            this.lbl_OR.Size = new System.Drawing.Size(199, 27);
            this.lbl_OR.TabIndex = 132;
            // 
            // tb_OR
            // 
            this.tb_OR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.tb_OR.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_OR.Cursor = System.Windows.Forms.Cursors.Default;
            this.tb_OR.Font = new System.Drawing.Font("Arial", 17F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.tb_OR.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tb_OR.Location = new System.Drawing.Point(4, 39);
            this.tb_OR.Margin = new System.Windows.Forms.Padding(0);
            this.tb_OR.Name = "tb_OR";
            this.tb_OR.ReadOnly = true;
            this.tb_OR.Size = new System.Drawing.Size(324, 27);
            this.tb_OR.TabIndex = 131;
            this.tb_OR.Text = "OFFICIAL RECEIPT NUMBER";
            // 
            // lbl_Control_Number
            // 
            this.lbl_Control_Number.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.lbl_Control_Number.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbl_Control_Number.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbl_Control_Number.Font = new System.Drawing.Font("Arial", 17F, System.Drawing.FontStyle.Italic);
            this.lbl_Control_Number.ForeColor = System.Drawing.Color.Red;
            this.lbl_Control_Number.Location = new System.Drawing.Point(238, 8);
            this.lbl_Control_Number.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_Control_Number.MinimumSize = new System.Drawing.Size(4, 25);
            this.lbl_Control_Number.Name = "lbl_Control_Number";
            this.lbl_Control_Number.ReadOnly = true;
            this.lbl_Control_Number.Size = new System.Drawing.Size(289, 27);
            this.lbl_Control_Number.TabIndex = 130;
            // 
            // textBox15
            // 
            this.textBox15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.textBox15.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox15.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox15.Font = new System.Drawing.Font("Arial", 17F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.textBox15.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBox15.Location = new System.Drawing.Point(4, 8);
            this.textBox15.Margin = new System.Windows.Forms.Padding(0);
            this.textBox15.Name = "textBox15";
            this.textBox15.ReadOnly = true;
            this.textBox15.Size = new System.Drawing.Size(235, 27);
            this.textBox15.TabIndex = 129;
            this.textBox15.Text = "CONTROL NUMBER";
            // 
            // textBox16
            // 
            this.textBox16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(106)))), ((int)(((byte)(113)))));
            this.textBox16.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox16.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox16.Location = new System.Drawing.Point(-1, 115);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(912, 8);
            this.textBox16.TabIndex = 128;
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.Location = new System.Drawing.Point(7, 229);
            this.textBox5.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.textBox5.MinimumSize = new System.Drawing.Size(2, 25);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(166, 20);
            this.textBox5.TabIndex = 127;
            this.textBox5.Text = "Request Origin";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox42
            // 
            this.textBox42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.textBox42.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox42.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox42.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox42.Location = new System.Drawing.Point(7, 196);
            this.textBox42.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.textBox42.MinimumSize = new System.Drawing.Size(2, 25);
            this.textBox42.Name = "textBox42";
            this.textBox42.ReadOnly = true;
            this.textBox42.Size = new System.Drawing.Size(166, 20);
            this.textBox42.TabIndex = 126;
            this.textBox42.Text = "Requesting Office";
            this.textBox42.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox26
            // 
            this.textBox26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.textBox26.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox26.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox26.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.textBox26.Location = new System.Drawing.Point(452, 128);
            this.textBox26.Margin = new System.Windows.Forms.Padding(0);
            this.textBox26.MinimumSize = new System.Drawing.Size(2, 30);
            this.textBox26.Name = "textBox26";
            this.textBox26.ReadOnly = true;
            this.textBox26.Size = new System.Drawing.Size(370, 22);
            this.textBox26.TabIndex = 116;
            this.textBox26.Text = "RESERVATION INFORMATION";
            // 
            // lbl_Reservation_Status
            // 
            this.lbl_Reservation_Status.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.lbl_Reservation_Status.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbl_Reservation_Status.Font = new System.Drawing.Font("Arial", 14F);
            this.lbl_Reservation_Status.Location = new System.Drawing.Point(662, 11);
            this.lbl_Reservation_Status.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_Reservation_Status.MinimumSize = new System.Drawing.Size(4, 25);
            this.lbl_Reservation_Status.Name = "lbl_Reservation_Status";
            this.lbl_Reservation_Status.ReadOnly = true;
            this.lbl_Reservation_Status.Size = new System.Drawing.Size(230, 29);
            this.lbl_Reservation_Status.TabIndex = 114;
            // 
            // lbl_Activity_Name
            // 
            this.lbl_Activity_Name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.lbl_Activity_Name.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbl_Activity_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Activity_Name.Location = new System.Drawing.Point(661, 190);
            this.lbl_Activity_Name.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_Activity_Name.MinimumSize = new System.Drawing.Size(4, 25);
            this.lbl_Activity_Name.Multiline = true;
            this.lbl_Activity_Name.Name = "lbl_Activity_Name";
            this.lbl_Activity_Name.ReadOnly = true;
            this.lbl_Activity_Name.Size = new System.Drawing.Size(230, 235);
            this.lbl_Activity_Name.TabIndex = 112;
            // 
            // lbl_Reservation_Dates
            // 
            this.lbl_Reservation_Dates.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.lbl_Reservation_Dates.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbl_Reservation_Dates.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Reservation_Dates.Location = new System.Drawing.Point(661, 159);
            this.lbl_Reservation_Dates.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_Reservation_Dates.MinimumSize = new System.Drawing.Size(4, 25);
            this.lbl_Reservation_Dates.Name = "lbl_Reservation_Dates";
            this.lbl_Reservation_Dates.ReadOnly = true;
            this.lbl_Reservation_Dates.Size = new System.Drawing.Size(230, 27);
            this.lbl_Reservation_Dates.TabIndex = 110;
            // 
            // lbl_Address
            // 
            this.lbl_Address.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.lbl_Address.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbl_Address.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Address.Location = new System.Drawing.Point(185, 294);
            this.lbl_Address.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_Address.MinimumSize = new System.Drawing.Size(230, 25);
            this.lbl_Address.Multiline = true;
            this.lbl_Address.Name = "lbl_Address";
            this.lbl_Address.ReadOnly = true;
            this.lbl_Address.Size = new System.Drawing.Size(230, 131);
            this.lbl_Address.TabIndex = 109;
            // 
            // lbl_Contact_Number
            // 
            this.lbl_Contact_Number.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.lbl_Contact_Number.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbl_Contact_Number.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Contact_Number.Location = new System.Drawing.Point(185, 260);
            this.lbl_Contact_Number.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_Contact_Number.MinimumSize = new System.Drawing.Size(230, 25);
            this.lbl_Contact_Number.Name = "lbl_Contact_Number";
            this.lbl_Contact_Number.ReadOnly = true;
            this.lbl_Contact_Number.Size = new System.Drawing.Size(230, 27);
            this.lbl_Contact_Number.TabIndex = 108;
            // 
            // lbl_Origin_Request
            // 
            this.lbl_Origin_Request.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.lbl_Origin_Request.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbl_Origin_Request.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Origin_Request.Location = new System.Drawing.Point(185, 227);
            this.lbl_Origin_Request.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_Origin_Request.MinimumSize = new System.Drawing.Size(230, 25);
            this.lbl_Origin_Request.Name = "lbl_Origin_Request";
            this.lbl_Origin_Request.ReadOnly = true;
            this.lbl_Origin_Request.Size = new System.Drawing.Size(230, 27);
            this.lbl_Origin_Request.TabIndex = 107;
            // 
            // lbl_Requesting_Office
            // 
            this.lbl_Requesting_Office.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.lbl_Requesting_Office.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbl_Requesting_Office.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Requesting_Office.Location = new System.Drawing.Point(185, 194);
            this.lbl_Requesting_Office.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_Requesting_Office.MinimumSize = new System.Drawing.Size(230, 25);
            this.lbl_Requesting_Office.Name = "lbl_Requesting_Office";
            this.lbl_Requesting_Office.ReadOnly = true;
            this.lbl_Requesting_Office.Size = new System.Drawing.Size(230, 27);
            this.lbl_Requesting_Office.TabIndex = 106;
            // 
            // lbl_Requesting_Person
            // 
            this.lbl_Requesting_Person.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.lbl_Requesting_Person.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbl_Requesting_Person.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Requesting_Person.Location = new System.Drawing.Point(185, 161);
            this.lbl_Requesting_Person.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_Requesting_Person.MinimumSize = new System.Drawing.Size(230, 25);
            this.lbl_Requesting_Person.Name = "lbl_Requesting_Person";
            this.lbl_Requesting_Person.ReadOnly = true;
            this.lbl_Requesting_Person.Size = new System.Drawing.Size(230, 27);
            this.lbl_Requesting_Person.TabIndex = 105;
            // 
            // textBox13
            // 
            this.textBox13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.textBox13.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox13.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox13.Location = new System.Drawing.Point(486, 14);
            this.textBox13.Margin = new System.Windows.Forms.Padding(0);
            this.textBox13.MinimumSize = new System.Drawing.Size(2, 25);
            this.textBox13.Name = "textBox13";
            this.textBox13.ReadOnly = true;
            this.textBox13.Size = new System.Drawing.Size(161, 22);
            this.textBox13.TabIndex = 103;
            this.textBox13.Text = "Status";
            this.textBox13.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox11
            // 
            this.textBox11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.textBox11.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox11.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox11.Location = new System.Drawing.Point(485, 193);
            this.textBox11.Margin = new System.Windows.Forms.Padding(0);
            this.textBox11.MinimumSize = new System.Drawing.Size(2, 25);
            this.textBox11.Name = "textBox11";
            this.textBox11.ReadOnly = true;
            this.textBox11.Size = new System.Drawing.Size(161, 20);
            this.textBox11.TabIndex = 101;
            this.textBox11.Text = "Activity";
            this.textBox11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox9
            // 
            this.textBox9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.textBox9.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox9.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox9.Location = new System.Drawing.Point(485, 161);
            this.textBox9.Margin = new System.Windows.Forms.Padding(0);
            this.textBox9.MinimumSize = new System.Drawing.Size(2, 25);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(161, 20);
            this.textBox9.TabIndex = 99;
            this.textBox9.Text = "Reservation Dates";
            this.textBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox8
            // 
            this.textBox8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.textBox8.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox8.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox8.Location = new System.Drawing.Point(7, 294);
            this.textBox8.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.textBox8.MinimumSize = new System.Drawing.Size(110, 16);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(166, 20);
            this.textBox8.TabIndex = 98;
            this.textBox8.Text = "Address";
            this.textBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox6.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.Location = new System.Drawing.Point(7, 262);
            this.textBox6.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.textBox6.MinimumSize = new System.Drawing.Size(110, 16);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(166, 20);
            this.textBox6.TabIndex = 97;
            this.textBox6.Text = "Contact Number";
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(8, 167);
            this.textBox4.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.textBox4.MinimumSize = new System.Drawing.Size(2, 25);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(166, 20);
            this.textBox4.TabIndex = 96;
            this.textBox4.Text = "Requesting Person";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.textBox3.Location = new System.Drawing.Point(6, 128);
            this.textBox3.Margin = new System.Windows.Forms.Padding(0);
            this.textBox3.MinimumSize = new System.Drawing.Size(2, 30);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(297, 22);
            this.textBox3.TabIndex = 95;
            this.textBox3.Text = "CLIENT INFORMATION";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(166)))), ((int)(((byte)(167)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.button1.Location = new System.Drawing.Point(445, 483);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 47);
            this.button1.TabIndex = 136;
            this.button1.Text = "RETURN SLIP";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Equipment_User_Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(203)))), ((int)(((byte)(208)))));
            this.Controls.Add(this.pnl_Billing_Details);
            this.MaximumSize = new System.Drawing.Size(700, 700);
            this.MinimumSize = new System.Drawing.Size(912, 1150);
            this.Name = "Equipment_User_Control";
            this.Size = new System.Drawing.Size(912, 1150);
            ((System.ComponentModel.ISupportInitialize)(this._BRIS_EXPERIMENT_3_0DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblReservationEquipmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Equipment_Billing_Records)).EndInit();
            this.pnl_Billing_Details.ResumeLayout(false);
            this.pnl_Billing_Details.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource tblReservationEquipmentBindingSource;
        private _BRIS_EXPERIMENT_3_0DataSet _BRIS_EXPERIMENT_3_0DataSet;
        private _BRIS_EXPERIMENT_3_0DataSetTableAdapters.tbl_Reservation_EquipmentTableAdapter tbl_Reservation_EquipmentTableAdapter;
        private System.Windows.Forms.DataGridView dgv_Equipment_Billing_Records;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_fld_Equipment_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Start_Date_Eq;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_End_Date_Eq;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Quantity_Returned;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Quantity_Damaged;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Unreturned;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_fld_Total_Equipment_Cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_fld_Equipment_Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_fld_Equipment_Price_Subsequent;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_fld_Number_Of_Days;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_OT_Days;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Reservation_EquipmentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_fk_EquipmentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_fk_Equipment_PricingID;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_fk_Reservation_ID;
        private System.Windows.Forms.Button btn_Add_Equipment_Billing;
        private System.Windows.Forms.TextBox lbl_fld_Total_Amount;
        private System.Windows.Forms.Button btn_Delete_Equipment_Billing;
        private System.Windows.Forms.Button btn_Return;
        private System.Windows.Forms.TextBox textBox36;
        private System.Windows.Forms.TextBox textBox35;
        private System.Windows.Forms.TextBox lbl_Rate_Type;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel pnl_Billing_Details;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox42;
        private System.Windows.Forms.TextBox textBox26;
        private System.Windows.Forms.TextBox lbl_Reservation_Status;
        private System.Windows.Forms.TextBox lbl_Activity_Name;
        private System.Windows.Forms.TextBox lbl_Reservation_Dates;
        private System.Windows.Forms.TextBox lbl_Address;
        private System.Windows.Forms.TextBox lbl_Contact_Number;
        private System.Windows.Forms.TextBox lbl_Origin_Request;
        private System.Windows.Forms.TextBox lbl_Requesting_Office;
        private System.Windows.Forms.TextBox lbl_Requesting_Person;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox16;
        private System.Windows.Forms.TextBox lbl_OR;
        private System.Windows.Forms.TextBox tb_OR;
        private System.Windows.Forms.TextBox lbl_Control_Number;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btn_Confirm_Reservation;
        private System.Windows.Forms.Button btn_Cancel_Reservation;
        private System.Windows.Forms.Button button1;
    }
}
