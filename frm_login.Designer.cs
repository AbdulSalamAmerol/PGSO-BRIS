namespace pgso
{
    partial class frm_Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Login));
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.btnlogin = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.showpass = new System.Windows.Forms.PictureBox();
            this.LBdatetime = new System.Windows.Forms.Label();
            this.combouname1 = new System.Windows.Forms.TextBox();
            this.combouname = new System.Windows.Forms.TextBox();
            this.combousertype = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.showpass)).BeginInit();
            this.SuspendLayout();
            // 
            // txtpassword
            // 
            this.txtpassword.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtpassword.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpassword.Location = new System.Drawing.Point(6, 97);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.Size = new System.Drawing.Size(290, 23);
            this.txtpassword.TabIndex = 3;
            // 
            // btnlogin
            // 
            this.btnlogin.BackColor = System.Drawing.Color.ForestGreen;
            this.btnlogin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnlogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlogin.ForeColor = System.Drawing.Color.White;
            this.btnlogin.Location = new System.Drawing.Point(6, 152);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(289, 27);
            this.btnlogin.TabIndex = 0;
            this.btnlogin.Text = "Login";
            this.btnlogin.UseVisualStyleBackColor = false;
            this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(123, 47);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(79, 78);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Stencil", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(91, -5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 42);
            this.label4.TabIndex = 13;
            this.label4.Text = ".PGSO.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Yellow;
            this.label5.Location = new System.Drawing.Point(5, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(293, 24);
            this.label5.TabIndex = 14;
            this.label5.Text = "Provincial General Services Office";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.ForestGreen;
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(6, 131);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(302, 64);
            this.panel2.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(93, 196);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 16);
            this.label6.TabIndex = 16;
            this.label6.Text = "Login to access GSRBS";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.showpass);
            this.panel3.Controls.Add(this.LBdatetime);
            this.panel3.Controls.Add(this.combouname1);
            this.panel3.Controls.Add(this.combouname);
            this.panel3.Controls.Add(this.combousertype);
            this.panel3.Controls.Add(this.checkBox1);
            this.panel3.Controls.Add(this.btnlogin);
            this.panel3.Controls.Add(this.txtpassword);
            this.panel3.Location = new System.Drawing.Point(6, 217);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(302, 192);
            this.panel3.TabIndex = 16;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // showpass
            // 
            this.showpass.Image = ((System.Drawing.Image)(resources.GetObject("showpass.Image")));
            this.showpass.Location = new System.Drawing.Point(264, 99);
            this.showpass.Name = "showpass";
            this.showpass.Size = new System.Drawing.Size(30, 19);
            this.showpass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.showpass.TabIndex = 16;
            this.showpass.TabStop = false;
            this.showpass.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // LBdatetime
            // 
            this.LBdatetime.AutoSize = true;
            this.LBdatetime.Location = new System.Drawing.Point(86, 9);
            this.LBdatetime.Name = "LBdatetime";
            this.LBdatetime.Size = new System.Drawing.Size(0, 13);
            this.LBdatetime.TabIndex = 15;
            // 
            // combouname1
            // 
            this.combouname1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.combouname1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combouname1.Location = new System.Drawing.Point(6, 69);
            this.combouname1.Name = "combouname1";
            this.combouname1.Size = new System.Drawing.Size(289, 23);
            this.combouname1.TabIndex = 14;
            this.combouname1.Enter += new System.EventHandler(this.combouname1_Enter);
            this.combouname1.Leave += new System.EventHandler(this.combouname1_Leave);
            // 
            // combouname
            // 
            this.combouname.BackColor = System.Drawing.SystemColors.MenuBar;
            this.combouname.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combouname.Location = new System.Drawing.Point(45, 422);
            this.combouname.Name = "combouname";
            this.combouname.Size = new System.Drawing.Size(190, 22);
            this.combouname.TabIndex = 9;
            this.combouname.TextChanged += new System.EventHandler(this.combouname1_TextChanged);
            // 
            // combousertype
            // 
            this.combousertype.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combousertype.FormattingEnabled = true;
            this.combousertype.Items.AddRange(new object[] {
            "Admin",
            "Staff"});
            this.combousertype.Location = new System.Drawing.Point(6, 36);
            this.combousertype.Name = "combousertype";
            this.combousertype.Size = new System.Drawing.Size(289, 25);
            this.combousertype.TabIndex = 12;
            this.combousertype.SelectedIndexChanged += new System.EventHandler(this.combousertype_SelectedIndexChanged_1);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(171, 124);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(117, 19);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Remember me?";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-1, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "@2025 - Provincial Information Technology Division";
            // 
            // frm_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 427);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "log_in";
            this.Load += new System.EventHandler(this.frm_login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.showpass)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnlogin;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox combousertype;
        private System.Windows.Forms.TextBox combouname;
        private System.Windows.Forms.TextBox combouname1;
        private System.Windows.Forms.Label LBdatetime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox showpass;
    }
}

