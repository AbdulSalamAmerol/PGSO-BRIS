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
            this.combo_Venues = new System.Windows.Forms.ComboBox();
            this.combo_Equipments = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblDays
            // 
            this.lblDays.AutoSize = true;
            this.lblDays.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDays.Location = new System.Drawing.Point(3, 0);
            this.lblDays.Name = "lblDays";
            this.lblDays.Size = new System.Drawing.Size(32, 22);
            this.lblDays.TabIndex = 0;
            this.lblDays.Text = "00";
            // 
            // combo_Venues
            // 
            this.combo_Venues.BackColor = System.Drawing.Color.Honeydew;
            this.combo_Venues.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_Venues.FormattingEnabled = true;
            this.combo_Venues.Location = new System.Drawing.Point(21, 25);
            this.combo_Venues.Name = "combo_Venues";
            this.combo_Venues.Size = new System.Drawing.Size(142, 25);
            this.combo_Venues.TabIndex = 3;
            // 
            // combo_Equipments
            // 
            this.combo_Equipments.BackColor = System.Drawing.Color.AliceBlue;
            this.combo_Equipments.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_Equipments.FormattingEnabled = true;
            this.combo_Equipments.Location = new System.Drawing.Point(21, 56);
            this.combo_Equipments.Name = "combo_Equipments";
            this.combo_Equipments.Size = new System.Drawing.Size(142, 25);
            this.combo_Equipments.TabIndex = 4;
            // 
            // UserControlDays
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.Controls.Add(this.combo_Equipments);
            this.Controls.Add(this.combo_Venues);
            this.Controls.Add(this.lblDays);
            this.Name = "UserControlDays";
            this.Size = new System.Drawing.Size(195, 104);
            this.Load += new System.EventHandler(this.UserControlDays_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDays;
        private System.Windows.Forms.ComboBox combo_Venues;
        private System.Windows.Forms.ComboBox combo_Equipments;
    }
}
