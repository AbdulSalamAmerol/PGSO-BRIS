namespace pgso.pgso_Billing.Forms
{
    partial class frm_Equipment_Returns
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Equipment_Returns));
            this.Equipment = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_Quantity = new System.Windows.Forms.TextBox();
            this.tb_Equipment = new System.Windows.Forms.TextBox();
            this.tb_Returned = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_Return_Now = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_Damaged = new System.Windows.Forms.TextBox();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_SubmitReturn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Equipment
            // 
            this.Equipment.AutoSize = true;
            this.Equipment.Location = new System.Drawing.Point(33, 95);
            this.Equipment.MaximumSize = new System.Drawing.Size(100, 30);
            this.Equipment.MinimumSize = new System.Drawing.Size(85, 15);
            this.Equipment.Name = "Equipment";
            this.Equipment.Size = new System.Drawing.Size(85, 15);
            this.Equipment.TabIndex = 0;
            this.Equipment.Text = "Equipment";
            this.Equipment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 121);
            this.label1.MaximumSize = new System.Drawing.Size(100, 30);
            this.label1.MinimumSize = new System.Drawing.Size(85, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "QTY Reserved";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 147);
            this.label2.MaximumSize = new System.Drawing.Size(100, 30);
            this.label2.MinimumSize = new System.Drawing.Size(85, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "QTY Returned";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tb_Quantity
            // 
            this.tb_Quantity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.tb_Quantity.Location = new System.Drawing.Point(124, 118);
            this.tb_Quantity.Name = "tb_Quantity";
            this.tb_Quantity.Size = new System.Drawing.Size(122, 20);
            this.tb_Quantity.TabIndex = 4;
            // 
            // tb_Equipment
            // 
            this.tb_Equipment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.tb_Equipment.Location = new System.Drawing.Point(124, 92);
            this.tb_Equipment.Name = "tb_Equipment";
            this.tb_Equipment.Size = new System.Drawing.Size(122, 20);
            this.tb_Equipment.TabIndex = 5;
            // 
            // tb_Returned
            // 
            this.tb_Returned.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.tb_Returned.Location = new System.Drawing.Point(124, 144);
            this.tb_Returned.Name = "tb_Returned";
            this.tb_Returned.Size = new System.Drawing.Size(122, 20);
            this.tb_Returned.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 173);
            this.label3.MaximumSize = new System.Drawing.Size(100, 30);
            this.label3.MinimumSize = new System.Drawing.Size(85, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Return Now";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tb_Return_Now
            // 
            this.tb_Return_Now.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.tb_Return_Now.Location = new System.Drawing.Point(124, 170);
            this.tb_Return_Now.Name = "tb_Return_Now";
            this.tb_Return_Now.Size = new System.Drawing.Size(122, 20);
            this.tb_Return_Now.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 199);
            this.label4.MaximumSize = new System.Drawing.Size(100, 30);
            this.label4.MinimumSize = new System.Drawing.Size(85, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Damaged";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tb_Damaged
            // 
            this.tb_Damaged.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.tb_Damaged.Location = new System.Drawing.Point(124, 196);
            this.tb_Damaged.Name = "tb_Damaged";
            this.tb_Damaged.Size = new System.Drawing.Size(122, 20);
            this.tb_Damaged.TabIndex = 10;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(166)))), ((int)(((byte)(167)))));
            this.btn_Cancel.Location = new System.Drawing.Point(171, 232);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 42);
            this.btn_Cancel.TabIndex = 12;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(298, 80);
            this.panel1.TabIndex = 3;
            // 
            // btn_SubmitReturn
            // 
            this.btn_SubmitReturn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(166)))), ((int)(((byte)(167)))));
            this.btn_SubmitReturn.Location = new System.Drawing.Point(90, 232);
            this.btn_SubmitReturn.Name = "btn_SubmitReturn";
            this.btn_SubmitReturn.Size = new System.Drawing.Size(75, 42);
            this.btn_SubmitReturn.TabIndex = 11;
            this.btn_SubmitReturn.Text = "Save";
            this.btn_SubmitReturn.UseVisualStyleBackColor = false;
            this.btn_SubmitReturn.Click += new System.EventHandler(this.btn_SubmitReturn_Click);
            // 
            // frm_Equipment_Returns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(203)))), ((int)(((byte)(208)))));
            this.ClientSize = new System.Drawing.Size(298, 286);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_SubmitReturn);
            this.Controls.Add(this.tb_Damaged);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_Return_Now);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_Returned);
            this.Controls.Add(this.tb_Equipment);
            this.Controls.Add(this.tb_Quantity);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Equipment);
            this.Name = "frm_Equipment_Returns";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Equipment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tb_Quantity;
        private System.Windows.Forms.TextBox tb_Equipment;
        private System.Windows.Forms.TextBox tb_Returned;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_Return_Now;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_Damaged;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_SubmitReturn;
    }
}