namespace pgso
{
    partial class Billing_Form
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this._BRIS_EXPERIMENT_3_0DataSet1 = new pgso._BRIS_EXPERIMENT_3_0DataSet();
            this.tlp_Venue_Billing_UControls = new System.Windows.Forms.TableLayoutPanel();
            this.Panel_Of_tpl_dgvVenue = new System.Windows.Forms.Panel();
            this.Venue_Search_Bar = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Panel_Of_tpl_dgvEquipment = new System.Windows.Forms.Panel();
            this.Equipment_Search_Bar = new System.Windows.Forms.TextBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.dgv_Venue_Billing_Records = new System.Windows.Forms.DataGridView();
            this.fld_Control_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Venue_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Start_Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Amount_Due = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Payment_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_Equipment_Billing_Records = new System.Windows.Forms.DataGridView();
            this.fld_Control_Number_Equipment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Equipment_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Formatted_Total_Equipment_Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_Generate_Billing = new System.Windows.Forms.Button();
            this.btn_Generate_Report = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this._BRIS_EXPERIMENT_3_0DataSet1)).BeginInit();
            this.tlp_Venue_Billing_UControls.SuspendLayout();
            this.Panel_Of_tpl_dgvVenue.SuspendLayout();
            this.Panel_Of_tpl_dgvEquipment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Venue_Billing_Records)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Equipment_Billing_Records)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _BRIS_EXPERIMENT_3_0DataSet1
            // 
            this._BRIS_EXPERIMENT_3_0DataSet1.DataSetName = "_BRIS_EXPERIMENT_3_0DataSet";
            this._BRIS_EXPERIMENT_3_0DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tlp_Venue_Billing_UControls
            // 
            this.tlp_Venue_Billing_UControls.ColumnCount = 1;
            this.tlp_Venue_Billing_UControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_Venue_Billing_UControls.Controls.Add(this.Panel_Of_tpl_dgvVenue, 0, 0);
            this.tlp_Venue_Billing_UControls.Controls.Add(this.Panel_Of_tpl_dgvEquipment, 0, 2);
            this.tlp_Venue_Billing_UControls.Controls.Add(this.dgv_Venue_Billing_Records, 0, 1);
            this.tlp_Venue_Billing_UControls.Controls.Add(this.dgv_Equipment_Billing_Records, 0, 3);
            this.tlp_Venue_Billing_UControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_Venue_Billing_UControls.Location = new System.Drawing.Point(152, 100);
            this.tlp_Venue_Billing_UControls.Name = "tlp_Venue_Billing_UControls";
            this.tlp_Venue_Billing_UControls.RowCount = 4;
            this.tlp_Venue_Billing_UControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.5F));
            this.tlp_Venue_Billing_UControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.5F));
            this.tlp_Venue_Billing_UControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.5F));
            this.tlp_Venue_Billing_UControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.5F));
            this.tlp_Venue_Billing_UControls.Size = new System.Drawing.Size(680, 804);
            this.tlp_Venue_Billing_UControls.TabIndex = 4;
            this.tlp_Venue_Billing_UControls.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // Panel_Of_tpl_dgvVenue
            // 
            this.Panel_Of_tpl_dgvVenue.Controls.Add(this.Venue_Search_Bar);
            this.Panel_Of_tpl_dgvVenue.Controls.Add(this.comboBox1);
            this.Panel_Of_tpl_dgvVenue.Location = new System.Drawing.Point(0, 0);
            this.Panel_Of_tpl_dgvVenue.Margin = new System.Windows.Forms.Padding(0);
            this.Panel_Of_tpl_dgvVenue.Name = "Panel_Of_tpl_dgvVenue";
            this.Panel_Of_tpl_dgvVenue.Size = new System.Drawing.Size(632, 26);
            this.Panel_Of_tpl_dgvVenue.TabIndex = 2;
            this.Panel_Of_tpl_dgvVenue.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // Venue_Search_Bar
            // 
            this.Venue_Search_Bar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Venue_Search_Bar.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Venue_Search_Bar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Venue_Search_Bar.Location = new System.Drawing.Point(3, 2);
            this.Venue_Search_Bar.Name = "Venue_Search_Bar";
            this.Venue_Search_Bar.Size = new System.Drawing.Size(200, 20);
            this.Venue_Search_Bar.TabIndex = 1;
            this.Venue_Search_Bar.TextChanged += new System.EventHandler(this.Venue_Search_Bar_TextChanged_1);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(209, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(200, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // Panel_Of_tpl_dgvEquipment
            // 
            this.Panel_Of_tpl_dgvEquipment.Controls.Add(this.Equipment_Search_Bar);
            this.Panel_Of_tpl_dgvEquipment.Controls.Add(this.comboBox2);
            this.Panel_Of_tpl_dgvEquipment.Location = new System.Drawing.Point(0, 401);
            this.Panel_Of_tpl_dgvEquipment.Margin = new System.Windows.Forms.Padding(0);
            this.Panel_Of_tpl_dgvEquipment.Name = "Panel_Of_tpl_dgvEquipment";
            this.Panel_Of_tpl_dgvEquipment.Size = new System.Drawing.Size(632, 26);
            this.Panel_Of_tpl_dgvEquipment.TabIndex = 3;
            this.Panel_Of_tpl_dgvEquipment.Paint += new System.Windows.Forms.PaintEventHandler(this.panel5_Paint);
            // 
            // Equipment_Search_Bar
            // 
            this.Equipment_Search_Bar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Equipment_Search_Bar.BackColor = System.Drawing.SystemColors.HotTrack;
            this.Equipment_Search_Bar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Equipment_Search_Bar.Location = new System.Drawing.Point(3, 3);
            this.Equipment_Search_Bar.Name = "Equipment_Search_Bar";
            this.Equipment_Search_Bar.Size = new System.Drawing.Size(200, 20);
            this.Equipment_Search_Bar.TabIndex = 3;
            // 
            // comboBox2
            // 
            this.comboBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(209, 3);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(200, 21);
            this.comboBox2.TabIndex = 0;
            // 
            // dgv_Venue_Billing_Records
            // 
            this.dgv_Venue_Billing_Records.AllowUserToAddRows = false;
            this.dgv_Venue_Billing_Records.AllowUserToDeleteRows = false;
            this.dgv_Venue_Billing_Records.AllowUserToOrderColumns = true;
            this.dgv_Venue_Billing_Records.AllowUserToResizeColumns = false;
            this.dgv_Venue_Billing_Records.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgv_Venue_Billing_Records.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_Venue_Billing_Records.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Venue_Billing_Records.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Venue_Billing_Records.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgv_Venue_Billing_Records.ColumnHeadersHeight = 40;
            this.dgv_Venue_Billing_Records.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_Venue_Billing_Records.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fld_Control_Number,
            this.fld_Venue_Name,
            this.fld_Start_Date,
            this.fld_Amount_Due,
            this.fld_Payment_Status});
            this.dgv_Venue_Billing_Records.Location = new System.Drawing.Point(3, 31);
            this.dgv_Venue_Billing_Records.MultiSelect = false;
            this.dgv_Venue_Billing_Records.Name = "dgv_Venue_Billing_Records";
            this.dgv_Venue_Billing_Records.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Venue_Billing_Records.Size = new System.Drawing.Size(674, 367);
            this.dgv_Venue_Billing_Records.TabIndex = 0;
            this.dgv_Venue_Billing_Records.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Venue_Billing_Records_CellContentClick);
            this.dgv_Venue_Billing_Records.SelectionChanged += new System.EventHandler(this.dgv_Venue_Billing_Records_SelectionChanged);
            // 
            // fld_Control_Number
            // 
            this.fld_Control_Number.DataPropertyName = "fld_Control_Number";
            this.fld_Control_Number.HeaderText = "CONTROL NUMBER";
            this.fld_Control_Number.Name = "fld_Control_Number";
            this.fld_Control_Number.ReadOnly = true;
            // 
            // fld_Venue_Name
            // 
            this.fld_Venue_Name.DataPropertyName = "fld_Venue_Name";
            this.fld_Venue_Name.HeaderText = "VENUE";
            this.fld_Venue_Name.Name = "fld_Venue_Name";
            this.fld_Venue_Name.ReadOnly = true;
            // 
            // fld_Start_Date
            // 
            this.fld_Start_Date.DataPropertyName = "Formatted_Start_Date";
            this.fld_Start_Date.HeaderText = "DATE";
            this.fld_Start_Date.Name = "fld_Start_Date";
            this.fld_Start_Date.ReadOnly = true;
            // 
            // fld_Amount_Due
            // 
            this.fld_Amount_Due.DataPropertyName = "Formatted_Amount_Due";
            this.fld_Amount_Due.HeaderText = "AMOUNT DUE";
            this.fld_Amount_Due.Name = "fld_Amount_Due";
            this.fld_Amount_Due.ReadOnly = true;
            // 
            // fld_Payment_Status
            // 
            this.fld_Payment_Status.DataPropertyName = "fld_Payment_Status";
            this.fld_Payment_Status.HeaderText = "STATUS";
            this.fld_Payment_Status.Name = "fld_Payment_Status";
            this.fld_Payment_Status.ReadOnly = true;
            // 
            // dgv_Equipment_Billing_Records
            // 
            this.dgv_Equipment_Billing_Records.AllowUserToAddRows = false;
            this.dgv_Equipment_Billing_Records.AllowUserToDeleteRows = false;
            this.dgv_Equipment_Billing_Records.AllowUserToOrderColumns = true;
            this.dgv_Equipment_Billing_Records.AllowUserToResizeColumns = false;
            this.dgv_Equipment_Billing_Records.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgv_Equipment_Billing_Records.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_Equipment_Billing_Records.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Equipment_Billing_Records.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Equipment_Billing_Records.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgv_Equipment_Billing_Records.ColumnHeadersHeight = 40;
            this.dgv_Equipment_Billing_Records.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_Equipment_Billing_Records.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fld_Control_Number_Equipment,
            this.fld_Equipment_Name,
            this.fld_Formatted_Total_Equipment_Cost});
            this.dgv_Equipment_Billing_Records.Location = new System.Drawing.Point(3, 432);
            this.dgv_Equipment_Billing_Records.MultiSelect = false;
            this.dgv_Equipment_Billing_Records.Name = "dgv_Equipment_Billing_Records";
            this.dgv_Equipment_Billing_Records.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Equipment_Billing_Records.Size = new System.Drawing.Size(674, 369);
            this.dgv_Equipment_Billing_Records.TabIndex = 2;
            this.dgv_Equipment_Billing_Records.SelectionChanged += new System.EventHandler(this.dgv_Equipment_Billing_Records_SelectionChanged);
            // 
            // fld_Control_Number_Equipment
            // 
            this.fld_Control_Number_Equipment.DataPropertyName = "fld_Control_Number";
            this.fld_Control_Number_Equipment.HeaderText = "CONTROL NUMBER";
            this.fld_Control_Number_Equipment.Name = "fld_Control_Number_Equipment";
            this.fld_Control_Number_Equipment.ReadOnly = true;
            // 
            // fld_Equipment_Name
            // 
            this.fld_Equipment_Name.DataPropertyName = "fld_Equipment_Name";
            this.fld_Equipment_Name.HeaderText = "EQUIPMENT";
            this.fld_Equipment_Name.Name = "fld_Equipment_Name";
            this.fld_Equipment_Name.ReadOnly = true;
            // 
            // fld_Formatted_Total_Equipment_Cost
            // 
            this.fld_Formatted_Total_Equipment_Cost.DataPropertyName = "Formatted_Total_Equipment_Cost";
            this.fld_Formatted_Total_Equipment_Cost.HeaderText = "TOTAL";
            this.fld_Formatted_Total_Equipment_Cost.Name = "fld_Formatted_Total_Equipment_Cost";
            this.fld_Formatted_Total_Equipment_Cost.ReadOnly = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btn_Generate_Billing);
            this.flowLayoutPanel1.Controls.Add(this.btn_Generate_Report);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1832, 100);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // btn_Generate_Billing
            // 
            this.btn_Generate_Billing.Location = new System.Drawing.Point(3, 3);
            this.btn_Generate_Billing.Name = "btn_Generate_Billing";
            this.btn_Generate_Billing.Size = new System.Drawing.Size(123, 23);
            this.btn_Generate_Billing.TabIndex = 0;
            this.btn_Generate_Billing.Text = "Generate Billing";
            this.btn_Generate_Billing.UseVisualStyleBackColor = true;
            this.btn_Generate_Billing.Click += new System.EventHandler(this.btn_Generate_Billing_Click);
            // 
            // btn_Generate_Report
            // 
            this.btn_Generate_Report.Location = new System.Drawing.Point(132, 3);
            this.btn_Generate_Report.Name = "btn_Generate_Report";
            this.btn_Generate_Report.Size = new System.Drawing.Size(123, 23);
            this.btn_Generate_Report.TabIndex = 1;
            this.btn_Generate_Report.Text = "Generate Report";
            this.btn_Generate_Report.UseVisualStyleBackColor = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "pgso.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 3);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1088, 730);
            this.reportViewer1.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.reportViewer1);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(832, 100);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1000, 804);
            this.flowLayoutPanel2.TabIndex = 0;
            this.flowLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 100);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(152, 804);
            this.flowLayoutPanel3.TabIndex = 0;
            // 
            // Billing_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1832, 904);
            this.Controls.Add(this.tlp_Venue_Billing_UControls);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel3);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "Billing_Form";
            this.Text = "Billing_Form";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Billing_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this._BRIS_EXPERIMENT_3_0DataSet1)).EndInit();
            this.tlp_Venue_Billing_UControls.ResumeLayout(false);
            this.Panel_Of_tpl_dgvVenue.ResumeLayout(false);
            this.Panel_Of_tpl_dgvVenue.PerformLayout();
            this.Panel_Of_tpl_dgvEquipment.ResumeLayout(false);
            this.Panel_Of_tpl_dgvEquipment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Venue_Billing_Records)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Equipment_Billing_Records)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private _BRIS_EXPERIMENT_3_0DataSet _BRIS_EXPERIMENT_3_0DataSet1;
        private System.Windows.Forms.TableLayoutPanel tlp_Venue_Billing_UControls;
        private System.Windows.Forms.TextBox Venue_Search_Bar;
        private System.Windows.Forms.DataGridView dgv_Equipment_Billing_Records;
        private System.Windows.Forms.TextBox Equipment_Search_Bar;
        private System.Windows.Forms.DataGridView dgv_Venue_Billing_Records;
        private System.Windows.Forms.Panel Panel_Of_tpl_dgvVenue;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel Panel_Of_tpl_dgvEquipment;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Control_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Venue_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Start_Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Amount_Due;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Payment_Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Control_Number_Equipment;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Equipment_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Formatted_Total_Equipment_Cost;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button btn_Generate_Billing;
        private System.Windows.Forms.Button btn_Generate_Report;
    }
}