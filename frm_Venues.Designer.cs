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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dt_all = new System.Windows.Forms.DataGridView();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Control_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Venue_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreatedAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Rate_Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Reservation_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Total_Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel_Information = new System.Windows.Forms.Panel();
            this.txt_Contact = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picturebox_IMG = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_Scope = new System.Windows.Forms.TextBox();
            this.btn_Update = new System.Windows.Forms.Button();
            this.txt_Venue = new System.Windows.Forms.TextBox();
            this.txt_Activity = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_Date_Start = new System.Windows.Forms.TextBox();
            this.txt_Total = new System.Windows.Forms.TextBox();
            this.txt_Status = new System.Windows.Forms.TextBox();
            this.txt_Participants = new System.Windows.Forms.TextBox();
            this.txt_Type = new System.Windows.Forms.TextBox();
            this.txt_Address = new System.Windows.Forms.TextBox();
            this.txt_Office = new System.Windows.Forms.TextBox();
            this.txt_FName = new System.Windows.Forms.TextBox();
            this.txt_CN = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
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
            this.panel5 = new System.Windows.Forms.Panel();
            this.label20 = new System.Windows.Forms.Label();
            this.combo_Sort = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblPageInfo = new System.Windows.Forms.Label();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.btnPrevPage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dt_all)).BeginInit();
            this.panel_Information.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_IMG)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dt_all
            // 
            this.dt_all.AllowUserToAddRows = false;
            this.dt_all.AllowUserToDeleteRows = false;
            this.dt_all.AllowUserToResizeColumns = false;
            this.dt_all.AllowUserToResizeRows = false;
            this.dt_all.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dt_all.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dt_all.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dt_all.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt_all.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Item,
            this.fld_Control_Number,
            this.fld_Venue_Name,
            this.Date,
            this.CreatedAt,
            this.fld_Rate_Type,
            this.fld_Reservation_Status,
            this.fld_Total_Amount});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dt_all.DefaultCellStyle = dataGridViewCellStyle4;
            this.dt_all.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dt_all.Location = new System.Drawing.Point(12, 76);
            this.dt_all.Name = "dt_all";
            this.dt_all.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dt_all.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dt_all.RowHeadersVisible = false;
            this.dt_all.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dt_all.Size = new System.Drawing.Size(1519, 950);
            this.dt_all.TabIndex = 6;
            this.dt_all.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dt_all_CellContentClick);
            // 
            // Item
            // 
            this.Item.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Item.DefaultCellStyle = dataGridViewCellStyle2;
            this.Item.HeaderText = "Item";
            this.Item.Name = "Item";
            this.Item.ReadOnly = true;
            this.Item.Width = 50;
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
            // Date
            // 
            this.Date.DataPropertyName = "Date";
            this.Date.HeaderText = "Date of Use";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // CreatedAt
            // 
            this.CreatedAt.DataPropertyName = "fld_Created_At";
            this.CreatedAt.HeaderText = "Date Requested";
            this.CreatedAt.Name = "CreatedAt";
            this.CreatedAt.ReadOnly = true;
            // 
            // fld_Rate_Type
            // 
            this.fld_Rate_Type.DataPropertyName = "fld_Rate_Type";
            this.fld_Rate_Type.HeaderText = "Rate Type";
            this.fld_Rate_Type.Name = "fld_Rate_Type";
            this.fld_Rate_Type.ReadOnly = true;
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fld_Total_Amount.DefaultCellStyle = dataGridViewCellStyle3;
            this.fld_Total_Amount.HeaderText = "Total";
            this.fld_Total_Amount.Name = "fld_Total_Amount";
            this.fld_Total_Amount.ReadOnly = true;
            // 
            // panel_Information
            // 
            this.panel_Information.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Information.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel_Information.Controls.Add(this.txt_Contact);
            this.panel_Information.Controls.Add(this.label18);
            this.panel_Information.Controls.Add(this.panel1);
            this.panel_Information.Controls.Add(this.label7);
            this.panel_Information.Controls.Add(this.txt_Scope);
            this.panel_Information.Controls.Add(this.btn_Update);
            this.panel_Information.Controls.Add(this.txt_Venue);
            this.panel_Information.Controls.Add(this.txt_Activity);
            this.panel_Information.Controls.Add(this.label8);
            this.panel_Information.Controls.Add(this.txt_Date_Start);
            this.panel_Information.Controls.Add(this.txt_Total);
            this.panel_Information.Controls.Add(this.txt_Status);
            this.panel_Information.Controls.Add(this.txt_Participants);
            this.panel_Information.Controls.Add(this.txt_Type);
            this.panel_Information.Controls.Add(this.txt_Address);
            this.panel_Information.Controls.Add(this.txt_Office);
            this.panel_Information.Controls.Add(this.txt_FName);
            this.panel_Information.Controls.Add(this.txt_CN);
            this.panel_Information.Controls.Add(this.label16);
            this.panel_Information.Controls.Add(this.label10);
            this.panel_Information.Controls.Add(this.label9);
            this.panel_Information.Controls.Add(this.label6);
            this.panel_Information.Controls.Add(this.label12);
            this.panel_Information.Controls.Add(this.label5);
            this.panel_Information.Controls.Add(this.label4);
            this.panel_Information.Controls.Add(this.label11);
            this.panel_Information.Controls.Add(this.label15);
            this.panel_Information.Controls.Add(this.label3);
            this.panel_Information.Controls.Add(this.label2);
            this.panel_Information.Controls.Add(this.label1);
            this.panel_Information.Location = new System.Drawing.Point(1537, 37);
            this.panel_Information.Name = "panel_Information";
            this.panel_Information.Size = new System.Drawing.Size(375, 654);
            this.panel_Information.TabIndex = 7;
            this.panel_Information.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Information_Paint);
            // 
            // txt_Contact
            // 
            this.txt_Contact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Contact.Location = new System.Drawing.Point(155, 99);
            this.txt_Contact.Name = "txt_Contact";
            this.txt_Contact.ReadOnly = true;
            this.txt_Contact.Size = new System.Drawing.Size(204, 26);
            this.txt_Contact.TabIndex = 72;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(9, 105);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(69, 20);
            this.label18.TabIndex = 71;
            this.label18.Text = "Contact:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.Controls.Add(this.picturebox_IMG);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(155, 514);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(69, 62);
            this.panel1.TabIndex = 70;
            // 
            // picturebox_IMG
            // 
            this.picturebox_IMG.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.picturebox_IMG.Location = new System.Drawing.Point(10, 7);
            this.picturebox_IMG.Name = "picturebox_IMG";
            this.picturebox_IMG.Size = new System.Drawing.Size(50, 47);
            this.picturebox_IMG.TabIndex = 68;
            this.picturebox_IMG.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(16, 556);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 20);
            this.label7.TabIndex = 69;
            this.label7.Text = "View Image:";
            // 
            // txt_Scope
            // 
            this.txt_Scope.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Scope.Location = new System.Drawing.Point(155, 287);
            this.txt_Scope.Name = "txt_Scope";
            this.txt_Scope.ReadOnly = true;
            this.txt_Scope.Size = new System.Drawing.Size(205, 26);
            this.txt_Scope.TabIndex = 17;
            this.txt_Scope.TextChanged += new System.EventHandler(this.txt_Scope_TextChanged);
            // 
            // btn_Update
            // 
            this.btn_Update.BackColor = System.Drawing.Color.Green;
            this.btn_Update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Update.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Update.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Update.Location = new System.Drawing.Point(282, 541);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(75, 35);
            this.btn_Update.TabIndex = 66;
            this.btn_Update.Text = "Update";
            this.btn_Update.UseVisualStyleBackColor = false;
            this.btn_Update.Visible = false;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // txt_Venue
            // 
            this.txt_Venue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Venue.Location = new System.Drawing.Point(153, 255);
            this.txt_Venue.Name = "txt_Venue";
            this.txt_Venue.ReadOnly = true;
            this.txt_Venue.Size = new System.Drawing.Size(205, 26);
            this.txt_Venue.TabIndex = 16;
            this.txt_Venue.TextChanged += new System.EventHandler(this.txt_Venue_TextChanged);
            // 
            // txt_Activity
            // 
            this.txt_Activity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Activity.Location = new System.Drawing.Point(155, 223);
            this.txt_Activity.Name = "txt_Activity";
            this.txt_Activity.ReadOnly = true;
            this.txt_Activity.Size = new System.Drawing.Size(204, 26);
            this.txt_Activity.TabIndex = 55;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(9, 229);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 20);
            this.label8.TabIndex = 15;
            this.label8.Text = "Activity:";
            // 
            // txt_Date_Start
            // 
            this.txt_Date_Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Date_Start.Location = new System.Drawing.Point(153, 351);
            this.txt_Date_Start.Multiline = true;
            this.txt_Date_Start.Name = "txt_Date_Start";
            this.txt_Date_Start.ReadOnly = true;
            this.txt_Date_Start.Size = new System.Drawing.Size(205, 61);
            this.txt_Date_Start.TabIndex = 67;
            // 
            // txt_Total
            // 
            this.txt_Total.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Total.Location = new System.Drawing.Point(153, 482);
            this.txt_Total.Name = "txt_Total";
            this.txt_Total.ReadOnly = true;
            this.txt_Total.Size = new System.Drawing.Size(204, 26);
            this.txt_Total.TabIndex = 60;
            this.txt_Total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_Status
            // 
            this.txt_Status.BackColor = System.Drawing.SystemColors.Control;
            this.txt_Status.Enabled = false;
            this.txt_Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Status.Location = new System.Drawing.Point(153, 450);
            this.txt_Status.Name = "txt_Status";
            this.txt_Status.ReadOnly = true;
            this.txt_Status.Size = new System.Drawing.Size(204, 26);
            this.txt_Status.TabIndex = 59;
            // 
            // txt_Participants
            // 
            this.txt_Participants.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Participants.Location = new System.Drawing.Point(154, 418);
            this.txt_Participants.Name = "txt_Participants";
            this.txt_Participants.ReadOnly = true;
            this.txt_Participants.Size = new System.Drawing.Size(204, 26);
            this.txt_Participants.TabIndex = 58;
            // 
            // txt_Type
            // 
            this.txt_Type.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Type.Location = new System.Drawing.Point(155, 319);
            this.txt_Type.Name = "txt_Type";
            this.txt_Type.ReadOnly = true;
            this.txt_Type.Size = new System.Drawing.Size(204, 26);
            this.txt_Type.TabIndex = 54;
            // 
            // txt_Address
            // 
            this.txt_Address.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Address.Location = new System.Drawing.Point(155, 131);
            this.txt_Address.Multiline = true;
            this.txt_Address.Name = "txt_Address";
            this.txt_Address.ReadOnly = true;
            this.txt_Address.Size = new System.Drawing.Size(204, 54);
            this.txt_Address.TabIndex = 51;
            // 
            // txt_Office
            // 
            this.txt_Office.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txt_Office.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Office.Location = new System.Drawing.Point(155, 191);
            this.txt_Office.Name = "txt_Office";
            this.txt_Office.ReadOnly = true;
            this.txt_Office.Size = new System.Drawing.Size(204, 26);
            this.txt_Office.TabIndex = 50;
            this.txt_Office.TextChanged += new System.EventHandler(this.txt_Office_TextChanged);
            // 
            // txt_FName
            // 
            this.txt_FName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_FName.Location = new System.Drawing.Point(154, 67);
            this.txt_FName.Name = "txt_FName";
            this.txt_FName.ReadOnly = true;
            this.txt_FName.Size = new System.Drawing.Size(205, 26);
            this.txt_FName.TabIndex = 49;
            // 
            // txt_CN
            // 
            this.txt_CN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_CN.Location = new System.Drawing.Point(154, 35);
            this.txt_CN.Name = "txt_CN";
            this.txt_CN.ReadOnly = true;
            this.txt_CN.Size = new System.Drawing.Size(204, 26);
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
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(11, 456);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 20);
            this.label10.TabIndex = 21;
            this.label10.Text = "Status:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(11, 421);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 20);
            this.label9.TabIndex = 19;
            this.label9.Text = "Participants:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(11, 392);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Date/Hour of Use:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(15, 325);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 20);
            this.label12.TabIndex = 28;
            this.label12.Text = "Type:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 293);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Venue Scope:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 261);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Venue:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(15, 488);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 20);
            this.label11.TabIndex = 23;
            this.label11.Text = "Total:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(8, 197);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(141, 20);
            this.label15.TabIndex = 30;
            this.label15.Text = "Requesting Office:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Address:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Control Number:";
            // 
            // txt_Search
            // 
            this.txt_Search.BackColor = System.Drawing.Color.White;
            this.txt_Search.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Search.Location = new System.Drawing.Point(76, 46);
            this.txt_Search.Name = "txt_Search";
            this.txt_Search.Size = new System.Drawing.Size(185, 26);
            this.txt_Search.TabIndex = 8;
            this.txt_Search.TextChanged += new System.EventHandler(this.txt_Search_TextChanged_1);
            // 
            // combobox_Filter
            // 
            this.combobox_Filter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combobox_Filter.FormattingEnabled = true;
            this.combobox_Filter.Location = new System.Drawing.Point(86, 5);
            this.combobox_Filter.Name = "combobox_Filter";
            this.combobox_Filter.Size = new System.Drawing.Size(138, 28);
            this.combobox_Filter.TabIndex = 9;
            this.combobox_Filter.SelectedIndexChanged += new System.EventHandler(this.combobox_Filter_SelectedIndexChanged_1);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(12, 11);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(68, 20);
            this.label14.TabIndex = 14;
            this.label14.Text = "Filter by:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(15, 51);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 17);
            this.label13.TabIndex = 13;
            this.label13.Text = "Search:";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(12, 9);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(90, 25);
            this.label17.TabIndex = 15;
            this.label17.Text = "VENUES";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label20);
            this.panel5.Controls.Add(this.label14);
            this.panel5.Controls.Add(this.combo_Sort);
            this.panel5.Controls.Add(this.combobox_Filter);
            this.panel5.Location = new System.Drawing.Point(1056, 37);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(257, 37);
            this.panel5.TabIndex = 35;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(230, 8);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(63, 20);
            this.label20.TabIndex = 1;
            this.label20.Text = "Sort by:";
            this.label20.Visible = false;
            // 
            // combo_Sort
            // 
            this.combo_Sort.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_Sort.FormattingEnabled = true;
            this.combo_Sort.Location = new System.Drawing.Point(305, 6);
            this.combo_Sort.Name = "combo_Sort";
            this.combo_Sort.Size = new System.Drawing.Size(121, 28);
            this.combo_Sort.TabIndex = 0;
            this.combo_Sort.Visible = false;
            this.combo_Sort.SelectedIndexChanged += new System.EventHandler(this.combo_Sort_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblPageInfo);
            this.panel3.Controls.Add(this.btnNextPage);
            this.panel3.Controls.Add(this.btnPrevPage);
            this.panel3.Location = new System.Drawing.Point(1338, 34);
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
            this.lblPageInfo.Click += new System.EventHandler(this.lblPageInfo_Click);
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
            // frm_Venues
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(1924, 1061);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txt_Search);
            this.Controls.Add(this.panel_Information);
            this.Controls.Add(this.dt_all);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Venues";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VENUES";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_Venues_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dt_all)).EndInit();
            this.panel_Information.ResumeLayout(false);
            this.panel_Information.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picturebox_IMG)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dt_all;
        private System.Windows.Forms.Panel panel_Information;
        private System.Windows.Forms.Label label8;
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
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.TextBox txt_Venue;
        private System.Windows.Forms.TextBox txt_Scope;
        private System.Windows.Forms.TextBox txt_Date_Start;
        private System.Windows.Forms.PictureBox picturebox_IMG;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_Contact;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox combo_Sort;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblPageInfo;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Button btnPrevPage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Control_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Venue_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedAt;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Rate_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Reservation_Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Total_Amount;
    }
}