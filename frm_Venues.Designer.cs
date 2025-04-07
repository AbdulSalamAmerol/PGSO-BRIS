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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dt_all = new System.Windows.Forms.DataGridView();
            this.panel_Information = new System.Windows.Forms.Panel();
            this.txt_Sname = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_Total = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_Status = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_Num_Participants = new System.Windows.Forms.TextBox();
            this.txt_HourEnd = new System.Windows.Forms.TextBox();
            this.txt_DateEnd = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_Activity_Name = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_HourStart = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_Date_Start = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Venue_Scope = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Venue_Name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Address = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Fname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_CN = new System.Windows.Forms.TextBox();
            this.txt_Search = new System.Windows.Forms.TextBox();
            this.fld_Control_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Venue_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Reservation_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Total_Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.combobox_Filter = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_Rate_Type = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_Requesting_Office = new System.Windows.Forms.TextBox();
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dt_all.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dt_all.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt_all.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fld_Control_Number,
            this.fld_Venue_Name,
            this.fld_Reservation_Status,
            this.fld_Total_Amount});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 10F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dt_all.DefaultCellStyle = dataGridViewCellStyle4;
            this.dt_all.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dt_all.Location = new System.Drawing.Point(12, 64);
            this.dt_all.Name = "dt_all";
            this.dt_all.ReadOnly = true;
            this.dt_all.RowHeadersVisible = false;
            this.dt_all.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dt_all.Size = new System.Drawing.Size(875, 562);
            this.dt_all.TabIndex = 6;
            this.dt_all.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dt_canceled_CellContentClick);
            // 
            // panel_Information
            // 
            this.panel_Information.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Information.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel_Information.Controls.Add(this.label15);
            this.panel_Information.Controls.Add(this.txt_Requesting_Office);
            this.panel_Information.Controls.Add(this.label12);
            this.panel_Information.Controls.Add(this.txt_Rate_Type);
            this.panel_Information.Controls.Add(this.txt_Sname);
            this.panel_Information.Controls.Add(this.label11);
            this.panel_Information.Controls.Add(this.txt_Total);
            this.panel_Information.Controls.Add(this.label10);
            this.panel_Information.Controls.Add(this.txt_Status);
            this.panel_Information.Controls.Add(this.label9);
            this.panel_Information.Controls.Add(this.txt_Num_Participants);
            this.panel_Information.Controls.Add(this.txt_HourEnd);
            this.panel_Information.Controls.Add(this.txt_DateEnd);
            this.panel_Information.Controls.Add(this.label8);
            this.panel_Information.Controls.Add(this.txt_Activity_Name);
            this.panel_Information.Controls.Add(this.label7);
            this.panel_Information.Controls.Add(this.txt_HourStart);
            this.panel_Information.Controls.Add(this.label6);
            this.panel_Information.Controls.Add(this.txt_Date_Start);
            this.panel_Information.Controls.Add(this.label5);
            this.panel_Information.Controls.Add(this.txt_Venue_Scope);
            this.panel_Information.Controls.Add(this.label4);
            this.panel_Information.Controls.Add(this.txt_Venue_Name);
            this.panel_Information.Controls.Add(this.label3);
            this.panel_Information.Controls.Add(this.txt_Address);
            this.panel_Information.Controls.Add(this.label2);
            this.panel_Information.Controls.Add(this.txt_Fname);
            this.panel_Information.Controls.Add(this.label1);
            this.panel_Information.Controls.Add(this.txt_CN);
            this.panel_Information.Location = new System.Drawing.Point(903, 12);
            this.panel_Information.Name = "panel_Information";
            this.panel_Information.Size = new System.Drawing.Size(332, 637);
            this.panel_Information.TabIndex = 7;
            this.panel_Information.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Information_Paint);
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
            this.label11.Location = new System.Drawing.Point(16, 561);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 17);
            this.label11.TabIndex = 23;
            this.label11.Text = "Total:";
            // 
            // txt_Total
            // 
            this.txt_Total.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Total.Location = new System.Drawing.Point(19, 581);
            this.txt_Total.Name = "txt_Total";
            this.txt_Total.ReadOnly = true;
            this.txt_Total.Size = new System.Drawing.Size(153, 26);
            this.txt_Total.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(16, 512);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 17);
            this.label10.TabIndex = 21;
            this.label10.Text = "Status:";
            // 
            // txt_Status
            // 
            this.txt_Status.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Status.Location = new System.Drawing.Point(19, 532);
            this.txt_Status.Name = "txt_Status";
            this.txt_Status.ReadOnly = true;
            this.txt_Status.Size = new System.Drawing.Size(286, 26);
            this.txt_Status.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(15, 463);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 17);
            this.label9.TabIndex = 19;
            this.label9.Text = "Participants";
            // 
            // txt_Num_Participants
            // 
            this.txt_Num_Participants.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Num_Participants.Location = new System.Drawing.Point(19, 483);
            this.txt_Num_Participants.Name = "txt_Num_Participants";
            this.txt_Num_Participants.ReadOnly = true;
            this.txt_Num_Participants.Size = new System.Drawing.Size(286, 26);
            this.txt_Num_Participants.TabIndex = 18;
            // 
            // txt_HourEnd
            // 
            this.txt_HourEnd.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_HourEnd.Location = new System.Drawing.Point(189, 378);
            this.txt_HourEnd.Name = "txt_HourEnd";
            this.txt_HourEnd.ReadOnly = true;
            this.txt_HourEnd.Size = new System.Drawing.Size(114, 26);
            this.txt_HourEnd.TabIndex = 17;
            // 
            // txt_DateEnd
            // 
            this.txt_DateEnd.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_DateEnd.Location = new System.Drawing.Point(190, 346);
            this.txt_DateEnd.Name = "txt_DateEnd";
            this.txt_DateEnd.ReadOnly = true;
            this.txt_DateEnd.Size = new System.Drawing.Size(114, 26);
            this.txt_DateEnd.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(16, 414);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 17);
            this.label8.TabIndex = 15;
            this.label8.Text = "Activity:";
            // 
            // txt_Activity_Name
            // 
            this.txt_Activity_Name.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Activity_Name.Location = new System.Drawing.Point(18, 434);
            this.txt_Activity_Name.Name = "txt_Activity_Name";
            this.txt_Activity_Name.ReadOnly = true;
            this.txt_Activity_Name.Size = new System.Drawing.Size(286, 26);
            this.txt_Activity_Name.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 385);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "Hours:";
            // 
            // txt_HourStart
            // 
            this.txt_HourStart.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_HourStart.Location = new System.Drawing.Point(69, 379);
            this.txt_HourStart.Name = "txt_HourStart";
            this.txt_HourStart.ReadOnly = true;
            this.txt_HourStart.Size = new System.Drawing.Size(114, 26);
            this.txt_HourStart.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(15, 352);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Date:";
            // 
            // txt_Date_Start
            // 
            this.txt_Date_Start.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Date_Start.Location = new System.Drawing.Point(69, 346);
            this.txt_Date_Start.Name = "txt_Date_Start";
            this.txt_Date_Start.ReadOnly = true;
            this.txt_Date_Start.Size = new System.Drawing.Size(114, 26);
            this.txt_Date_Start.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 294);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Venue Scope:";
            // 
            // txt_Venue_Scope
            // 
            this.txt_Venue_Scope.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Venue_Scope.Location = new System.Drawing.Point(17, 314);
            this.txt_Venue_Scope.Name = "txt_Venue_Scope";
            this.txt_Venue_Scope.ReadOnly = true;
            this.txt_Venue_Scope.Size = new System.Drawing.Size(286, 26);
            this.txt_Venue_Scope.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Venue";
            // 
            // txt_Venue_Name
            // 
            this.txt_Venue_Name.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Venue_Name.Location = new System.Drawing.Point(17, 216);
            this.txt_Venue_Name.Name = "txt_Venue_Name";
            this.txt_Venue_Name.ReadOnly = true;
            this.txt_Venue_Name.Size = new System.Drawing.Size(286, 26);
            this.txt_Venue_Name.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Address";
            // 
            // txt_Address
            // 
            this.txt_Address.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Address.Location = new System.Drawing.Point(17, 170);
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
            // txt_Search
            // 
            this.txt_Search.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Search.Location = new System.Drawing.Point(70, 18);
            this.txt_Search.Name = "txt_Search";
            this.txt_Search.Size = new System.Drawing.Size(185, 26);
            this.txt_Search.TabIndex = 8;
            this.txt_Search.TextChanged += new System.EventHandler(this.txt_Search_TextChanged);
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
            // combobox_Filter
            // 
            this.combobox_Filter.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combobox_Filter.FormattingEnabled = true;
            this.combobox_Filter.Location = new System.Drawing.Point(335, 19);
            this.combobox_Filter.Name = "combobox_Filter";
            this.combobox_Filter.Size = new System.Drawing.Size(121, 25);
            this.combobox_Filter.TabIndex = 9;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(269, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(60, 17);
            this.label14.TabIndex = 14;
            this.label14.Text = "Filter by:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(9, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 17);
            this.label13.TabIndex = 13;
            this.label13.Text = "Search:";
            // 
            // txt_Rate_Type
            // 
            this.txt_Rate_Type.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Rate_Type.Location = new System.Drawing.Point(15, 265);
            this.txt_Rate_Type.Name = "txt_Rate_Type";
            this.txt_Rate_Type.ReadOnly = true;
            this.txt_Rate_Type.Size = new System.Drawing.Size(286, 26);
            this.txt_Rate_Type.TabIndex = 27;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(16, 245);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(36, 17);
            this.label12.TabIndex = 28;
            this.label12.Text = "Type";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(14, 101);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(121, 17);
            this.label15.TabIndex = 30;
            this.label15.Text = "Requesting Office";
            // 
            // txt_Requesting_Office
            // 
            this.txt_Requesting_Office.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Requesting_Office.Location = new System.Drawing.Point(17, 121);
            this.txt_Requesting_Office.Name = "txt_Requesting_Office";
            this.txt_Requesting_Office.ReadOnly = true;
            this.txt_Requesting_Office.Size = new System.Drawing.Size(286, 26);
            this.txt_Requesting_Office.TabIndex = 29;
            // 
            // frm_Venues
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(1259, 661);
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
        private System.Windows.Forms.TextBox txt_CN;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_Activity_Name;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_HourStart;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_Date_Start;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Venue_Scope;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Venue_Name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Address;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Fname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_DateEnd;
        private System.Windows.Forms.TextBox txt_HourEnd;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_Total;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_Status;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_Num_Participants;
        private System.Windows.Forms.TextBox txt_Sname;
        private System.Windows.Forms.TextBox txt_Search;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Control_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Venue_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Reservation_Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Total_Amount;
        private System.Windows.Forms.ComboBox combobox_Filter;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_Rate_Type;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txt_Requesting_Office;
    }
}