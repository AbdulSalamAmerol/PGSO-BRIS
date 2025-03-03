namespace pgso
{
    partial class frm_choosevenues
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
            this.btn_ammunganhall = new System.Windows.Forms.Button();
            this.btn_convention = new System.Windows.Forms.Button();
            this.btn_pasalubong = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.SuspendLayout();
            // 
            // btn_ammunganhall
            // 
            this.btn_ammunganhall.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ammunganhall.Location = new System.Drawing.Point(26, 54);
            this.btn_ammunganhall.Name = "btn_ammunganhall";
            this.btn_ammunganhall.Size = new System.Drawing.Size(251, 36);
            this.btn_ammunganhall.TabIndex = 0;
            this.btn_ammunganhall.Text = "Ammungan Hall";
            this.btn_ammunganhall.UseVisualStyleBackColor = true;
            this.btn_ammunganhall.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_convention
            // 
            this.btn_convention.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_convention.Location = new System.Drawing.Point(26, 96);
            this.btn_convention.Name = "btn_convention";
            this.btn_convention.Size = new System.Drawing.Size(251, 36);
            this.btn_convention.TabIndex = 1;
            this.btn_convention.Text = "Convention Hall";
            this.btn_convention.UseVisualStyleBackColor = true;
            this.btn_convention.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_pasalubong
            // 
            this.btn_pasalubong.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_pasalubong.Location = new System.Drawing.Point(26, 138);
            this.btn_pasalubong.Name = "btn_pasalubong";
            this.btn_pasalubong.Size = new System.Drawing.Size(251, 36);
            this.btn_pasalubong.TabIndex = 2;
            this.btn_pasalubong.Text = "NV Pasalubong Center";
            this.btn_pasalubong.UseVisualStyleBackColor = true;
            this.btn_pasalubong.Click += new System.EventHandler(this.btn_pasalubong_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(26, 180);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(251, 36);
            this.button4.TabIndex = 3;
            this.button4.Text = "NV Sports Complex";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(26, 222);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(251, 36);
            this.button5.TabIndex = 4;
            this.button5.Text = "Ammungan Hall";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(26, 263);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(251, 36);
            this.button6.TabIndex = 5;
            this.button6.Text = "Ammungan Hall";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 33);
            this.label1.TabIndex = 6;
            this.label1.Text = "SELECT VENUES";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(316, 54);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.ShowTodayCircle = false;
            this.monthCalendar1.TabIndex = 7;
            // 
            // frm_choosevenues
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(604, 327);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btn_pasalubong);
            this.Controls.Add(this.btn_convention);
            this.Controls.Add(this.btn_ammunganhall);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_choosevenues";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Venues";
            this.Load += new System.EventHandler(this.venuesmodal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_ammunganhall;
        private System.Windows.Forms.Button btn_convention;
        private System.Windows.Forms.Button btn_pasalubong;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
    }
}