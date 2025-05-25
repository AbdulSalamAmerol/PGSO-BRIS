namespace pgso
{
    partial class frm_Logs
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
            this._BRIS_EXPERIMENT_3_0DataSet1 = new pgso._BRIS_EXPERIMENT_3_0DataSet();
            this.dt_Audit = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.searchbox = new System.Windows.Forms.TextBox();
            this.btnGeneratePDFadm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._BRIS_EXPERIMENT_3_0DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_Audit)).BeginInit();
            this.SuspendLayout();
            // 
            // _BRIS_EXPERIMENT_3_0DataSet1
            // 
            this._BRIS_EXPERIMENT_3_0DataSet1.DataSetName = "_BRIS_EXPERIMENT_3_0DataSet";
            this._BRIS_EXPERIMENT_3_0DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dt_Audit
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_Audit.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dt_Audit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dt_Audit.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dt_Audit.BackgroundColor = System.Drawing.Color.White;
            this.dt_Audit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dt_Audit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt_Audit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dt_Audit.Location = new System.Drawing.Point(-1, 39);
            this.dt_Audit.Name = "dt_Audit";
            this.dt_Audit.ReadOnly = true;
            this.dt_Audit.RowHeadersVisible = false;
            this.dt_Audit.Size = new System.Drawing.Size(792, 474);
            this.dt_Audit.TabIndex = 0;
            this.dt_Audit.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dt_Audit_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "fld_Username";
            this.Column1.HeaderText = "Username";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "fld_Changed_By";
            this.Column2.HeaderText = "User Type";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "fld_ActionType";
            this.Column3.HeaderText = "Actiion";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "fld_Changed_At";
            this.Column4.HeaderText = "Time";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // searchbox
            // 
            this.searchbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchbox.BackColor = System.Drawing.Color.Silver;
            this.searchbox.Location = new System.Drawing.Point(582, 13);
            this.searchbox.Name = "searchbox";
            this.searchbox.Size = new System.Drawing.Size(177, 20);
            this.searchbox.TabIndex = 1;
            this.searchbox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnGeneratePDFadm
            // 
            this.btnGeneratePDFadm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGeneratePDFadm.Location = new System.Drawing.Point(690, 533);
            this.btnGeneratePDFadm.Name = "btnGeneratePDFadm";
            this.btnGeneratePDFadm.Size = new System.Drawing.Size(101, 23);
            this.btnGeneratePDFadm.TabIndex = 2;
            this.btnGeneratePDFadm.Text = "Generate PDF";
            this.btnGeneratePDFadm.UseVisualStyleBackColor = true;
            this.btnGeneratePDFadm.Click += new System.EventHandler(this.btnGeneratePDFadm_Click);
            // 
            // frm_Logs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 625);
            this.Controls.Add(this.btnGeneratePDFadm);
            this.Controls.Add(this.searchbox);
            this.Controls.Add(this.dt_Audit);
            this.Name = "frm_Logs";
            this.Text = "Logs";
            this.Load += new System.EventHandler(this.frm_Logs_Load);
            ((System.ComponentModel.ISupportInitialize)(this._BRIS_EXPERIMENT_3_0DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_Audit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private _BRIS_EXPERIMENT_3_0DataSet _BRIS_EXPERIMENT_3_0DataSet1;
        private System.Windows.Forms.DataGridView dt_Audit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.TextBox searchbox;
        private System.Windows.Forms.Button btnGeneratePDFadm;
    }
}