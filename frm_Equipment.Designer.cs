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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dt_equipment = new System.Windows.Forms.DataGridView();
            this.fld_Control_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Equipment_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Reservation_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Total_Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel_Information = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_Reservation_type = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_Number_of_Days = new System.Windows.Forms.TextBox();
            this.txt_Sname = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_Total = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_Status = new System.Windows.Forms.TextBox();
            this.txt_HourEnd = new System.Windows.Forms.TextBox();
            this.txt_DateEnd = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_Purpose = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_HourStart = new System.Windows.Forms.TextBox();
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
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_Requesting_Office = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dt_equipment)).BeginInit();
            this.panel_Information.SuspendLayout();
            this.SuspendLayout();
            // 
            // dt_equipment
            // 
            this.dt_equipment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dt_equipment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dt_equipment.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dt_equipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt_equipment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fld_Control_Number,
            this.fld_Quantity,
            this.fld_Equipment_Name,
            this.fld_Reservation_Status,
            this.fld_Total_Amount});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dt_equipment.DefaultCellStyle = dataGridViewCellStyle2;
            this.dt_equipment.Location = new System.Drawing.Point(12, 82);
            this.dt_equipment.Name = "dt_equipment";
            this.dt_equipment.ReadOnly = true;
            this.dt_equipment.RowHeadersVisible = false;
            this.dt_equipment.Size = new System.Drawing.Size(903, 603);
            this.dt_equipment.TabIndex = 1;
            // 
            // fld_Control_Number
            // 
            this.fld_Control_Number.DataPropertyName = "fld_Control_Number";
            this.fld_Control_Number.HeaderText = "Control Number";
            this.fld_Control_Number.Name = "fld_Control_Number";
            this.fld_Control_Number.ReadOnly = true;
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
            // panel_Information
            // 
            this.panel_Information.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Information.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel_Information.Controls.Add(this.label15);
            this.panel_Information.Controls.Add(this.txt_Requesting_Office);
            this.panel_Information.Controls.Add(this.label12);
            this.panel_Information.Controls.Add(this.txt_Reservation_type);
            this.panel_Information.Controls.Add(this.label9);
            this.panel_Information.Controls.Add(this.txt_Number_of_Days);
            this.panel_Information.Controls.Add(this.txt_Sname);
            this.panel_Information.Controls.Add(this.label11);
            this.panel_Information.Controls.Add(this.txt_Total);
            this.panel_Information.Controls.Add(this.label10);
            this.panel_Information.Controls.Add(this.txt_Status);
            this.panel_Information.Controls.Add(this.txt_HourEnd);
            this.panel_Information.Controls.Add(this.txt_DateEnd);
            this.panel_Information.Controls.Add(this.label8);
            this.panel_Information.Controls.Add(this.txt_Purpose);
            this.panel_Information.Controls.Add(this.label7);
            this.panel_Information.Controls.Add(this.txt_HourStart);
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
            this.panel_Information.Location = new System.Drawing.Point(921, 12);
            this.panel_Information.Name = "panel_Information";
            this.panel_Information.Size = new System.Drawing.Size(319, 654);
            this.panel_Information.TabIndex = 8;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(16, 199);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 17);
            this.label12.TabIndex = 30;
            this.label12.Text = "Type:";
            // 
            // txt_Reservation_type
            // 
            this.txt_Reservation_type.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Reservation_type.Location = new System.Drawing.Point(19, 219);
            this.txt_Reservation_type.Name = "txt_Reservation_type";
            this.txt_Reservation_type.ReadOnly = true;
            this.txt_Reservation_type.Size = new System.Drawing.Size(286, 26);
            this.txt_Reservation_type.TabIndex = 29;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(14, 418);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 17);
            this.label9.TabIndex = 28;
            this.label9.Text = "Number of Days:";
            // 
            // txt_Number_of_Days
            // 
            this.txt_Number_of_Days.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Number_of_Days.Location = new System.Drawing.Point(16, 438);
            this.txt_Number_of_Days.Name = "txt_Number_of_Days";
            this.txt_Number_of_Days.ReadOnly = true;
            this.txt_Number_of_Days.Size = new System.Drawing.Size(286, 26);
            this.txt_Number_of_Days.TabIndex = 27;
            // 
            // txt_Sname
            // 
            this.txt_Sname.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Sname.Location = new System.Drawing.Point(175, 72);
            this.txt_Sname.Name = "txt_Sname";
            this.txt_Sname.ReadOnly = true;
            this.txt_Sname.Size = new System.Drawing.Size(128, 26);
            this.txt_Sname.TabIndex = 26;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(16, 585);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 17);
            this.label11.TabIndex = 23;
            this.label11.Text = "Total:";
            // 
            // txt_Total
            // 
            this.txt_Total.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Total.Location = new System.Drawing.Point(19, 605);
            this.txt_Total.Name = "txt_Total";
            this.txt_Total.ReadOnly = true;
            this.txt_Total.Size = new System.Drawing.Size(153, 26);
            this.txt_Total.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(17, 534);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 17);
            this.label10.TabIndex = 21;
            this.label10.Text = "Status:";
            // 
            // txt_Status
            // 
            this.txt_Status.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Status.Location = new System.Drawing.Point(19, 554);
            this.txt_Status.Name = "txt_Status";
            this.txt_Status.ReadOnly = true;
            this.txt_Status.Size = new System.Drawing.Size(286, 26);
            this.txt_Status.TabIndex = 20;
            // 
            // txt_HourEnd
            // 
            this.txt_HourEnd.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_HourEnd.Location = new System.Drawing.Point(191, 379);
            this.txt_HourEnd.Name = "txt_HourEnd";
            this.txt_HourEnd.ReadOnly = true;
            this.txt_HourEnd.Size = new System.Drawing.Size(114, 26);
            this.txt_HourEnd.TabIndex = 17;
            // 
            // txt_DateEnd
            // 
            this.txt_DateEnd.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_DateEnd.Location = new System.Drawing.Point(192, 347);
            this.txt_DateEnd.Name = "txt_DateEnd";
            this.txt_DateEnd.ReadOnly = true;
            this.txt_DateEnd.Size = new System.Drawing.Size(114, 26);
            this.txt_DateEnd.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(18, 475);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 17);
            this.label8.TabIndex = 15;
            this.label8.Text = "Purpose:";
            // 
            // txt_Purpose
            // 
            this.txt_Purpose.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Purpose.Location = new System.Drawing.Point(20, 495);
            this.txt_Purpose.Name = "txt_Purpose";
            this.txt_Purpose.ReadOnly = true;
            this.txt_Purpose.Size = new System.Drawing.Size(286, 26);
            this.txt_Purpose.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 386);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "Hours:";
            // 
            // txt_HourStart
            // 
            this.txt_HourStart.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_HourStart.Location = new System.Drawing.Point(71, 380);
            this.txt_HourStart.Name = "txt_HourStart";
            this.txt_HourStart.ReadOnly = true;
            this.txt_HourStart.Size = new System.Drawing.Size(114, 26);
            this.txt_HourStart.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(17, 353);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Date:";
            // 
            // txt_Date_Start
            // 
            this.txt_Date_Start.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Date_Start.Location = new System.Drawing.Point(71, 347);
            this.txt_Date_Start.Name = "txt_Date_Start";
            this.txt_Date_Start.ReadOnly = true;
            this.txt_Date_Start.Size = new System.Drawing.Size(114, 26);
            this.txt_Date_Start.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 295);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Quantity:";
            // 
            // txt_Quantity
            // 
            this.txt_Quantity.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Quantity.Location = new System.Drawing.Point(19, 315);
            this.txt_Quantity.Name = "txt_Quantity";
            this.txt_Quantity.ReadOnly = true;
            this.txt_Quantity.Size = new System.Drawing.Size(286, 26);
            this.txt_Quantity.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 249);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Equipment:";
            // 
            // txt_Equipment_Name
            // 
            this.txt_Equipment_Name.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Equipment_Name.Location = new System.Drawing.Point(19, 269);
            this.txt_Equipment_Name.Name = "txt_Equipment_Name";
            this.txt_Equipment_Name.ReadOnly = true;
            this.txt_Equipment_Name.Size = new System.Drawing.Size(286, 26);
            this.txt_Equipment_Name.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Requesting Office";
            // 
            // txt_Address
            // 
            this.txt_Address.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Address.Location = new System.Drawing.Point(16, 170);
            this.txt_Address.Name = "txt_Address";
            this.txt_Address.ReadOnly = true;
            this.txt_Address.Size = new System.Drawing.Size(286, 26);
            this.txt_Address.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name:";
            // 
            // txt_Fname
            // 
            this.txt_Fname.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Fname.Location = new System.Drawing.Point(17, 72);
            this.txt_Fname.Name = "txt_Fname";
            this.txt_Fname.ReadOnly = true;
            this.txt_Fname.Size = new System.Drawing.Size(128, 26);
            this.txt_Fname.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Control Number:";
            // 
            // txt_CN
            // 
            this.txt_CN.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_CN.Location = new System.Drawing.Point(17, 26);
            this.txt_CN.Name = "txt_CN";
            this.txt_CN.ReadOnly = true;
            this.txt_CN.Size = new System.Drawing.Size(286, 26);
            this.txt_CN.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(73, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(175, 23);
            this.textBox1.TabIndex = 9;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // combobox_Filter
            // 
            this.combobox_Filter.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combobox_Filter.FormattingEnabled = true;
            this.combobox_Filter.Location = new System.Drawing.Point(334, 12);
            this.combobox_Filter.Name = "combobox_Filter";
            this.combobox_Filter.Size = new System.Drawing.Size(121, 25);
            this.combobox_Filter.TabIndex = 10;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(12, 12);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 17);
            this.label13.TabIndex = 11;
            this.label13.Text = "Search:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(268, 9);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(60, 17);
            this.label14.TabIndex = 12;
            this.label14.Text = "Filter by:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(13, 150);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(57, 17);
            this.label15.TabIndex = 32;
            this.label15.Text = "Address";
            // 
            // txt_Requesting_Office
            // 
            this.txt_Requesting_Office.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Requesting_Office.Location = new System.Drawing.Point(16, 118);
            this.txt_Requesting_Office.Name = "txt_Requesting_Office";
            this.txt_Requesting_Office.ReadOnly = true;
            this.txt_Requesting_Office.Size = new System.Drawing.Size(286, 26);
            this.txt_Requesting_Office.TabIndex = 31;
            // 
            // frm_Equipment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1252, 697);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.combobox_Filter);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel_Information);
            this.Controls.Add(this.dt_equipment);
            this.Name = "frm_Equipment";
            this.Text = "frm_Equipment";
            this.Load += new System.EventHandler(this.frm_Equipment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dt_equipment)).EndInit();
            this.panel_Information.ResumeLayout(false);
            this.panel_Information.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dt_equipment;
        private System.Windows.Forms.Panel panel_Information;
        private System.Windows.Forms.TextBox txt_Sname;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_Total;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_Status;
        private System.Windows.Forms.TextBox txt_HourEnd;
        private System.Windows.Forms.TextBox txt_DateEnd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_Purpose;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_HourStart;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Control_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Equipment_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Reservation_Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Total_Amount;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_Reservation_type;
        private System.Windows.Forms.ComboBox combobox_Filter;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txt_Requesting_Office;
    }
}