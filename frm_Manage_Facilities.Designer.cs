namespace pgso
{
    partial class frm_Manage_Venue
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Manage_Venue));
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblPageInfo = new System.Windows.Forms.Label();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.btnPrevPage = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.combo_Filter = new System.Windows.Forms.ComboBox();
            this.txt_Search_Venue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.combo_Sort = new System.Windows.Forms.ComboBox();
            this.btn_AddScope = new System.Windows.Forms.Button();
            this.btn_Add_Venue = new System.Windows.Forms.Button();
            this.dt_Venues = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.panel_Add_Venue = new System.Windows.Forms.Panel();
            this.panel_AddScope = new System.Windows.Forms.Panel();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Venue_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Venue_Scope_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Aircon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Rate_Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_First4Hrs_Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Hourly_Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Additional_Charge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Caterer_Fee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pk_Venue_PricingID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EditVenue = new System.Windows.Forms.DataGridViewImageColumn();
            this.DeleteVenue = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt_Venues)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.btn_AddScope);
            this.panel2.Controls.Add(this.btn_Add_Venue);
            this.panel2.Controls.Add(this.dt_Venues);
            this.panel2.Location = new System.Drawing.Point(12, 189);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1900, 778);
            this.panel2.TabIndex = 3;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblPageInfo);
            this.panel3.Controls.Add(this.btnNextPage);
            this.panel3.Controls.Add(this.btnPrevPage);
            this.panel3.Location = new System.Drawing.Point(1684, 11);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(205, 38);
            this.panel3.TabIndex = 36;
            // 
            // lblPageInfo
            // 
            this.lblPageInfo.AutoSize = true;
            this.lblPageInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageInfo.Location = new System.Drawing.Point(55, 11);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(89, 20);
            this.lblPageInfo.TabIndex = 17;
            this.lblPageInfo.Text = "lblPageInfo";
            this.lblPageInfo.Click += new System.EventHandler(this.lblPageInfo_Click);
            // 
            // btnNextPage
            // 
            this.btnNextPage.Location = new System.Drawing.Point(150, 8);
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
            // panel5
            // 
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.combo_Filter);
            this.panel5.Controls.Add(this.txt_Search_Venue);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.combo_Sort);
            this.panel5.Location = new System.Drawing.Point(259, 11);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(710, 37);
            this.panel5.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Search:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(258, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Fiter:";
            // 
            // combo_Filter
            // 
            this.combo_Filter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_Filter.FormattingEnabled = true;
            this.combo_Filter.Location = new System.Drawing.Point(309, 5);
            this.combo_Filter.Name = "combo_Filter";
            this.combo_Filter.Size = new System.Drawing.Size(153, 28);
            this.combo_Filter.TabIndex = 2;
            this.combo_Filter.SelectedIndexChanged += new System.EventHandler(this.combo_Filter_SelectedIndexChanged);
            // 
            // txt_Search_Venue
            // 
            this.txt_Search_Venue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Search_Venue.Location = new System.Drawing.Point(93, 5);
            this.txt_Search_Venue.Name = "txt_Search_Venue";
            this.txt_Search_Venue.Size = new System.Drawing.Size(136, 26);
            this.txt_Search_Venue.TabIndex = 9;
            this.txt_Search_Venue.TextChanged += new System.EventHandler(this.txt_Search_Venue_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(485, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Sort by:";
            // 
            // combo_Sort
            // 
            this.combo_Sort.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_Sort.FormattingEnabled = true;
            this.combo_Sort.Location = new System.Drawing.Point(554, 5);
            this.combo_Sort.Name = "combo_Sort";
            this.combo_Sort.Size = new System.Drawing.Size(153, 28);
            this.combo_Sort.TabIndex = 0;
            this.combo_Sort.SelectedIndexChanged += new System.EventHandler(this.combo_Sort_SelectedIndexChanged);
            // 
            // btn_AddScope
            // 
            this.btn_AddScope.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btn_AddScope.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_AddScope.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddScope.Location = new System.Drawing.Point(133, 7);
            this.btn_AddScope.Name = "btn_AddScope";
            this.btn_AddScope.Size = new System.Drawing.Size(109, 41);
            this.btn_AddScope.TabIndex = 8;
            this.btn_AddScope.Text = "Add Scope";
            this.btn_AddScope.UseVisualStyleBackColor = false;
            this.btn_AddScope.Click += new System.EventHandler(this.btn_AddScope_Click);
            // 
            // btn_Add_Venue
            // 
            this.btn_Add_Venue.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btn_Add_Venue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Add_Venue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Add_Venue.Location = new System.Drawing.Point(7, 7);
            this.btn_Add_Venue.Name = "btn_Add_Venue";
            this.btn_Add_Venue.Size = new System.Drawing.Size(109, 41);
            this.btn_Add_Venue.TabIndex = 7;
            this.btn_Add_Venue.Text = "Add Venue";
            this.btn_Add_Venue.UseVisualStyleBackColor = false;
            this.btn_Add_Venue.Click += new System.EventHandler(this.btn_Add_Venue_Click);
            // 
            // dt_Venues
            // 
            this.dt_Venues.AllowUserToAddRows = false;
            this.dt_Venues.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dt_Venues.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dt_Venues.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
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
            this.fld_Caterer_Fee,
            this.vid,
            this.pk_Venue_PricingID,
            this.EditVenue,
            this.DeleteVenue});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dt_Venues.DefaultCellStyle = dataGridViewCellStyle3;
            this.dt_Venues.Location = new System.Drawing.Point(7, 54);
            this.dt_Venues.Name = "dt_Venues";
            this.dt_Venues.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dt_Venues.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dt_Venues.RowHeadersVisible = false;
            this.dt_Venues.Size = new System.Drawing.Size(1882, 711);
            this.dt_Venues.TabIndex = 5;
            this.dt_Venues.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dt_Venues_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label2.Location = new System.Drawing.Point(2, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Venues";
            // 
            // panel_Add_Venue
            // 
            this.panel_Add_Venue.Location = new System.Drawing.Point(12, 24);
            this.panel_Add_Venue.Name = "panel_Add_Venue";
            this.panel_Add_Venue.Size = new System.Drawing.Size(966, 159);
            this.panel_Add_Venue.TabIndex = 7;
            this.panel_Add_Venue.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Add_Venue_Paint);
            // 
            // panel_AddScope
            // 
            this.panel_AddScope.Location = new System.Drawing.Point(992, 24);
            this.panel_AddScope.Name = "panel_AddScope";
            this.panel_AddScope.Size = new System.Drawing.Size(909, 159);
            this.panel_AddScope.TabIndex = 8;
            this.panel_AddScope.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_AddScope_Paint);
            // 
            // Item
            // 
            this.Item.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Item.DefaultCellStyle = dataGridViewCellStyle2;
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
            // fld_Caterer_Fee
            // 
            this.fld_Caterer_Fee.DataPropertyName = "fld_Caterer_Fee";
            this.fld_Caterer_Fee.HeaderText = "Caterer Fee";
            this.fld_Caterer_Fee.Name = "fld_Caterer_Fee";
            this.fld_Caterer_Fee.ReadOnly = true;
            // 
            // vid
            // 
            this.vid.DataPropertyName = "pk_VenueID";
            this.vid.HeaderText = "vd";
            this.vid.Name = "vid";
            this.vid.ReadOnly = true;
            this.vid.Visible = false;
            // 
            // pk_Venue_PricingID
            // 
            this.pk_Venue_PricingID.DataPropertyName = "pk_Venue_PricingID";
            this.pk_Venue_PricingID.HeaderText = "ID";
            this.pk_Venue_PricingID.Name = "pk_Venue_PricingID";
            this.pk_Venue_PricingID.ReadOnly = true;
            this.pk_Venue_PricingID.Visible = false;
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
            // frm_Manage_Venue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1061);
            this.Controls.Add(this.panel_AddScope);
            this.Controls.Add(this.panel_Add_Venue);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label2);
            this.Name = "frm_Manage_Venue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_Manage_Facilities";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_Manage_Facilities_Load);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt_Venues)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dt_Venues;
        private System.Windows.Forms.Button btn_Add_Venue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_AddScope;
        private System.Windows.Forms.TextBox txt_Search_Venue;
        private System.Windows.Forms.Panel panel_Add_Venue;
        private System.Windows.Forms.Panel panel_AddScope;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox combo_Filter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox combo_Sort;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblPageInfo;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Button btnPrevPage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Venue_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Venue_Scope_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Aircon;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Rate_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_First4Hrs_Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Hourly_Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Additional_Charge;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Caterer_Fee;
        private System.Windows.Forms.DataGridViewTextBoxColumn vid;
        private System.Windows.Forms.DataGridViewTextBoxColumn pk_Venue_PricingID;
        private System.Windows.Forms.DataGridViewImageColumn EditVenue;
        private System.Windows.Forms.DataGridViewImageColumn DeleteVenue;
    }
}