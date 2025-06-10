namespace pgso
{
    partial class frm_Manage_Equipment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle61 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle64 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle65 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle62 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle63 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Manage_Equipment));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_Search_Equipmet = new System.Windows.Forms.TextBox();
            this.btn_Add_Equipment = new System.Windows.Forms.Button();
            this.dt_Equipments = new System.Windows.Forms.DataGridView();
            this.Items = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Equipment_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Equipment_Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Equipment_Price_Subsequent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Remaining_Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Total_Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.combo_Sort = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblPageInfo = new System.Windows.Forms.Label();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.btnPrevPage = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt_Equipments)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.btn_Add_Equipment);
            this.panel1.Controls.Add(this.dt_Equipments);
            this.panel1.Location = new System.Drawing.Point(12, 204);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1884, 785);
            this.panel1.TabIndex = 3;
            // 
            // txt_Search_Equipmet
            // 
            this.txt_Search_Equipmet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Search_Equipmet.Location = new System.Drawing.Point(93, 5);
            this.txt_Search_Equipmet.Name = "txt_Search_Equipmet";
            this.txt_Search_Equipmet.Size = new System.Drawing.Size(136, 26);
            this.txt_Search_Equipmet.TabIndex = 10;
            // 
            // btn_Add_Equipment
            // 
            this.btn_Add_Equipment.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btn_Add_Equipment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Add_Equipment.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Add_Equipment.Location = new System.Drawing.Point(7, 21);
            this.btn_Add_Equipment.Name = "btn_Add_Equipment";
            this.btn_Add_Equipment.Size = new System.Drawing.Size(109, 30);
            this.btn_Add_Equipment.TabIndex = 2;
            this.btn_Add_Equipment.Text = "Add Equipment";
            this.btn_Add_Equipment.UseVisualStyleBackColor = false;
            this.btn_Add_Equipment.Click += new System.EventHandler(this.btn_Add_Equipment_Click_1);
            // 
            // dt_Equipments
            // 
            this.dt_Equipments.AllowUserToAddRows = false;
            this.dt_Equipments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dt_Equipments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle61.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle61.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle61.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle61.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle61.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle61.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle61.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dt_Equipments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle61;
            this.dt_Equipments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dt_Equipments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Items,
            this.fld_Equipment_Name,
            this.fld_Equipment_Price,
            this.fld_Equipment_Price_Subsequent,
            this.fld_Remaining_Stock,
            this.fld_Total_Stock,
            this.Edit,
            this.Delete});
            dataGridViewCellStyle64.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle64.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle64.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle64.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle64.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle64.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle64.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dt_Equipments.DefaultCellStyle = dataGridViewCellStyle64;
            this.dt_Equipments.Location = new System.Drawing.Point(7, 57);
            this.dt_Equipments.Name = "dt_Equipments";
            this.dt_Equipments.ReadOnly = true;
            dataGridViewCellStyle65.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle65.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle65.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle65.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle65.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle65.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle65.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dt_Equipments.RowHeadersDefaultCellStyle = dataGridViewCellStyle65;
            this.dt_Equipments.RowHeadersVisible = false;
            this.dt_Equipments.Size = new System.Drawing.Size(1859, 660);
            this.dt_Equipments.TabIndex = 1;
            // 
            // Items
            // 
            this.Items.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle62.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle62.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Items.DefaultCellStyle = dataGridViewCellStyle62;
            this.Items.HeaderText = "Item";
            this.Items.Name = "Items";
            this.Items.ReadOnly = true;
            this.Items.Width = 50;
            // 
            // fld_Equipment_Name
            // 
            this.fld_Equipment_Name.DataPropertyName = "fld_Equipment_Name";
            dataGridViewCellStyle63.BackColor = System.Drawing.Color.White;
            this.fld_Equipment_Name.DefaultCellStyle = dataGridViewCellStyle63;
            this.fld_Equipment_Name.FillWeight = 89.7534F;
            this.fld_Equipment_Name.HeaderText = "Equipment Name";
            this.fld_Equipment_Name.Name = "fld_Equipment_Name";
            this.fld_Equipment_Name.ReadOnly = true;
            // 
            // fld_Equipment_Price
            // 
            this.fld_Equipment_Price.DataPropertyName = "fld_Equipment_Price";
            this.fld_Equipment_Price.FillWeight = 89.7534F;
            this.fld_Equipment_Price.HeaderText = "Price";
            this.fld_Equipment_Price.Name = "fld_Equipment_Price";
            this.fld_Equipment_Price.ReadOnly = true;
            // 
            // fld_Equipment_Price_Subsequent
            // 
            this.fld_Equipment_Price_Subsequent.DataPropertyName = "fld_Equipment_Price_Subsequent";
            this.fld_Equipment_Price_Subsequent.FillWeight = 89.7534F;
            this.fld_Equipment_Price_Subsequent.HeaderText = "Price Subsequent";
            this.fld_Equipment_Price_Subsequent.Name = "fld_Equipment_Price_Subsequent";
            this.fld_Equipment_Price_Subsequent.ReadOnly = true;
            // 
            // fld_Remaining_Stock
            // 
            this.fld_Remaining_Stock.DataPropertyName = "fld_Total_Stock";
            this.fld_Remaining_Stock.HeaderText = "Total Stock";
            this.fld_Remaining_Stock.Name = "fld_Remaining_Stock";
            this.fld_Remaining_Stock.ReadOnly = true;
            // 
            // fld_Total_Stock
            // 
            this.fld_Total_Stock.DataPropertyName = "fld_Remaining_Stock";
            this.fld_Total_Stock.HeaderText = "Available Stock";
            this.fld_Total_Stock.Name = "fld_Total_Stock";
            this.fld_Total_Stock.ReadOnly = true;
            // 
            // Edit
            // 
            this.Edit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Edit.FillWeight = 171.7778F;
            this.Edit.HeaderText = "Edit";
            this.Edit.Image = ((System.Drawing.Image)(resources.GetObject("Edit.Image")));
            this.Edit.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Edit.MinimumWidth = 10;
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            this.Edit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Edit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Edit.Width = 40;
            // 
            // Delete
            // 
            this.Delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Delete.FillWeight = 58.96209F;
            this.Delete.HeaderText = "Delete";
            this.Delete.Image = ((System.Drawing.Image)(resources.GetObject("Delete.Image")));
            this.Delete.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Delete.MinimumWidth = 10;
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Delete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Delete.Width = 60;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Equipment";
            // 
            // panel2
            // 
            this.panel2.Enabled = false;
            this.panel2.Location = new System.Drawing.Point(12, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(897, 165);
            this.panel2.TabIndex = 4;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.txt_Search_Equipmet);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.combo_Sort);
            this.panel5.Location = new System.Drawing.Point(122, 14);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(481, 37);
            this.panel5.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Search:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(246, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Sort by:";
            // 
            // combo_Sort
            // 
            this.combo_Sort.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_Sort.FormattingEnabled = true;
            this.combo_Sort.Location = new System.Drawing.Point(315, 3);
            this.combo_Sort.Name = "combo_Sort";
            this.combo_Sort.Size = new System.Drawing.Size(153, 28);
            this.combo_Sort.TabIndex = 0;
            this.combo_Sort.SelectedIndexChanged += new System.EventHandler(this.combo_Sort_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblPageInfo);
            this.panel3.Controls.Add(this.btnNextPage);
            this.panel3.Controls.Add(this.btnPrevPage);
            this.panel3.Location = new System.Drawing.Point(1661, 13);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(205, 38);
            this.panel3.TabIndex = 37;
            // 
            // lblPageInfo
            // 
            this.lblPageInfo.AutoSize = true;
            this.lblPageInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageInfo.Location = new System.Drawing.Point(55, 11);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(89, 20);
            this.lblPageInfo.TabIndex = 17;
            this.lblPageInfo.Text = "lblPageInfo";
            // 
            // btnNextPage
            // 
            this.btnNextPage.Location = new System.Drawing.Point(150, 8);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(46, 23);
            this.btnNextPage.TabIndex = 1;
            this.btnNextPage.Text = ">>";
            this.btnNextPage.UseVisualStyleBackColor = true;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // btnPrevPage
            // 
            this.btnPrevPage.Location = new System.Drawing.Point(3, 8);
            this.btnPrevPage.Name = "btnPrevPage";
            this.btnPrevPage.Size = new System.Drawing.Size(46, 23);
            this.btnPrevPage.TabIndex = 0;
            this.btnPrevPage.Text = "<<";
            this.btnPrevPage.UseVisualStyleBackColor = true;
            this.btnPrevPage.Click += new System.EventHandler(this.btnPrevPage_Click);
            // 
            // frm_Manage_Equipment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1061);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "frm_Manage_Equipment";
            this.Text = "frm_Manage_Equipment";
            this.Load += new System.EventHandler(this.frm_Manage_Equipment_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dt_Equipments)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_Search_Equipmet;
        private System.Windows.Forms.Button btn_Add_Equipment;
        private System.Windows.Forms.DataGridView dt_Equipments;
        private System.Windows.Forms.DataGridViewTextBoxColumn Items;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Equipment_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Equipment_Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Equipment_Price_Subsequent;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Remaining_Stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Total_Stock;
        private System.Windows.Forms.DataGridViewImageColumn Edit;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox combo_Sort;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblPageInfo;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Button btnPrevPage;
    }
}