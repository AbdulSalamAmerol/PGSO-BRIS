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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Btn_Approved = new System.Windows.Forms.Button();
            this.Btn_Pending = new System.Windows.Forms.Button();
            this.Btn_Canceled = new System.Windows.Forms.Button();
            this.Btn_Refresh = new System.Windows.Forms.Button();
            this.btn_approvependings = new System.Windows.Forms.Button();
            this.Btn_Cancel = new System.Windows.Forms.Button();
            this.Btn_Create = new System.Windows.Forms.Button();
            this.dt_approved = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Contact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbl_approved = new System.Windows.Forms.Label();
            this.lbl_pending = new System.Windows.Forms.Label();
            this.dt_pendings = new System.Windows.Forms.DataGridView();
            this.lbl_canceled = new System.Windows.Forms.Label();
            this.dt_canceled = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt_approved)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_pendings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_canceled)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.Btn_Refresh);
            this.panel1.Controls.Add(this.btn_approvependings);
            this.panel1.Controls.Add(this.Btn_Cancel);
            this.panel1.Controls.Add(this.Btn_Create);
            this.panel1.Location = new System.Drawing.Point(3, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1173, 96);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Btn_Approved);
            this.groupBox1.Controls.Add(this.Btn_Pending);
            this.groupBox1.Controls.Add(this.Btn_Canceled);
            this.groupBox1.Location = new System.Drawing.Point(9, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(465, 56);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "VIEW:";
            // 
            // Btn_Approved
            // 
            this.Btn_Approved.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn_Approved.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Approved.Location = new System.Drawing.Point(12, 19);
            this.Btn_Approved.Name = "Btn_Approved";
            this.Btn_Approved.Size = new System.Drawing.Size(145, 35);
            this.Btn_Approved.TabIndex = 2;
            this.Btn_Approved.Text = "Approved";
            this.Btn_Approved.UseVisualStyleBackColor = true;
            this.Btn_Approved.Click += new System.EventHandler(this.Btn_Approved_Click);
            // 
            // Btn_Pending
            // 
            this.Btn_Pending.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn_Pending.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Pending.Location = new System.Drawing.Point(163, 19);
            this.Btn_Pending.Name = "Btn_Pending";
            this.Btn_Pending.Size = new System.Drawing.Size(145, 35);
            this.Btn_Pending.TabIndex = 1;
            this.Btn_Pending.Text = "Pendings";
            this.Btn_Pending.UseVisualStyleBackColor = true;
            this.Btn_Pending.Click += new System.EventHandler(this.Btn_Pending_Click);
            // 
            // Btn_Canceled
            // 
            this.Btn_Canceled.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn_Canceled.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Canceled.Location = new System.Drawing.Point(314, 19);
            this.Btn_Canceled.Name = "Btn_Canceled";
            this.Btn_Canceled.Size = new System.Drawing.Size(145, 35);
            this.Btn_Canceled.TabIndex = 3;
            this.Btn_Canceled.Text = "Cancelled";
            this.Btn_Canceled.UseVisualStyleBackColor = true;
            this.Btn_Canceled.Click += new System.EventHandler(this.Btn_Cancel_Click);
            // 
            // Btn_Refresh
            // 
            this.Btn_Refresh.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Btn_Refresh.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Refresh.Location = new System.Drawing.Point(657, 3);
            this.Btn_Refresh.Name = "Btn_Refresh";
            this.Btn_Refresh.Size = new System.Drawing.Size(212, 33);
            this.Btn_Refresh.TabIndex = 6;
            this.Btn_Refresh.Text = "Refresh";
            this.Btn_Refresh.UseVisualStyleBackColor = true;
            this.Btn_Refresh.Click += new System.EventHandler(this.Btn_Refresh_Click);
            // 
            // btn_approvependings
            // 
            this.btn_approvependings.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btn_approvependings.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_approvependings.Location = new System.Drawing.Point(439, 3);
            this.btn_approvependings.Name = "btn_approvependings";
            this.btn_approvependings.Size = new System.Drawing.Size(212, 33);
            this.btn_approvependings.TabIndex = 5;
            this.btn_approvependings.Text = "Approve Pendings";
            this.btn_approvependings.UseVisualStyleBackColor = true;
            this.btn_approvependings.Click += new System.EventHandler(this.btn_approvependings_Click);
            // 
            // Btn_Cancel
            // 
            this.Btn_Cancel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Btn_Cancel.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Cancel.Location = new System.Drawing.Point(221, 3);
            this.Btn_Cancel.Name = "Btn_Cancel";
            this.Btn_Cancel.Size = new System.Drawing.Size(212, 33);
            this.Btn_Cancel.TabIndex = 4;
            this.Btn_Cancel.Text = "Cancel Reservation";
            this.Btn_Cancel.UseVisualStyleBackColor = true;
            this.Btn_Cancel.Click += new System.EventHandler(this.Btn_Cancel_Click_1);
            // 
            // Btn_Create
            // 
            this.Btn_Create.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Btn_Create.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Create.Location = new System.Drawing.Point(9, 3);
            this.Btn_Create.Name = "Btn_Create";
            this.Btn_Create.Size = new System.Drawing.Size(206, 33);
            this.Btn_Create.TabIndex = 0;
            this.Btn_Create.Text = "Create Reservation";
            this.Btn_Create.UseVisualStyleBackColor = true;
            this.Btn_Create.Click += new System.EventHandler(this.Btn_Create_Click);
            // 
            // dt_approved
            // 
            this.dt_approved.AllowUserToResizeRows = false;
            this.dt_approved.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dt_approved.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dt_approved.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dt_approved.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt_approved.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column8,
            this.Contact,
            this.Column6,
            this.Column10,
            this.Column7,
            this.Column9,
            this.Column5,
            this.Column13});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dt_approved.DefaultCellStyle = dataGridViewCellStyle2;
            this.dt_approved.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dt_approved.Location = new System.Drawing.Point(23, 124);
            this.dt_approved.Name = "dt_approved";
            this.dt_approved.RowHeadersVisible = false;
            this.dt_approved.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dt_approved.Size = new System.Drawing.Size(1135, 153);
            this.dt_approved.TabIndex = 1;
            this.dt_approved.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtvenuereservation_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "fld_Control_Number";
            this.Column1.HeaderText = "Control No.";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "fld_First_Name";
            this.Column2.HeaderText = "Requestor";
            this.Column2.Name = "Column2";
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "fld_Activity_Name";
            this.Column8.HeaderText = "Activity";
            this.Column8.Name = "Column8";
            // 
            // Contact
            // 
            this.Contact.DataPropertyName = "fld_Contact_Number";
            this.Contact.HeaderText = "Contact";
            this.Contact.Name = "Contact";
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "fld_Start_Date";
            this.Column6.HeaderText = "Date Start";
            this.Column6.Name = "Column6";
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "fld_End_Date";
            this.Column10.HeaderText = "Date End";
            this.Column10.Name = "Column10";
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "fld_Start_Time";
            this.Column7.HeaderText = "Time Start";
            this.Column7.Name = "Column7";
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "fld_End_Time";
            this.Column9.HeaderText = "Time End";
            this.Column9.Name = "Column9";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "fld_Reservation_Status";
            this.Column5.HeaderText = "Status";
            this.Column5.Name = "Column5";
            // 
            // Column13
            // 
            this.Column13.DataPropertyName = "fld_Total_Amount";
            this.Column13.HeaderText = "Total";
            this.Column13.Name = "Column13";
            // 
            // lbl_approved
            // 
            this.lbl_approved.AutoSize = true;
            this.lbl_approved.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_approved.Location = new System.Drawing.Point(20, 100);
            this.lbl_approved.Name = "lbl_approved";
            this.lbl_approved.Size = new System.Drawing.Size(97, 21);
            this.lbl_approved.TabIndex = 2;
            this.lbl_approved.Text = "APPROVED";
            // 
            // lbl_pending
            // 
            this.lbl_pending.AutoSize = true;
            this.lbl_pending.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_pending.Location = new System.Drawing.Point(19, 296);
            this.lbl_pending.Name = "lbl_pending";
            this.lbl_pending.Size = new System.Drawing.Size(86, 21);
            this.lbl_pending.TabIndex = 3;
            this.lbl_pending.Text = "PENDNGS";
            // 
            // dt_pendings
            // 
            this.dt_pendings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dt_pendings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dt_pendings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dt_pendings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt_pendings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.Column11,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.Column14});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dt_pendings.DefaultCellStyle = dataGridViewCellStyle4;
            this.dt_pendings.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dt_pendings.Location = new System.Drawing.Point(23, 320);
            this.dt_pendings.Name = "dt_pendings";
            this.dt_pendings.RowHeadersVisible = false;
            this.dt_pendings.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dt_pendings.Size = new System.Drawing.Size(1135, 152);
            this.dt_pendings.TabIndex = 4;
            this.dt_pendings.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dt_pendings_CellContentClick);
            // 
            // lbl_canceled
            // 
            this.lbl_canceled.AutoSize = true;
            this.lbl_canceled.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_canceled.Location = new System.Drawing.Point(19, 490);
            this.lbl_canceled.Name = "lbl_canceled";
            this.lbl_canceled.Size = new System.Drawing.Size(98, 21);
            this.lbl_canceled.TabIndex = 5;
            this.lbl_canceled.Text = "CANCELED";
            // 
            // dt_canceled
            // 
            this.dt_canceled.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dt_canceled.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft YaHei", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dt_canceled.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dt_canceled.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt_canceled.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15,
            this.Column15,
            this.Column16});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dt_canceled.DefaultCellStyle = dataGridViewCellStyle6;
            this.dt_canceled.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dt_canceled.Location = new System.Drawing.Point(23, 523);
            this.dt_canceled.Name = "dt_canceled";
            this.dt_canceled.RowHeadersVisible = false;
            this.dt_canceled.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dt_canceled.Size = new System.Drawing.Size(1135, 171);
            this.dt_canceled.TabIndex = 6;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "fld_Control_Number";
            this.dataGridViewTextBoxColumn11.HeaderText = "Control Number";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "fld_First_Name";
            this.dataGridViewTextBoxColumn12.HeaderText = "First Name";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "fld_Requesting_Person_Address";
            this.dataGridViewTextBoxColumn13.HeaderText = "Address";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "fld_Activity_Name";
            this.dataGridViewTextBoxColumn14.HeaderText = "Activity";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "fld_Number_Of_Participants";
            this.dataGridViewTextBoxColumn15.HeaderText = "Participants";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            // 
            // Column15
            // 
            this.Column15.DataPropertyName = "fld_Reservation_Status";
            this.Column15.HeaderText = "Status";
            this.Column15.Name = "Column15";
            // 
            // Column16
            // 
            this.Column16.DataPropertyName = "fld_Total_Amount";
            this.Column16.HeaderText = "Total";
            this.Column16.Name = "Column16";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "fld_Control_Number";
            this.dataGridViewTextBoxColumn1.HeaderText = "Control No.";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "fld_First_Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Requestor";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "fld_Requesting_Person_Address";
            this.dataGridViewTextBoxColumn3.HeaderText = "Address";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "fld_Activity_Name";
            this.dataGridViewTextBoxColumn4.HeaderText = "Activity";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "fld_Contact_Number";
            this.dataGridViewTextBoxColumn5.HeaderText = "Contact";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "fld_Number_Of_Participants";
            this.dataGridViewTextBoxColumn6.HeaderText = "Participants";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "fld_Start_Date";
            this.Column11.HeaderText = "Date Start";
            this.Column11.Name = "Column11";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "fld_End_Date";
            this.dataGridViewTextBoxColumn7.HeaderText = "Date End";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "fld_Start_Time";
            this.dataGridViewTextBoxColumn8.HeaderText = "Time Start";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "fld_End_Time";
            this.dataGridViewTextBoxColumn9.HeaderText = "Time End";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "fld_Reservation_Status";
            this.dataGridViewTextBoxColumn10.HeaderText = "Status";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // Column14
            // 
            this.Column14.DataPropertyName = "fld_Total_Amount";
            this.Column14.HeaderText = "Total";
            this.Column14.Name = "Column14";
            // 
            // frm_Venues
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(1180, 727);
            this.Controls.Add(this.dt_canceled);
            this.Controls.Add(this.lbl_canceled);
            this.Controls.Add(this.dt_pendings);
            this.Controls.Add(this.lbl_pending);
            this.Controls.Add(this.lbl_approved);
            this.Controls.Add(this.dt_approved);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frm_Venues";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VENUES";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_Venues_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dt_approved)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_pendings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_canceled)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Btn_Create;
        private System.Windows.Forms.Button Btn_Approved;
        private System.Windows.Forms.Button Btn_Pending;
        private System.Windows.Forms.DataGridView dt_approved;
        private System.Windows.Forms.Label lbl_approved;
        private System.Windows.Forms.Label lbl_pending;
        private System.Windows.Forms.DataGridView dt_pendings;
        private System.Windows.Forms.Label lbl_canceled;
        private System.Windows.Forms.DataGridView dt_canceled;
        private System.Windows.Forms.Button Btn_Canceled;
        private System.Windows.Forms.Button Btn_Cancel;
        private System.Windows.Forms.Button btn_approvependings;
        private System.Windows.Forms.Button Btn_Refresh;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Contact;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
    }
}