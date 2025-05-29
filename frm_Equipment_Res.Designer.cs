namespace pgso
{
    partial class frm_Equipment_Res
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
            this.panel_Information = new System.Windows.Forms.Panel();
            this.label_Des = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label_Equipment = new System.Windows.Forms.Label();
            this.dt_equipment = new System.Windows.Forms.DataGridView();
            this.Items = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.frm_Control_NumberE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Equipment_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Reservation_StatusE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel_Information.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt_equipment)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_Information
            // 
            this.panel_Information.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.panel_Information.AutoScroll = true;
            this.panel_Information.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel_Information.Controls.Add(this.label_Des);
            this.panel_Information.Controls.Add(this.label1);
            this.panel_Information.Controls.Add(this.label_Equipment);
            this.panel_Information.Location = new System.Drawing.Point(12, 221);
            this.panel_Information.Name = "panel_Information";
            this.panel_Information.Size = new System.Drawing.Size(450, 380);
            this.panel_Information.TabIndex = 10;
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
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label_Equipment
            // 
            this.label_Equipment.AutoSize = true;
            this.label_Equipment.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Equipment.Location = new System.Drawing.Point(13, 54);
            this.label_Equipment.Name = "label_Equipment";
            this.label_Equipment.Size = new System.Drawing.Size(0, 17);
            this.label_Equipment.TabIndex = 47;
            // 
            // dt_equipment
            // 
            this.dt_equipment.AllowUserToAddRows = false;
            this.dt_equipment.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dt_equipment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dt_equipment.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dt_equipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt_equipment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Items,
            this.frm_Control_NumberE,
            this.fld_Equipment_Name,
            this.fld_Quantity,
            this.fld_Reservation_StatusE});
            this.dt_equipment.Location = new System.Drawing.Point(12, 12);
            this.dt_equipment.Name = "dt_equipment";
            this.dt_equipment.RowHeadersVisible = false;
            this.dt_equipment.Size = new System.Drawing.Size(450, 203);
            this.dt_equipment.TabIndex = 9;
            this.dt_equipment.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dt_equipment_CellContentClick_1);
            // 
            // Items
            // 
            this.Items.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Items.DefaultCellStyle = dataGridViewCellStyle2;
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
            // frm_Equipment_Res
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 620);
            this.Controls.Add(this.panel_Information);
            this.Controls.Add(this.dt_equipment);
            this.Name = "frm_Equipment_Res";
            this.Text = "frm_Equipment_Res";
            this.Load += new System.EventHandler(this.frm_Equipment_Res_Load_1);
            this.panel_Information.ResumeLayout(false);
            this.panel_Information.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt_equipment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Information;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_Equipment;
        private System.Windows.Forms.DataGridView dt_equipment;
        private System.Windows.Forms.DataGridViewTextBoxColumn Items;
        private System.Windows.Forms.DataGridViewTextBoxColumn frm_Control_NumberE;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Equipment_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Reservation_StatusE;
        private System.Windows.Forms.Label label_Des;
    }
}