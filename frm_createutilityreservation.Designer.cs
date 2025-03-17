namespace pgso
{
    partial class frm_createutilityreservation
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel_faci = new System.Windows.Forms.Panel();
            this.dt_Utilities = new System.Windows.Forms.DataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.data_of_use_end = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_controlnum = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TimeEnd = new System.Windows.Forms.DateTimePicker();
            this.TimeStart = new System.Windows.Forms.DateTimePicker();
            this.btn_clearform = new System.Windows.Forms.Button();
            this.btn_submit = new System.Windows.Forms.Button();
            this.date_of_use_start = new System.Windows.Forms.DateTimePicker();
            this.txt_contact = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_address = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_requestingperson = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel_faci.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt_Utilities)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Khaki;
            this.panel1.Controls.Add(this.panel_faci);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.data_of_use_end);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txt_controlnum);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.TimeEnd);
            this.panel1.Controls.Add(this.TimeStart);
            this.panel1.Controls.Add(this.btn_clearform);
            this.panel1.Controls.Add(this.btn_submit);
            this.panel1.Controls.Add(this.date_of_use_start);
            this.panel1.Controls.Add(this.txt_contact);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txt_address);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txt_requestingperson);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(34, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(678, 701);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel_faci
            // 
            this.panel_faci.Controls.Add(this.dt_Utilities);
            this.panel_faci.Controls.Add(this.label7);
            this.panel_faci.Location = new System.Drawing.Point(64, 278);
            this.panel_faci.Name = "panel_faci";
            this.panel_faci.Size = new System.Drawing.Size(522, 307);
            this.panel_faci.TabIndex = 42;
            // 
            // dt_Utilities
            // 
            this.dt_Utilities.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dt_Utilities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt_Utilities.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dt_Utilities.Location = new System.Drawing.Point(15, 30);
            this.dt_Utilities.Name = "dt_Utilities";
            this.dt_Utilities.RowHeadersVisible = false;
            this.dt_Utilities.Size = new System.Drawing.Size(496, 225);
            this.dt_Utilities.TabIndex = 13;
            this.dt_Utilities.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dt_Utilities_CellContentClick);
            // 
            // Column5
            // 
            this.Column5.FillWeight = 35.40416F;
            this.Column5.HeaderText = "Choose";
            this.Column5.Name = "Column5";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "FacilityName";
            this.Column1.FillWeight = 78.33169F;
            this.Column1.HeaderText = "Facilities";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "FacilityPricePerUnit";
            this.Column2.FillWeight = 78.33169F;
            this.Column2.HeaderText = "Price per Unit";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "FacilityTotalQuantity";
            this.Column3.FillWeight = 78.33169F;
            this.Column3.HeaderText = "Total Quantity";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "FacilityAvailableQuantity";
            this.Column4.FillWeight = 78.33169F;
            this.Column4.HeaderText = "Available";
            this.Column4.Name = "Column4";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(12, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(167, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "FACILITIES (Please Check)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(207, 224);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(36, 20);
            this.label13.TabIndex = 28;
            this.label13.Text = "End";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(202, 192);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 20);
            this.label12.TabIndex = 27;
            this.label12.Text = "Start";
            // 
            // data_of_use_end
            // 
            this.data_of_use_end.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.data_of_use_end.Location = new System.Drawing.Point(259, 222);
            this.data_of_use_end.Name = "data_of_use_end";
            this.data_of_use_end.Size = new System.Drawing.Size(227, 22);
            this.data_of_use_end.TabIndex = 26;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(118, 29);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(125, 20);
            this.label11.TabIndex = 25;
            this.label11.Text = "Control Number";
            // 
            // txt_controlnum
            // 
            this.txt_controlnum.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_controlnum.Location = new System.Drawing.Point(258, 25);
            this.txt_controlnum.Name = "txt_controlnum";
            this.txt_controlnum.Size = new System.Drawing.Size(139, 24);
            this.txt_controlnum.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(393, 255);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 17);
            this.label9.TabIndex = 21;
            this.label9.Text = "To:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(195, 249);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 20);
            this.label8.TabIndex = 20;
            this.label8.Text = "From:";
            // 
            // TimeEnd
            // 
            this.TimeEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.TimeEnd.Location = new System.Drawing.Point(430, 317);
            this.TimeEnd.Name = "TimeEnd";
            this.TimeEnd.ShowUpDown = true;
            this.TimeEnd.Size = new System.Drawing.Size(106, 22);
            this.TimeEnd.TabIndex = 19;
            // 
            // TimeStart
            // 
            this.TimeStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeStart.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.TimeStart.Location = new System.Drawing.Point(258, 250);
            this.TimeStart.Name = "TimeStart";
            this.TimeStart.ShowUpDown = true;
            this.TimeStart.Size = new System.Drawing.Size(106, 22);
            this.TimeStart.TabIndex = 18;
            // 
            // btn_clearform
            // 
            this.btn_clearform.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_clearform.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_clearform.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_clearform.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_clearform.Location = new System.Drawing.Point(332, 591);
            this.btn_clearform.Name = "btn_clearform";
            this.btn_clearform.Size = new System.Drawing.Size(111, 30);
            this.btn_clearform.TabIndex = 17;
            this.btn_clearform.Text = "CLEAR FORM";
            this.btn_clearform.UseVisualStyleBackColor = false;
            // 
            // btn_submit
            // 
            this.btn_submit.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_submit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_submit.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_submit.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_submit.Location = new System.Drawing.Point(500, 591);
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.Size = new System.Drawing.Size(75, 30);
            this.btn_submit.TabIndex = 16;
            this.btn_submit.Text = "SUBMIT";
            this.btn_submit.UseVisualStyleBackColor = false;
            // 
            // date_of_use_start
            // 
            this.date_of_use_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_of_use_start.Location = new System.Drawing.Point(258, 190);
            this.date_of_use_start.Name = "date_of_use_start";
            this.date_of_use_start.Size = new System.Drawing.Size(227, 22);
            this.date_of_use_start.TabIndex = 14;
            // 
            // txt_contact
            // 
            this.txt_contact.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_contact.Location = new System.Drawing.Point(259, 159);
            this.txt_contact.Name = "txt_contact";
            this.txt_contact.Size = new System.Drawing.Size(125, 24);
            this.txt_contact.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(60, 249);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "TIME OF USE:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(130, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "CONTACT NO.:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(60, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "DATE OF USE:";
            // 
            // txt_address
            // 
            this.txt_address.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_address.Location = new System.Drawing.Point(258, 94);
            this.txt_address.Multiline = true;
            this.txt_address.Name = "txt_address";
            this.txt_address.Size = new System.Drawing.Size(328, 59);
            this.txt_address.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(166, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "ADDRESS:";
            // 
            // txt_requestingperson
            // 
            this.txt_requestingperson.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_requestingperson.Location = new System.Drawing.Point(259, 60);
            this.txt_requestingperson.Name = "txt_requestingperson";
            this.txt_requestingperson.Size = new System.Drawing.Size(328, 24);
            this.txt_requestingperson.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(20, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "REQUESTING OFFICE/PERSON:";
            // 
            // frm_createutilityreservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 725);
            this.Controls.Add(this.panel1);
            this.Name = "frm_createutilityreservation";
            this.Text = "Create Utility Reservation";
            this.Load += new System.EventHandler(this.frm_createutilityreservation_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel_faci.ResumeLayout(false);
            this.panel_faci.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt_Utilities)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel_faci;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker data_of_use_end;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_controlnum;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker TimeEnd;
        private System.Windows.Forms.DateTimePicker TimeStart;
        private System.Windows.Forms.Button btn_clearform;
        private System.Windows.Forms.Button btn_submit;
        private System.Windows.Forms.DateTimePicker date_of_use_start;
        private System.Windows.Forms.TextBox txt_contact;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_address;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_requestingperson;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dt_Utilities;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
    }
}