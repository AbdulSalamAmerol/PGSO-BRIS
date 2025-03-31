namespace pgso
{
    partial class frm_Approved_Venue
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
            this.lbl_approved = new System.Windows.Forms.Label();
            this.dt_approved = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Contact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Total_Amount1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dt_approved)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_approved
            // 
            this.lbl_approved.AutoSize = true;
            this.lbl_approved.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_approved.Location = new System.Drawing.Point(8, 27);
            this.lbl_approved.Name = "lbl_approved";
            this.lbl_approved.Size = new System.Drawing.Size(97, 21);
            this.lbl_approved.TabIndex = 4;
            this.lbl_approved.Text = "APPROVED";
            // 
            // dt_approved
            // 
            this.dt_approved.AllowUserToDeleteRows = false;
            this.dt_approved.AllowUserToResizeRows = false;
            this.dt_approved.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dt_approved.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dt_approved.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dt_approved.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt_approved.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column13,
            this.Column8,
            this.Contact,
            this.Column6,
            this.Column10,
            this.Column7,
            this.Column9,
            this.Column5,
            this.fld_Total_Amount1});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dt_approved.DefaultCellStyle = dataGridViewCellStyle4;
            this.dt_approved.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dt_approved.Location = new System.Drawing.Point(12, 51);
            this.dt_approved.Name = "dt_approved";
            this.dt_approved.ReadOnly = true;
            this.dt_approved.RowHeadersVisible = false;
            this.dt_approved.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dt_approved.Size = new System.Drawing.Size(1057, 534);
            this.dt_approved.TabIndex = 3;
            
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "fld_Control_Number";
            this.Column1.HeaderText = "Control No.";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "fld_First_Name";
            this.Column2.HeaderText = "First Name";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column13
            // 
            this.Column13.DataPropertyName = "fld_Surname";
            this.Column13.HeaderText = "Last Name";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "fld_Activity_Name";
            this.Column8.HeaderText = "Activity";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Contact
            // 
            this.Contact.DataPropertyName = "fld_Contact_Number";
            this.Contact.HeaderText = "Contact";
            this.Contact.Name = "Contact";
            this.Contact.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "fld_Start_Date";
            this.Column6.HeaderText = "Date Start";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "fld_End_Date";
            this.Column10.HeaderText = "Date End";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "fld_Start_Time";
            this.Column7.HeaderText = "Time Start";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "fld_End_Time";
            this.Column9.HeaderText = "Time End";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "fld_Reservation_Status";
            this.Column5.HeaderText = "Status";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // fld_Total_Amount1
            // 
            this.fld_Total_Amount1.DataPropertyName = "fld_Total_Amount";
            this.fld_Total_Amount1.HeaderText = "Total";
            this.fld_Total_Amount1.Name = "fld_Total_Amount1";
            this.fld_Total_Amount1.ReadOnly = true;
            // 
            // frm_Approved_Venue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 617);
            this.Controls.Add(this.lbl_approved);
            this.Controls.Add(this.dt_approved);
            this.Name = "frm_Approved_Venue";
            this.Text = "frm_Approved";
            this.Load += new System.EventHandler(this.frm_Approved_Venue_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dt_approved)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_approved;
        private System.Windows.Forms.DataGridView dt_approved;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Contact;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Total_Amount1;
    }
}