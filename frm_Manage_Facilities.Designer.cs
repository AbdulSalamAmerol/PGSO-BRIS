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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Manage_Facilities));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dt_Equipments = new System.Windows.Forms.DataGridView();
            this.Items = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Equipment_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Equipment_Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Equipment_Price_Subsequent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Remaining_Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Total_Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_Search_Equipmet = new System.Windows.Forms.TextBox();
            this.btn_Add_Equipment = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_Search_Venue = new System.Windows.Forms.TextBox();
            this.btn_AddScope = new System.Windows.Forms.Button();
            this.btn_Add_Venue = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dt_Venues = new System.Windows.Forms.DataGridView();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Venue_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Venue_Scope_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Aircon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Rate_Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_First4Hrs_Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Hourly_Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Additional_Charge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EditVenue = new System.Windows.Forms.DataGridViewImageColumn();
            this.DeleteVenue = new System.Windows.Forms.DataGridViewImageColumn();
            this.combo_Facilities = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dt_Equipments)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt_Venues)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Equipment";
            // 
            // dt_Equipments
            // 
            this.dt_Equipments.AllowUserToAddRows = false;
            this.dt_Equipments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dt_Equipments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dt_Equipments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dt_Equipments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt_Equipments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Items,
            this.fld_Equipment_Name,
            this.fld_Equipment_Price,
            this.fld_Equipment_Price_Subsequent,
            this.fld_Remaining_Stock,
            this.fld_Total_Stock,
            this.Edit,
            this.Delete});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dt_Equipments.DefaultCellStyle = dataGridViewCellStyle11;
            this.dt_Equipments.Location = new System.Drawing.Point(7, 62);
            this.dt_Equipments.Name = "dt_Equipments";
            this.dt_Equipments.ReadOnly = true;
            this.dt_Equipments.RowHeadersVisible = false;
            this.dt_Equipments.Size = new System.Drawing.Size(1249, 262);
            this.dt_Equipments.TabIndex = 1;
            this.dt_Equipments.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dt_Equipments_CellContentClick);
            // 
            // Items
            // 
            this.Items.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Items.DefaultCellStyle = dataGridViewCellStyle9;
            this.Items.HeaderText = "Item";
            this.Items.Name = "Items";
            this.Items.ReadOnly = true;
            this.Items.Width = 50;
            // 
            // fld_Equipment_Name
            // 
            this.fld_Equipment_Name.DataPropertyName = "fld_Equipment_Name";
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            this.fld_Equipment_Name.DefaultCellStyle = dataGridViewCellStyle10;
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
            // fld_Remaining_Stock
            // 
            this.fld_Remaining_Stock.DataPropertyName = "fld_Total_Stock";
            this.fld_Remaining_Stock.HeaderText = "Total Stock";
            this.fld_Remaining_Stock.Name = "fld_Remaining_Stock";
            this.fld_Remaining_Stock.ReadOnly = true;
            // 
            // fld_Total_Stock
            // 
            this.fld_Total_Stock.DataPropertyName = "fld_Remaining_Stock";
            this.fld_Total_Stock.HeaderText = "Available Stock";
            this.fld_Total_Stock.Name = "fld_Total_Stock";
            this.fld_Total_Stock.ReadOnly = true;
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
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.txt_Search_Equipmet);
            this.panel1.Controls.Add(this.btn_Add_Equipment);
            this.panel1.Controls.Add(this.dt_Equipments);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 402);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1272, 335);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // txt_Search_Equipmet
            // 
            this.txt_Search_Equipmet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Search_Equipmet.Location = new System.Drawing.Point(133, 23);
            this.txt_Search_Equipmet.Name = "txt_Search_Equipmet";
            this.txt_Search_Equipmet.Size = new System.Drawing.Size(136, 21);
            this.txt_Search_Equipmet.TabIndex = 10;
            this.txt_Search_Equipmet.TextChanged += new System.EventHandler(this.txt_Search_Equipmet_TextChanged);
            // 
            // btn_Add_Equipment
            // 
            this.btn_Add_Equipment.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btn_Add_Equipment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Add_Equipment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Add_Equipment.Location = new System.Drawing.Point(7, 21);
            this.btn_Add_Equipment.Name = "btn_Add_Equipment";
            this.btn_Add_Equipment.Size = new System.Drawing.Size(109, 23);
            this.btn_Add_Equipment.TabIndex = 2;
            this.btn_Add_Equipment.Text = "Add Equipment";
            this.btn_Add_Equipment.UseVisualStyleBackColor = false;
            this.btn_Add_Equipment.Click += new System.EventHandler(this.btn_Add_Equipment_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.txt_Search_Venue);
            this.panel2.Controls.Add(this.btn_AddScope);
            this.panel2.Controls.Add(this.btn_Add_Venue);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.dt_Venues);
            this.panel2.Location = new System.Drawing.Point(12, 56);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1272, 340);
            this.panel2.TabIndex = 3;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // txt_Search_Venue
            // 
            this.txt_Search_Venue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Search_Venue.Location = new System.Drawing.Point(269, 23);
            this.txt_Search_Venue.Name = "txt_Search_Venue";
            this.txt_Search_Venue.Size = new System.Drawing.Size(136, 22);
            this.txt_Search_Venue.TabIndex = 9;
            this.txt_Search_Venue.TextChanged += new System.EventHandler(this.txt_Search_Venue_TextChanged);
            // 
            // btn_AddScope
            // 
            this.btn_AddScope.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btn_AddScope.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddScope.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btn_AddScope.Location = new System.Drawing.Point(133, 23);
            this.btn_AddScope.Name = "btn_AddScope";
            this.btn_AddScope.Size = new System.Drawing.Size(109, 23);
            this.btn_AddScope.TabIndex = 8;
            this.btn_AddScope.Text = "Add Scope";
            this.btn_AddScope.UseVisualStyleBackColor = false;
            this.btn_AddScope.Click += new System.EventHandler(this.btn_AddScope_Click);
            // 
            // btn_Add_Venue
            // 
            this.btn_Add_Venue.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btn_Add_Venue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Add_Venue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btn_Add_Venue.Location = new System.Drawing.Point(7, 23);
            this.btn_Add_Venue.Name = "btn_Add_Venue";
            this.btn_Add_Venue.Size = new System.Drawing.Size(109, 23);
            this.btn_Add_Venue.TabIndex = 7;
            this.btn_Add_Venue.Text = "Add Venue";
            this.btn_Add_Venue.UseVisualStyleBackColor = false;
            this.btn_Add_Venue.Click += new System.EventHandler(this.btn_Add_Venue_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Venues";
            // 
            // dt_Venues
            // 
            this.dt_Venues.AllowUserToAddRows = false;
            this.dt_Venues.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dt_Venues.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dt_Venues.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dt_Venues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt_Venues.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Item,
            this.fld_Venue_Name,
            this.fld_Venue_Scope_Name,
            this.fld_Aircon,
            this.fld_Rate_Type,
            this.fld_First4Hrs_Rate,
            this.fld_Hourly_Rate,
            this.fld_Additional_Charge,
            this.EditVenue,
            this.DeleteVenue});
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dt_Venues.DefaultCellStyle = dataGridViewCellStyle14;
            this.dt_Venues.Location = new System.Drawing.Point(7, 52);
            this.dt_Venues.Name = "dt_Venues";
            this.dt_Venues.ReadOnly = true;
            this.dt_Venues.RowHeadersVisible = false;
            this.dt_Venues.Size = new System.Drawing.Size(1254, 279);
            this.dt_Venues.TabIndex = 5;
            this.dt_Venues.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dt_Venues_CellContentClick);
            // 
            // Item
            // 
            this.Item.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Item.DefaultCellStyle = dataGridViewCellStyle13;
            this.Item.HeaderText = "Item";
            this.Item.Name = "Item";
            this.Item.ReadOnly = true;
            this.Item.Width = 50;
            // 
            // fld_Venue_Name
            // 
            this.fld_Venue_Name.DataPropertyName = "fld_Venue_Name";
            this.fld_Venue_Name.FillWeight = 85.16833F;
            this.fld_Venue_Name.HeaderText = "Venue Name";
            this.fld_Venue_Name.Name = "fld_Venue_Name";
            this.fld_Venue_Name.ReadOnly = true;
            // 
            // fld_Venue_Scope_Name
            // 
            this.fld_Venue_Scope_Name.DataPropertyName = "fld_Venue_Scope_Name";
            this.fld_Venue_Scope_Name.FillWeight = 85.16833F;
            this.fld_Venue_Scope_Name.HeaderText = "Venue Scope";
            this.fld_Venue_Scope_Name.Name = "fld_Venue_Scope_Name";
            this.fld_Venue_Scope_Name.ReadOnly = true;
            // 
            // fld_Aircon
            // 
            this.fld_Aircon.DataPropertyName = "fld_Aircon";
            this.fld_Aircon.FillWeight = 85.16833F;
            this.fld_Aircon.HeaderText = "Airconditioned";
            this.fld_Aircon.Name = "fld_Aircon";
            this.fld_Aircon.ReadOnly = true;
            // 
            // fld_Rate_Type
            // 
            this.fld_Rate_Type.DataPropertyName = "fld_Rate_Type";
            this.fld_Rate_Type.FillWeight = 85.16833F;
            this.fld_Rate_Type.HeaderText = "Rate Type";
            this.fld_Rate_Type.Name = "fld_Rate_Type";
            this.fld_Rate_Type.ReadOnly = true;
            // 
            // fld_First4Hrs_Rate
            // 
            this.fld_First4Hrs_Rate.DataPropertyName = "fld_First4Hrs_Rate";
            this.fld_First4Hrs_Rate.FillWeight = 85.16833F;
            this.fld_First4Hrs_Rate.HeaderText = "First 4 Hrs Rate";
            this.fld_First4Hrs_Rate.Name = "fld_First4Hrs_Rate";
            this.fld_First4Hrs_Rate.ReadOnly = true;
            // 
            // fld_Hourly_Rate
            // 
            this.fld_Hourly_Rate.DataPropertyName = "fld_Hourly_Rate";
            this.fld_Hourly_Rate.FillWeight = 85.16833F;
            this.fld_Hourly_Rate.HeaderText = "Succeeding Hours Rate";
            this.fld_Hourly_Rate.Name = "fld_Hourly_Rate";
            this.fld_Hourly_Rate.ReadOnly = true;
            // 
            // fld_Additional_Charge
            // 
            this.fld_Additional_Charge.DataPropertyName = "fld_Additional_Charge";
            this.fld_Additional_Charge.FillWeight = 85.16833F;
            this.fld_Additional_Charge.HeaderText = "Additional Charges";
            this.fld_Additional_Charge.Name = "fld_Additional_Charge";
            this.fld_Additional_Charge.ReadOnly = true;
            // 
            // EditVenue
            // 
            this.EditVenue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.EditVenue.HeaderText = "Edit";
            this.EditVenue.Image = ((System.Drawing.Image)(resources.GetObject("EditVenue.Image")));
            this.EditVenue.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.EditVenue.Name = "EditVenue";
            this.EditVenue.ReadOnly = true;
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
            this.DeleteVenue.ReadOnly = true;
            this.DeleteVenue.Width = 60;
            // 
            // combo_Facilities
            // 
            this.combo_Facilities.FormattingEnabled = true;
            this.combo_Facilities.Location = new System.Drawing.Point(12, 13);
            this.combo_Facilities.Name = "combo_Facilities";
            this.combo_Facilities.Size = new System.Drawing.Size(121, 21);
            this.combo_Facilities.TabIndex = 4;
            // 
            // frm_Manage_Facilities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1296, 749);
            this.Controls.Add(this.combo_Facilities);
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
        private System.Windows.Forms.Button btn_Add_Equipment;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dt_Venues;
        private System.Windows.Forms.Button btn_Add_Venue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_AddScope;
        private System.Windows.Forms.DataGridViewTextBoxColumn Items;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Equipment_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Equipment_Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Equipment_Price_Subsequent;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Remaining_Stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Total_Stock;
        private System.Windows.Forms.DataGridViewImageColumn Edit;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Venue_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Venue_Scope_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Aircon;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Rate_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_First4Hrs_Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Hourly_Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Additional_Charge;
        private System.Windows.Forms.DataGridViewImageColumn EditVenue;
        private System.Windows.Forms.DataGridViewImageColumn DeleteVenue;

        private System.Windows.Forms.TextBox txt_Search_Equipmet;
        private System.Windows.Forms.TextBox txt_Search_Venue;
        private System.Windows.Forms.ComboBox combo_Facilities;
    }
}