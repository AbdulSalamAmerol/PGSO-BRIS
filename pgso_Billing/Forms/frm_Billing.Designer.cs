namespace pgso
{
    partial class frm_Billing
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            this._BRIS_EXPERIMENT_3_0DataSet1 = new pgso._BRIS_EXPERIMENT_3_0DataSet();
            this.tlp_Billing_UControls = new System.Windows.Forms.TableLayoutPanel();
            this.dgv_Billing_Records = new System.Windows.Forms.DataGridView();
            this.pk_ReservationID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Control_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Full_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Reservation_Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Venue_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Equipment_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Start_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Amount_Due = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Payment_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Print = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel_UC_Billing = new System.Windows.Forms.Panel();
            this.cmb_Billing_Filter = new System.Windows.Forms.ComboBox();
            this.sb_Billing_Search_Bar = new System.Windows.Forms.TextBox();
            this.flp_Top = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_Reports = new System.Windows.Forms.Button();
            this.flp_Left_Side = new System.Windows.Forms.FlowLayoutPanel();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this._BRIS_EXPERIMENT_3_0DataSet1)).BeginInit();
            this.tlp_Billing_UControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Billing_Records)).BeginInit();
            this.panel_UC_Billing.SuspendLayout();
            this.flp_Top.SuspendLayout();
            this.SuspendLayout();
            // 
            // _BRIS_EXPERIMENT_3_0DataSet1
            // 
            this._BRIS_EXPERIMENT_3_0DataSet1.DataSetName = "_BRIS_EXPERIMENT_3_0DataSet";
            this._BRIS_EXPERIMENT_3_0DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tlp_Billing_UControls
            // 
            this.tlp_Billing_UControls.ColumnCount = 1;
            this.tlp_Billing_UControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Billing_UControls.Controls.Add(this.dgv_Billing_Records, 0, 1);
            this.tlp_Billing_UControls.Controls.Add(this.panel_UC_Billing, 0, 0);
            this.tlp_Billing_UControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Billing_UControls.Location = new System.Drawing.Point(152, 100);
            this.tlp_Billing_UControls.Name = "tlp_Billing_UControls";
            this.tlp_Billing_UControls.RowCount = 4;
            this.tlp_Billing_UControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.5F));
            this.tlp_Billing_UControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.16915F));
            this.tlp_Billing_UControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1.243781F));
            this.tlp_Billing_UControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.980099F));
            this.tlp_Billing_UControls.Size = new System.Drawing.Size(1680, 804);
            this.tlp_Billing_UControls.TabIndex = 4;
            // 
            // dgv_Billing_Records
            // 
            this.dgv_Billing_Records.AllowUserToAddRows = false;
            this.dgv_Billing_Records.AllowUserToDeleteRows = false;
            this.dgv_Billing_Records.AllowUserToOrderColumns = true;
            this.dgv_Billing_Records.AllowUserToResizeColumns = false;
            this.dgv_Billing_Records.AllowUserToResizeRows = false;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgv_Billing_Records.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgv_Billing_Records.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Billing_Records.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Billing_Records.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgv_Billing_Records.ColumnHeadersHeight = 40;
            this.dgv_Billing_Records.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_Billing_Records.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pk_ReservationID,
            this.fld_Control_Number,
            this.fld_Full_Name,
            this.col_Reservation_Type,
            this.col_Venue_Name,
            this.col_Equipment_Name,
            this.col_Start_Date,
            this.col_Amount_Due,
            this.col_Payment_Status,
            this.col_Print});
            this.dgv_Billing_Records.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Billing_Records.Location = new System.Drawing.Point(3, 31);
            this.dgv_Billing_Records.MultiSelect = false;
            this.dgv_Billing_Records.Name = "dgv_Billing_Records";
            this.dgv_Billing_Records.ReadOnly = true;
            this.dgv_Billing_Records.RowHeadersVisible = false;
            this.dgv_Billing_Records.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Billing_Records.Size = new System.Drawing.Size(1674, 727);
            this.dgv_Billing_Records.TabIndex = 0;
            this.dgv_Billing_Records.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Billing_Records_CellContentClick);
            // 
            // pk_ReservationID
            // 
            this.pk_ReservationID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.pk_ReservationID.DataPropertyName = "pk_ReservationID";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.pk_ReservationID.DefaultCellStyle = dataGridViewCellStyle14;
            this.pk_ReservationID.FillWeight = 5F;
            this.pk_ReservationID.HeaderText = "Reservation ID";
            this.pk_ReservationID.MinimumWidth = 10;
            this.pk_ReservationID.Name = "pk_ReservationID";
            this.pk_ReservationID.ReadOnly = true;
            this.pk_ReservationID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // fld_Control_Number
            // 
            this.fld_Control_Number.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fld_Control_Number.DataPropertyName = "fld_Control_Number";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fld_Control_Number.DefaultCellStyle = dataGridViewCellStyle15;
            this.fld_Control_Number.FillWeight = 15F;
            this.fld_Control_Number.HeaderText = "CONTROL NUMBER";
            this.fld_Control_Number.Name = "fld_Control_Number";
            this.fld_Control_Number.ReadOnly = true;
            this.fld_Control_Number.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // fld_Full_Name
            // 
            this.fld_Full_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fld_Full_Name.DataPropertyName = "fld_Full_Name";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fld_Full_Name.DefaultCellStyle = dataGridViewCellStyle16;
            this.fld_Full_Name.FillWeight = 15F;
            this.fld_Full_Name.HeaderText = "Requesting Person";
            this.fld_Full_Name.Name = "fld_Full_Name";
            this.fld_Full_Name.ReadOnly = true;
            this.fld_Full_Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // col_Reservation_Type
            // 
            this.col_Reservation_Type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_Reservation_Type.DataPropertyName = "fld_Reservation_Type";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_Reservation_Type.DefaultCellStyle = dataGridViewCellStyle17;
            this.col_Reservation_Type.FillWeight = 10F;
            this.col_Reservation_Type.HeaderText = "Reservation Type";
            this.col_Reservation_Type.Name = "col_Reservation_Type";
            this.col_Reservation_Type.ReadOnly = true;
            this.col_Reservation_Type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // col_Venue_Name
            // 
            this.col_Venue_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_Venue_Name.DataPropertyName = "fld_Venue_Name";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_Venue_Name.DefaultCellStyle = dataGridViewCellStyle18;
            this.col_Venue_Name.FillWeight = 15F;
            this.col_Venue_Name.HeaderText = "Venue Name";
            this.col_Venue_Name.Name = "col_Venue_Name";
            this.col_Venue_Name.ReadOnly = true;
            this.col_Venue_Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // col_Equipment_Name
            // 
            this.col_Equipment_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_Equipment_Name.DataPropertyName = "fld_Equipment_Name";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_Equipment_Name.DefaultCellStyle = dataGridViewCellStyle19;
            this.col_Equipment_Name.FillWeight = 10F;
            this.col_Equipment_Name.HeaderText = "Equipment Name";
            this.col_Equipment_Name.Name = "col_Equipment_Name";
            this.col_Equipment_Name.ReadOnly = true;
            this.col_Equipment_Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // col_Start_Date
            // 
            this.col_Start_Date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_Start_Date.DataPropertyName = "fld_Start_Date";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_Start_Date.DefaultCellStyle = dataGridViewCellStyle20;
            this.col_Start_Date.FillWeight = 10F;
            this.col_Start_Date.HeaderText = "Start Date";
            this.col_Start_Date.Name = "col_Start_Date";
            this.col_Start_Date.ReadOnly = true;
            this.col_Start_Date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // col_Amount_Due
            // 
            this.col_Amount_Due.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_Amount_Due.DataPropertyName = "fld_Amount_Due";
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_Amount_Due.DefaultCellStyle = dataGridViewCellStyle21;
            this.col_Amount_Due.FillWeight = 10F;
            this.col_Amount_Due.HeaderText = "Amount Due";
            this.col_Amount_Due.Name = "col_Amount_Due";
            this.col_Amount_Due.ReadOnly = true;
            this.col_Amount_Due.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // col_Payment_Status
            // 
            this.col_Payment_Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_Payment_Status.DataPropertyName = "fld_Payment_Status";
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.col_Payment_Status.DefaultCellStyle = dataGridViewCellStyle22;
            this.col_Payment_Status.FillWeight = 7F;
            this.col_Payment_Status.HeaderText = "Payment Status";
            this.col_Payment_Status.Name = "col_Payment_Status";
            this.col_Payment_Status.ReadOnly = true;
            this.col_Payment_Status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // col_Print
            // 
            this.col_Print.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_Print.FillWeight = 3F;
            this.col_Print.HeaderText = "PRINT";
            this.col_Print.Image = global::pgso.Properties.Resources.print;
            this.col_Print.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.col_Print.MinimumWidth = 20;
            this.col_Print.Name = "col_Print";
            this.col_Print.ReadOnly = true;
            // 
            // panel_UC_Billing
            // 
            this.panel_UC_Billing.Controls.Add(this.cmb_Billing_Filter);
            this.panel_UC_Billing.Controls.Add(this.sb_Billing_Search_Bar);
            this.panel_UC_Billing.Location = new System.Drawing.Point(0, 0);
            this.panel_UC_Billing.Margin = new System.Windows.Forms.Padding(0);
            this.panel_UC_Billing.Name = "panel_UC_Billing";
            this.panel_UC_Billing.Size = new System.Drawing.Size(632, 26);
            this.panel_UC_Billing.TabIndex = 2;
            // 
            // cmb_Billing_Filter
            // 
            this.cmb_Billing_Filter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cmb_Billing_Filter.FormattingEnabled = true;
            this.cmb_Billing_Filter.Location = new System.Drawing.Point(209, 3);
            this.cmb_Billing_Filter.Name = "cmb_Billing_Filter";
            this.cmb_Billing_Filter.Size = new System.Drawing.Size(200, 21);
            this.cmb_Billing_Filter.TabIndex = 0;
            // 
            // sb_Billing_Search_Bar
            // 
            this.sb_Billing_Search_Bar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.sb_Billing_Search_Bar.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.sb_Billing_Search_Bar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sb_Billing_Search_Bar.Location = new System.Drawing.Point(3, 3);
            this.sb_Billing_Search_Bar.Name = "sb_Billing_Search_Bar";
            this.sb_Billing_Search_Bar.Size = new System.Drawing.Size(200, 20);
            this.sb_Billing_Search_Bar.TabIndex = 1;
            // 
            // flp_Top
            // 
            this.flp_Top.Controls.Add(this.btn_Reports);
            this.flp_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.flp_Top.Location = new System.Drawing.Point(0, 0);
            this.flp_Top.Name = "flp_Top";
            this.flp_Top.Size = new System.Drawing.Size(1832, 100);
            this.flp_Top.TabIndex = 5;
            // 
            // btn_Reports
            // 
            this.btn_Reports.Location = new System.Drawing.Point(3, 3);
            this.btn_Reports.Name = "btn_Reports";
            this.btn_Reports.Size = new System.Drawing.Size(123, 23);
            this.btn_Reports.TabIndex = 1;
            this.btn_Reports.Text = "REPORTS";
            this.btn_Reports.UseVisualStyleBackColor = true;
            this.btn_Reports.Click += new System.EventHandler(this.btn_Reports_Click);
            // 
            // flp_Left_Side
            // 
            this.flp_Left_Side.Dock = System.Windows.Forms.DockStyle.Left;
            this.flp_Left_Side.Location = new System.Drawing.Point(0, 100);
            this.flp_Left_Side.Name = "flp_Left_Side";
            this.flp_Left_Side.Size = new System.Drawing.Size(152, 804);
            this.flp_Left_Side.TabIndex = 0;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewImageColumn1.FillWeight = 3F;
            this.dataGridViewImageColumn1.HeaderText = "PRINT";
            this.dataGridViewImageColumn1.Image = global::pgso.Properties.Resources.print;
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.MinimumWidth = 20;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            // 
            // frm_Billing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1832, 904);
            this.Controls.Add(this.tlp_Billing_UControls);
            this.Controls.Add(this.flp_Left_Side);
            this.Controls.Add(this.flp_Top);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Billing";
            this.Text = "Billing_Form";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_Billing_Load);
            ((System.ComponentModel.ISupportInitialize)(this._BRIS_EXPERIMENT_3_0DataSet1)).EndInit();
            this.tlp_Billing_UControls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Billing_Records)).EndInit();
            this.panel_UC_Billing.ResumeLayout(false);
            this.panel_UC_Billing.PerformLayout();
            this.flp_Top.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private _BRIS_EXPERIMENT_3_0DataSet _BRIS_EXPERIMENT_3_0DataSet1;
        private System.Windows.Forms.TableLayoutPanel tlp_Billing_UControls;
        private System.Windows.Forms.TextBox sb_Billing_Search_Bar;
        private System.Windows.Forms.DataGridView dgv_Billing_Records;
        private System.Windows.Forms.Panel panel_UC_Billing;
        private System.Windows.Forms.ComboBox cmb_Billing_Filter;
        private System.Windows.Forms.FlowLayoutPanel flp_Top;
        private System.Windows.Forms.FlowLayoutPanel flp_Left_Side;
        private System.Windows.Forms.Button btn_Reports;
        private System.Windows.Forms.DataGridViewTextBoxColumn pk_ReservationID;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Control_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Full_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Reservation_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Venue_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Equipment_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Start_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Amount_Due;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Payment_Status;
        private System.Windows.Forms.DataGridViewImageColumn col_Print;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
    }
}