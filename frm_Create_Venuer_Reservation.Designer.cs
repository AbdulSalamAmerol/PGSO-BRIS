using System;

namespace pgso
{
    partial class frm_Create_Venuer_Reservation
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label27 = new System.Windows.Forms.Label();
            this.txt_Requesting_Office = new System.Windows.Forms.TextBox();
            this.combo_Request = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.txt_Total = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txt_Hourly_Rate = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txtx_Num_Hours = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txt_Num_Days = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.num_participants = new System.Windows.Forms.NumericUpDown();
            this.radio_No = new System.Windows.Forms.RadioButton();
            this.radio_Yes = new System.Windows.Forms.RadioButton();
            this.panel_night_time = new System.Windows.Forms.Panel();
            this.label23 = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label15 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_controlnum = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.combo_venues = new System.Windows.Forms.ComboBox();
            this.combo_scope = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.combo_ReservationType = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txt_surname = new System.Windows.Forms.TextBox();
            this.txt_rate = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.date_of_use_end = new System.Windows.Forms.DateTimePicker();
            this.txt_activity = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TimeEnd = new System.Windows.Forms.DateTimePicker();
            this.TimeStart = new System.Windows.Forms.DateTimePicker();
            this.btn_clearform = new System.Windows.Forms.Button();
            this.btn_submit = new System.Windows.Forms.Button();
            this.date_of_use_start = new System.Windows.Forms.DateTimePicker();
            this.txt_contact = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_address = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_firstname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_SelectedVenues = new System.Windows.Forms.DataGridView();
            this.VenueName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScopeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReservationType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsesAircon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hours = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReservationDateStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReservationDateEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_AddVenue = new System.Windows.Forms.Button();
            this.btn_RemoveVenue = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_participants)).BeginInit();
            this.panel_night_time.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SelectedVenues)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Khaki;
            this.panel1.Controls.Add(this.btn_RemoveVenue);
            this.panel1.Controls.Add(this.label27);
            this.panel1.Controls.Add(this.btn_AddVenue);
            this.panel1.Controls.Add(this.txt_Requesting_Office);
            this.panel1.Controls.Add(this.combo_Request);
            this.panel1.Controls.Add(this.dgv_SelectedVenues);
            this.panel1.Controls.Add(this.label26);
            this.panel1.Controls.Add(this.txt_Total);
            this.panel1.Controls.Add(this.label25);
            this.panel1.Controls.Add(this.txt_Hourly_Rate);
            this.panel1.Controls.Add(this.label24);
            this.panel1.Controls.Add(this.txtx_Num_Hours);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.txt_Num_Days);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.num_participants);
            this.panel1.Controls.Add(this.radio_No);
            this.panel1.Controls.Add(this.radio_Yes);
            this.panel1.Controls.Add(this.panel_night_time);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txt_controlnum);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.combo_venues);
            this.panel1.Controls.Add(this.combo_scope);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.combo_ReservationType);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.txt_surname);
            this.panel1.Controls.Add(this.txt_rate);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.date_of_use_end);
            this.panel1.Controls.Add(this.txt_activity);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.TimeEnd);
            this.panel1.Controls.Add(this.TimeStart);
            this.panel1.Controls.Add(this.btn_clearform);
            this.panel1.Controls.Add(this.btn_submit);
            this.panel1.Controls.Add(this.date_of_use_start);
            this.panel1.Controls.Add(this.txt_contact);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txt_address);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txt_firstname);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(998, 717);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.Black;
            this.label27.Location = new System.Drawing.Point(609, 163);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(159, 20);
            this.label27.TabIndex = 64;
            this.label27.Text = "REQUESTING OFFICE:";
            // 
            // txt_Requesting_Office
            // 
            this.txt_Requesting_Office.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Requesting_Office.Location = new System.Drawing.Point(613, 186);
            this.txt_Requesting_Office.Name = "txt_Requesting_Office";
            this.txt_Requesting_Office.Size = new System.Drawing.Size(238, 24);
            this.txt_Requesting_Office.TabIndex = 63;
            // 
            // combo_Request
            // 
            this.combo_Request.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_Request.FormattingEnabled = true;
            this.combo_Request.Location = new System.Drawing.Point(613, 269);
            this.combo_Request.Name = "combo_Request";
            this.combo_Request.Size = new System.Drawing.Size(215, 28);
            this.combo_Request.TabIndex = 62;
            this.combo_Request.SelectedIndexChanged += new System.EventHandler(this.combo_Request_SelectedIndexChanged);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Black;
            this.label26.Location = new System.Drawing.Point(745, 367);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(46, 20);
            this.label26.TabIndex = 61;
            this.label26.Text = "Total:";
            // 
            // txt_Total
            // 
            this.txt_Total.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Total.Location = new System.Drawing.Point(749, 390);
            this.txt_Total.Name = "txt_Total";
            this.txt_Total.ReadOnly = true;
            this.txt_Total.Size = new System.Drawing.Size(133, 29);
            this.txt_Total.TabIndex = 60;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(151, 399);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(92, 20);
            this.label25.TabIndex = 59;
            this.label25.Text = "Hourly Rate";
            // 
            // txt_Hourly_Rate
            // 
            this.txt_Hourly_Rate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Hourly_Rate.Location = new System.Drawing.Point(256, 395);
            this.txt_Hourly_Rate.Name = "txt_Hourly_Rate";
            this.txt_Hourly_Rate.ReadOnly = true;
            this.txt_Hourly_Rate.Size = new System.Drawing.Size(108, 24);
            this.txt_Hourly_Rate.TabIndex = 58;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Black;
            this.label24.Location = new System.Drawing.Point(117, 358);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(130, 20);
            this.label24.TabIndex = 57;
            this.label24.Text = "Number of Hours";
            // 
            // txtx_Num_Hours
            // 
            this.txtx_Num_Hours.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtx_Num_Hours.Location = new System.Drawing.Point(257, 358);
            this.txtx_Num_Hours.Name = "txtx_Num_Hours";
            this.txtx_Num_Hours.ReadOnly = true;
            this.txtx_Num_Hours.Size = new System.Drawing.Size(64, 24);
            this.txtx_Num_Hours.TabIndex = 56;
            this.txtx_Num_Hours.TextChanged += new System.EventHandler(this.txtx_Num_Hours_TextChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(846, 277);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(129, 20);
            this.label22.TabIndex = 55;
            this.label22.Text = "Number of Days:";
            this.label22.Visible = false;
            // 
            // txt_Num_Days
            // 
            this.txt_Num_Days.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Num_Days.Location = new System.Drawing.Point(862, 296);
            this.txt_Num_Days.Name = "txt_Num_Days";
            this.txt_Num_Days.Size = new System.Drawing.Size(64, 24);
            this.txt_Num_Days.TabIndex = 54;
            this.txt_Num_Days.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(11, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 23);
            this.label7.TabIndex = 53;
            this.label7.Text = "VENUE";
            // 
            // num_participants
            // 
            this.num_participants.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_participants.Location = new System.Drawing.Point(265, 156);
            this.num_participants.Name = "num_participants";
            this.num_participants.Size = new System.Drawing.Size(81, 24);
            this.num_participants.TabIndex = 11;
            // 
            // radio_No
            // 
            this.radio_No.AutoSize = true;
            this.radio_No.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_No.Location = new System.Drawing.Point(228, 126);
            this.radio_No.Name = "radio_No";
            this.radio_No.Size = new System.Drawing.Size(48, 24);
            this.radio_No.TabIndex = 33;
            this.radio_No.TabStop = true;
            this.radio_No.Text = "No";
            this.radio_No.UseVisualStyleBackColor = true;
            // 
            // radio_Yes
            // 
            this.radio_Yes.AutoSize = true;
            this.radio_Yes.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_Yes.Location = new System.Drawing.Point(168, 126);
            this.radio_Yes.Name = "radio_Yes";
            this.radio_Yes.Size = new System.Drawing.Size(50, 24);
            this.radio_Yes.TabIndex = 32;
            this.radio_Yes.TabStop = true;
            this.radio_Yes.Text = "Yes";
            this.radio_Yes.UseVisualStyleBackColor = true;
            // 
            // panel_night_time
            // 
            this.panel_night_time.Controls.Add(this.label23);
            this.panel_night_time.Controls.Add(this.radioButton2);
            this.panel_night_time.Controls.Add(this.radioButton1);
            this.panel_night_time.Enabled = false;
            this.panel_night_time.Location = new System.Drawing.Point(343, 93);
            this.panel_night_time.Name = "panel_night_time";
            this.panel_night_time.Size = new System.Drawing.Size(207, 32);
            this.panel_night_time.TabIndex = 2;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(3, 8);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(91, 20);
            this.label23.TabIndex = 57;
            this.label23.Text = "Night Time?";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton2.Location = new System.Drawing.Point(156, 4);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(48, 24);
            this.radioButton2.TabIndex = 56;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "No";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.Location = new System.Drawing.Point(100, 4);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(50, 24);
            this.radioButton1.TabIndex = 55;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Yes";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(45, 126);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(117, 20);
            this.label15.TabIndex = 31;
            this.label15.Text = "Airconditioned";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(37, 31);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(125, 20);
            this.label11.TabIndex = 25;
            this.label11.Text = "Control Number";
            // 
            // txt_controlnum
            // 
            this.txt_controlnum.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_controlnum.Location = new System.Drawing.Point(168, 27);
            this.txt_controlnum.Name = "txt_controlnum";
            this.txt_controlnum.Size = new System.Drawing.Size(162, 24);
            this.txt_controlnum.TabIndex = 24;
            this.txt_controlnum.TextChanged += new System.EventHandler(this.txt_controlnum_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(56, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(203, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "NUMBER OF PARTICIPANTS:";
            // 
            // combo_venues
            // 
            this.combo_venues.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_venues.FormattingEnabled = true;
            this.combo_venues.Location = new System.Drawing.Point(167, 59);
            this.combo_venues.Name = "combo_venues";
            this.combo_venues.Size = new System.Drawing.Size(162, 28);
            this.combo_venues.TabIndex = 37;
            this.combo_venues.SelectedIndexChanged += new System.EventHandler(this.combo_venues_SelectedIndexChanged);
            // 
            // combo_scope
            // 
            this.combo_scope.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_scope.FormattingEnabled = true;
            this.combo_scope.Location = new System.Drawing.Point(167, 93);
            this.combo_scope.Name = "combo_scope";
            this.combo_scope.Size = new System.Drawing.Size(162, 28);
            this.combo_scope.TabIndex = 52;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(36, 101);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(60, 20);
            this.label21.TabIndex = 51;
            this.label21.Text = "Scope:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(58, 239);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(185, 20);
            this.label17.TabIndex = 49;
            this.label17.Text = "Regular/Special/PGNV?";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(38, 62);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(125, 20);
            this.label16.TabIndex = 38;
            this.label16.Text = "Choose Venues";
            // 
            // combo_ReservationType
            // 
            this.combo_ReservationType.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_ReservationType.FormattingEnabled = true;
            this.combo_ReservationType.Location = new System.Drawing.Point(256, 236);
            this.combo_ReservationType.Name = "combo_ReservationType";
            this.combo_ReservationType.Size = new System.Drawing.Size(164, 28);
            this.combo_ReservationType.TabIndex = 48;
            this.combo_ReservationType.SelectedIndexChanged += new System.EventHandler(this.combo_ReservationType_SelectedIndexChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(495, 274);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(115, 20);
            this.label20.TabIndex = 46;
            this.label20.Text = "Request Origin";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(469, 213);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(60, 17);
            this.label19.TabIndex = 45;
            this.label19.Text = "Surname";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(305, 213);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(70, 17);
            this.label18.TabIndex = 44;
            this.label18.Text = "First Name";
            // 
            // txt_surname
            // 
            this.txt_surname.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_surname.Location = new System.Drawing.Point(429, 186);
            this.txt_surname.Name = "txt_surname";
            this.txt_surname.Size = new System.Drawing.Size(158, 24);
            this.txt_surname.TabIndex = 43;
            // 
            // txt_rate
            // 
            this.txt_rate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_rate.Location = new System.Drawing.Point(499, 358);
            this.txt_rate.Name = "txt_rate";
            this.txt_rate.ReadOnly = true;
            this.txt_rate.Size = new System.Drawing.Size(106, 24);
            this.txt_rate.TabIndex = 30;
            this.txt_rate.TextChanged += new System.EventHandler(this.txt_rate_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(364, 360);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(129, 20);
            this.label14.TabIndex = 29;
            this.label14.Text = "First 4 Hours Rate";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(551, 305);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(36, 20);
            this.label13.TabIndex = 28;
            this.label13.Text = "End";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(255, 305);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 20);
            this.label12.TabIndex = 27;
            this.label12.Text = "Start";
            // 
            // date_of_use_end
            // 
            this.date_of_use_end.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_of_use_end.Location = new System.Drawing.Point(613, 303);
            this.date_of_use_end.Name = "date_of_use_end";
            this.date_of_use_end.Size = new System.Drawing.Size(227, 22);
            this.date_of_use_end.TabIndex = 26;
            // 
            // txt_activity
            // 
            this.txt_activity.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_activity.Location = new System.Drawing.Point(472, 395);
            this.txt_activity.Name = "txt_activity";
            this.txt_activity.Size = new System.Drawing.Size(227, 24);
            this.txt_activity.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(388, 399);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 20);
            this.label10.TabIndex = 22;
            this.label10.Text = "ACTIVITY: ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(440, 334);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 17);
            this.label9.TabIndex = 21;
            this.label9.Text = "To:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(261, 331);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 20);
            this.label8.TabIndex = 20;
            this.label8.Text = "From:";
            // 
            // TimeEnd
            // 
            this.TimeEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.TimeEnd.Location = new System.Drawing.Point(465, 331);
            this.TimeEnd.Name = "TimeEnd";
            this.TimeEnd.ShowUpDown = true;
            this.TimeEnd.Size = new System.Drawing.Size(106, 22);
            this.TimeEnd.TabIndex = 19;
            // 
            // TimeStart
            // 
            this.TimeStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeStart.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.TimeStart.Location = new System.Drawing.Point(317, 331);
            this.TimeStart.Name = "TimeStart";
            this.TimeStart.ShowUpDown = true;
            this.TimeStart.Size = new System.Drawing.Size(106, 22);
            this.TimeStart.TabIndex = 18;
            this.TimeStart.ValueChanged += new System.EventHandler(this.TimeStart_ValueChanged);
            // 
            // btn_clearform
            // 
            this.btn_clearform.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_clearform.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_clearform.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_clearform.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_clearform.Location = new System.Drawing.Point(729, 649);
            this.btn_clearform.Name = "btn_clearform";
            this.btn_clearform.Size = new System.Drawing.Size(111, 30);
            this.btn_clearform.TabIndex = 17;
            this.btn_clearform.Text = "CLEAR FORM";
            this.btn_clearform.UseVisualStyleBackColor = false;
            this.btn_clearform.Click += new System.EventHandler(this.btn_clearform_Click);
            // 
            // btn_submit
            // 
            this.btn_submit.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_submit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_submit.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_submit.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_submit.Location = new System.Drawing.Point(851, 649);
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.Size = new System.Drawing.Size(75, 30);
            this.btn_submit.TabIndex = 16;
            this.btn_submit.Text = "SUBMIT";
            this.btn_submit.UseVisualStyleBackColor = false;
            this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click);
            // 
            // date_of_use_start
            // 
            this.date_of_use_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_of_use_start.Location = new System.Drawing.Point(302, 303);
            this.date_of_use_start.Name = "date_of_use_start";
            this.date_of_use_start.Size = new System.Drawing.Size(227, 22);
            this.date_of_use_start.TabIndex = 14;
            this.date_of_use_start.ValueChanged += new System.EventHandler(this.date_of_use_start_ValueChanged);
            // 
            // txt_contact
            // 
            this.txt_contact.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_contact.Location = new System.Drawing.Point(258, 270);
            this.txt_contact.Name = "txt_contact";
            this.txt_contact.Size = new System.Drawing.Size(198, 24);
            this.txt_contact.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(143, 331);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "TIME OF USE:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(130, 274);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "CONTACT NO.:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(141, 303);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "DATE OF USE:";
            // 
            // txt_address
            // 
            this.txt_address.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_address.Location = new System.Drawing.Point(613, 237);
            this.txt_address.Name = "txt_address";
            this.txt_address.Size = new System.Drawing.Size(215, 24);
            this.txt_address.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(494, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "ADDRESS:";
            // 
            // txt_firstname
            // 
            this.txt_firstname.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_firstname.Location = new System.Drawing.Point(261, 186);
            this.txt_firstname.Name = "txt_firstname";
            this.txt_firstname.Size = new System.Drawing.Size(162, 24);
            this.txt_firstname.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(32, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "REQUESTING OFFICE/PERSON:";
            // 
            // dgv_SelectedVenues
            // 
            this.dgv_SelectedVenues.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_SelectedVenues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_SelectedVenues.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.VenueName,
            this.ScopeName,
            this.ReservationType,
            this.UsesAircon,
            this.Rate,
            this.Hours,
            this.TotalAmount,
            this.ReservationDateStart,
            this.ReservationDateEnd,
            this.StartTime,
            this.EndTime});
            this.dgv_SelectedVenues.Location = new System.Drawing.Point(96, 480);
            this.dgv_SelectedVenues.Name = "dgv_SelectedVenues";
            this.dgv_SelectedVenues.RowHeadersVisible = false;
            this.dgv_SelectedVenues.Size = new System.Drawing.Size(830, 150);
            this.dgv_SelectedVenues.TabIndex = 2;
            // 
            // VenueName
            // 
            this.VenueName.HeaderText = "Venue Name";
            this.VenueName.Name = "VenueName";
            // 
            // ScopeName
            // 
            this.ScopeName.HeaderText = "Scope Name";
            this.ScopeName.Name = "ScopeName";
            // 
            // ReservationType
            // 
            this.ReservationType.HeaderText = "Reservation Type";
            this.ReservationType.Name = "ReservationType";
            // 
            // UsesAircon
            // 
            this.UsesAircon.HeaderText = "Aircon (Yes/No)";
            this.UsesAircon.Name = "UsesAircon";
            // 
            // Rate
            // 
            this.Rate.HeaderText = "Rate";
            this.Rate.Name = "Rate";
            // 
            // Hours
            // 
            this.Hours.HeaderText = "Hours";
            this.Hours.Name = "Hours";
            // 
            // TotalAmount
            // 
            this.TotalAmount.HeaderText = "Total Amount";
            this.TotalAmount.Name = "TotalAmount";
            // 
            // ReservationDateStart
            // 
            this.ReservationDateStart.HeaderText = "Start Date";
            this.ReservationDateStart.Name = "ReservationDateStart";
            // 
            // ReservationDateEnd
            // 
            this.ReservationDateEnd.HeaderText = "End Date";
            this.ReservationDateEnd.Name = "ReservationDateEnd";
            // 
            // StartTime
            // 
            this.StartTime.HeaderText = "Start Time";
            this.StartTime.Name = "StartTime";
            // 
            // EndTime
            // 
            this.EndTime.HeaderText = "End Time";
            this.EndTime.Name = "EndTime";
            // 
            // btn_AddVenue
            // 
            this.btn_AddVenue.Location = new System.Drawing.Point(180, 441);
            this.btn_AddVenue.Name = "btn_AddVenue";
            this.btn_AddVenue.Size = new System.Drawing.Size(75, 33);
            this.btn_AddVenue.TabIndex = 3;
            this.btn_AddVenue.Text = "Add";
            this.btn_AddVenue.UseVisualStyleBackColor = true;
            this.btn_AddVenue.Click += new System.EventHandler(this.btn_AddVenue_Click);
            // 
            // btn_RemoveVenue
            // 
            this.btn_RemoveVenue.Location = new System.Drawing.Point(271, 442);
            this.btn_RemoveVenue.Name = "btn_RemoveVenue";
            this.btn_RemoveVenue.Size = new System.Drawing.Size(75, 32);
            this.btn_RemoveVenue.TabIndex = 4;
            this.btn_RemoveVenue.Text = "Remove";
            this.btn_RemoveVenue.UseVisualStyleBackColor = true;
            // 
            // frm_Create_Venuer_Reservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1005, 724);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_Create_Venuer_Reservation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "s";
            this.Load += new System.EventHandler(this.frm_ammunganhall_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_participants)).EndInit();
            this.panel_night_time.ResumeLayout(false);
            this.panel_night_time.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SelectedVenues)).EndInit();
            this.ResumeLayout(false);

        }
        private void frm_ammunganhall_Load(object sender, EventArgs e)
        {
            // Add your load event logic here
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker TimeEnd;
        private System.Windows.Forms.DateTimePicker TimeStart;
        private System.Windows.Forms.Button btn_clearform;
        private System.Windows.Forms.Button btn_submit;
        private System.Windows.Forms.DateTimePicker date_of_use_start;
        private System.Windows.Forms.NumericUpDown num_participants;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_contact;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_address;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_firstname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_activity;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_controlnum;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker date_of_use_end;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txt_rate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.RadioButton radio_No;
        private System.Windows.Forms.RadioButton radio_Yes;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox combo_venues;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txt_surname;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox combo_ReservationType;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox combo_scope;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Panel panel_night_time;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txt_Num_Days;
        private System.Windows.Forms.TextBox txtx_Num_Hours;
        private System.Windows.Forms.TextBox txt_Hourly_Rate;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txt_Total;
        private System.Windows.Forms.ComboBox combo_Request;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txt_Requesting_Office;
        private System.Windows.Forms.DataGridView dgv_SelectedVenues;
        private System.Windows.Forms.Button btn_AddVenue;
        private System.Windows.Forms.Button btn_RemoveVenue;
        private System.Windows.Forms.DataGridViewTextBoxColumn VenueName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScopeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReservationType;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsesAircon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hours;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReservationDateStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReservationDateEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn EndTime;
    }
}