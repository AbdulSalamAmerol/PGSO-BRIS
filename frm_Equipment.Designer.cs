namespace pgso
{
    partial class frm_Equipment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dt_equipment = new System.Windows.Forms.DataGridView();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Control_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Equipment_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Created = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Equipment_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Total_Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel_Information = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.txt_Contact = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_Update = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_Requesting_Office = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_Number_of_Days = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_Total = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_Status = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_Purpose = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_Date_Start = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Quantity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Equipment_Name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Address = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Fname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_CN = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.combobox_Filter = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.combo_Sort = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblPageInfo = new System.Windows.Forms.Label();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.btnPrevPage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dt_equipment)).BeginInit();
            this.panel_Information.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dt_equipment
            // 
            this.dt_equipment.AllowUserToAddRows = false;
            this.dt_equipment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dt_equipment.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dt_equipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt_equipment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Item,
            this.fld_Control_Number,
            this.fld_Quantity,
            this.fld_Equipment_Name,
            this.Date,
            this.Created,
            this.fld_Equipment_Status,
            this.fld_Total_Amount});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dt_equipment.DefaultCellStyle = dataGridViewCellStyle9;
            this.dt_equipment.Location = new System.Drawing.Point(15, 64);
            this.dt_equipment.Name = "dt_equipment";
            this.dt_equipment.ReadOnly = true;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dt_equipment.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dt_equipment.RowHeadersVisible = false;
            this.dt_equipment.Size = new System.Drawing.Size(1507, 881);
            this.dt_equipment.TabIndex = 1;
            this.dt_equipment.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dt_equipment_CellContentClick);
            // 
            // Item
            // 
            this.Item.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Item.DefaultCellStyle = dataGridViewCellStyle7;
            this.Item.HeaderText = "Item";
            this.Item.Name = "Item";
            this.Item.ReadOnly = true;
            this.Item.Width = 50;
            // 
            // fld_Control_Number
            // 
            this.fld_Control_Number.DataPropertyName = "fld_Control_Number";
            this.fld_Control_Number.FillWeight = 57.44501F;
            this.fld_Control_Number.HeaderText = "Control Number";
            this.fld_Control_Number.Name = "fld_Control_Number";
            this.fld_Control_Number.ReadOnly = true;
            // 
            // fld_Quantity
            // 
            this.fld_Quantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.fld_Quantity.DataPropertyName = "fld_Quantity";
            this.fld_Quantity.FillWeight = 355.33F;
            this.fld_Quantity.HeaderText = "Quantity";
            this.fld_Quantity.Name = "fld_Quantity";
            this.fld_Quantity.ReadOnly = true;
            this.fld_Quantity.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.fld_Quantity.Width = 85;
            // 
            // fld_Equipment_Name
            // 
            this.fld_Equipment_Name.DataPropertyName = "fld_Equipment_Name";
            this.fld_Equipment_Name.FillWeight = 57.44501F;
            this.fld_Equipment_Name.HeaderText = "Equipment";
            this.fld_Equipment_Name.Name = "fld_Equipment_Name";
            this.fld_Equipment_Name.ReadOnly = true;
            // 
            // Date
            // 
            this.Date.DataPropertyName = "Date";
            this.Date.FillWeight = 57.44501F;
            this.Date.HeaderText = "Date of Use";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // Created
            // 
            this.Created.DataPropertyName = "fld_Created_At";
            this.Created.FillWeight = 57.44501F;
            this.Created.HeaderText = "Date Requested";
            this.Created.Name = "Created";
            this.Created.ReadOnly = true;
            // 
            // fld_Equipment_Status
            // 
            this.fld_Equipment_Status.DataPropertyName = "fld_Equipment_Status";
            this.fld_Equipment_Status.FillWeight = 57.44501F;
            this.fld_Equipment_Status.HeaderText = "Status";
            this.fld_Equipment_Status.Name = "fld_Equipment_Status";
            this.fld_Equipment_Status.ReadOnly = true;
            // 
            // fld_Total_Amount
            // 
            this.fld_Total_Amount.DataPropertyName = "fld_Total_Amount";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fld_Total_Amount.DefaultCellStyle = dataGridViewCellStyle8;
            this.fld_Total_Amount.FillWeight = 57.44501F;
            this.fld_Total_Amount.HeaderText = "Total";
            this.fld_Total_Amount.Name = "fld_Total_Amount";
            this.fld_Total_Amount.ReadOnly = true;
            // 
            // panel_Information
            // 
            this.panel_Information.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Information.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel_Information.Controls.Add(this.label17);
            this.panel_Information.Controls.Add(this.txt_Contact);
            this.panel_Information.Controls.Add(this.label7);
            this.panel_Information.Controls.Add(this.btn_Update);
            this.panel_Information.Controls.Add(this.label15);
            this.panel_Information.Controls.Add(this.txt_Requesting_Office);
            this.panel_Information.Controls.Add(this.label9);
            this.panel_Information.Controls.Add(this.txt_Number_of_Days);
            this.panel_Information.Controls.Add(this.label11);
            this.panel_Information.Controls.Add(this.txt_Total);
            this.panel_Information.Controls.Add(this.label10);
            this.panel_Information.Controls.Add(this.txt_Status);
            this.panel_Information.Controls.Add(this.label8);
            this.panel_Information.Controls.Add(this.txt_Purpose);
            this.panel_Information.Controls.Add(this.label6);
            this.panel_Information.Controls.Add(this.txt_Date_Start);
            this.panel_Information.Controls.Add(this.label5);
            this.panel_Information.Controls.Add(this.txt_Quantity);
            this.panel_Information.Controls.Add(this.label4);
            this.panel_Information.Controls.Add(this.txt_Equipment_Name);
            this.panel_Information.Controls.Add(this.label3);
            this.panel_Information.Controls.Add(this.txt_Address);
            this.panel_Information.Controls.Add(this.label2);
            this.panel_Information.Controls.Add(this.txt_Fname);
            this.panel_Information.Controls.Add(this.label1);
            this.panel_Information.Controls.Add(this.txt_CN);
            this.panel_Information.Location = new System.Drawing.Point(1548, 64);
            this.panel_Information.Name = "panel_Information";
            this.panel_Information.Size = new System.Drawing.Size(364, 473);
            this.panel_Information.TabIndex = 8;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(16, 112);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(68, 20);
            this.label17.TabIndex = 50;
            this.label17.Text = "Address";
            // 
            // txt_Contact
            // 
            this.txt_Contact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Contact.Location = new System.Drawing.Point(158, 102);
            this.txt_Contact.Name = "txt_Contact";
            this.txt_Contact.ReadOnly = true;
            this.txt_Contact.Size = new System.Drawing.Size(190, 26);
            this.txt_Contact.TabIndex = 49;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(16, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(162, 17);
            this.label7.TabIndex = 48;
            this.label7.Text = "Reservation Information";
            // 
            // btn_Update
            // 
            this.btn_Update.BackColor = System.Drawing.Color.Green;
            this.btn_Update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Update.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Update.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Update.Location = new System.Drawing.Point(271, 426);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(75, 35);
            this.btn_Update.TabIndex = 33;
            this.btn_Update.Text = "Update";
            this.btn_Update.UseVisualStyleBackColor = false;
            this.btn_Update.Visible = false;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(16, 144);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(68, 20);
            this.label15.TabIndex = 32;
            this.label15.Text = "Address";
            // 
            // txt_Requesting_Office
            // 
            this.txt_Requesting_Office.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Requesting_Office.Location = new System.Drawing.Point(158, 166);
            this.txt_Requesting_Office.Name = "txt_Requesting_Office";
            this.txt_Requesting_Office.ReadOnly = true;
            this.txt_Requesting_Office.Size = new System.Drawing.Size(190, 26);
            this.txt_Requesting_Office.TabIndex = 31;
            this.txt_Requesting_Office.TextChanged += new System.EventHandler(this.txt_Requesting_Office_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(16, 308);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(127, 20);
            this.label9.TabIndex = 28;
            this.label9.Text = "Number of Days:";
            // 
            // txt_Number_of_Days
            // 
            this.txt_Number_of_Days.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Number_of_Days.Location = new System.Drawing.Point(156, 298);
            this.txt_Number_of_Days.Name = "txt_Number_of_Days";
            this.txt_Number_of_Days.ReadOnly = true;
            this.txt_Number_of_Days.Size = new System.Drawing.Size(190, 26);
            this.txt_Number_of_Days.TabIndex = 27;
            this.txt_Number_of_Days.TextChanged += new System.EventHandler(this.txt_Number_of_Days_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(16, 404);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(129, 20);
            this.label11.TabIndex = 23;
            this.label11.Text = "Equipment Price:";
            // 
            // txt_Total
            // 
            this.txt_Total.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Total.Location = new System.Drawing.Point(158, 394);
            this.txt_Total.Name = "txt_Total";
            this.txt_Total.ReadOnly = true;
            this.txt_Total.Size = new System.Drawing.Size(190, 26);
            this.txt_Total.TabIndex = 22;
            this.txt_Total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_Total.TextChanged += new System.EventHandler(this.txt_Total_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(18, 372);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 20);
            this.label10.TabIndex = 21;
            this.label10.Text = "Status:";
            // 
            // txt_Status
            // 
            this.txt_Status.BackColor = System.Drawing.SystemColors.Control;
            this.txt_Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Status.Location = new System.Drawing.Point(158, 362);
            this.txt_Status.Name = "txt_Status";
            this.txt_Status.ReadOnly = true;
            this.txt_Status.Size = new System.Drawing.Size(190, 26);
            this.txt_Status.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(17, 340);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 20);
            this.label8.TabIndex = 15;
            this.label8.Text = "Purpose:";
            // 
            // txt_Purpose
            // 
            this.txt_Purpose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Purpose.Location = new System.Drawing.Point(158, 330);
            this.txt_Purpose.Name = "txt_Purpose";
            this.txt_Purpose.ReadOnly = true;
            this.txt_Purpose.Size = new System.Drawing.Size(190, 26);
            this.txt_Purpose.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(17, 271);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Date of Use:";
            // 
            // txt_Date_Start
            // 
            this.txt_Date_Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Date_Start.Location = new System.Drawing.Point(158, 261);
            this.txt_Date_Start.Name = "txt_Date_Start";
            this.txt_Date_Start.ReadOnly = true;
            this.txt_Date_Start.Size = new System.Drawing.Size(188, 26);
            this.txt_Date_Start.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 239);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Quantity:";
            // 
            // txt_Quantity
            // 
            this.txt_Quantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Quantity.Location = new System.Drawing.Point(158, 229);
            this.txt_Quantity.Name = "txt_Quantity";
            this.txt_Quantity.ReadOnly = true;
            this.txt_Quantity.Size = new System.Drawing.Size(190, 26);
            this.txt_Quantity.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Equipment:";
            // 
            // txt_Equipment_Name
            // 
            this.txt_Equipment_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Equipment_Name.Location = new System.Drawing.Point(158, 197);
            this.txt_Equipment_Name.Name = "txt_Equipment_Name";
            this.txt_Equipment_Name.ReadOnly = true;
            this.txt_Equipment_Name.Size = new System.Drawing.Size(190, 26);
            this.txt_Equipment_Name.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Requesting Office";
            // 
            // txt_Address
            // 
            this.txt_Address.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Address.Location = new System.Drawing.Point(158, 134);
            this.txt_Address.Name = "txt_Address";
            this.txt_Address.ReadOnly = true;
            this.txt_Address.Size = new System.Drawing.Size(190, 26);
            this.txt_Address.TabIndex = 4;
            this.txt_Address.TextChanged += new System.EventHandler(this.txt_Address_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name:";
            // 
            // txt_Fname
            // 
            this.txt_Fname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Fname.Location = new System.Drawing.Point(158, 64);
            this.txt_Fname.Name = "txt_Fname";
            this.txt_Fname.ReadOnly = true;
            this.txt_Fname.Size = new System.Drawing.Size(190, 26);
            this.txt_Fname.TabIndex = 2;
            this.txt_Fname.TextChanged += new System.EventHandler(this.txt_Fname_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Control Number:";
            // 
            // txt_CN
            // 
            this.txt_CN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_CN.Location = new System.Drawing.Point(158, 33);
            this.txt_CN.Name = "txt_CN";
            this.txt_CN.ReadOnly = true;
            this.txt_CN.Size = new System.Drawing.Size(190, 26);
            this.txt_CN.TabIndex = 0;
            this.txt_CN.TextChanged += new System.EventHandler(this.txt_CN_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(75, 35);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(175, 23);
            this.textBox1.TabIndex = 9;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // combobox_Filter
            // 
            this.combobox_Filter.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combobox_Filter.FormattingEnabled = true;
            this.combobox_Filter.Location = new System.Drawing.Point(83, 9);
            this.combobox_Filter.Name = "combobox_Filter";
            this.combobox_Filter.Size = new System.Drawing.Size(121, 25);
            this.combobox_Filter.TabIndex = 10;
            this.combobox_Filter.SelectedIndexChanged += new System.EventHandler(this.combobox_Filter_SelectedIndexChanged_1);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(14, 35);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 17);
            this.label13.TabIndex = 11;
            this.label13.Text = "Search:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(7, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(114, 23);
            this.label16.TabIndex = 13;
            this.label16.Text = "EQUIPMENT";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label12);
            this.panel5.Controls.Add(this.label18);
            this.panel5.Controls.Add(this.combo_Sort);
            this.panel5.Controls.Add(this.combobox_Filter);
            this.panel5.Location = new System.Drawing.Point(1085, 21);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(238, 37);
            this.panel5.TabIndex = 35;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(12, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 20);
            this.label12.TabIndex = 3;
            this.label12.Text = "Fiter by:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(224, 8);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(63, 20);
            this.label18.TabIndex = 1;
            this.label18.Text = "Sort by:";
            this.label18.Visible = false;
            // 
            // combo_Sort
            // 
            this.combo_Sort.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_Sort.FormattingEnabled = true;
            this.combo_Sort.Location = new System.Drawing.Point(299, 6);
            this.combo_Sort.Name = "combo_Sort";
            this.combo_Sort.Size = new System.Drawing.Size(121, 28);
            this.combo_Sort.TabIndex = 0;
            this.combo_Sort.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblPageInfo);
            this.panel3.Controls.Add(this.btnNextPage);
            this.panel3.Controls.Add(this.btnPrevPage);
            this.panel3.Location = new System.Drawing.Point(1329, 20);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(193, 38);
            this.panel3.TabIndex = 33;
            // 
            // lblPageInfo
            // 
            this.lblPageInfo.AutoSize = true;
            this.lblPageInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageInfo.Location = new System.Drawing.Point(55, 11);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(75, 16);
            this.lblPageInfo.TabIndex = 17;
            this.lblPageInfo.Text = "lblPageInfo";
            // 
            // btnNextPage
            // 
            this.btnNextPage.Location = new System.Drawing.Point(136, 8);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(46, 23);
            this.btnNextPage.TabIndex = 1;
            this.btnNextPage.Text = ">>";
            this.btnNextPage.UseVisualStyleBackColor = true;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // btnPrevPage
            // 
            this.btnPrevPage.Location = new System.Drawing.Point(3, 8);
            this.btnPrevPage.Name = "btnPrevPage";
            this.btnPrevPage.Size = new System.Drawing.Size(46, 23);
            this.btnPrevPage.TabIndex = 0;
            this.btnPrevPage.Text = "<<";
            this.btnPrevPage.UseVisualStyleBackColor = true;
            this.btnPrevPage.Click += new System.EventHandler(this.btnPrevPage_Click);
            // 
            // frm_Equipment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1061);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel_Information);
            this.Controls.Add(this.dt_equipment);
            this.Name = "frm_Equipment";
            this.Text = "frm_Equipment";
            this.Load += new System.EventHandler(this.frm_Equipment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dt_equipment)).EndInit();
            this.panel_Information.ResumeLayout(false);
            this.panel_Information.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dt_equipment;
        private System.Windows.Forms.Panel panel_Information;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_Total;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_Status;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_Purpose;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_Date_Start;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Quantity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Equipment_Name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Address;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Fname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_CN;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_Number_of_Days;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox combobox_Filter;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txt_Requesting_Office;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txt_Contact;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox combo_Sort;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblPageInfo;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Button btnPrevPage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Control_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Equipment_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Created;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Equipment_Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Total_Amount;
    }
}