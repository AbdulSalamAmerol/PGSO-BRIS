namespace pgso
{
    partial class frm_mngreservation
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
            this.button1 = new System.Windows.Forms.Button();
            this.btn_rentals = new System.Windows.Forms.Button();
            this.btn_Manage_Facilities = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(55, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 44);
            this.button1.TabIndex = 0;
            this.button1.Text = "Venues";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_rentals
            // 
            this.btn_rentals.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_rentals.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_rentals.Location = new System.Drawing.Point(55, 86);
            this.btn_rentals.Name = "btn_rentals";
            this.btn_rentals.Size = new System.Drawing.Size(147, 44);
            this.btn_rentals.TabIndex = 1;
            this.btn_rentals.Text = "Rentals";
            this.btn_rentals.UseVisualStyleBackColor = true;
            this.btn_rentals.Click += new System.EventHandler(this.btn_rentals_Click);
            // 
            // btn_Manage_Facilities
            // 
            this.btn_Manage_Facilities.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Manage_Facilities.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Manage_Facilities.Location = new System.Drawing.Point(55, 173);
            this.btn_Manage_Facilities.Name = "btn_Manage_Facilities";
            this.btn_Manage_Facilities.Size = new System.Drawing.Size(147, 44);
            this.btn_Manage_Facilities.TabIndex = 2;
            this.btn_Manage_Facilities.Text = "Rentals";
            this.btn_Manage_Facilities.UseVisualStyleBackColor = true;
            this.btn_Manage_Facilities.Click += new System.EventHandler(this.btn_Manage_Facilities_Click);
            // 
            // frm_mngreservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 229);
            this.Controls.Add(this.btn_Manage_Facilities);
            this.Controls.Add(this.btn_rentals);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frm_mngreservation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frm_mngreservation";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.frm_mngreservation_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_rentals;
        private System.Windows.Forms.Button btn_Manage_Facilities;
    }
}