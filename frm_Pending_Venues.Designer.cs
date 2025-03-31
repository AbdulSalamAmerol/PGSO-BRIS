namespace pgso
{
    partial class frm_Pending_Venues
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
            this.dt_pendings = new System.Windows.Forms.DataGridView();
            this.lbl_pending = new System.Windows.Forms.Label();
            this.Control_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Total_Amount2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Approve = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Cancel = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dt_pendings)).BeginInit();
            this.SuspendLayout();
            // 
            // dt_pendings
            // 
            this.dt_pendings.AllowUserToAddRows = false;
            this.dt_pendings.AllowUserToDeleteRows = false;
            this.dt_pendings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dt_pendings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dt_pendings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dt_pendings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt_pendings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Control_Number,
            this.dataGridViewTextBoxColumn2,
            this.Column3,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.Column4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.Column11,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.fld_Total_Amount2,
            this.Approve,
            this.Cancel});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dt_pendings.DefaultCellStyle = dataGridViewCellStyle2;
            this.dt_pendings.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dt_pendings.Location = new System.Drawing.Point(12, 25);
            this.dt_pendings.Name = "dt_pendings";
            this.dt_pendings.ReadOnly = true;
            this.dt_pendings.RowHeadersVisible = false;
            this.dt_pendings.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dt_pendings.Size = new System.Drawing.Size(1334, 383);
            this.dt_pendings.TabIndex = 6;
            // 
            // lbl_pending
            // 
            this.lbl_pending.AutoSize = true;
            this.lbl_pending.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_pending.Location = new System.Drawing.Point(12, 1);
            this.lbl_pending.Name = "lbl_pending";
            this.lbl_pending.Size = new System.Drawing.Size(86, 21);
            this.lbl_pending.TabIndex = 5;
            this.lbl_pending.Text = "PENDNGS";
            // 
            // Control_Number
            // 
            this.Control_Number.DataPropertyName = "fld_Control_Number";
            this.Control_Number.HeaderText = "Control No.";
            this.Control_Number.Name = "Control_Number";
            this.Control_Number.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "fld_First_Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "First Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "fld_Surname";
            this.Column3.HeaderText = "Last Name";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "fld_Requesting_Person_Address";
            this.dataGridViewTextBoxColumn3.HeaderText = "Address";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "fld_Activity_Name";
            this.dataGridViewTextBoxColumn4.HeaderText = "Event";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "fld_Venue_Name";
            this.Column4.HeaderText = "Venue";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "fld_Contact_Number";
            this.dataGridViewTextBoxColumn5.HeaderText = "Contact";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "fld_Number_Of_Participants";
            this.dataGridViewTextBoxColumn6.HeaderText = "Audience";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "fld_Start_Date";
            this.Column11.HeaderText = "Date Start";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "fld_End_Date";
            this.dataGridViewTextBoxColumn7.HeaderText = "Date End";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "fld_Start_Time";
            this.dataGridViewTextBoxColumn8.HeaderText = "Time Start";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "fld_End_Time";
            this.dataGridViewTextBoxColumn9.HeaderText = "Time End";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "fld_Reservation_Status";
            this.dataGridViewTextBoxColumn10.HeaderText = "Status";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // fld_Total_Amount2
            // 
            this.fld_Total_Amount2.DataPropertyName = "fld_Total_Amount";
            this.fld_Total_Amount2.HeaderText = "Total";
            this.fld_Total_Amount2.Name = "fld_Total_Amount2";
            this.fld_Total_Amount2.ReadOnly = true;
            // 
            // Approve
            // 
            this.Approve.HeaderText = "";
            this.Approve.Name = "Approve";
            this.Approve.ReadOnly = true;
            this.Approve.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Approve.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Approve.Text = "Approve";
            this.Approve.UseColumnTextForButtonValue = true;
            // 
            // Cancel
            // 
            this.Cancel.HeaderText = "";
            this.Cancel.Name = "Cancel";
            this.Cancel.ReadOnly = true;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseColumnTextForButtonValue = true;
            // 
            // frm_Pending_Venues
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1358, 581);
            this.Controls.Add(this.dt_pendings);
            this.Controls.Add(this.lbl_pending);
            this.Name = "frm_Pending_Venues";
            this.Text = "frm_Pending_Venues";
            this.Load += new System.EventHandler(this.frm_Pending_Venues_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dt_pendings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dt_pendings;
        private System.Windows.Forms.Label lbl_pending;
        private System.Windows.Forms.DataGridViewTextBoxColumn Control_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Total_Amount2;
        private System.Windows.Forms.DataGridViewButtonColumn Approve;
        private System.Windows.Forms.DataGridViewButtonColumn Cancel;
    }
}