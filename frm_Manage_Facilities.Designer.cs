﻿namespace pgso
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Manage_Facilities));
            this.label1 = new System.Windows.Forms.Label();
            this.dt_Equipments = new System.Windows.Forms.DataGridView();
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
            this.fld_Venue_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Venue_Scope_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Aircon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Rate_Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_First4Hrs_Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Hourly_Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Additional_Charge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EditVenue = new System.Windows.Forms.DataGridViewImageColumn();
            this.DeleteVenue = new System.Windows.Forms.DataGridViewImageColumn();
            this.fld_Equipment_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Equipment_Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Equipment_Price_Subsequent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
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
            this.dt_Equipments.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dt_Equipments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dt_Equipments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dt_Equipments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt_Equipments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fld_Equipment_Name,
            this.fld_Equipment_Price,
            this.fld_Equipment_Price_Subsequent,
            this.Edit,
            this.Delete});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dt_Equipments.DefaultCellStyle = dataGridViewCellStyle2;
            this.dt_Equipments.Location = new System.Drawing.Point(7, 70);
            this.dt_Equipments.Name = "dt_Equipments";
            this.dt_Equipments.ReadOnly = true;
            this.dt_Equipments.Size = new System.Drawing.Size(701, 262);
            this.dt_Equipments.TabIndex = 1;
            this.dt_Equipments.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dt_Equipments_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.btn_Delete_Equipment);
            this.panel1.Controls.Add(this.btn_Edit_Equipment);
            this.panel1.Controls.Add(this.btn_Add_Equipment);
            this.panel1.Controls.Add(this.dt_Equipments);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(7, 327);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(711, 335);
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
            this.btn_Delete_Equipment.Click += new System.EventHandler(this.btn_Delete_Equipment_Click);
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
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.Controls.Add(this.btn_Delete_Venue);
            this.panel2.Controls.Add(this.btn_Edit_Venue);
            this.panel2.Controls.Add(this.btn_Add_Venue);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.dt_Venues);
            this.panel2.Location = new System.Drawing.Point(0, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1135, 329);
            this.panel2.TabIndex = 3;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
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
            this.btn_Add_Venue.Click += new System.EventHandler(this.btn_Add_Venue_Click);
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
            this.dt_Venues.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dt_Venues.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dt_Venues.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dt_Venues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt_Venues.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fld_Venue_Name,
            this.fld_Venue_Scope_Name,
            this.fld_Aircon,
            this.fld_Rate_Type,
            this.fld_First4Hrs_Rate,
            this.fld_Hourly_Rate,
            this.fld_Additional_Charge,
            this.EditVenue,
            this.DeleteVenue});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 10F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dt_Venues.DefaultCellStyle = dataGridViewCellStyle4;
            this.dt_Venues.Location = new System.Drawing.Point(14, 62);
            this.dt_Venues.Name = "dt_Venues";
            this.dt_Venues.RowHeadersVisible = false;
            this.dt_Venues.Size = new System.Drawing.Size(1103, 258);
            this.dt_Venues.TabIndex = 5;
            this.dt_Venues.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dt_Venues_CellContentClick);
            // 
            // fld_Venue_Name
            // 
            this.fld_Venue_Name.DataPropertyName = "fld_Venue_Name";
            this.fld_Venue_Name.FillWeight = 85.16833F;
            this.fld_Venue_Name.HeaderText = "Venue Name";
            this.fld_Venue_Name.Name = "fld_Venue_Name";
            // 
            // fld_Venue_Scope_Name
            // 
            this.fld_Venue_Scope_Name.DataPropertyName = "fld_Venue_Scope_Name";
            this.fld_Venue_Scope_Name.FillWeight = 85.16833F;
            this.fld_Venue_Scope_Name.HeaderText = "Venue Scope";
            this.fld_Venue_Scope_Name.Name = "fld_Venue_Scope_Name";
            // 
            // fld_Aircon
            // 
            this.fld_Aircon.DataPropertyName = "fld_Aircon";
            this.fld_Aircon.FillWeight = 85.16833F;
            this.fld_Aircon.HeaderText = "Airconditioned?";
            this.fld_Aircon.Name = "fld_Aircon";
            // 
            // fld_Rate_Type
            // 
            this.fld_Rate_Type.DataPropertyName = "fld_Rate_Type";
            this.fld_Rate_Type.FillWeight = 85.16833F;
            this.fld_Rate_Type.HeaderText = "Rate Type";
            this.fld_Rate_Type.Name = "fld_Rate_Type";
            // 
            // fld_First4Hrs_Rate
            // 
            this.fld_First4Hrs_Rate.DataPropertyName = "fld_First4Hrs_Rate";
            this.fld_First4Hrs_Rate.FillWeight = 85.16833F;
            this.fld_First4Hrs_Rate.HeaderText = "First 4 Hrs Rate";
            this.fld_First4Hrs_Rate.Name = "fld_First4Hrs_Rate";
            // 
            // fld_Hourly_Rate
            // 
            this.fld_Hourly_Rate.DataPropertyName = "fld_Hourly_Rate";
            this.fld_Hourly_Rate.FillWeight = 85.16833F;
            this.fld_Hourly_Rate.HeaderText = "Hourly Rate";
            this.fld_Hourly_Rate.Name = "fld_Hourly_Rate";
            // 
            // fld_Additional_Charge
            // 
            this.fld_Additional_Charge.DataPropertyName = "fld_Additional_Charge";
            this.fld_Additional_Charge.FillWeight = 85.16833F;
            this.fld_Additional_Charge.HeaderText = "Additional Charges";
            this.fld_Additional_Charge.Name = "fld_Additional_Charge";
            // 
            // EditVenue
            // 
            this.EditVenue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.EditVenue.HeaderText = "Edit";
            this.EditVenue.Image = ((System.Drawing.Image)(resources.GetObject("EditVenue.Image")));
            this.EditVenue.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.EditVenue.Name = "EditVenue";
            this.EditVenue.Width = 40;
            // 
            // DeleteVenue
            // 
            this.DeleteVenue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DeleteVenue.FillWeight = 203.8217F;
            this.DeleteVenue.HeaderText = "Delete";
            this.DeleteVenue.Image = ((System.Drawing.Image)(resources.GetObject("DeleteVenue.Image")));
            this.DeleteVenue.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.DeleteVenue.Name = "DeleteVenue";
            this.DeleteVenue.Width = 60;
            // 
            // fld_Equipment_Name
            // 
            this.fld_Equipment_Name.DataPropertyName = "fld_Equipment_Name";
            this.fld_Equipment_Name.FillWeight = 89.7534F;
            this.fld_Equipment_Name.HeaderText = "Equipment Name";
            this.fld_Equipment_Name.Name = "fld_Equipment_Name";
            this.fld_Equipment_Name.ReadOnly = true;
            // 
            // fld_Equipment_Price
            // 
            this.fld_Equipment_Price.DataPropertyName = "fld_Equipment_Price";
            this.fld_Equipment_Price.FillWeight = 89.7534F;
            this.fld_Equipment_Price.HeaderText = "Price";
            this.fld_Equipment_Price.Name = "fld_Equipment_Price";
            this.fld_Equipment_Price.ReadOnly = true;
            // 
            // fld_Equipment_Price_Subsequent
            // 
            this.fld_Equipment_Price_Subsequent.DataPropertyName = "fld_Equipment_Price_Subsequent";
            this.fld_Equipment_Price_Subsequent.FillWeight = 89.7534F;
            this.fld_Equipment_Price_Subsequent.HeaderText = "Price Subsequent";
            this.fld_Equipment_Price_Subsequent.Name = "fld_Equipment_Price_Subsequent";
            this.fld_Equipment_Price_Subsequent.ReadOnly = true;
            // 
            // Edit
            // 
            this.Edit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Edit.FillWeight = 171.7778F;
            this.Edit.HeaderText = "Edit";
            this.Edit.Image = ((System.Drawing.Image)(resources.GetObject("Edit.Image")));
            this.Edit.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Edit.MinimumWidth = 10;
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            this.Edit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Edit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Edit.Width = 40;
            // 
            // Delete
            // 
            this.Delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Delete.FillWeight = 58.96209F;
            this.Delete.HeaderText = "Delete";
            this.Delete.Image = ((System.Drawing.Image)(resources.GetObject("Delete.Image")));
            this.Delete.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Delete.MinimumWidth = 10;
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Delete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Delete.Width = 60;
            // 
            // frm_Manage_Facilities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 674);
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
        private System.Windows.Forms.Button btn_Delete_Venue;
        private System.Windows.Forms.Button btn_Edit_Venue;
        private System.Windows.Forms.Button btn_Add_Venue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Venue_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Venue_Scope_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Aircon;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Rate_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_First4Hrs_Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Hourly_Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Additional_Charge;
        private System.Windows.Forms.DataGridViewImageColumn EditVenue;
        private System.Windows.Forms.DataGridViewImageColumn DeleteVenue;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Equipment_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Equipment_Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Equipment_Price_Subsequent;
        private System.Windows.Forms.DataGridViewImageColumn Edit;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
    }
}