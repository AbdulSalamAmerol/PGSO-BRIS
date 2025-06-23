using System;

namespace pgso
{
    partial class frm_login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, </param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_login));
            this.lb_pitd = new System.Windows.Forms.Label();
            this.panel_bg_pgso = new System.Windows.Forms.Panel();
            this.lb_pgis = new System.Windows.Forms.Label();
            this.lb_pgso = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_grop_login = new System.Windows.Forms.Panel();
            this.btn_Login = new System.Windows.Forms.Button();
            this.CB_remember = new System.Windows.Forms.CheckBox();
            this.TXT_password = new System.Windows.Forms.TextBox();
            this.TXT_username = new System.Windows.Forms.TextBox();
            this.LB_datetime = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PicB_logo = new System.Windows.Forms.PictureBox();
            this.btn_Close = new System.Windows.Forms.Button();
            this.panel_bg_pgso.SuspendLayout();
            this.panel_grop_login.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicB_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_pitd
            // 
            this.lb_pitd.AutoSize = true;
            this.lb_pitd.Location = new System.Drawing.Point(4, 3);
            this.lb_pitd.Name = "lb_pitd";
            this.lb_pitd.Size = new System.Drawing.Size(245, 13);
            this.lb_pitd.TabIndex = 1;
            this.lb_pitd.Text = "@2025 Provincial Information Technology Division";
            // 
            // panel_bg_pgso
            // 
            this.panel_bg_pgso.BackColor = System.Drawing.Color.Green;
            this.panel_bg_pgso.Controls.Add(this.lb_pgis);
            this.panel_bg_pgso.Controls.Add(this.lb_pgso);
            this.panel_bg_pgso.Location = new System.Drawing.Point(7, 142);
            this.panel_bg_pgso.Name = "panel_bg_pgso";
            this.panel_bg_pgso.Size = new System.Drawing.Size(310, 69);
            this.panel_bg_pgso.TabIndex = 2;
            // 
            // lb_pgis
            // 
            this.lb_pgis.AutoSize = true;
            this.lb_pgis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_pgis.ForeColor = System.Drawing.Color.Yellow;
            this.lb_pgis.Location = new System.Drawing.Point(4, 44);
            this.lb_pgis.Name = "lb_pgis";
            this.lb_pgis.Size = new System.Drawing.Size(300, 20);
            this.lb_pgis.TabIndex = 1;
            this.lb_pgis.Text = "Provicial Government Information System";
            // 
            // lb_pgso
            // 
            this.lb_pgso.AutoSize = true;
            this.lb_pgso.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_pgso.ForeColor = System.Drawing.Color.White;
            this.lb_pgso.Location = new System.Drawing.Point(100, 0);
            this.lb_pgso.Name = "lb_pgso";
            this.lb_pgso.Size = new System.Drawing.Size(133, 37);
            this.lb_pgso.TabIndex = 0;
            this.lb_pgso.Text = ".PGSO.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(74, 214);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Login to Access GSRBS";
            // 
            // panel_grop_login
            // 
            this.panel_grop_login.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_grop_login.Controls.Add(this.btn_Close);
            this.panel_grop_login.Controls.Add(this.pictureBox1);
            this.panel_grop_login.Controls.Add(this.btn_Login);
            this.panel_grop_login.Controls.Add(this.CB_remember);
            this.panel_grop_login.Controls.Add(this.TXT_password);
            this.panel_grop_login.Controls.Add(this.TXT_username);
            this.panel_grop_login.Controls.Add(this.LB_datetime);
            this.panel_grop_login.Location = new System.Drawing.Point(7, 238);
            this.panel_grop_login.Name = "panel_grop_login";
            this.panel_grop_login.Size = new System.Drawing.Size(310, 197);
            this.panel_grop_login.TabIndex = 4;
            // 
            // btn_Login
            // 
            this.btn_Login.BackColor = System.Drawing.Color.Green;
            this.btn_Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Login.ForeColor = System.Drawing.Color.White;
            this.btn_Login.Location = new System.Drawing.Point(8, 118);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(292, 31);
            this.btn_Login.TabIndex = 5;
            this.btn_Login.Text = "Login";
            this.btn_Login.UseVisualStyleBackColor = false;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // CB_remember
            // 
            this.CB_remember.AutoSize = true;
            this.CB_remember.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_remember.Location = new System.Drawing.Point(163, 95);
            this.CB_remember.Name = "CB_remember";
            this.CB_remember.Size = new System.Drawing.Size(142, 24);
            this.CB_remember.TabIndex = 4;
            this.CB_remember.Text = "Remember Me?";
            this.CB_remember.UseVisualStyleBackColor = true;
            // 
            // TXT_password
            // 
            this.TXT_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_password.Location = new System.Drawing.Point(7, 63);
            this.TXT_password.Name = "TXT_password";
            this.TXT_password.Size = new System.Drawing.Size(296, 26);
            this.TXT_password.TabIndex = 3;
            this.TXT_password.TextChanged += new System.EventHandler(this.TXT_password_TextChanged);
            // 
            // TXT_username
            // 
            this.TXT_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_username.Location = new System.Drawing.Point(7, 33);
            this.TXT_username.Name = "TXT_username";
            this.TXT_username.Size = new System.Drawing.Size(296, 26);
            this.TXT_username.TabIndex = 2;
            this.TXT_username.TextChanged += new System.EventHandler(this.TXT_username_TextChanged);
            // 
            // LB_datetime
            // 
            this.LB_datetime.AutoSize = true;
            this.LB_datetime.Location = new System.Drawing.Point(83, 4);
            this.LB_datetime.Name = "LB_datetime";
            this.LB_datetime.Size = new System.Drawing.Size(0, 13);
            this.LB_datetime.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(278, 67);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(23, 18);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // PicB_logo
            // 
            this.PicB_logo.Image = ((System.Drawing.Image)(resources.GetObject("PicB_logo.Image")));
            this.PicB_logo.Location = new System.Drawing.Point(115, 52);
            this.PicB_logo.Name = "PicB_logo";
            this.PicB_logo.Size = new System.Drawing.Size(100, 71);
            this.PicB_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicB_logo.TabIndex = 0;
            this.PicB_logo.TabStop = false;
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.Green;
            this.btn_Close.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.ForeColor = System.Drawing.Color.White;
            this.btn_Close.Location = new System.Drawing.Point(8, 153);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(292, 31);
            this.btn_Close.TabIndex = 7;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // frm_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 444);
            this.Controls.Add(this.panel_grop_login);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel_bg_pgso);
            this.Controls.Add(this.lb_pitd);
            this.Controls.Add(this.PicB_logo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_login";
            this.Text = "frm_login";
            this.Load += new System.EventHandler(this.frm_login_Load);
            this.panel_bg_pgso.ResumeLayout(false);
            this.panel_bg_pgso.PerformLayout();
            this.panel_grop_login.ResumeLayout(false);
            this.panel_grop_login.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicB_logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PicB_logo;
        private System.Windows.Forms.Label lb_pitd;
        private System.Windows.Forms.Panel panel_bg_pgso;
        private System.Windows.Forms.Label lb_pgis;
        private System.Windows.Forms.Label lb_pgso;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel_grop_login;
        private System.Windows.Forms.Label LB_datetime;
        private System.Windows.Forms.Button btn_Login;
        public System.Windows.Forms.CheckBox CB_remember;
        private System.Windows.Forms.TextBox TXT_password;
        private System.Windows.Forms.TextBox TXT_username;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_Close;
    }
}