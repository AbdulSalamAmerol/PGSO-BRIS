﻿namespace pgso
{
    partial class frm_Create_Equipment_Reservation
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.combo_Name = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Remaining = new System.Windows.Forms.TextBox();
            this.btn_Remove = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.txt_Price_Subsequent = new System.Windows.Forms.TextBox();
            this.btn_AddEquipment = new System.Windows.Forms.Button();
            this.dgv_Selected_Equipments = new System.Windows.Forms.DataGridView();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EquipmentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label19 = new System.Windows.Forms.Label();
            this.txt_Requesting_Office = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.combo_Origin = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txt_Days_Of_Use = new System.Windows.Forms.TextBox();
            this.txt_Activity = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_Quantity = new System.Windows.Forms.TextBox();
            this.txt_Total = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.combo_Utility = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.Date_End = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_Control_Num = new System.Windows.Forms.TextBox();
            this.btn_clearform = new System.Windows.Forms.Button();
            this.btn_submit = new System.Windows.Forms.Button();
            this.Date_Start = new System.Windows.Forms.DateTimePicker();
            this.txt_Contact = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Address = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Selected_Equipments)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MediumAquamarine;
            this.panel1.Controls.Add(this.combo_Name);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txt_Remaining);
            this.panel1.Controls.Add(this.btn_Remove);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.txt_Price_Subsequent);
            this.panel1.Controls.Add(this.btn_AddEquipment);
            this.panel1.Controls.Add(this.dgv_Selected_Equipments);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.txt_Requesting_Office);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.combo_Origin);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.txt_Days_Of_Use);
            this.panel1.Controls.Add(this.txt_Activity);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.txt_Quantity);
            this.panel1.Controls.Add(this.txt_Total);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.combo_Utility);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.Date_End);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txt_Control_Num);
            this.panel1.Controls.Add(this.btn_clearform);
            this.panel1.Controls.Add(this.btn_submit);
            this.panel1.Controls.Add(this.Date_Start);
            this.panel1.Controls.Add(this.txt_Contact);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txt_Address);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(681, 628);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // combo_Name
            // 
            this.combo_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_Name.FormattingEnabled = true;
            this.combo_Name.Location = new System.Drawing.Point(173, 68);
            this.combo_Name.Name = "combo_Name";
            this.combo_Name.Size = new System.Drawing.Size(482, 28);
            this.combo_Name.TabIndex = 79;
            this.combo_Name.SelectedIndexChanged += new System.EventHandler(this.combo_Name_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(317, 360);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 20);
            this.label5.TabIndex = 78;
            this.label5.Text = "Remaining:";
            // 
            // txt_Remaining
            // 
            this.txt_Remaining.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Remaining.Location = new System.Drawing.Point(406, 355);
            this.txt_Remaining.Name = "txt_Remaining";
            this.txt_Remaining.ReadOnly = true;
            this.txt_Remaining.Size = new System.Drawing.Size(86, 26);
            this.txt_Remaining.TabIndex = 77;
            // 
            // btn_Remove
            // 
            this.btn_Remove.BackColor = System.Drawing.Color.IndianRed;
            this.btn_Remove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Remove.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Remove.ForeColor = System.Drawing.Color.Transparent;
            this.btn_Remove.Location = new System.Drawing.Point(485, 421);
            this.btn_Remove.Name = "btn_Remove";
            this.btn_Remove.Size = new System.Drawing.Size(84, 30);
            this.btn_Remove.TabIndex = 76;
            this.btn_Remove.Text = "Remove";
            this.btn_Remove.UseVisualStyleBackColor = false;
            this.btn_Remove.Click += new System.EventHandler(this.btn_Remove_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(16, 392);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(139, 20);
            this.label21.TabIndex = 70;
            this.label21.Text = "Price Subsequent:";
            // 
            // txt_Price_Subsequent
            // 
            this.txt_Price_Subsequent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Price_Subsequent.Location = new System.Drawing.Point(173, 387);
            this.txt_Price_Subsequent.Name = "txt_Price_Subsequent";
            this.txt_Price_Subsequent.ReadOnly = true;
            this.txt_Price_Subsequent.Size = new System.Drawing.Size(161, 26);
            this.txt_Price_Subsequent.TabIndex = 69;
            this.txt_Price_Subsequent.TextChanged += new System.EventHandler(this.txt_Price_Subsequent_TextChanged);
            // 
            // btn_AddEquipment
            // 
            this.btn_AddEquipment.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btn_AddEquipment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddEquipment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddEquipment.Location = new System.Drawing.Point(575, 421);
            this.btn_AddEquipment.Name = "btn_AddEquipment";
            this.btn_AddEquipment.Size = new System.Drawing.Size(75, 30);
            this.btn_AddEquipment.TabIndex = 68;
            this.btn_AddEquipment.Text = "Add";
            this.btn_AddEquipment.UseVisualStyleBackColor = false;
            this.btn_AddEquipment.Click += new System.EventHandler(this.btn_AddEquipment_Click_1);
            // 
            // dgv_Selected_Equipments
            // 
            this.dgv_Selected_Equipments.AllowUserToAddRows = false;
            this.dgv_Selected_Equipments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Selected_Equipments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Selected_Equipments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Item,
            this.EquipmentName,
            this.Quantity,
            this.Rate,
            this.Total});
            this.dgv_Selected_Equipments.Location = new System.Drawing.Point(31, 457);
            this.dgv_Selected_Equipments.Name = "dgv_Selected_Equipments";
            this.dgv_Selected_Equipments.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Selected_Equipments.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            this.dgv_Selected_Equipments.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Selected_Equipments.Size = new System.Drawing.Size(621, 108);
            this.dgv_Selected_Equipments.TabIndex = 67;
            this.dgv_Selected_Equipments.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Selected_Equipments_CellContentClick);
            // 
            // Item
            // 
            this.Item.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Item.HeaderText = "Item";
            this.Item.Name = "Item";
            this.Item.ReadOnly = true;
            this.Item.Width = 50;
            // 
            // EquipmentName
            // 
            this.EquipmentName.HeaderText = "Equipment";
            this.EquipmentName.Name = "EquipmentName";
            this.EquipmentName.ReadOnly = true;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            // 
            // Rate
            // 
            this.Rate.HeaderText = "Days";
            this.Rate.Name = "Rate";
            this.Rate.ReadOnly = true;
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(17, 137);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(210, 20);
            this.label19.TabIndex = 66;
            this.label19.Text = "Requesting Office(Optional):";
            // 
            // txt_Requesting_Office
            // 
            this.txt_Requesting_Office.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Requesting_Office.Location = new System.Drawing.Point(241, 134);
            this.txt_Requesting_Office.Name = "txt_Requesting_Office";
            this.txt_Requesting_Office.Size = new System.Drawing.Size(412, 26);
            this.txt_Requesting_Office.TabIndex = 65;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(5, 8);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(114, 23);
            this.label17.TabIndex = 64;
            this.label17.Text = "EQUIPMENT";
            // 
            // combo_Origin
            // 
            this.combo_Origin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_Origin.FormattingEnabled = true;
            this.combo_Origin.Location = new System.Drawing.Point(171, 198);
            this.combo_Origin.Name = "combo_Origin";
            this.combo_Origin.Size = new System.Drawing.Size(482, 28);
            this.combo_Origin.TabIndex = 63;
            this.combo_Origin.SelectedIndexChanged += new System.EventHandler(this.combo_Origin_SelectedIndexChanged_1);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(20, 326);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(127, 20);
            this.label18.TabIndex = 62;
            this.label18.Text = "Number of Days:";
            // 
            // txt_Days_Of_Use
            // 
            this.txt_Days_Of_Use.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Days_Of_Use.Location = new System.Drawing.Point(174, 323);
            this.txt_Days_Of_Use.Name = "txt_Days_Of_Use";
            this.txt_Days_Of_Use.Size = new System.Drawing.Size(478, 26);
            this.txt_Days_Of_Use.TabIndex = 59;
            // 
            // txt_Activity
            // 
            this.txt_Activity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Activity.Location = new System.Drawing.Point(172, 232);
            this.txt_Activity.Name = "txt_Activity";
            this.txt_Activity.Size = new System.Drawing.Size(483, 26);
            this.txt_Activity.TabIndex = 56;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(19, 235);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 20);
            this.label7.TabIndex = 55;
            this.label7.Text = "Reason:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(17, 200);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(119, 20);
            this.label20.TabIndex = 53;
            this.label20.Text = "Request Origin:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(502, 360);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 20);
            this.label15.TabIndex = 51;
            this.label15.Text = "Quantity:";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // txt_Quantity
            // 
            this.txt_Quantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Quantity.Location = new System.Drawing.Point(575, 355);
            this.txt_Quantity.Name = "txt_Quantity";
            this.txt_Quantity.Size = new System.Drawing.Size(77, 26);
            this.txt_Quantity.TabIndex = 50;
            this.txt_Quantity.TextChanged += new System.EventHandler(this.txt_Quantity_TextChanged_1);
            // 
            // txt_Total
            // 
            this.txt_Total.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Total.Location = new System.Drawing.Point(462, 389);
            this.txt_Total.Name = "txt_Total";
            this.txt_Total.ReadOnly = true;
            this.txt_Total.Size = new System.Drawing.Size(193, 26);
            this.txt_Total.TabIndex = 49;
            this.txt_Total.TextChanged += new System.EventHandler(this.txt_Total_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(349, 394);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(108, 20);
            this.label14.TabIndex = 48;
            this.label14.Text = "Total Amount:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(127, 352);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 20);
            this.label10.TabIndex = 47;
            // 
            // combo_Utility
            // 
            this.combo_Utility.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_Utility.FormattingEnabled = true;
            this.combo_Utility.Location = new System.Drawing.Point(172, 353);
            this.combo_Utility.Name = "combo_Utility";
            this.combo_Utility.Size = new System.Drawing.Size(136, 28);
            this.combo_Utility.TabIndex = 45;
            this.combo_Utility.SelectedIndexChanged += new System.EventHandler(this.combo_Utility_SelectedIndexChanged_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(17, 360);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 20);
            this.label6.TabIndex = 44;
            this.label6.Text = "Choose Uitlity:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(167, 293);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 20);
            this.label13.TabIndex = 28;
            this.label13.Text = "End:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(167, 265);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 20);
            this.label12.TabIndex = 27;
            this.label12.Text = "Start:";
            // 
            // Date_End
            // 
            this.Date_End.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Date_End.Location = new System.Drawing.Point(225, 291);
            this.Date_End.Name = "Date_End";
            this.Date_End.Size = new System.Drawing.Size(428, 26);
            this.Date_End.TabIndex = 26;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(21, 39);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(124, 20);
            this.label11.TabIndex = 25;
            this.label11.Text = "Control Number:";
            // 
            // txt_Control_Num
            // 
            this.txt_Control_Num.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Control_Num.Location = new System.Drawing.Point(173, 36);
            this.txt_Control_Num.Name = "txt_Control_Num";
            this.txt_Control_Num.ReadOnly = true;
            this.txt_Control_Num.Size = new System.Drawing.Size(224, 26);
            this.txt_Control_Num.TabIndex = 24;
            // 
            // btn_clearform
            // 
            this.btn_clearform.BackColor = System.Drawing.Color.Crimson;
            this.btn_clearform.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_clearform.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_clearform.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_clearform.Location = new System.Drawing.Point(430, 571);
            this.btn_clearform.Name = "btn_clearform";
            this.btn_clearform.Size = new System.Drawing.Size(110, 30);
            this.btn_clearform.TabIndex = 17;
            this.btn_clearform.Text = "Clear";
            this.btn_clearform.UseVisualStyleBackColor = false;
            this.btn_clearform.Click += new System.EventHandler(this.btn_clearform_Click);
            // 
            // btn_submit
            // 
            this.btn_submit.BackColor = System.Drawing.Color.Green;
            this.btn_submit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_submit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_submit.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_submit.Location = new System.Drawing.Point(546, 571);
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.Size = new System.Drawing.Size(107, 30);
            this.btn_submit.TabIndex = 16;
            this.btn_submit.Text = "Submit";
            this.btn_submit.UseVisualStyleBackColor = false;
            this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click_1);
            // 
            // Date_Start
            // 
            this.Date_Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Date_Start.Location = new System.Drawing.Point(225, 263);
            this.Date_Start.Name = "Date_Start";
            this.Date_Start.Size = new System.Drawing.Size(427, 26);
            this.Date_Start.TabIndex = 14;
            this.Date_Start.ValueChanged += new System.EventHandler(this.Date_Start_ValueChanged);
            // 
            // txt_Contact
            // 
            this.txt_Contact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Contact.Location = new System.Drawing.Point(172, 166);
            this.txt_Contact.Name = "txt_Contact";
            this.txt_Contact.Size = new System.Drawing.Size(483, 26);
            this.txt_Contact.TabIndex = 5;
            this.txt_Contact.TextChanged += new System.EventHandler(this.txt_Contact_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(19, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Contact No.:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(17, 265);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Date of Use:";
            // 
            // txt_Address
            // 
            this.txt_Address.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Address.Location = new System.Drawing.Point(173, 102);
            this.txt_Address.Name = "txt_Address";
            this.txt_Address.Size = new System.Drawing.Size(483, 26);
            this.txt_Address.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(20, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Address:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(21, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Requesting Person:";
            // 
            // frm_Create_Equipment_Reservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 628);
            this.Controls.Add(this.panel1);
            this.Name = "frm_Create_Equipment_Reservation";
            this.Text = "EQUIPMENTS";
            this.Load += new System.EventHandler(this.frm_createutilityreservation_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Selected_Equipments)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker Date_End;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_Control_Num;
        private System.Windows.Forms.Button btn_clearform;
        private System.Windows.Forms.Button btn_submit;
        private System.Windows.Forms.DateTimePicker Date_Start;
        private System.Windows.Forms.TextBox txt_Contact;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Address;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox combo_Utility;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txt_Quantity;
        private System.Windows.Forms.TextBox txt_Total;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_Activity;
        private System.Windows.Forms.TextBox txt_Days_Of_Use;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox combo_Origin;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txt_Requesting_Office;
        private System.Windows.Forms.DataGridView dgv_Selected_Equipments;
        private System.Windows.Forms.Button btn_AddEquipment;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txt_Price_Subsequent;
        private System.Windows.Forms.Button btn_Remove;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn EquipmentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Remaining;
        private System.Windows.Forms.ComboBox combo_Name;
    }
}