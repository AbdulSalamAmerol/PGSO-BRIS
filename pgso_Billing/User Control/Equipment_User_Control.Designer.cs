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
            this.textBox26 = new System.Windows.Forms.TextBox();
            this.lbl_Control_Number = new System.Windows.Forms.TextBox();
            this.lbl_Reservation_Dates = new System.Windows.Forms.TextBox();
            this.lbl_Address = new System.Windows.Forms.TextBox();
            this.lbl_Contact_Number = new System.Windows.Forms.TextBox();
            this.lbl_Origin_Request = new System.Windows.Forms.TextBox();
            this.lbl_Requesting_Office = new System.Windows.Forms.TextBox();
            this.lbl_Requesting_Person = new System.Windows.Forms.TextBox();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.pnl_Billing_Details = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_Delete_Equipment_Billing = new System.Windows.Forms.Button();
            this.lbl_fld_Total_Amount = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_Add_Equipment_Billing = new System.Windows.Forms.Button();
            this.lbl_Reservation_Status = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.dgv_Equipment_Billing_Records = new System.Windows.Forms.DataGridView();
            this.textBox38 = new System.Windows.Forms.TextBox();
            this.lbl_Rate_Type = new System.Windows.Forms.TextBox();
            this.textBox35 = new System.Windows.Forms.TextBox();
            this.textBox36 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this._BRIS_EXPERIMENT_3_0DataSet = new pgso._BRIS_EXPERIMENT_3_0DataSet();
            this.tblReservationEquipmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbl_Reservation_EquipmentTableAdapter = new pgso._BRIS_EXPERIMENT_3_0DataSetTableAdapters.tbl_Reservation_EquipmentTableAdapter();
            this.col_fk_Reservation_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Start_Date_Eq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_End_Date_Eq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_OT_Days = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Reservation_EquipmentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_fk_EquipmentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_fk_Equipment_PricingID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_fld_Number_Of_Days = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_fld_Total_Equipment_Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_fld_Equipment_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_fld_Equipment_Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_fld_Equipment_Price_Subsequent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnl_Billing_Details.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Equipment_Billing_Records)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._BRIS_EXPERIMENT_3_0DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblReservationEquipmentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox26
            // 
            this.textBox26.BackColor = System.Drawing.SystemColors.Control;
            this.textBox26.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox26.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox26.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox26.Location = new System.Drawing.Point(401, 57);
            this.textBox26.Margin = new System.Windows.Forms.Padding(0);
            this.textBox26.MinimumSize = new System.Drawing.Size(2, 30);
            this.textBox26.Name = "textBox26";
            this.textBox26.ReadOnly = true;
            this.textBox26.Size = new System.Drawing.Size(253, 19);
            this.textBox26.TabIndex = 24;
            this.textBox26.Text = "RESERVATION INFORMATION";
            // 
            // lbl_Control_Number
            // 
            this.lbl_Control_Number.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_Control_Number.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbl_Control_Number.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Control_Number.ForeColor = System.Drawing.Color.Red;
            this.lbl_Control_Number.Location = new System.Drawing.Point(132, 3);
            this.lbl_Control_Number.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_Control_Number.MinimumSize = new System.Drawing.Size(4, 25);
            this.lbl_Control_Number.Name = "lbl_Control_Number";
            this.lbl_Control_Number.ReadOnly = true;
            this.lbl_Control_Number.Size = new System.Drawing.Size(267, 27);
            this.lbl_Control_Number.TabIndex = 23;
            this.lbl_Control_Number.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbl_Reservation_Dates
            // 
            this.lbl_Reservation_Dates.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_Reservation_Dates.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Reservation_Dates.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbl_Reservation_Dates.Font = new System.Drawing.Font("Arial", 10F);
            this.lbl_Reservation_Dates.Location = new System.Drawing.Point(547, 100);
            this.lbl_Reservation_Dates.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_Reservation_Dates.MinimumSize = new System.Drawing.Size(2, 25);
            this.lbl_Reservation_Dates.Name = "lbl_Reservation_Dates";
            this.lbl_Reservation_Dates.ReadOnly = true;
            this.lbl_Reservation_Dates.Size = new System.Drawing.Size(249, 23);
            this.lbl_Reservation_Dates.TabIndex = 18;
            // 
            // lbl_Address
            // 
            this.lbl_Address.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_Address.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Address.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbl_Address.Font = new System.Drawing.Font("Arial", 10F);
            this.lbl_Address.Location = new System.Drawing.Point(149, 208);
            this.lbl_Address.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_Address.MinimumSize = new System.Drawing.Size(2, 25);
            this.lbl_Address.Name = "lbl_Address";
            this.lbl_Address.ReadOnly = true;
            this.lbl_Address.Size = new System.Drawing.Size(250, 23);
            this.lbl_Address.TabIndex = 17;
            // 
            // lbl_Contact_Number
            // 
            this.lbl_Contact_Number.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_Contact_Number.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Contact_Number.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbl_Contact_Number.Font = new System.Drawing.Font("Arial", 10F);
            this.lbl_Contact_Number.Location = new System.Drawing.Point(149, 181);
            this.lbl_Contact_Number.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_Contact_Number.MinimumSize = new System.Drawing.Size(2, 25);
            this.lbl_Contact_Number.Name = "lbl_Contact_Number";
            this.lbl_Contact_Number.ReadOnly = true;
            this.lbl_Contact_Number.Size = new System.Drawing.Size(250, 23);
            this.lbl_Contact_Number.TabIndex = 16;
            // 
            // lbl_Origin_Request
            // 
            this.lbl_Origin_Request.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_Origin_Request.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Origin_Request.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbl_Origin_Request.Font = new System.Drawing.Font("Arial", 10F);
            this.lbl_Origin_Request.Location = new System.Drawing.Point(149, 154);
            this.lbl_Origin_Request.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_Origin_Request.MinimumSize = new System.Drawing.Size(2, 25);
            this.lbl_Origin_Request.Name = "lbl_Origin_Request";
            this.lbl_Origin_Request.ReadOnly = true;
            this.lbl_Origin_Request.Size = new System.Drawing.Size(250, 23);
            this.lbl_Origin_Request.TabIndex = 15;
            // 
            // lbl_Requesting_Office
            // 
            this.lbl_Requesting_Office.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_Requesting_Office.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Requesting_Office.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbl_Requesting_Office.Font = new System.Drawing.Font("Arial", 10F);
            this.lbl_Requesting_Office.Location = new System.Drawing.Point(149, 127);
            this.lbl_Requesting_Office.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_Requesting_Office.MinimumSize = new System.Drawing.Size(2, 25);
            this.lbl_Requesting_Office.Name = "lbl_Requesting_Office";
            this.lbl_Requesting_Office.ReadOnly = true;
            this.lbl_Requesting_Office.Size = new System.Drawing.Size(250, 23);
            this.lbl_Requesting_Office.TabIndex = 14;
            // 
            // lbl_Requesting_Person
            // 
            this.lbl_Requesting_Person.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_Requesting_Person.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Requesting_Person.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbl_Requesting_Person.Font = new System.Drawing.Font("Arial", 10F);
            this.lbl_Requesting_Person.Location = new System.Drawing.Point(149, 100);
            this.lbl_Requesting_Person.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_Requesting_Person.MinimumSize = new System.Drawing.Size(2, 25);
            this.lbl_Requesting_Person.Name = "lbl_Requesting_Person";
            this.lbl_Requesting_Person.ReadOnly = true;
            this.lbl_Requesting_Person.Size = new System.Drawing.Size(250, 23);
            this.lbl_Requesting_Person.TabIndex = 13;
            // 
            // textBox15
            // 
            this.textBox15.BackColor = System.Drawing.SystemColors.Control;
            this.textBox15.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox15.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox15.ForeColor = System.Drawing.Color.Red;
            this.textBox15.Location = new System.Drawing.Point(2, 3);
            this.textBox15.Margin = new System.Windows.Forms.Padding(0);
            this.textBox15.MinimumSize = new System.Drawing.Size(4, 25);
            this.textBox15.Name = "textBox15";
            this.textBox15.ReadOnly = true;
            this.textBox15.Size = new System.Drawing.Size(130, 27);
            this.textBox15.TabIndex = 12;
            this.textBox15.Text = "Control Number";
            // 
            // textBox9
            // 
            this.textBox9.BackColor = System.Drawing.SystemColors.Control;
            this.textBox9.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox9.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox9.Font = new System.Drawing.Font("Arial", 10F);
            this.textBox9.Location = new System.Drawing.Point(401, 100);
            this.textBox9.Margin = new System.Windows.Forms.Padding(0);
            this.textBox9.MinimumSize = new System.Drawing.Size(2, 25);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(132, 16);
            this.textBox9.TabIndex = 6;
            this.textBox9.Text = "Reservation Dates";
            this.textBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox8
            // 
            this.textBox8.BackColor = System.Drawing.SystemColors.Control;
            this.textBox8.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox8.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox8.Font = new System.Drawing.Font("Arial", 10F);
            this.textBox8.Location = new System.Drawing.Point(4, 208);
            this.textBox8.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.textBox8.MinimumSize = new System.Drawing.Size(2, 25);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(132, 16);
            this.textBox8.TabIndex = 5;
            this.textBox8.Text = "Address";
            this.textBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.SystemColors.Control;
            this.textBox7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox7.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox7.Font = new System.Drawing.Font("Arial", 10F);
            this.textBox7.Location = new System.Drawing.Point(4, 154);
            this.textBox7.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.textBox7.MinimumSize = new System.Drawing.Size(2, 25);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(132, 16);
            this.textBox7.TabIndex = 4;
            this.textBox7.Text = "Origin of Request";
            this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.SystemColors.Control;
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox6.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox6.Font = new System.Drawing.Font("Arial", 10F);
            this.textBox6.Location = new System.Drawing.Point(4, 181);
            this.textBox6.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.textBox6.MinimumSize = new System.Drawing.Size(2, 25);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(132, 16);
            this.textBox6.TabIndex = 3;
            this.textBox6.Text = "Contact Number";
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.SystemColors.Control;
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox5.Font = new System.Drawing.Font("Arial", 10F);
            this.textBox5.Location = new System.Drawing.Point(4, 127);
            this.textBox5.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.textBox5.MinimumSize = new System.Drawing.Size(2, 25);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(132, 16);
            this.textBox5.TabIndex = 2;
            this.textBox5.Text = "Requesting Office";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.Control;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox4.Font = new System.Drawing.Font("Arial", 10F);
            this.textBox4.Location = new System.Drawing.Point(4, 100);
            this.textBox4.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.textBox4.MinimumSize = new System.Drawing.Size(2, 25);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(132, 16);
            this.textBox4.TabIndex = 1;
            this.textBox4.Text = "Requesting Person";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pnl_Billing_Details
            // 
            this.pnl_Billing_Details.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_Billing_Details.Controls.Add(this.button1);
            this.pnl_Billing_Details.Controls.Add(this.btn_Delete_Equipment_Billing);
            this.pnl_Billing_Details.Controls.Add(this.lbl_fld_Total_Amount);
            this.pnl_Billing_Details.Controls.Add(this.textBox1);
            this.pnl_Billing_Details.Controls.Add(this.btn_Add_Equipment_Billing);
            this.pnl_Billing_Details.Controls.Add(this.lbl_Reservation_Status);
            this.pnl_Billing_Details.Controls.Add(this.textBox13);
            this.pnl_Billing_Details.Controls.Add(this.dgv_Equipment_Billing_Records);
            this.pnl_Billing_Details.Controls.Add(this.textBox38);
            this.pnl_Billing_Details.Controls.Add(this.lbl_Rate_Type);
            this.pnl_Billing_Details.Controls.Add(this.textBox35);
            this.pnl_Billing_Details.Controls.Add(this.textBox36);
            this.pnl_Billing_Details.Controls.Add(this.textBox26);
            this.pnl_Billing_Details.Controls.Add(this.lbl_Control_Number);
            this.pnl_Billing_Details.Controls.Add(this.lbl_Reservation_Dates);
            this.pnl_Billing_Details.Controls.Add(this.lbl_Address);
            this.pnl_Billing_Details.Controls.Add(this.lbl_Contact_Number);
            this.pnl_Billing_Details.Controls.Add(this.lbl_Origin_Request);
            this.pnl_Billing_Details.Controls.Add(this.lbl_Requesting_Office);
            this.pnl_Billing_Details.Controls.Add(this.lbl_Requesting_Person);
            this.pnl_Billing_Details.Controls.Add(this.textBox15);
            this.pnl_Billing_Details.Controls.Add(this.textBox9);
            this.pnl_Billing_Details.Controls.Add(this.textBox8);
            this.pnl_Billing_Details.Controls.Add(this.textBox7);
            this.pnl_Billing_Details.Controls.Add(this.textBox6);
            this.pnl_Billing_Details.Controls.Add(this.textBox5);
            this.pnl_Billing_Details.Controls.Add(this.textBox4);
            this.pnl_Billing_Details.Controls.Add(this.textBox3);
            this.pnl_Billing_Details.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Billing_Details.Location = new System.Drawing.Point(0, 0);
            this.pnl_Billing_Details.MaximumSize = new System.Drawing.Size(810, 700);
            this.pnl_Billing_Details.MinimumSize = new System.Drawing.Size(810, 700);
            this.pnl_Billing_Details.Name = "pnl_Billing_Details";
            this.pnl_Billing_Details.Size = new System.Drawing.Size(810, 700);
            this.pnl_Billing_Details.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(420, 287);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 23);
            this.button1.TabIndex = 53;
            this.button1.Text = "next feature extend";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btn_Delete_Equipment_Billing
            // 
            this.btn_Delete_Equipment_Billing.Location = new System.Drawing.Point(338, 287);
            this.btn_Delete_Equipment_Billing.Name = "btn_Delete_Equipment_Billing";
            this.btn_Delete_Equipment_Billing.Size = new System.Drawing.Size(75, 23);
            this.btn_Delete_Equipment_Billing.TabIndex = 52;
            this.btn_Delete_Equipment_Billing.Text = "DELETE";
            this.btn_Delete_Equipment_Billing.UseVisualStyleBackColor = true;
            this.btn_Delete_Equipment_Billing.Click += new System.EventHandler(this.btn_Delete_Equipment_Billing_Click);
            // 
            // lbl_fld_Total_Amount
            // 
            this.lbl_fld_Total_Amount.Location = new System.Drawing.Point(363, 261);
            this.lbl_fld_Total_Amount.Name = "lbl_fld_Total_Amount";
            this.lbl_fld_Total_Amount.Size = new System.Drawing.Size(100, 20);
            this.lbl_fld_Total_Amount.TabIndex = 51;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(257, 261);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 50;
            this.textBox1.Text = "Overall Total";
            // 
            // btn_Add_Equipment_Billing
            // 
            this.btn_Add_Equipment_Billing.Location = new System.Drawing.Point(257, 287);
            this.btn_Add_Equipment_Billing.Name = "btn_Add_Equipment_Billing";
            this.btn_Add_Equipment_Billing.Size = new System.Drawing.Size(75, 23);
            this.btn_Add_Equipment_Billing.TabIndex = 49;
            this.btn_Add_Equipment_Billing.Text = "ADD";
            this.btn_Add_Equipment_Billing.UseVisualStyleBackColor = true;
            this.btn_Add_Equipment_Billing.Click += new System.EventHandler(this.btn_Add_Equipment_Billing_Click);
            // 
            // lbl_Reservation_Status
            // 
            this.lbl_Reservation_Status.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_Reservation_Status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Reservation_Status.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbl_Reservation_Status.Font = new System.Drawing.Font("Arial", 10F);
            this.lbl_Reservation_Status.Location = new System.Drawing.Point(547, 129);
            this.lbl_Reservation_Status.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_Reservation_Status.MinimumSize = new System.Drawing.Size(2, 25);
            this.lbl_Reservation_Status.Name = "lbl_Reservation_Status";
            this.lbl_Reservation_Status.ReadOnly = true;
            this.lbl_Reservation_Status.Size = new System.Drawing.Size(249, 23);
            this.lbl_Reservation_Status.TabIndex = 48;
            // 
            // textBox13
            // 
            this.textBox13.BackColor = System.Drawing.SystemColors.Control;
            this.textBox13.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox13.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox13.Font = new System.Drawing.Font("Arial", 10F);
            this.textBox13.Location = new System.Drawing.Point(401, 129);
            this.textBox13.Margin = new System.Windows.Forms.Padding(0);
            this.textBox13.MinimumSize = new System.Drawing.Size(2, 25);
            this.textBox13.Name = "textBox13";
            this.textBox13.ReadOnly = true;
            this.textBox13.Size = new System.Drawing.Size(132, 16);
            this.textBox13.TabIndex = 47;
            this.textBox13.Text = "Status";
            this.textBox13.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dgv_Equipment_Billing_Records
            // 
            this.dgv_Equipment_Billing_Records.AllowUserToAddRows = false;
            this.dgv_Equipment_Billing_Records.AllowUserToDeleteRows = false;
            this.dgv_Equipment_Billing_Records.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Equipment_Billing_Records.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_fk_Reservation_ID,
            this.col_Start_Date_Eq,
            this.col_End_Date_Eq,
            this.col_OT_Days,
            this.col_Reservation_EquipmentID,
            this.col_fk_EquipmentID,
            this.col_fk_Equipment_PricingID,
            this.col_Quantity,
            this.col_fld_Number_Of_Days,
            this.col_fld_Total_Equipment_Cost,
            this.col_fld_Equipment_Name,
            this.col_fld_Equipment_Price,
            this.col_fld_Equipment_Price_Subsequent,
            this.col_Total});
            this.dgv_Equipment_Billing_Records.Location = new System.Drawing.Point(6, 331);
            this.dgv_Equipment_Billing_Records.Name = "dgv_Equipment_Billing_Records";
            this.dgv_Equipment_Billing_Records.ReadOnly = true;
            this.dgv_Equipment_Billing_Records.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Equipment_Billing_Records.Size = new System.Drawing.Size(790, 352);
            this.dgv_Equipment_Billing_Records.TabIndex = 46;
            // 
            // textBox38
            // 
            this.textBox38.BackColor = System.Drawing.SystemColors.Control;
            this.textBox38.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox38.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox38.Font = new System.Drawing.Font("Arial", 10F);
            this.textBox38.Location = new System.Drawing.Point(4, 75);
            this.textBox38.Margin = new System.Windows.Forms.Padding(0);
            this.textBox38.MinimumSize = new System.Drawing.Size(2, 21);
            this.textBox38.Name = "textBox38";
            this.textBox38.ReadOnly = true;
            this.textBox38.Size = new System.Drawing.Size(792, 23);
            this.textBox38.TabIndex = 45;
            // 
            // lbl_Rate_Type
            // 
            this.lbl_Rate_Type.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_Rate_Type.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbl_Rate_Type.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbl_Rate_Type.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Rate_Type.Location = new System.Drawing.Point(136, 280);
            this.lbl_Rate_Type.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_Rate_Type.MinimumSize = new System.Drawing.Size(0, 25);
            this.lbl_Rate_Type.Name = "lbl_Rate_Type";
            this.lbl_Rate_Type.ReadOnly = true;
            this.lbl_Rate_Type.Size = new System.Drawing.Size(87, 20);
            this.lbl_Rate_Type.TabIndex = 35;
            this.lbl_Rate_Type.Text = "Description";
            // 
            // textBox35
            // 
            this.textBox35.BackColor = System.Drawing.SystemColors.Control;
            this.textBox35.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox35.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox35.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox35.Location = new System.Drawing.Point(6, 280);
            this.textBox35.Margin = new System.Windows.Forms.Padding(0);
            this.textBox35.MinimumSize = new System.Drawing.Size(0, 25);
            this.textBox35.Name = "textBox35";
            this.textBox35.ReadOnly = true;
            this.textBox35.Size = new System.Drawing.Size(103, 20);
            this.textBox35.TabIndex = 30;
            this.textBox35.Text = "Rate Type";
            // 
            // textBox36
            // 
            this.textBox36.BackColor = System.Drawing.SystemColors.Control;
            this.textBox36.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox36.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox36.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox36.Location = new System.Drawing.Point(4, 248);
            this.textBox36.Margin = new System.Windows.Forms.Padding(0);
            this.textBox36.MinimumSize = new System.Drawing.Size(0, 30);
            this.textBox36.Name = "textBox36";
            this.textBox36.ReadOnly = true;
            this.textBox36.Size = new System.Drawing.Size(243, 19);
            this.textBox36.TabIndex = 29;
            this.textBox36.Text = "TRANSACTION DETAILS";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Control;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(6, 57);
            this.textBox3.Margin = new System.Windows.Forms.Padding(0);
            this.textBox3.MinimumSize = new System.Drawing.Size(2, 30);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(196, 19);
            this.textBox3.TabIndex = 0;
            this.textBox3.Text = "CLIENT INFORMATION";
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
            // col_fk_Reservation_ID
            // 
            this.col_fk_Reservation_ID.DataPropertyName = "pk_ReservationID";
            this.col_fk_Reservation_ID.HeaderText = "Reservation ID";
            this.col_fk_Reservation_ID.Name = "col_fk_Reservation_ID";
            this.col_fk_Reservation_ID.ReadOnly = true;
            // 
            // col_Start_Date_Eq
            // 
            this.col_Start_Date_Eq.DataPropertyName = "fld_Start_Date_Eq";
            this.col_Start_Date_Eq.HeaderText = "Start Date";
            this.col_Start_Date_Eq.Name = "col_Start_Date_Eq";
            this.col_Start_Date_Eq.ReadOnly = true;
            // 
            // col_End_Date_Eq
            // 
            this.col_End_Date_Eq.DataPropertyName = "fld_End_Date_Eq";
            this.col_End_Date_Eq.HeaderText = "End Date";
            this.col_End_Date_Eq.Name = "col_End_Date_Eq";
            this.col_End_Date_Eq.ReadOnly = true;
            // 
            // col_OT_Days
            // 
            this.col_OT_Days.DataPropertyName = "fld_OT_Days";
            this.col_OT_Days.HeaderText = "OT Days";
            this.col_OT_Days.Name = "col_OT_Days";
            this.col_OT_Days.ReadOnly = true;
            // 
            // col_Reservation_EquipmentID
            // 
            this.col_Reservation_EquipmentID.DataPropertyName = "pk_Reservation_EquipmentID";
            this.col_Reservation_EquipmentID.HeaderText = "Reservation Equipment ID";
            this.col_Reservation_EquipmentID.Name = "col_Reservation_EquipmentID";
            this.col_Reservation_EquipmentID.ReadOnly = true;
            // 
            // col_fk_EquipmentID
            // 
            this.col_fk_EquipmentID.DataPropertyName = "fk_EquipmentID";
            this.col_fk_EquipmentID.HeaderText = "Equipment ID";
            this.col_fk_EquipmentID.Name = "col_fk_EquipmentID";
            this.col_fk_EquipmentID.ReadOnly = true;
            // 
            // col_fk_Equipment_PricingID
            // 
            this.col_fk_Equipment_PricingID.DataPropertyName = "fk_Equipment_PricingID";
            this.col_fk_Equipment_PricingID.HeaderText = "Equipment Pricing ID";
            this.col_fk_Equipment_PricingID.Name = "col_fk_Equipment_PricingID";
            this.col_fk_Equipment_PricingID.ReadOnly = true;
            // 
            // col_Quantity
            // 
            this.col_Quantity.DataPropertyName = "fld_Quantity";
            this.col_Quantity.HeaderText = "Quantity";
            this.col_Quantity.Name = "col_Quantity";
            this.col_Quantity.ReadOnly = true;
            // 
            // col_fld_Number_Of_Days
            // 
            this.col_fld_Number_Of_Days.DataPropertyName = "fld_Number_Of_Days";
            this.col_fld_Number_Of_Days.HeaderText = "Days";
            this.col_fld_Number_Of_Days.Name = "col_fld_Number_Of_Days";
            this.col_fld_Number_Of_Days.ReadOnly = true;
            // 
            // col_fld_Total_Equipment_Cost
            // 
            this.col_fld_Total_Equipment_Cost.DataPropertyName = "fld_Total_Equipment_Cost";
            this.col_fld_Total_Equipment_Cost.HeaderText = "Total Equipment Cost";
            this.col_fld_Total_Equipment_Cost.Name = "col_fld_Total_Equipment_Cost";
            this.col_fld_Total_Equipment_Cost.ReadOnly = true;
            // 
            // col_fld_Equipment_Name
            // 
            this.col_fld_Equipment_Name.DataPropertyName = "fld_Equipment_Name";
            this.col_fld_Equipment_Name.HeaderText = "Equipment Name";
            this.col_fld_Equipment_Name.Name = "col_fld_Equipment_Name";
            this.col_fld_Equipment_Name.ReadOnly = true;
            // 
            // col_fld_Equipment_Price
            // 
            this.col_fld_Equipment_Price.DataPropertyName = "fld_Equipment_Price";
            this.col_fld_Equipment_Price.HeaderText = "Base Price";
            this.col_fld_Equipment_Price.Name = "col_fld_Equipment_Price";
            this.col_fld_Equipment_Price.ReadOnly = true;
            // 
            // col_fld_Equipment_Price_Subsequent
            // 
            this.col_fld_Equipment_Price_Subsequent.DataPropertyName = "fld_Equipment_Price_Subsequent";
            this.col_fld_Equipment_Price_Subsequent.HeaderText = "Sub Price";
            this.col_fld_Equipment_Price_Subsequent.Name = "col_fld_Equipment_Price_Subsequent";
            this.col_fld_Equipment_Price_Subsequent.ReadOnly = true;
            // 
            // col_Total
            // 
            this.col_Total.HeaderText = "Total";
            this.col_Total.Name = "col_Total";
            this.col_Total.ReadOnly = true;
            // 
            // Equipment_User_Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnl_Billing_Details);
            this.MaximumSize = new System.Drawing.Size(810, 700);
            this.MinimumSize = new System.Drawing.Size(810, 700);
            this.Name = "Equipment_User_Control";
            this.Size = new System.Drawing.Size(810, 700);
            this.pnl_Billing_Details.ResumeLayout(false);
            this.pnl_Billing_Details.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Equipment_Billing_Records)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._BRIS_EXPERIMENT_3_0DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblReservationEquipmentBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox textBox26;
        private System.Windows.Forms.TextBox lbl_Control_Number;
        private System.Windows.Forms.TextBox lbl_Reservation_Dates;
        private System.Windows.Forms.TextBox lbl_Address;
        private System.Windows.Forms.TextBox lbl_Contact_Number;
        private System.Windows.Forms.TextBox lbl_Origin_Request;
        private System.Windows.Forms.TextBox lbl_Requesting_Office;
        private System.Windows.Forms.TextBox lbl_Requesting_Person;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Panel pnl_Billing_Details;
        private System.Windows.Forms.TextBox textBox38;
        private System.Windows.Forms.TextBox lbl_Rate_Type;
        private System.Windows.Forms.TextBox textBox35;
        private System.Windows.Forms.TextBox textBox36;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.DataGridView dgv_Equipment_Billing_Records;
        private System.Windows.Forms.BindingSource tblReservationEquipmentBindingSource;
        private _BRIS_EXPERIMENT_3_0DataSet _BRIS_EXPERIMENT_3_0DataSet;
        private _BRIS_EXPERIMENT_3_0DataSetTableAdapters.tbl_Reservation_EquipmentTableAdapter tbl_Reservation_EquipmentTableAdapter;
        private System.Windows.Forms.TextBox lbl_Reservation_Status;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.Button btn_Add_Equipment_Billing;
        private System.Windows.Forms.TextBox lbl_fld_Total_Amount;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_Delete_Equipment_Billing;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_fk_Reservation_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Start_Date_Eq;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_End_Date_Eq;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_OT_Days;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Reservation_EquipmentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_fk_EquipmentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_fk_Equipment_PricingID;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_fld_Number_Of_Days;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_fld_Total_Equipment_Cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_fld_Equipment_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_fld_Equipment_Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_fld_Equipment_Price_Subsequent;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Total;
    }
}
