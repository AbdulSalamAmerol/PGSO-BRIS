namespace pgso
{
    partial class UserControlDays
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblDays = new System.Windows.Forms.Label();
            this.lbl_Reservations = new System.Windows.Forms.Label();
            this.lbl_Equipment = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDays
            // 
            this.lblDays.AutoSize = true;
            this.lblDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDays.Location = new System.Drawing.Point(3, 0);
            this.lblDays.Name = "lblDays";
            this.lblDays.Size = new System.Drawing.Size(38, 25);
            this.lblDays.TabIndex = 0;
            this.lblDays.Text = "00";
            // 
            // lbl_Reservations
            // 
            this.lbl_Reservations.AutoSize = true;
            this.lbl_Reservations.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Reservations.Location = new System.Drawing.Point(27, 38);
            this.lbl_Reservations.Name = "lbl_Reservations";
            this.lbl_Reservations.Size = new System.Drawing.Size(27, 20);
            this.lbl_Reservations.TabIndex = 5;
            this.lbl_Reservations.Text = "00";
            this.lbl_Reservations.Click += new System.EventHandler(this.lbl_Reservations_Click_1);
            // 
            // lbl_Equipment
            // 
            this.lbl_Equipment.AutoSize = true;
            this.lbl_Equipment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Equipment.Location = new System.Drawing.Point(27, 91);
            this.lbl_Equipment.Name = "lbl_Equipment";
            this.lbl_Equipment.Size = new System.Drawing.Size(27, 20);
            this.lbl_Equipment.TabIndex = 6;
            this.lbl_Equipment.Text = "00";
            // 
            // UserControlDays
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.Controls.Add(this.lbl_Equipment);
            this.Controls.Add(this.lbl_Reservations);
            this.Controls.Add(this.lblDays);
            this.Name = "UserControlDays";
            this.Size = new System.Drawing.Size(260, 154);
            this.Load += new System.EventHandler(this.UserControlDays_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDays;
        private System.Windows.Forms.Label lbl_Reservations;
        private System.Windows.Forms.Label lbl_Equipment;
    }
}
