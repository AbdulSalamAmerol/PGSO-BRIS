namespace pgso.pgso_Billing.Forms
{
    partial class frm_Add_Equipment_Billing
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
            this.cmb_Equipment = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.num_Quantity = new System.Windows.Forms.NumericUpDown();
            this.btn_Save = new System.Windows.Forms.Button();
            this.lbl_Standard_Price = new System.Windows.Forms.TextBox();
            this.lbl_Subsequent_Price = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.dtp_Start_Date_Eq = new System.Windows.Forms.DateTimePicker();
            this.dtp_End_Date_Eq = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.num_Quantity)).BeginInit();
            this.SuspendLayout();
            // 
            // cmb_Equipment
            // 
            this.cmb_Equipment.FormattingEnabled = true;
            this.cmb_Equipment.Location = new System.Drawing.Point(128, 75);
            this.cmb_Equipment.Name = "cmb_Equipment";
            this.cmb_Equipment.Size = new System.Drawing.Size(199, 21);
            this.cmb_Equipment.TabIndex = 0;
            this.cmb_Equipment.SelectedIndexChanged += new System.EventHandler(this.cmb_Equipment_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 75);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "cmb_Equipment";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(12, 127);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 3;
            this.textBox3.Text = "num_Quantity";
            // 
            // num_Quantity
            // 
            this.num_Quantity.Location = new System.Drawing.Point(128, 127);
            this.num_Quantity.Name = "num_Quantity";
            this.num_Quantity.Size = new System.Drawing.Size(199, 20);
            this.num_Quantity.TabIndex = 8;
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(252, 153);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 10;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // lbl_Standard_Price
            // 
            this.lbl_Standard_Price.Location = new System.Drawing.Point(12, 101);
            this.lbl_Standard_Price.Name = "lbl_Standard_Price";
            this.lbl_Standard_Price.Size = new System.Drawing.Size(100, 20);
            this.lbl_Standard_Price.TabIndex = 11;
            // 
            // lbl_Subsequent_Price
            // 
            this.lbl_Subsequent_Price.Location = new System.Drawing.Point(128, 102);
            this.lbl_Subsequent_Price.Name = "lbl_Subsequent_Price";
            this.lbl_Subsequent_Price.Size = new System.Drawing.Size(200, 20);
            this.lbl_Subsequent_Price.TabIndex = 12;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 49);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 13;
            this.textBox2.Text = "End Date";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(12, 23);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 20);
            this.textBox5.TabIndex = 14;
            this.textBox5.Text = "Start Date";
            // 
            // dtp_Start_Date_Eq
            // 
            this.dtp_Start_Date_Eq.Location = new System.Drawing.Point(128, 23);
            this.dtp_Start_Date_Eq.Name = "dtp_Start_Date_Eq";
            this.dtp_Start_Date_Eq.Size = new System.Drawing.Size(200, 20);
            this.dtp_Start_Date_Eq.TabIndex = 15;
            // 
            // dtp_End_Date_Eq
            // 
            this.dtp_End_Date_Eq.Location = new System.Drawing.Point(128, 49);
            this.dtp_End_Date_Eq.Name = "dtp_End_Date_Eq";
            this.dtp_End_Date_Eq.Size = new System.Drawing.Size(200, 20);
            this.dtp_End_Date_Eq.TabIndex = 16;
            // 
            // frm_Add_Equipment_Billing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 214);
            this.Controls.Add(this.dtp_End_Date_Eq);
            this.Controls.Add(this.dtp_Start_Date_Eq);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.lbl_Subsequent_Price);
            this.Controls.Add(this.lbl_Standard_Price);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.num_Quantity);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.cmb_Equipment);
            this.Name = "frm_Add_Equipment_Billing";
            this.Text = "frm_Add_Equipment_Billing";
            ((System.ComponentModel.ISupportInitialize)(this.num_Quantity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_Equipment;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.NumericUpDown num_Quantity;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.TextBox lbl_Standard_Price;
        private System.Windows.Forms.TextBox lbl_Subsequent_Price;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.DateTimePicker dtp_Start_Date_Eq;
        private System.Windows.Forms.DateTimePicker dtp_End_Date_Eq;
    }
}