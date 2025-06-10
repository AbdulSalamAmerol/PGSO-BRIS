namespace pgso
{
    partial class frm_Client_Info
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Client_Info));
            this.panel_dgv = new System.Windows.Forms.Panel();
            this.dgv_Client = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label26 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.txt_Surname_Edit = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txt_Contact_Edit = new System.Windows.Forms.TextBox();
            this.txt_MiddleName_Edit = new System.Windows.Forms.TextBox();
            this.btn_Update = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_Office_Edit = new System.Windows.Forms.TextBox();
            this.txt_Fname_Edit = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_Address_Edit = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblPageInfo = new System.Windows.Forms.Label();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.btnPrevPage = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txt_Search = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.combo_Filter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.combo_Sort = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbl_paging = new System.Windows.Forms.Label();
            this.btn_Next = new System.Windows.Forms.Button();
            this.btn_Prev = new System.Windows.Forms.Button();
            this.dgv_Additional_Info = new System.Windows.Forms.DataGridView();
            this.lbl_Total = new System.Windows.Forms.Label();
            this.lbl_Confirmed = new System.Windows.Forms.Label();
            this.lbl_Cancelled = new System.Windows.Forms.Label();
            this.lbl_Pending = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pk_Requesting_PersonID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_First_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Middle_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Surname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Office = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Contact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fld_Province = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_Delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.ContolNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Event = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel_dgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Client)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Additional_Info)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_dgv
            // 
            this.panel_dgv.Controls.Add(this.dgv_Client);
            this.panel_dgv.Location = new System.Drawing.Point(12, 88);
            this.panel_dgv.Name = "panel_dgv";
            this.panel_dgv.Size = new System.Drawing.Size(1476, 897);
            this.panel_dgv.TabIndex = 1;
            // 
            // dgv_Client
            // 
            this.dgv_Client.AllowUserToAddRows = false;
            this.dgv_Client.AllowUserToResizeColumns = false;
            this.dgv_Client.AllowUserToResizeRows = false;
            this.dgv_Client.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Client.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Client.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Client.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pk_Requesting_PersonID,
            this.fld_First_name,
            this.fld_Middle_Name,
            this.fld_Surname,
            this.Office,
            this.Contact,
            this.Address,
            this.fld_Province,
            this.dgv_Delete});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Client.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_Client.Location = new System.Drawing.Point(20, 13);
            this.dgv_Client.Name = "dgv_Client";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Client.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgv_Client.RowHeadersVisible = false;
            this.dgv_Client.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_Client.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgv_Client.Size = new System.Drawing.Size(1444, 807);
            this.dgv_Client.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.label26);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.btn_Clear);
            this.panel1.Controls.Add(this.txt_Surname_Edit);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.txt_Contact_Edit);
            this.panel1.Controls.Add(this.txt_MiddleName_Edit);
            this.panel1.Controls.Add(this.btn_Update);
            this.panel1.Controls.Add(this.label23);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.txt_Office_Edit);
            this.panel1.Controls.Add(this.txt_Fname_Edit);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txt_Address_Edit);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Location = new System.Drawing.Point(1535, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(377, 261);
            this.panel1.TabIndex = 2;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Red;
            this.label26.Location = new System.Drawing.Point(138, 4);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(157, 15);
            this.label26.TabIndex = 33;
            this.label26.Text = "Double click the cell to edit*";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(15, 4);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(117, 18);
            this.label14.TabIndex = 32;
            this.label14.Text = "EDIT DETAILS";
            // 
            // btn_Clear
            // 
            this.btn_Clear.BackColor = System.Drawing.Color.MistyRose;
            this.btn_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Clear.Location = new System.Drawing.Point(176, 217);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(75, 32);
            this.btn_Clear.TabIndex = 30;
            this.btn_Clear.Text = "Clear";
            this.btn_Clear.UseVisualStyleBackColor = false;
            this.btn_Clear.Visible = false;
            // 
            // txt_Surname_Edit
            // 
            this.txt_Surname_Edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Surname_Edit.Location = new System.Drawing.Point(115, 89);
            this.txt_Surname_Edit.Name = "txt_Surname_Edit";
            this.txt_Surname_Edit.Size = new System.Drawing.Size(217, 26);
            this.txt_Surname_Edit.TabIndex = 26;
            this.txt_Surname_Edit.TextChanged += new System.EventHandler(this.txt_Surname_Edit_TextChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(9, 97);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(78, 20);
            this.label22.TabIndex = 25;
            this.label22.Text = "Surname:";
            // 
            // txt_Contact_Edit
            // 
            this.txt_Contact_Edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Contact_Edit.Location = new System.Drawing.Point(115, 121);
            this.txt_Contact_Edit.Name = "txt_Contact_Edit";
            this.txt_Contact_Edit.ReadOnly = true;
            this.txt_Contact_Edit.Size = new System.Drawing.Size(217, 26);
            this.txt_Contact_Edit.TabIndex = 24;
            this.txt_Contact_Edit.TextChanged += new System.EventHandler(this.txt_Contact_Edit_TextChanged);
            // 
            // txt_MiddleName_Edit
            // 
            this.txt_MiddleName_Edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_MiddleName_Edit.Location = new System.Drawing.Point(115, 57);
            this.txt_MiddleName_Edit.Name = "txt_MiddleName_Edit";
            this.txt_MiddleName_Edit.Size = new System.Drawing.Size(217, 26);
            this.txt_MiddleName_Edit.TabIndex = 24;
            this.txt_MiddleName_Edit.TextChanged += new System.EventHandler(this.txt_MiddleName_Edit_TextChanged);
            // 
            // btn_Update
            // 
            this.btn_Update.BackColor = System.Drawing.Color.PaleGreen;
            this.btn_Update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Update.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Update.Location = new System.Drawing.Point(257, 217);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(75, 32);
            this.btn_Update.TabIndex = 29;
            this.btn_Update.Text = "Update";
            this.btn_Update.UseVisualStyleBackColor = false;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(4, 63);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(105, 20);
            this.label23.TabIndex = 23;
            this.label23.Text = "Middle Name:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(6, 33);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(90, 20);
            this.label13.TabIndex = 17;
            this.label13.Text = "First Name:";
            // 
            // txt_Office_Edit
            // 
            this.txt_Office_Edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Office_Edit.Location = new System.Drawing.Point(115, 153);
            this.txt_Office_Edit.Name = "txt_Office_Edit";
            this.txt_Office_Edit.ReadOnly = true;
            this.txt_Office_Edit.Size = new System.Drawing.Size(217, 26);
            this.txt_Office_Edit.TabIndex = 28;
            this.txt_Office_Edit.TextChanged += new System.EventHandler(this.txt_Office_Edit_TextChanged);
            // 
            // txt_Fname_Edit
            // 
            this.txt_Fname_Edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Fname_Edit.Location = new System.Drawing.Point(115, 25);
            this.txt_Fname_Edit.Name = "txt_Fname_Edit";
            this.txt_Fname_Edit.ReadOnly = true;
            this.txt_Fname_Edit.Size = new System.Drawing.Size(217, 26);
            this.txt_Fname_Edit.TabIndex = 18;
            this.txt_Fname_Edit.TextChanged += new System.EventHandler(this.txt_Fname_Edit_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(9, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 20);
            this.label7.TabIndex = 27;
            this.label7.Text = "Office:";
            // 
            // txt_Address_Edit
            // 
            this.txt_Address_Edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Address_Edit.Location = new System.Drawing.Point(115, 185);
            this.txt_Address_Edit.Name = "txt_Address_Edit";
            this.txt_Address_Edit.ReadOnly = true;
            this.txt_Address_Edit.Size = new System.Drawing.Size(217, 26);
            this.txt_Address_Edit.TabIndex = 26;
            this.txt_Address_Edit.TextChanged += new System.EventHandler(this.txt_Address_Edit_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(14, 191);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 20);
            this.label9.TabIndex = 25;
            this.label9.Text = "Purok:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(9, 127);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 20);
            this.label10.TabIndex = 23;
            this.label10.Text = "Contact:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblPageInfo);
            this.panel3.Controls.Add(this.btnNextPage);
            this.panel3.Controls.Add(this.btnPrevPage);
            this.panel3.Location = new System.Drawing.Point(1306, 45);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(193, 38);
            this.panel3.TabIndex = 32;
            // 
            // lblPageInfo
            // 
            this.lblPageInfo.AutoSize = true;
            this.lblPageInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageInfo.Location = new System.Drawing.Point(55, 11);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(75, 16);
            this.lblPageInfo.TabIndex = 17;
            this.lblPageInfo.Text = "lblPageInfo";
            this.lblPageInfo.Click += new System.EventHandler(this.lblPageInfo_Click);
            // 
            // btnNextPage
            // 
            this.btnNextPage.Location = new System.Drawing.Point(136, 8);
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
            // panel5
            // 
            this.panel5.Controls.Add(this.txt_Search);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.combo_Filter);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.combo_Sort);
            this.panel5.Location = new System.Drawing.Point(743, 46);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(493, 37);
            this.panel5.TabIndex = 34;
            // 
            // txt_Search
            // 
            this.txt_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Search.Location = new System.Drawing.Point(12, 7);
            this.txt_Search.Name = "txt_Search";
            this.txt_Search.Size = new System.Drawing.Size(173, 26);
            this.txt_Search.TabIndex = 35;
            this.txt_Search.TextChanged += new System.EventHandler(this.txt_Search_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(296, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Filter:";
            // 
            // combo_Filter
            // 
            this.combo_Filter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_Filter.FormattingEnabled = true;
            this.combo_Filter.Location = new System.Drawing.Point(350, 5);
            this.combo_Filter.Name = "combo_Filter";
            this.combo_Filter.Size = new System.Drawing.Size(121, 28);
            this.combo_Filter.TabIndex = 2;
            this.combo_Filter.SelectedIndexChanged += new System.EventHandler(this.combo_Filter_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(516, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Sort by:";
            this.label2.Visible = false;
            // 
            // combo_Sort
            // 
            this.combo_Sort.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combo_Sort.FormattingEnabled = true;
            this.combo_Sort.Location = new System.Drawing.Point(591, 5);
            this.combo_Sort.Name = "combo_Sort";
            this.combo_Sort.Size = new System.Drawing.Size(121, 28);
            this.combo_Sort.TabIndex = 0;
            this.combo_Sort.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.dgv_Additional_Info);
            this.panel2.Controls.Add(this.lbl_Total);
            this.panel2.Controls.Add(this.lbl_Confirmed);
            this.panel2.Controls.Add(this.lbl_Cancelled);
            this.panel2.Controls.Add(this.lbl_Pending);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(1494, 331);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(418, 577);
            this.panel2.TabIndex = 35;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lbl_paging);
            this.panel4.Controls.Add(this.btn_Next);
            this.panel4.Controls.Add(this.btn_Prev);
            this.panel4.Location = new System.Drawing.Point(222, 121);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(193, 38);
            this.panel4.TabIndex = 33;
            // 
            // lbl_paging
            // 
            this.lbl_paging.AutoSize = true;
            this.lbl_paging.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_paging.Location = new System.Drawing.Point(55, 11);
            this.lbl_paging.Name = "lbl_paging";
            this.lbl_paging.Size = new System.Drawing.Size(44, 16);
            this.lbl_paging.TabIndex = 17;
            this.lbl_paging.Text = "label8";
            this.lbl_paging.Click += new System.EventHandler(this.lbl_paging_Click);
            // 
            // btn_Next
            // 
            this.btn_Next.Location = new System.Drawing.Point(136, 8);
            this.btn_Next.Name = "btn_Next";
            this.btn_Next.Size = new System.Drawing.Size(46, 23);
            this.btn_Next.TabIndex = 1;
            this.btn_Next.Text = ">>";
            this.btn_Next.UseVisualStyleBackColor = true;
            this.btn_Next.Click += new System.EventHandler(this.btn_Next_Click);
            // 
            // btn_Prev
            // 
            this.btn_Prev.Location = new System.Drawing.Point(3, 8);
            this.btn_Prev.Name = "btn_Prev";
            this.btn_Prev.Size = new System.Drawing.Size(46, 23);
            this.btn_Prev.TabIndex = 0;
            this.btn_Prev.Text = "<<";
            this.btn_Prev.UseVisualStyleBackColor = true;
            this.btn_Prev.Click += new System.EventHandler(this.btn_Prev_Click);
            // 
            // dgv_Additional_Info
            // 
            this.dgv_Additional_Info.AllowUserToAddRows = false;
            this.dgv_Additional_Info.AllowUserToDeleteRows = false;
            this.dgv_Additional_Info.AllowUserToResizeColumns = false;
            this.dgv_Additional_Info.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Additional_Info.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgv_Additional_Info.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Additional_Info.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ContolNumber,
            this.Date,
            this.Type,
            this.Event});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Additional_Info.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgv_Additional_Info.Location = new System.Drawing.Point(10, 165);
            this.dgv_Additional_Info.Name = "dgv_Additional_Info";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Additional_Info.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgv_Additional_Info.RowHeadersVisible = false;
            this.dgv_Additional_Info.Size = new System.Drawing.Size(405, 397);
            this.dgv_Additional_Info.TabIndex = 42;
            // 
            // lbl_Total
            // 
            this.lbl_Total.AutoSize = true;
            this.lbl_Total.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Total.Location = new System.Drawing.Point(323, 55);
            this.lbl_Total.Name = "lbl_Total";
            this.lbl_Total.Size = new System.Drawing.Size(29, 20);
            this.lbl_Total.TabIndex = 41;
            this.lbl_Total.Text = "00";
            // 
            // lbl_Confirmed
            // 
            this.lbl_Confirmed.AutoSize = true;
            this.lbl_Confirmed.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Confirmed.Location = new System.Drawing.Point(228, 55);
            this.lbl_Confirmed.Name = "lbl_Confirmed";
            this.lbl_Confirmed.Size = new System.Drawing.Size(29, 20);
            this.lbl_Confirmed.TabIndex = 40;
            this.lbl_Confirmed.Text = "00";
            // 
            // lbl_Cancelled
            // 
            this.lbl_Cancelled.AutoSize = true;
            this.lbl_Cancelled.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Cancelled.Location = new System.Drawing.Point(144, 55);
            this.lbl_Cancelled.Name = "lbl_Cancelled";
            this.lbl_Cancelled.Size = new System.Drawing.Size(29, 20);
            this.lbl_Cancelled.TabIndex = 39;
            this.lbl_Cancelled.Text = "00";
            // 
            // lbl_Pending
            // 
            this.lbl_Pending.AutoSize = true;
            this.lbl_Pending.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Pending.Location = new System.Drawing.Point(67, 55);
            this.lbl_Pending.Name = "lbl_Pending";
            this.lbl_Pending.Size = new System.Drawing.Size(29, 20);
            this.lbl_Pending.TabIndex = 38;
            this.lbl_Pending.Text = "00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(317, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 20);
            this.label6.TabIndex = 37;
            this.label6.Text = "Total";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(205, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 20);
            this.label5.TabIndex = 36;
            this.label5.Text = "Confirmed";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(120, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 20);
            this.label4.TabIndex = 35;
            this.label4.Text = "Cancelled";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.TabIndex = 34;
            this.label1.Text = "Pending";
            // 
            // pk_Requesting_PersonID
            // 
            this.pk_Requesting_PersonID.DataPropertyName = "pk_Requesting_PersonID";
            this.pk_Requesting_PersonID.HeaderText = "ID";
            this.pk_Requesting_PersonID.Name = "pk_Requesting_PersonID";
            this.pk_Requesting_PersonID.Visible = false;
            // 
            // fld_First_name
            // 
            this.fld_First_name.DataPropertyName = "fld_First_name";
            this.fld_First_name.HeaderText = "First Name";
            this.fld_First_name.Name = "fld_First_name";
            // 
            // fld_Middle_Name
            // 
            this.fld_Middle_Name.DataPropertyName = "fld_Middle_Name";
            this.fld_Middle_Name.HeaderText = "Middle Name";
            this.fld_Middle_Name.Name = "fld_Middle_Name";
            // 
            // fld_Surname
            // 
            this.fld_Surname.DataPropertyName = "fld_Surname";
            this.fld_Surname.HeaderText = "Surname";
            this.fld_Surname.Name = "fld_Surname";
            // 
            // Office
            // 
            this.Office.DataPropertyName = "Office";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Office.DefaultCellStyle = dataGridViewCellStyle2;
            this.Office.HeaderText = "Office";
            this.Office.Name = "Office";
            // 
            // Contact
            // 
            this.Contact.DataPropertyName = "Contact";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Contact.DefaultCellStyle = dataGridViewCellStyle3;
            this.Contact.HeaderText = "Contact";
            this.Contact.Name = "Contact";
            // 
            // Address
            // 
            this.Address.DataPropertyName = "Address";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Address.DefaultCellStyle = dataGridViewCellStyle4;
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
            // 
            // fld_Province
            // 
            this.fld_Province.DataPropertyName = "Origin";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fld_Province.DefaultCellStyle = dataGridViewCellStyle5;
            this.fld_Province.HeaderText = "Origin";
            this.fld_Province.Name = "fld_Province";
            // 
            // dgv_Delete
            // 
            this.dgv_Delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dgv_Delete.HeaderText = "Delete";
            this.dgv_Delete.Image = ((System.Drawing.Image)(resources.GetObject("dgv_Delete.Image")));
            this.dgv_Delete.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dgv_Delete.Name = "dgv_Delete";
            this.dgv_Delete.ReadOnly = true;
            this.dgv_Delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Delete.Visible = false;
            this.dgv_Delete.Width = 65;
            // 
            // ContolNumber
            // 
            this.ContolNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ContolNumber.DataPropertyName = "Control Number";
            this.ContolNumber.HeaderText = "CN";
            this.ContolNumber.Name = "ContolNumber";
            this.ContolNumber.Width = 120;
            // 
            // Date
            // 
            this.Date.DataPropertyName = "Request Date";
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            // 
            // Type
            // 
            this.Type.DataPropertyName = "Reservation Type";
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            // 
            // Event
            // 
            this.Event.DataPropertyName = "Status";
            this.Event.HeaderText = "Status";
            this.Event.Name = "Event";
            // 
            // frm_Client_Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1061);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_dgv);
            this.Name = "frm_Client_Info";
            this.Text = "frm_Client_Info";
            this.panel_dgv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Client)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Additional_Info)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel_dgv;
        private System.Windows.Forms.DataGridView dgv_Client;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.TextBox txt_Contact_Edit;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_Office_Edit;
        private System.Windows.Forms.TextBox txt_Fname_Edit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_Address_Edit;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Button btnPrevPage;
        private System.Windows.Forms.Label lblPageInfo;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox combo_Filter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox combo_Sort;
        private System.Windows.Forms.TextBox txt_Surname_Edit;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txt_MiddleName_Edit;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txt_Search;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_Total;
        private System.Windows.Forms.Label lbl_Confirmed;
        private System.Windows.Forms.Label lbl_Cancelled;
        private System.Windows.Forms.Label lbl_Pending;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_Additional_Info;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbl_paging;
        private System.Windows.Forms.Button btn_Next;
        private System.Windows.Forms.Button btn_Prev;
        private System.Windows.Forms.DataGridViewTextBoxColumn pk_Requesting_PersonID;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_First_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Middle_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Surname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Office;
        private System.Windows.Forms.DataGridViewTextBoxColumn Contact;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn fld_Province;
        private System.Windows.Forms.DataGridViewImageColumn dgv_Delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContolNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Event;
    }
}