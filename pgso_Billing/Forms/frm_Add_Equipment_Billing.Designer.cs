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
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.num_Quantity = new System.Windows.Forms.NumericUpDown();
            this.num_Days = new System.Windows.Forms.NumericUpDown();
            this.btn_Save = new System.Windows.Forms.Button();
            this.lbl_Standard_Price = new System.Windows.Forms.TextBox();
            this.lbl_Subsequent_Price = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.num_Quantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Days)).BeginInit();
            this.SuspendLayout();
            // 
            // cmb_Equipment
            // 
            this.cmb_Equipment.FormattingEnabled = true;
            this.cmb_Equipment.Location = new System.Drawing.Point(139, 43);
            this.cmb_Equipment.Name = "cmb_Equipment";
            this.cmb_Equipment.Size = new System.Drawing.Size(121, 21);
            this.cmb_Equipment.TabIndex = 0;
            this.cmb_Equipment.SelectedIndexChanged += new System.EventHandler(this.cmb_Equipment_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(22, 43);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "cmb_Equipment";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(22, 126);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 3;
            this.textBox3.Text = "num_Quantity";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(22, 184);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 4;
            this.textBox4.Text = "num_Days";
            // 
            // num_Quantity
            // 
            this.num_Quantity.Location = new System.Drawing.Point(140, 126);
            this.num_Quantity.Name = "num_Quantity";
            this.num_Quantity.Size = new System.Drawing.Size(120, 20);
            this.num_Quantity.TabIndex = 8;
            // 
            // num_Days
            // 
            this.num_Days.Location = new System.Drawing.Point(140, 185);
            this.num_Days.Name = "num_Days";
            this.num_Days.Size = new System.Drawing.Size(120, 20);
            this.num_Days.TabIndex = 9;
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(87, 241);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 10;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // lbl_Standard_Price
            // 
            this.lbl_Standard_Price.Location = new System.Drawing.Point(12, 84);
            this.lbl_Standard_Price.Name = "lbl_Standard_Price";
            this.lbl_Standard_Price.Size = new System.Drawing.Size(100, 20);
            this.lbl_Standard_Price.TabIndex = 11;
            // 
            // lbl_Subsequent_Price
            // 
            this.lbl_Subsequent_Price.Location = new System.Drawing.Point(140, 84);
            this.lbl_Subsequent_Price.Name = "lbl_Subsequent_Price";
            this.lbl_Subsequent_Price.Size = new System.Drawing.Size(100, 20);
            this.lbl_Subsequent_Price.TabIndex = 12;
            // 
            // frm_Add_Equipment_Billing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbl_Subsequent_Price);
            this.Controls.Add(this.lbl_Standard_Price);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.num_Days);
            this.Controls.Add(this.num_Quantity);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.cmb_Equipment);
            this.Name = "frm_Add_Equipment_Billing";
            this.Text = "frm_Add_Equipment_Billing";
            ((System.ComponentModel.ISupportInitialize)(this.num_Quantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Days)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_Equipment;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.NumericUpDown num_Quantity;
        private System.Windows.Forms.NumericUpDown num_Days;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.TextBox lbl_Standard_Price;
        private System.Windows.Forms.TextBox lbl_Subsequent_Price;
    }
}