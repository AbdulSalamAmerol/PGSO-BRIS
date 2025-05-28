namespace pgso
{
    partial class frm_Venue_Res
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dt_venue = new System.Windows.Forms.DataGridView();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Venue_Control = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Venue_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Venue_Scope_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Reservation_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel_Information = new System.Windows.Forms.Panel();
            this.label_Des = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label_Venue = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dt_venue)).BeginInit();
            this.panel_Information.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // dt_venue
            // 
            this.dt_venue.AllowUserToAddRows = false;
            this.dt_venue.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dt_venue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.dt_venue.Location = new System.Drawing.Point(12, 12);
            this.dt_venue.Name = "dt_venue";
            this.dt_venue.RowHeadersVisible = false;
            this.dt_venue.Size = new System.Drawing.Size(508, 134);
            this.dt_venue.TabIndex = 4;
            this.dt_venue.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dt_venue_CellContentClick_1);
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
            // panel_Information
            // 
            this.panel_Information.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel_Information.AutoScroll = true;
            this.panel_Information.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel_Information.Controls.Add(this.label_Des);
            this.panel_Information.Controls.Add(this.label1);
            this.panel_Information.Controls.Add(this.label_Venue);
            this.panel_Information.Location = new System.Drawing.Point(12, 152);
            this.panel_Information.Name = "panel_Information";
            this.panel_Information.Size = new System.Drawing.Size(508, 282);
            this.panel_Information.TabIndex = 9;
            // 
            // label_Des
            // 
            this.label_Des.AutoSize = true;
            this.label_Des.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Des.Location = new System.Drawing.Point(13, 33);
            this.label_Des.Name = "label_Des";
            this.label_Des.Size = new System.Drawing.Size(0, 18);
            this.label_Des.TabIndex = 49;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 17);
            this.label1.TabIndex = 48;
            this.label1.Text = "Reservation Information";
            // 
            // label_Venue
            // 
            this.label_Venue.AutoSize = true;
            this.label_Venue.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Venue.Location = new System.Drawing.Point(13, 54);
            this.label_Venue.Name = "label_Venue";
            this.label_Venue.Size = new System.Drawing.Size(0, 17);
            this.label_Venue.TabIndex = 47;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frm_Venue_Res
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 493);
            this.Controls.Add(this.panel_Information);
            this.Controls.Add(this.dt_venue);
            this.Name = "frm_Venue_Res";
            this.Text = "frm_Venue_Res";
            this.Load += new System.EventHandler(this.frm_Venue_Res_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dt_venue)).EndInit();
            this.panel_Information.ResumeLayout(false);
            this.panel_Information.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dt_venue;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn Venue_Control;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Venue_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Venue_Scope_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Reservation_Status;
        private System.Windows.Forms.Panel panel_Information;
        private System.Windows.Forms.Label label_Des;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_Venue;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}