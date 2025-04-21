namespace pgso
{
    partial class UserControlDaysEquipment
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
            this.lblEquipmentReservations = new System.Windows.Forms.Label();
            this.lblDays_Equipment = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblEquipmentReservations
            // 
            this.lblEquipmentReservations.AutoSize = true;
            this.lblEquipmentReservations.Font = new System.Drawing.Font("Microsoft PhagsPa", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEquipmentReservations.Location = new System.Drawing.Point(4, 22);
            this.lblEquipmentReservations.Name = "lblEquipmentReservations";
            this.lblEquipmentReservations.Size = new System.Drawing.Size(19, 16);
            this.lblEquipmentReservations.TabIndex = 5;
            this.lblEquipmentReservations.Text = "00";
            // 
            // lblDays_Equipment
            // 
            this.lblDays_Equipment.AutoSize = true;
            this.lblDays_Equipment.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDays_Equipment.Location = new System.Drawing.Point(3, 0);
            this.lblDays_Equipment.Name = "lblDays_Equipment";
            this.lblDays_Equipment.Size = new System.Drawing.Size(32, 22);
            this.lblDays_Equipment.TabIndex = 3;
            this.lblDays_Equipment.Text = "00";
            // 
            // UserControlDaysEquipment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblEquipmentReservations);
            this.Controls.Add(this.lblDays_Equipment);
            this.Name = "UserControlDaysEquipment";
            this.Size = new System.Drawing.Size(163, 117);
            this.Load += new System.EventHandler(this.UserControlDaysEquipment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEquipmentReservations;
        private System.Windows.Forms.Label lblDays_Equipment;
    }
}
