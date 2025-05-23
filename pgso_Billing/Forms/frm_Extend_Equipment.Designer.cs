namespace pgso.pgso_Billing.Forms
{
    partial class frm_Extend_Equipment
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lbl_Extend_Equipment = new System.Windows.Forms.TextBox();
            this.btn_Extend_Equipment = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(9, 22);
            this.textBox1.Margin = new System.Windows.Forms.Padding(0);
            this.textBox1.MinimumSize = new System.Drawing.Size(0, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(146, 19);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "Extension ( Day/s )";
            // 
            // lbl_Extend_Equipment
            // 
            this.lbl_Extend_Equipment.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_Extend_Equipment.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbl_Extend_Equipment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Extend_Equipment.Location = new System.Drawing.Point(164, 19);
            this.lbl_Extend_Equipment.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_Extend_Equipment.MinimumSize = new System.Drawing.Size(4, 30);
            this.lbl_Extend_Equipment.Name = "lbl_Extend_Equipment";
            this.lbl_Extend_Equipment.ReadOnly = true;
            this.lbl_Extend_Equipment.Size = new System.Drawing.Size(180, 26);
            this.lbl_Extend_Equipment.TabIndex = 4;
            // 
            // btn_Extend_Equipment
            // 
            this.btn_Extend_Equipment.Location = new System.Drawing.Point(274, 59);
            this.btn_Extend_Equipment.Name = "btn_Extend_Equipment";
            this.btn_Extend_Equipment.Size = new System.Drawing.Size(70, 35);
            this.btn_Extend_Equipment.TabIndex = 5;
            this.btn_Extend_Equipment.Text = "Enter";
            this.btn_Extend_Equipment.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btn_Extend_Equipment);
            this.panel2.Controls.Add(this.lbl_Extend_Equipment);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(353, 207);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "WALA NA ITO";
            // 
            // frm_Extend_Equipment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 207);
            this.Controls.Add(this.panel2);
            this.Name = "frm_Extend_Equipment";
            this.Text = "frm_Extend_Equipment";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox lbl_Extend_Equipment;
        private System.Windows.Forms.Button btn_Extend_Equipment;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
    }
}