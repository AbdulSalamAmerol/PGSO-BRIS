namespace pgso
{
    partial class frm_Add_Equipment
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
            this.txt_Equipment_Name_Add = new System.Windows.Forms.TextBox();
            this.txt_Price_Add = new System.Windows.Forms.TextBox();
            this.txt_Price_Subsequent_Add = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Submit_Add = new System.Windows.Forms.Button();
            this.btn_Cancel_Add = new System.Windows.Forms.Button();
            this.panel_Add_Equipment = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel_Add_Equipment.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_Equipment_Name_Add
            // 
            this.txt_Equipment_Name_Add.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Equipment_Name_Add.Location = new System.Drawing.Point(23, 82);
            this.txt_Equipment_Name_Add.Name = "txt_Equipment_Name_Add";
            this.txt_Equipment_Name_Add.Size = new System.Drawing.Size(249, 26);
            this.txt_Equipment_Name_Add.TabIndex = 0;
            this.txt_Equipment_Name_Add.TextChanged += new System.EventHandler(this.txt_Equipment_Name_Add_TextChanged);
            // 
            // txt_Price_Add
            // 
            this.txt_Price_Add.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Price_Add.Location = new System.Drawing.Point(23, 147);
            this.txt_Price_Add.Name = "txt_Price_Add";
            this.txt_Price_Add.Size = new System.Drawing.Size(249, 26);
            this.txt_Price_Add.TabIndex = 1;
            this.txt_Price_Add.TextChanged += new System.EventHandler(this.txt_Price_Add_TextChanged);
            // 
            // txt_Price_Subsequent_Add
            // 
            this.txt_Price_Subsequent_Add.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Price_Subsequent_Add.Location = new System.Drawing.Point(23, 211);
            this.txt_Price_Subsequent_Add.Name = "txt_Price_Subsequent_Add";
            this.txt_Price_Subsequent_Add.Size = new System.Drawing.Size(249, 26);
            this.txt_Price_Subsequent_Add.TabIndex = 2;
            this.txt_Price_Subsequent_Add.TextChanged += new System.EventHandler(this.txt_Price_Subsequent_Add_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Equipment Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Equipment Price";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(216, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Equipment Price Subsequent";
            // 
            // btn_Submit_Add
            // 
            this.btn_Submit_Add.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_Submit_Add.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Submit_Add.Location = new System.Drawing.Point(197, 259);
            this.btn_Submit_Add.Name = "btn_Submit_Add";
            this.btn_Submit_Add.Size = new System.Drawing.Size(75, 31);
            this.btn_Submit_Add.TabIndex = 6;
            this.btn_Submit_Add.Text = "Submit";
            this.btn_Submit_Add.UseVisualStyleBackColor = true;
            this.btn_Submit_Add.Click += new System.EventHandler(this.btn_Submit_Add_Click);
            // 
            // btn_Cancel_Add
            // 
            this.btn_Cancel_Add.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_Cancel_Add.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancel_Add.Location = new System.Drawing.Point(116, 259);
            this.btn_Cancel_Add.Name = "btn_Cancel_Add";
            this.btn_Cancel_Add.Size = new System.Drawing.Size(75, 31);
            this.btn_Cancel_Add.TabIndex = 7;
            this.btn_Cancel_Add.Text = "Cancel";
            this.btn_Cancel_Add.UseVisualStyleBackColor = true;
            this.btn_Cancel_Add.Click += new System.EventHandler(this.btn_Cancel_Add_Click);
            // 
            // panel_Add_Equipment
            // 
            this.panel_Add_Equipment.Controls.Add(this.label4);
            this.panel_Add_Equipment.Controls.Add(this.txt_Price_Subsequent_Add);
            this.panel_Add_Equipment.Controls.Add(this.btn_Cancel_Add);
            this.panel_Add_Equipment.Controls.Add(this.txt_Equipment_Name_Add);
            this.panel_Add_Equipment.Controls.Add(this.btn_Submit_Add);
            this.panel_Add_Equipment.Controls.Add(this.txt_Price_Add);
            this.panel_Add_Equipment.Controls.Add(this.label3);
            this.panel_Add_Equipment.Controls.Add(this.label1);
            this.panel_Add_Equipment.Controls.Add(this.label2);
            this.panel_Add_Equipment.Location = new System.Drawing.Point(3, 5);
            this.panel_Add_Equipment.Name = "panel_Add_Equipment";
            this.panel_Add_Equipment.Size = new System.Drawing.Size(293, 300);
            this.panel_Add_Equipment.TabIndex = 8;
            this.panel_Add_Equipment.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Add_Equipment_Paint);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(39, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(221, 33);
            this.label4.TabIndex = 8;
            this.label4.Text = "Add Equipment";
            // 
            // frm_Add_Equipment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 344);
            this.Controls.Add(this.panel_Add_Equipment);
            this.Name = "frm_Add_Equipment";
            this.Text = "Manage Equipment Form";
            this.Load += new System.EventHandler(this.frm_Add_Equipment_Load);
            this.panel_Add_Equipment.ResumeLayout(false);
            this.panel_Add_Equipment.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Equipment_Name_Add;
        private System.Windows.Forms.TextBox txt_Price_Add;
        private System.Windows.Forms.TextBox txt_Price_Subsequent_Add;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Submit_Add;
        private System.Windows.Forms.Button btn_Cancel_Add;
        private System.Windows.Forms.Panel panel_Add_Equipment;
        private System.Windows.Forms.Label label4;
    }
}