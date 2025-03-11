namespace pgso
{
    partial class frm_reservation_forms
    {
   
        private System.ComponentModel.IContainer components = null;

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

        private void InitializeComponent()
        {
            this.cmb_ReservationType = new System.Windows.Forms.ComboBox();
            this.cmb_VenueSelection = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cmb_ReservationType
            // 
            this.cmb_ReservationType.FormattingEnabled = true;
            this.cmb_ReservationType.Items.AddRange(new object[] {
            "Venue Reservation",
            "Facility Reservation"});
            this.cmb_ReservationType.Location = new System.Drawing.Point(12, 31);
            this.cmb_ReservationType.Name = "cmb_ReservationType";
            this.cmb_ReservationType.Size = new System.Drawing.Size(121, 21);
            this.cmb_ReservationType.TabIndex = 0;
            this.cmb_ReservationType.Text = "Reservation Type";
            this.cmb_ReservationType.SelectedIndexChanged += new System.EventHandler(this.cmb_ReservationType_SelectedIndexChanged);
            // 
            // cmb_VenueSelection
            // 
            this.cmb_VenueSelection.FormattingEnabled = true;
            this.cmb_VenueSelection.Location = new System.Drawing.Point(12, 58);
            this.cmb_VenueSelection.Name = "cmb_VenueSelection";
            this.cmb_VenueSelection.Size = new System.Drawing.Size(121, 21);
            this.cmb_VenueSelection.TabIndex = 1;
            this.cmb_VenueSelection.Visible = false;
            // 
            // frm_reservation_forms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(852, 761);
            this.Controls.Add(this.cmb_VenueSelection);
            this.Controls.Add(this.cmb_ReservationType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_reservation_forms";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RESERVATION FORMS";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_ReservationType;
        private System.Windows.Forms.ComboBox cmb_VenueSelection;
    }
}