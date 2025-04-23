namespace pgso.pgso_Billing.Forms
{
    partial class frm_Extend_Venue
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_Extend_Venue = new System.Windows.Forms.Button();
            this.lbl_Extend_Venue = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lbl_OR_Extension = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbl_OR_Extension);
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Controls.Add(this.btn_Extend_Venue);
            this.panel2.Controls.Add(this.lbl_Extend_Venue);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(369, 243);
            this.panel2.TabIndex = 3;
            // 
            // btn_Extend_Venue
            // 
            this.btn_Extend_Venue.Location = new System.Drawing.Point(274, 114);
            this.btn_Extend_Venue.Name = "btn_Extend_Venue";
            this.btn_Extend_Venue.Size = new System.Drawing.Size(70, 35);
            this.btn_Extend_Venue.TabIndex = 6;
            this.btn_Extend_Venue.Text = "Enter";
            this.btn_Extend_Venue.UseVisualStyleBackColor = true;
            this.btn_Extend_Venue.Click += new System.EventHandler(this.btn_Extend_Venue_Click);
            // 
            // lbl_Extend_Venue
            // 
            this.lbl_Extend_Venue.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_Extend_Venue.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbl_Extend_Venue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Extend_Venue.Location = new System.Drawing.Point(164, 19);
            this.lbl_Extend_Venue.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_Extend_Venue.MinimumSize = new System.Drawing.Size(4, 30);
            this.lbl_Extend_Venue.Name = "lbl_Extend_Venue";
            this.lbl_Extend_Venue.Size = new System.Drawing.Size(180, 26);
            this.lbl_Extend_Venue.TabIndex = 4;
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
            this.textBox1.Text = "Extension ( Hour/s )";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(369, 45);
            this.panel1.TabIndex = 2;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Control;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(9, 9);
            this.textBox3.Margin = new System.Windows.Forms.Padding(0);
            this.textBox3.MinimumSize = new System.Drawing.Size(0, 30);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(238, 19);
            this.textBox3.TabIndex = 2;
            this.textBox3.Text = "EXTEND VENUE USAGE";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(9, 59);
            this.textBox2.Margin = new System.Windows.Forms.Padding(0);
            this.textBox2.MinimumSize = new System.Drawing.Size(0, 30);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(146, 30);
            this.textBox2.TabIndex = 7;
            this.textBox2.Text = "OR";
            // 
            // lbl_OR_Extension
            // 
            this.lbl_OR_Extension.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbl_OR_Extension.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbl_OR_Extension.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_OR_Extension.Location = new System.Drawing.Point(164, 59);
            this.lbl_OR_Extension.Margin = new System.Windows.Forms.Padding(0);
            this.lbl_OR_Extension.MinimumSize = new System.Drawing.Size(4, 30);
            this.lbl_OR_Extension.Name = "lbl_OR_Extension";
            this.lbl_OR_Extension.Size = new System.Drawing.Size(180, 30);
            this.lbl_OR_Extension.TabIndex = 8;
            // 
            // frm_Extend_Venue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 288);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frm_Extend_Venue";
            this.Text = "frm_Extend_Venue";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox lbl_Extend_Venue;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button btn_Extend_Venue;
        private System.Windows.Forms.TextBox lbl_OR_Extension;
        private System.Windows.Forms.TextBox textBox2;
    }
}