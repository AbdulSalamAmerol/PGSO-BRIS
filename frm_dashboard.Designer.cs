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
            this.panel_Display = new System.Windows.Forms.Panel();
            this.billingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.MediumAquamarine;
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calendarToolStripMenuItem,
            this.createReservationToolStripMenuItem,
            this.viewReservationToolStripMenuItem,
            this.manageFacilitiesToolStripMenuItem,
            this.billingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1386, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // calendarToolStripMenuItem
            // 
            this.calendarToolStripMenuItem.Name = "calendarToolStripMenuItem";
            this.calendarToolStripMenuItem.Size = new System.Drawing.Size(69, 25);
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
            this.createReservationToolStripMenuItem.Size = new System.Drawing.Size(139, 25);
            this.createReservationToolStripMenuItem.Text = "Create Reservation";
            this.createReservationToolStripMenuItem.Click += new System.EventHandler(this.createReservationToolStripMenuItem_Click);
            // 
            // venueToolStripMenuItem
            // 
            this.venueToolStripMenuItem.Name = "venueToolStripMenuItem";
            this.venueToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.venueToolStripMenuItem.Text = "Venues";
            this.venueToolStripMenuItem.Click += new System.EventHandler(this.venueToolStripMenuItem_Click);
            // 
            // equipmentToolStripMenuItem
            // 
            this.equipmentToolStripMenuItem.Name = "equipmentToolStripMenuItem";
            this.equipmentToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.equipmentToolStripMenuItem.Text = "Equipments";
            this.equipmentToolStripMenuItem.Click += new System.EventHandler(this.equipmentToolStripMenuItem_Click);
            // 
            // viewReservationToolStripMenuItem
            // 
            this.viewReservationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.venueToolStripMenuItem1,
            this.equipmentToolStripMenuItem1});
            this.viewReservationToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("viewReservationToolStripMenuItem.Image")));
            this.viewReservationToolStripMenuItem.Name = "viewReservationToolStripMenuItem";
            this.viewReservationToolStripMenuItem.Size = new System.Drawing.Size(149, 25);
            this.viewReservationToolStripMenuItem.Text = "Manage Reservation";
            this.viewReservationToolStripMenuItem.Click += new System.EventHandler(this.viewReservationToolStripMenuItem_Click);
            // 
            // venueToolStripMenuItem1
            // 
            this.venueToolStripMenuItem1.Name = "venueToolStripMenuItem1";
            this.venueToolStripMenuItem1.Size = new System.Drawing.Size(140, 22);
            this.venueToolStripMenuItem1.Text = "Venues";
            this.venueToolStripMenuItem1.Click += new System.EventHandler(this.venueToolStripMenuItem1_Click);
            // 
            // equipmentToolStripMenuItem1
            // 
            this.equipmentToolStripMenuItem1.Name = "equipmentToolStripMenuItem1";
            this.equipmentToolStripMenuItem1.Size = new System.Drawing.Size(140, 22);
            this.equipmentToolStripMenuItem1.Text = "Equipments";
            this.equipmentToolStripMenuItem1.Click += new System.EventHandler(this.equipmentToolStripMenuItem1_Click);
            // 
            // manageFacilitiesToolStripMenuItem
            // 
            this.manageFacilitiesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("manageFacilitiesToolStripMenuItem.Image")));
            this.manageFacilitiesToolStripMenuItem.Name = "manageFacilitiesToolStripMenuItem";
            this.manageFacilitiesToolStripMenuItem.Size = new System.Drawing.Size(110, 25);
            this.manageFacilitiesToolStripMenuItem.Text = "Lookup Table";
            this.manageFacilitiesToolStripMenuItem.Click += new System.EventHandler(this.manageFacilitiesToolStripMenuItem_Click);
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
            // billingToolStripMenuItem
            // 
            this.billingToolStripMenuItem.Name = "billingToolStripMenuItem";
            this.billingToolStripMenuItem.Size = new System.Drawing.Size(53, 25);
            this.billingToolStripMenuItem.Text = "Billing";
            this.billingToolStripMenuItem.Click += new System.EventHandler(this.billingToolStripMenuItem_Click);
            // 
            // frm_Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1386, 720);
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
    }
}
