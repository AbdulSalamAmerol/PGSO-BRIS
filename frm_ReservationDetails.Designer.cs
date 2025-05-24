namespace pgso
{
    partial class frm_ReservationDetails
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
            this.button1 = new System.Windows.Forms.Button();
            this.dt_venue = new System.Windows.Forms.DataGridView();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Venue_Control = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Venue_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Venue_Scope_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Reservation_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dt_equipment = new System.Windows.Forms.DataGridView();
            this.Items = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.frm_Control_NumberE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Equipment_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Reservation_StatusE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbl_Date = new System.Windows.Forms.Label();
            this.lbl_Venue = new System.Windows.Forms.Label();
            this.lbl_Equipment = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dt_venue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_equipment)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(839, 358);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 30);
            this.button1.TabIndex = 2;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dt_venue
            // 
            this.dt_venue.AllowUserToAddRows = false;
            this.dt_venue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dt_venue.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dt_venue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt_venue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Item,
            this.Venue_Control,
            this.fld_Venue_Name,
            this.fld_Venue_Scope_Name,
            this.fld_Reservation_Status});
            this.dt_venue.Location = new System.Drawing.Point(12, 66);
            this.dt_venue.Name = "dt_venue";
            this.dt_venue.RowHeadersVisible = false;
            this.dt_venue.Size = new System.Drawing.Size(448, 286);
            this.dt_venue.TabIndex = 3;
            this.dt_venue.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dt_venue_CellContentClick);
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
            // Venue_Control
            // 
            this.Venue_Control.DataPropertyName = "fld_Control_Number";
            this.Venue_Control.HeaderText = "Control Number";
            this.Venue_Control.Name = "Venue_Control";
            // 
            // fld_Venue_Name
            // 
            this.fld_Venue_Name.DataPropertyName = "fld_Venue_Name";
            this.fld_Venue_Name.HeaderText = "Venue";
            this.fld_Venue_Name.Name = "fld_Venue_Name";
            // 
            // fld_Venue_Scope_Name
            // 
            this.fld_Venue_Scope_Name.DataPropertyName = "fld_Venue_Scope_Name";
            this.fld_Venue_Scope_Name.HeaderText = "Scope";
            this.fld_Venue_Scope_Name.Name = "fld_Venue_Scope_Name";
            this.fld_Venue_Scope_Name.ReadOnly = true;
            // 
            // fld_Reservation_Status
            // 
            this.fld_Reservation_Status.DataPropertyName = "fld_Reservation_Status";
            this.fld_Reservation_Status.HeaderText = "Status";
            this.fld_Reservation_Status.Name = "fld_Reservation_Status";
            this.fld_Reservation_Status.ReadOnly = true;
            // 
            // dt_equipment
            // 
            this.dt_equipment.AllowUserToAddRows = false;
            this.dt_equipment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dt_equipment.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dt_equipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt_equipment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Items,
            this.frm_Control_NumberE,
            this.fld_Equipment_Name,
            this.fld_Quantity,
            this.fld_Reservation_StatusE});
            this.dt_equipment.Location = new System.Drawing.Point(466, 66);
            this.dt_equipment.Name = "dt_equipment";
            this.dt_equipment.RowHeadersVisible = false;
            this.dt_equipment.Size = new System.Drawing.Size(448, 286);
            this.dt_equipment.TabIndex = 4;
            this.dt_equipment.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dt_equipment_CellContentClick);
            // 
            // Items
            // 
            this.Items.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Items.DefaultCellStyle = dataGridViewCellStyle4;
            this.Items.HeaderText = "Item";
            this.Items.Name = "Items";
            this.Items.ReadOnly = true;
            this.Items.Width = 50;
            // 
            // frm_Control_NumberE
            // 
            this.frm_Control_NumberE.DataPropertyName = "fld_Control_Number";
            this.frm_Control_NumberE.HeaderText = "Control Number";
            this.frm_Control_NumberE.Name = "frm_Control_NumberE";
            // 
            // fld_Equipment_Name
            // 
            this.fld_Equipment_Name.DataPropertyName = "fld_Equipment_Name";
            this.fld_Equipment_Name.HeaderText = "Equipment";
            this.fld_Equipment_Name.Name = "fld_Equipment_Name";
            // 
            // fld_Quantity
            // 
            this.fld_Quantity.DataPropertyName = "fld_Quantity";
            this.fld_Quantity.HeaderText = "Quantity";
            this.fld_Quantity.Name = "fld_Quantity";
            this.fld_Quantity.ReadOnly = true;
            // 
            // fld_Reservation_StatusE
            // 
            this.fld_Reservation_StatusE.DataPropertyName = "fld_Equipment_Status";
            this.fld_Reservation_StatusE.HeaderText = "Status";
            this.fld_Reservation_StatusE.Name = "fld_Reservation_StatusE";
            this.fld_Reservation_StatusE.ReadOnly = true;
            // 
            // lbl_Date
            // 
            this.lbl_Date.AutoSize = true;
            this.lbl_Date.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.lbl_Date.Location = new System.Drawing.Point(12, 9);
            this.lbl_Date.Name = "lbl_Date";
            this.lbl_Date.Size = new System.Drawing.Size(66, 24);
            this.lbl_Date.TabIndex = 5;
            this.lbl_Date.Text = "label2";
            // 
            // lbl_Venue
            // 
            this.lbl_Venue.AutoSize = true;
            this.lbl_Venue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbl_Venue.Location = new System.Drawing.Point(9, 46);
            this.lbl_Venue.Name = "lbl_Venue";
            this.lbl_Venue.Size = new System.Drawing.Size(51, 16);
            this.lbl_Venue.TabIndex = 6;
            this.lbl_Venue.Text = "Venue";
            this.lbl_Venue.Visible = false;
            // 
            // lbl_Equipment
            // 
            this.lbl_Equipment.AutoSize = true;
            this.lbl_Equipment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lbl_Equipment.Location = new System.Drawing.Point(463, 46);
            this.lbl_Equipment.Name = "lbl_Equipment";
            this.lbl_Equipment.Size = new System.Drawing.Size(80, 16);
            this.lbl_Equipment.TabIndex = 7;
            this.lbl_Equipment.Text = "Equipment";
            this.lbl_Equipment.Visible = false;
            // 
            // frm_ReservationDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(930, 397);
            this.Controls.Add(this.lbl_Equipment);
            this.Controls.Add(this.lbl_Venue);
            this.Controls.Add(this.lbl_Date);
            this.Controls.Add(this.dt_equipment);
            this.Controls.Add(this.dt_venue);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimizeBox = false;
            this.Name = "frm_ReservationDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reservation Details";
            this.Load += new System.EventHandler(this.frm_ReservationDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dt_venue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_equipment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dt_venue;
        private System.Windows.Forms.DataGridView dt_equipment;
        private System.Windows.Forms.Label lbl_Date;
        private System.Windows.Forms.Label lbl_Venue;
        private System.Windows.Forms.Label lbl_Equipment;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn Venue_Control;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Venue_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Venue_Scope_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Reservation_Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Items;
        private System.Windows.Forms.DataGridViewTextBoxColumn frm_Control_NumberE;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Equipment_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Reservation_StatusE;
    }
}