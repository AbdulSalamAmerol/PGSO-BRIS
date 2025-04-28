namespace pgso
{
    partial class frm_Venues
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
            this.dt_all = new System.Windows.Forms.DataGridView();
            this.fld_Control_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Venue_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Reservation_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Total_Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel_Information = new System.Windows.Forms.Panel();
            this.txt_Hour_End = new System.Windows.Forms.TextBox();
            this.txt_Scope = new System.Windows.Forms.TextBox();
            this.txt_Hour_Start = new System.Windows.Forms.TextBox();
            this.btn_Update = new System.Windows.Forms.Button();
            this.txt_Date_End = new System.Windows.Forms.TextBox();
            this.txt_Venue = new System.Windows.Forms.TextBox();
            this.txt_Date_Start = new System.Windows.Forms.TextBox();
            this.txt_LName = new System.Windows.Forms.TextBox();
            this.txt_Total = new System.Windows.Forms.TextBox();
            this.txt_Status = new System.Windows.Forms.TextBox();
            this.txt_Participants = new System.Windows.Forms.TextBox();
            this.txt_Activity = new System.Windows.Forms.TextBox();
            this.txt_Type = new System.Windows.Forms.TextBox();
            this.txt_Address = new System.Windows.Forms.TextBox();
            this.txt_Office = new System.Windows.Forms.TextBox();
            this.txt_FName = new System.Windows.Forms.TextBox();
            this.txt_CN = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Search = new System.Windows.Forms.TextBox();
            this.combobox_Filter = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dt_all)).BeginInit();
            this.panel_Information.SuspendLayout();
            this.SuspendLayout();
            // 
            // dt_all
            // 
            this.dt_all.AllowUserToDeleteRows = false;
            this.dt_all.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dt_all.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dt_all.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dt_all.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt_all.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fld_Control_Number,
            this.fld_Venue_Name,
            this.fld_Reservation_Status,
            this.fld_Total_Amount});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dt_all.DefaultCellStyle = dataGridViewCellStyle2;
            this.dt_all.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dt_all.Location = new System.Drawing.Point(12, 76);
            this.dt_all.Name = "dt_all";
            this.dt_all.ReadOnly = true;
            this.dt_all.RowHeadersVisible = false;
            this.dt_all.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dt_all.Size = new System.Drawing.Size(981, 550);
            this.dt_all.TabIndex = 6;
            this.dt_all.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dt_all_CellContentClick);
            // 
            // fld_Control_Number
            // 
            this.fld_Control_Number.DataPropertyName = "fld_Control_Number";
            this.fld_Control_Number.HeaderText = "Control Number";
            this.fld_Control_Number.Name = "fld_Control_Number";
            this.fld_Control_Number.ReadOnly = true;
            // 
            // fld_Venue_Name
            // 
            this.fld_Venue_Name.DataPropertyName = "fld_Venue_Name";
            this.fld_Venue_Name.HeaderText = "Venue";
            this.fld_Venue_Name.Name = "fld_Venue_Name";
            this.fld_Venue_Name.ReadOnly = true;
            // 
            // fld_Reservation_Status
            // 
            this.fld_Reservation_Status.DataPropertyName = "fld_Reservation_Status";
            this.fld_Reservation_Status.HeaderText = "Status";
            this.fld_Reservation_Status.Name = "fld_Reservation_Status";
            this.fld_Reservation_Status.ReadOnly = true;
            this.fld_Reservation_Status.Resizable = System.Windows.Forms.DataGridViewTriState.True;
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
            this.panel_Information.Controls.Add(this.txt_Hour_End);
            this.panel_Information.Controls.Add(this.txt_Scope);
            this.panel_Information.Controls.Add(this.txt_Hour_Start);
            this.panel_Information.Controls.Add(this.btn_Update);
            this.panel_Information.Controls.Add(this.txt_Date_End);
            this.panel_Information.Controls.Add(this.txt_Venue);
            this.panel_Information.Controls.Add(this.txt_Date_Start);
            this.panel_Information.Controls.Add(this.txt_LName);
            this.panel_Information.Controls.Add(this.txt_Total);
            this.panel_Information.Controls.Add(this.txt_Status);
            this.panel_Information.Controls.Add(this.txt_Participants);
            this.panel_Information.Controls.Add(this.txt_Activity);
            this.panel_Information.Controls.Add(this.txt_Type);
            this.panel_Information.Controls.Add(this.txt_Address);
            this.panel_Information.Controls.Add(this.txt_Office);
            this.panel_Information.Controls.Add(this.txt_FName);
            this.panel_Information.Controls.Add(this.txt_CN);
            this.panel_Information.Controls.Add(this.label16);
            this.panel_Information.Controls.Add(this.label10);
            this.panel_Information.Controls.Add(this.label9);
            this.panel_Information.Controls.Add(this.label6);
            this.panel_Information.Controls.Add(this.label7);
            this.panel_Information.Controls.Add(this.label8);
            this.panel_Information.Controls.Add(this.label12);
            this.panel_Information.Controls.Add(this.label5);
            this.panel_Information.Controls.Add(this.label4);
            this.panel_Information.Controls.Add(this.label11);
            this.panel_Information.Controls.Add(this.label15);
            this.panel_Information.Controls.Add(this.label3);
            this.panel_Information.Controls.Add(this.label2);
            this.panel_Information.Controls.Add(this.label1);
            this.panel_Information.Location = new System.Drawing.Point(999, 37);
            this.panel_Information.Name = "panel_Information";
            this.panel_Information.Size = new System.Drawing.Size(375, 468);
            this.panel_Information.TabIndex = 7;
            this.panel_Information.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Information_Paint);
            // 
            // txt_Hour_End
            // 
            this.txt_Hour_End.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Hour_End.Location = new System.Drawing.Point(259, 249);
            this.txt_Hour_End.Name = "txt_Hour_End";
            this.txt_Hour_End.ReadOnly = true;
            this.txt_Hour_End.Size = new System.Drawing.Size(100, 23);
            this.txt_Hour_End.TabIndex = 70;
            // 
            // txt_Scope
            // 
            this.txt_Scope.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Scope.Location = new System.Drawing.Point(153, 172);
            this.txt_Scope.Name = "txt_Scope";
            this.txt_Scope.ReadOnly = true;
            this.txt_Scope.Size = new System.Drawing.Size(205, 22);
            this.txt_Scope.TabIndex = 17;
            this.txt_Scope.TextChanged += new System.EventHandler(this.txt_Scope_TextChanged);
            // 
            // txt_Hour_Start
            // 
            this.txt_Hour_Start.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Hour_Start.Location = new System.Drawing.Point(153, 249);
            this.txt_Hour_Start.Name = "txt_Hour_Start";
            this.txt_Hour_Start.ReadOnly = true;
            this.txt_Hour_Start.Size = new System.Drawing.Size(100, 23);
            this.txt_Hour_Start.TabIndex = 69;
            // 
            // btn_Update
            // 
            this.btn_Update.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Update.Location = new System.Drawing.Point(283, 422);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(75, 35);
            this.btn_Update.TabIndex = 66;
            this.btn_Update.Text = "UPDATE";
            this.btn_Update.UseVisualStyleBackColor = true;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // txt_Date_End
            // 
            this.txt_Date_End.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Date_End.Location = new System.Drawing.Point(153, 301);
            this.txt_Date_End.Name = "txt_Date_End";
            this.txt_Date_End.ReadOnly = true;
            this.txt_Date_End.Size = new System.Drawing.Size(204, 23);
            this.txt_Date_End.TabIndex = 68;
            // 
            // txt_Venue
            // 
            this.txt_Venue.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Venue.Location = new System.Drawing.Point(154, 146);
            this.txt_Venue.Name = "txt_Venue";
            this.txt_Venue.ReadOnly = true;
            this.txt_Venue.Size = new System.Drawing.Size(205, 22);
            this.txt_Venue.TabIndex = 16;
            this.txt_Venue.TextChanged += new System.EventHandler(this.txt_Venue_TextChanged);
            // 
            // txt_Date_Start
            // 
            this.txt_Date_Start.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Date_Start.Location = new System.Drawing.Point(154, 275);
            this.txt_Date_Start.Name = "txt_Date_Start";
            this.txt_Date_Start.ReadOnly = true;
            this.txt_Date_Start.Size = new System.Drawing.Size(204, 23);
            this.txt_Date_Start.TabIndex = 67;
            // 
            // txt_LName
            // 
            this.txt_LName.Location = new System.Drawing.Point(258, 63);
            this.txt_LName.Name = "txt_LName";
            this.txt_LName.Size = new System.Drawing.Size(100, 20);
            this.txt_LName.TabIndex = 61;
            // 
            // txt_Total
            // 
            this.txt_Total.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Total.Location = new System.Drawing.Point(154, 380);
            this.txt_Total.Name = "txt_Total";
            this.txt_Total.ReadOnly = true;
            this.txt_Total.Size = new System.Drawing.Size(204, 23);
            this.txt_Total.TabIndex = 60;
            // 
            // txt_Status
            // 
            this.txt_Status.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Status.Location = new System.Drawing.Point(154, 354);
            this.txt_Status.Name = "txt_Status";
            this.txt_Status.Size = new System.Drawing.Size(204, 23);
            this.txt_Status.TabIndex = 59;
            // 
            // txt_Participants
            // 
            this.txt_Participants.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Participants.Location = new System.Drawing.Point(154, 328);
            this.txt_Participants.Name = "txt_Participants";
            this.txt_Participants.ReadOnly = true;
            this.txt_Participants.Size = new System.Drawing.Size(204, 23);
            this.txt_Participants.TabIndex = 58;
            // 
            // txt_Activity
            // 
            this.txt_Activity.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Activity.Location = new System.Drawing.Point(154, 223);
            this.txt_Activity.Name = "txt_Activity";
            this.txt_Activity.ReadOnly = true;
            this.txt_Activity.Size = new System.Drawing.Size(204, 23);
            this.txt_Activity.TabIndex = 55;
            // 
            // txt_Type
            // 
            this.txt_Type.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Type.Location = new System.Drawing.Point(154, 197);
            this.txt_Type.Name = "txt_Type";
            this.txt_Type.ReadOnly = true;
            this.txt_Type.Size = new System.Drawing.Size(204, 23);
            this.txt_Type.TabIndex = 54;
            // 
            // txt_Address
            // 
            this.txt_Address.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Address.Location = new System.Drawing.Point(154, 120);
            this.txt_Address.Name = "txt_Address";
            this.txt_Address.Size = new System.Drawing.Size(204, 23);
            this.txt_Address.TabIndex = 51;
            // 
            // txt_Office
            // 
            this.txt_Office.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Office.Location = new System.Drawing.Point(154, 89);
            this.txt_Office.Name = "txt_Office";
            this.txt_Office.ReadOnly = true;
            this.txt_Office.Size = new System.Drawing.Size(204, 23);
            this.txt_Office.TabIndex = 50;
            // 
            // txt_FName
            // 
            this.txt_FName.Location = new System.Drawing.Point(153, 63);
            this.txt_FName.Name = "txt_FName";
            this.txt_FName.Size = new System.Drawing.Size(100, 20);
            this.txt_FName.TabIndex = 49;
            // 
            // txt_CN
            // 
            this.txt_CN.Location = new System.Drawing.Point(154, 35);
            this.txt_CN.Name = "txt_CN";
            this.txt_CN.ReadOnly = true;
            this.txt_CN.Size = new System.Drawing.Size(204, 20);
            this.txt_CN.TabIndex = 48;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(16, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(162, 17);
            this.label16.TabIndex = 47;
            this.label16.Text = "Reservation Information";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(93, 361);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 16);
            this.label10.TabIndex = 21;
            this.label10.Text = "Status:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(54, 335);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 16);
            this.label9.TabIndex = 19;
            this.label9.Text = "Participants:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(101, 282);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Date:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(95, 256);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "Hours:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(82, 230);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 16);
            this.label8.TabIndex = 15;
            this.label8.Text = "Activity:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(100, 204);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 16);
            this.label12.TabIndex = 28;
            this.label12.Text = "Type:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(46, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Venue Scope:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(90, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Venue:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(100, 387);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 16);
            this.label11.TabIndex = 23;
            this.label11.Text = "Total:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(16, 93);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(126, 16);
            this.label15.TabIndex = 30;
            this.label15.Text = "Requesting Office:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(78, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Address:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(88, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Control Number:";
            // 
            // txt_Search
            // 
            this.txt_Search.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Search.Location = new System.Drawing.Point(71, 36);
            this.txt_Search.Name = "txt_Search";
            this.txt_Search.Size = new System.Drawing.Size(185, 26);
            this.txt_Search.TabIndex = 8;
            // 
            // combobox_Filter
            // 
            this.combobox_Filter.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combobox_Filter.FormattingEnabled = true;
            this.combobox_Filter.Location = new System.Drawing.Point(336, 37);
            this.combobox_Filter.Name = "combobox_Filter";
            this.combobox_Filter.Size = new System.Drawing.Size(121, 25);
            this.combobox_Filter.TabIndex = 9;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(270, 37);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(60, 17);
            this.label14.TabIndex = 14;
            this.label14.Text = "Filter by:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(10, 36);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 17);
            this.label13.TabIndex = 13;
            this.label13.Text = "Search:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(12, 9);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(55, 16);
            this.label17.TabIndex = 15;
            this.label17.Text = "VENUES";
            // 
            // frm_Venues
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(1386, 661);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.combobox_Filter);
            this.Controls.Add(this.txt_Search);
            this.Controls.Add(this.panel_Information);
            this.Controls.Add(this.dt_all);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_Venues";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VENUES";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_Venues_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dt_all)).EndInit();
            this.panel_Information.ResumeLayout(false);
            this.panel_Information.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dt_all;
        private System.Windows.Forms.Panel panel_Information;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_Search;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Control_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Venue_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Reservation_Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Total_Amount;
        private System.Windows.Forms.ComboBox combobox_Filter;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txt_FName;
        private System.Windows.Forms.TextBox txt_CN;
        private System.Windows.Forms.TextBox txt_Total;
        private System.Windows.Forms.TextBox txt_Status;
        private System.Windows.Forms.TextBox txt_Participants;
        private System.Windows.Forms.TextBox txt_Activity;
        private System.Windows.Forms.TextBox txt_Type;
        private System.Windows.Forms.TextBox txt_Address;
        private System.Windows.Forms.TextBox txt_Office;
        private System.Windows.Forms.TextBox txt_LName;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.TextBox txt_Venue;
        private System.Windows.Forms.TextBox txt_Scope;
        private System.Windows.Forms.TextBox txt_Date_Start;
        private System.Windows.Forms.TextBox txt_Date_End;
        private System.Windows.Forms.TextBox txt_Hour_Start;
        private System.Windows.Forms.TextBox txt_Hour_End;
    }
}