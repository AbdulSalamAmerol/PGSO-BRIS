using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace pgso
{
    partial class frm_Dashboard
    {
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Dashboard));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.calendarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createReservationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.venueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.equipmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewReservationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.venueToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.equipmentToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.manageFacilitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.venueToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.equipmentToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.clientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.billingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.auditLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_Display = new System.Windows.Forms.Panel();
            this.btn_logout = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.MediumAquamarine;
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calendarToolStripMenuItem,
            this.createReservationToolStripMenuItem,
            this.viewReservationToolStripMenuItem,
            this.manageFacilitiesToolStripMenuItem,
            this.billingToolStripMenuItem,
            this.auditLogsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1386, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // calendarToolStripMenuItem
            // 
            this.calendarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("calendarToolStripMenuItem.Image")));
            this.calendarToolStripMenuItem.Name = "calendarToolStripMenuItem";
            this.calendarToolStripMenuItem.Size = new System.Drawing.Size(101, 25);
            this.calendarToolStripMenuItem.Text = "Calendar";
            this.calendarToolStripMenuItem.Click += new System.EventHandler(this.calendarToolStripMenuItem_Click);
            // 
            // createReservationToolStripMenuItem
            // 
            this.createReservationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.venueToolStripMenuItem,
            this.equipmentToolStripMenuItem});
            this.createReservationToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("createReservationToolStripMenuItem.Image")));
            this.createReservationToolStripMenuItem.Name = "createReservationToolStripMenuItem";
            this.createReservationToolStripMenuItem.Size = new System.Drawing.Size(174, 25);
            this.createReservationToolStripMenuItem.Text = "Create Reservation";
            this.createReservationToolStripMenuItem.Click += new System.EventHandler(this.createReservationToolStripMenuItem_Click);
            // 
            // venueToolStripMenuItem
            // 
            this.venueToolStripMenuItem.Name = "venueToolStripMenuItem";
            this.venueToolStripMenuItem.Size = new System.Drawing.Size(155, 24);
            this.venueToolStripMenuItem.Text = "Venue";
            this.venueToolStripMenuItem.Click += new System.EventHandler(this.venueToolStripMenuItem_Click);
            // 
            // equipmentToolStripMenuItem
            // 
            this.equipmentToolStripMenuItem.Name = "equipmentToolStripMenuItem";
            this.equipmentToolStripMenuItem.Size = new System.Drawing.Size(155, 24);
            this.equipmentToolStripMenuItem.Text = "Equipment";
            this.equipmentToolStripMenuItem.Click += new System.EventHandler(this.equipmentToolStripMenuItem_Click);
            // 
            // viewReservationToolStripMenuItem
            // 
            this.viewReservationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.venueToolStripMenuItem1,
            this.equipmentToolStripMenuItem1});
            this.viewReservationToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("viewReservationToolStripMenuItem.Image")));
            this.viewReservationToolStripMenuItem.Name = "viewReservationToolStripMenuItem";
            this.viewReservationToolStripMenuItem.Size = new System.Drawing.Size(160, 25);
            this.viewReservationToolStripMenuItem.Text = "View Reservation";
            this.viewReservationToolStripMenuItem.Click += new System.EventHandler(this.viewReservationToolStripMenuItem_Click);
            // 
            // venueToolStripMenuItem1
            // 
            this.venueToolStripMenuItem1.Name = "venueToolStripMenuItem1";
            this.venueToolStripMenuItem1.Size = new System.Drawing.Size(155, 24);
            this.venueToolStripMenuItem1.Text = "Venue";
            this.venueToolStripMenuItem1.Click += new System.EventHandler(this.venueToolStripMenuItem1_Click);
            // 
            // equipmentToolStripMenuItem1
            // 
            this.equipmentToolStripMenuItem1.Name = "equipmentToolStripMenuItem1";
            this.equipmentToolStripMenuItem1.Size = new System.Drawing.Size(155, 24);
            this.equipmentToolStripMenuItem1.Text = "Equipment";
            this.equipmentToolStripMenuItem1.Click += new System.EventHandler(this.equipmentToolStripMenuItem1_Click);
            // 
            // manageFacilitiesToolStripMenuItem
            // 
            this.manageFacilitiesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.venueToolStripMenuItem2,
            this.equipmentToolStripMenuItem2,
            this.clientToolStripMenuItem});
            this.manageFacilitiesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("manageFacilitiesToolStripMenuItem.Image")));
            this.manageFacilitiesToolStripMenuItem.Name = "manageFacilitiesToolStripMenuItem";
            this.manageFacilitiesToolStripMenuItem.Size = new System.Drawing.Size(133, 25);
            this.manageFacilitiesToolStripMenuItem.Text = "Lookup Table";
            this.manageFacilitiesToolStripMenuItem.Click += new System.EventHandler(this.manageFacilitiesToolStripMenuItem_Click);
            // 
            // venueToolStripMenuItem2
            // 
            this.venueToolStripMenuItem2.Name = "venueToolStripMenuItem2";
            this.venueToolStripMenuItem2.Size = new System.Drawing.Size(180, 24);
            this.venueToolStripMenuItem2.Text = "Venue";
            this.venueToolStripMenuItem2.Click += new System.EventHandler(this.venueToolStripMenuItem2_Click);
            // 
            // equipmentToolStripMenuItem2
            // 
            this.equipmentToolStripMenuItem2.Name = "equipmentToolStripMenuItem2";
            this.equipmentToolStripMenuItem2.Size = new System.Drawing.Size(180, 24);
            this.equipmentToolStripMenuItem2.Text = "Equipment";
            this.equipmentToolStripMenuItem2.Click += new System.EventHandler(this.equipmentToolStripMenuItem2_Click);
            // 
            // clientToolStripMenuItem
            // 
            this.clientToolStripMenuItem.Name = "clientToolStripMenuItem";
            this.clientToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.clientToolStripMenuItem.Text = "Client";
            this.clientToolStripMenuItem.Click += new System.EventHandler(this.clientToolStripMenuItem_Click);
            // 
            // billingToolStripMenuItem
            // 
            this.billingToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("billingToolStripMenuItem.Image")));
            this.billingToolStripMenuItem.Name = "billingToolStripMenuItem";
            this.billingToolStripMenuItem.Size = new System.Drawing.Size(78, 25);
            this.billingToolStripMenuItem.Text = "Billing";
            this.billingToolStripMenuItem.Click += new System.EventHandler(this.billingToolStripMenuItem_Click);
            // 
            // auditLogsToolStripMenuItem
            // 
            this.auditLogsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("auditLogsToolStripMenuItem.Image")));
            this.auditLogsToolStripMenuItem.Name = "auditLogsToolStripMenuItem";
            this.auditLogsToolStripMenuItem.Size = new System.Drawing.Size(113, 25);
            this.auditLogsToolStripMenuItem.Text = "Audit Logs";
            this.auditLogsToolStripMenuItem.Click += new System.EventHandler(this.auditLogsToolStripMenuItem_Click_1);
            // 
            // panel_Display
            // 
            this.panel_Display.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Display.Location = new System.Drawing.Point(0, 29);
            this.panel_Display.Name = "panel_Display";
            this.panel_Display.Size = new System.Drawing.Size(1386, 691);
            this.panel_Display.TabIndex = 1;
            this.panel_Display.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Display_Paint);
            // 
            // btn_logout
            // 
            this.btn_logout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_logout.BackColor = System.Drawing.Color.IndianRed;
            this.btn_logout.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_logout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_logout.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_logout.Location = new System.Drawing.Point(1287, 1);
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.Size = new System.Drawing.Size(87, 26);
            this.btn_logout.TabIndex = 2;
            this.btn_logout.Text = "Logout";
            this.btn_logout.UseVisualStyleBackColor = false;
            this.btn_logout.Click += new System.EventHandler(this.btn_logout_Click);
            // 
            // frm_Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1386, 720);
            this.ControlBox = false;
            this.Controls.Add(this.btn_logout);
            this.Controls.Add(this.panel_Display);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimizeBox = false;
            this.Name = "frm_Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Venue and Equipment Reservation";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_dashboard_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem createReservationToolStripMenuItem;
        private ToolStripMenuItem venueToolStripMenuItem;
        private ToolStripMenuItem equipmentToolStripMenuItem;
        private ToolStripMenuItem viewReservationToolStripMenuItem;
        private ToolStripMenuItem venueToolStripMenuItem1;
        private ToolStripMenuItem equipmentToolStripMenuItem1;
        private ToolStripMenuItem manageFacilitiesToolStripMenuItem;
        private Panel panel_Display;
        private ToolStripMenuItem calendarToolStripMenuItem;
        private ToolStripMenuItem billingToolStripMenuItem;
        private ToolStripMenuItem venueToolStripMenuItem2;
        private ToolStripMenuItem equipmentToolStripMenuItem2;
        private ToolStripMenuItem clientToolStripMenuItem;
        private ToolStripMenuItem auditLogsToolStripMenuItem;
        private Button btn_logout;

    }
}
