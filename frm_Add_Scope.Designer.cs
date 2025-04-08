namespace pgso
{
    partial class frm_Add_Scope
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
            this.combo_Venue = new System.Windows.Forms.ComboBox();
            this.txt_Scope_Name = new System.Windows.Forms.TextBox();
            this.tbn_Save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // combo_Venue
            // 
            this.combo_Venue.FormattingEnabled = true;
            this.combo_Venue.Location = new System.Drawing.Point(48, 41);
            this.combo_Venue.Name = "combo_Venue";
            this.combo_Venue.Size = new System.Drawing.Size(121, 21);
            this.combo_Venue.TabIndex = 0;
            // 
            // txt_Scope_Name
            // 
            this.txt_Scope_Name.Location = new System.Drawing.Point(64, 102);
            this.txt_Scope_Name.Name = "txt_Scope_Name";
            this.txt_Scope_Name.Size = new System.Drawing.Size(100, 20);
            this.txt_Scope_Name.TabIndex = 1;
            // 
            // tbn_Save
            // 
            this.tbn_Save.Location = new System.Drawing.Point(91, 143);
            this.tbn_Save.Name = "tbn_Save";
            this.tbn_Save.Size = new System.Drawing.Size(75, 23);
            this.tbn_Save.TabIndex = 2;
            this.tbn_Save.Text = "button1";
            this.tbn_Save.UseVisualStyleBackColor = true;
            this.tbn_Save.Click += new System.EventHandler(this.tbn_Save_Click);
            // 
            // frm_Add_Scope
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 266);
            this.Controls.Add(this.tbn_Save);
            this.Controls.Add(this.txt_Scope_Name);
            this.Controls.Add(this.combo_Venue);
            this.Name = "frm_Add_Scope";
            this.Text = "frm_Add_Scope";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox combo_Venue;
        private System.Windows.Forms.TextBox txt_Scope_Name;
        private System.Windows.Forms.Button tbn_Save;
    }
}