namespace pgso
{
    partial class frm_Manage_Facilities
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
            this.label1 = new System.Windows.Forms.Label();
            this.dt_Equipments = new System.Windows.Forms.DataGridView();
            this.fld_Equipment_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Equipment_Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Equipment_Price_Subsequent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Delete_Equipment = new System.Windows.Forms.Button();
            this.btn_Edit_Equipment = new System.Windows.Forms.Button();
            this.btn_Add_Equipment = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_Delete_Venue = new System.Windows.Forms.Button();
            this.btn_Edit_Venue = new System.Windows.Forms.Button();
            this.btn_Add_Venue = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dt_Venues = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dt_Equipments)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt_Venues)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Equipment";
            // 
            // dt_Equipments
            // 
            this.dt_Equipments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dt_Equipments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dt_Equipments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt_Equipments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fld_Equipment_Name,
            this.fld_Equipment_Price,
            this.fld_Equipment_Price_Subsequent});
            this.dt_Equipments.Location = new System.Drawing.Point(7, 80);
            this.dt_Equipments.Name = "dt_Equipments";
            this.dt_Equipments.ReadOnly = true;
            this.dt_Equipments.Size = new System.Drawing.Size(506, 234);
            this.dt_Equipments.TabIndex = 1;
            this.dt_Equipments.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dt_Equipments_CellContentClick);
            // 
            // fld_Equipment_Name
            // 
            this.fld_Equipment_Name.DataPropertyName = "fld_Equipment_Name";
            this.fld_Equipment_Name.HeaderText = "Equipment Name";
            this.fld_Equipment_Name.Name = "fld_Equipment_Name";
            this.fld_Equipment_Name.ReadOnly = true;
            // 
            // fld_Equipment_Price
            // 
            this.fld_Equipment_Price.DataPropertyName = "fld_Equipment_Price";
            this.fld_Equipment_Price.HeaderText = "Price";
            this.fld_Equipment_Price.Name = "fld_Equipment_Price";
            this.fld_Equipment_Price.ReadOnly = true;
            // 
            // fld_Equipment_Price_Subsequent
            // 
            this.fld_Equipment_Price_Subsequent.DataPropertyName = "fld_Equipment_Price_Subsequent";
            this.fld_Equipment_Price_Subsequent.HeaderText = "Price Subsequent";
            this.fld_Equipment_Price_Subsequent.Name = "fld_Equipment_Price_Subsequent";
            this.fld_Equipment_Price_Subsequent.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btn_Delete_Equipment);
            this.panel1.Controls.Add(this.btn_Edit_Equipment);
            this.panel1.Controls.Add(this.btn_Add_Equipment);
            this.panel1.Controls.Add(this.dt_Equipments);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(605, 336);
            this.panel1.TabIndex = 2;
            // 
            // btn_Delete_Equipment
            // 
            this.btn_Delete_Equipment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_Delete_Equipment.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Delete_Equipment.Location = new System.Drawing.Point(237, 33);
            this.btn_Delete_Equipment.Name = "btn_Delete_Equipment";
            this.btn_Delete_Equipment.Size = new System.Drawing.Size(119, 23);
            this.btn_Delete_Equipment.TabIndex = 4;
            this.btn_Delete_Equipment.Text = "Delete Equipment";
            this.btn_Delete_Equipment.UseVisualStyleBackColor = true;
            // 
            // btn_Edit_Equipment
            // 
            this.btn_Edit_Equipment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_Edit_Equipment.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Edit_Equipment.Location = new System.Drawing.Point(122, 33);
            this.btn_Edit_Equipment.Name = "btn_Edit_Equipment";
            this.btn_Edit_Equipment.Size = new System.Drawing.Size(109, 23);
            this.btn_Edit_Equipment.TabIndex = 3;
            this.btn_Edit_Equipment.Text = "Edit Equipment";
            this.btn_Edit_Equipment.UseVisualStyleBackColor = true;
            this.btn_Edit_Equipment.Click += new System.EventHandler(this.btn_Edit_Equipment_Click);
            // 
            // btn_Add_Equipment
            // 
            this.btn_Add_Equipment.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_Add_Equipment.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Add_Equipment.Location = new System.Drawing.Point(7, 33);
            this.btn_Add_Equipment.Name = "btn_Add_Equipment";
            this.btn_Add_Equipment.Size = new System.Drawing.Size(109, 23);
            this.btn_Add_Equipment.TabIndex = 2;
            this.btn_Add_Equipment.Text = "Add Equipment";
            this.btn_Add_Equipment.UseVisualStyleBackColor = true;
            this.btn_Add_Equipment.Click += new System.EventHandler(this.btn_Add_Equipment_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.btn_Delete_Venue);
            this.panel2.Controls.Add(this.btn_Edit_Venue);
            this.panel2.Controls.Add(this.btn_Add_Venue);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.dt_Venues);
            this.panel2.Location = new System.Drawing.Point(12, 354);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1201, 383);
            this.panel2.TabIndex = 3;
            // 
            // btn_Delete_Venue
            // 
            this.btn_Delete_Venue.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_Delete_Venue.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Delete_Venue.Location = new System.Drawing.Point(237, 33);
            this.btn_Delete_Venue.Name = "btn_Delete_Venue";
            this.btn_Delete_Venue.Size = new System.Drawing.Size(119, 23);
            this.btn_Delete_Venue.TabIndex = 9;
            this.btn_Delete_Venue.Text = "Delete Venue";
            this.btn_Delete_Venue.UseVisualStyleBackColor = true;
            // 
            // btn_Edit_Venue
            // 
            this.btn_Edit_Venue.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_Edit_Venue.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Edit_Venue.Location = new System.Drawing.Point(122, 33);
            this.btn_Edit_Venue.Name = "btn_Edit_Venue";
            this.btn_Edit_Venue.Size = new System.Drawing.Size(109, 23);
            this.btn_Edit_Venue.TabIndex = 8;
            this.btn_Edit_Venue.Text = "Edit Venue";
            this.btn_Edit_Venue.UseVisualStyleBackColor = true;
            // 
            // btn_Add_Venue
            // 
            this.btn_Add_Venue.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_Add_Venue.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Add_Venue.Location = new System.Drawing.Point(7, 33);
            this.btn_Add_Venue.Name = "btn_Add_Venue";
            this.btn_Add_Venue.Size = new System.Drawing.Size(109, 23);
            this.btn_Add_Venue.TabIndex = 7;
            this.btn_Add_Venue.Text = "Add Venue";
            this.btn_Add_Venue.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Venues";
            // 
            // dt_Venues
            // 
            this.dt_Venues.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dt_Venues.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dt_Venues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt_Venues.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.dt_Venues.Location = new System.Drawing.Point(7, 64);
            this.dt_Venues.Name = "dt_Venues";
            this.dt_Venues.RowHeadersVisible = false;
            this.dt_Venues.Size = new System.Drawing.Size(1181, 315);
            this.dt_Venues.TabIndex = 5;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Venue Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Airconditioned?";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Rate Type";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "First 4 Hrs Rate";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Hourly Rate";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Additional Charges";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Venue Scope";
            this.Column7.Name = "Column7";
            // 
            // frm_Manage_Facilities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 749);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frm_Manage_Facilities";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_Manage_Facilities";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_Manage_Facilities_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dt_Equipments)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt_Venues)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dt_Equipments;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Delete_Equipment;
        private System.Windows.Forms.Button btn_Edit_Equipment;
        private System.Windows.Forms.Button btn_Add_Equipment;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dt_Venues;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.Button btn_Delete_Venue;
        private System.Windows.Forms.Button btn_Edit_Venue;
        private System.Windows.Forms.Button btn_Add_Venue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Equipment_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Equipment_Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Equipment_Price_Subsequent;
    }
}