﻿using System;
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
            this.approvedReservationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pendingReservationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelledReservationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageFacilitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_Display = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calendarToolStripMenuItem,
            this.createReservationToolStripMenuItem,
            this.viewReservationToolStripMenuItem,
            this.manageFacilitiesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1280, 41);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // calendarToolStripMenuItem
            // 
            this.calendarToolStripMenuItem.Name = "calendarToolStripMenuItem";
            this.calendarToolStripMenuItem.Size = new System.Drawing.Size(76, 37);
            this.calendarToolStripMenuItem.Text = "Dashboard";
            this.calendarToolStripMenuItem.Click += new System.EventHandler(this.calendarToolStripMenuItem_Click);
            // 
            // createReservationToolStripMenuItem
            // 
            this.createReservationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.venueToolStripMenuItem,
            this.equipmentToolStripMenuItem});
            this.createReservationToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("createReservationToolStripMenuItem.Image")));
            this.createReservationToolStripMenuItem.Name = "createReservationToolStripMenuItem";
            this.createReservationToolStripMenuItem.Size = new System.Drawing.Size(133, 37);
            this.createReservationToolStripMenuItem.Text = "Create Reservation";
            // 
            // venueToolStripMenuItem
            // 
            this.venueToolStripMenuItem.Name = "venueToolStripMenuItem";
            this.venueToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.venueToolStripMenuItem.Text = "Venues";
            this.venueToolStripMenuItem.Click += new System.EventHandler(this.venueToolStripMenuItem_Click);
            // 
            // equipmentToolStripMenuItem
            // 
            this.equipmentToolStripMenuItem.Name = "equipmentToolStripMenuItem";
            this.equipmentToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
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
            this.viewReservationToolStripMenuItem.Size = new System.Drawing.Size(142, 37);
            this.viewReservationToolStripMenuItem.Text = "Manage Reservation";
            // 
            // venueToolStripMenuItem1
            // 
            this.venueToolStripMenuItem1.Name = "venueToolStripMenuItem1";
            this.venueToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.venueToolStripMenuItem1.Text = "Venues";
            this.venueToolStripMenuItem1.Click += new System.EventHandler(this.venueToolStripMenuItem1_Click);
            // 
            // equipmentToolStripMenuItem1
            // 
            this.equipmentToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.approvedReservationToolStripMenuItem,
            this.pendingReservationToolStripMenuItem,
            this.cancelledReservationToolStripMenuItem});
            this.equipmentToolStripMenuItem1.Name = "equipmentToolStripMenuItem1";
            this.equipmentToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.equipmentToolStripMenuItem1.Text = "Equipments";
            this.equipmentToolStripMenuItem1.Click += new System.EventHandler(this.equipmentToolStripMenuItem1_Click);
            // 
            // approvedReservationToolStripMenuItem
            // 
            this.approvedReservationToolStripMenuItem.Name = "approvedReservationToolStripMenuItem";
            this.approvedReservationToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.approvedReservationToolStripMenuItem.Text = "Approved";
            this.approvedReservationToolStripMenuItem.Click += new System.EventHandler(this.approvedReservationToolStripMenuItem_Click);
            // 
            // pendingReservationToolStripMenuItem
            // 
            this.pendingReservationToolStripMenuItem.Name = "pendingReservationToolStripMenuItem";
            this.pendingReservationToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.pendingReservationToolStripMenuItem.Text = "Pending";
            this.pendingReservationToolStripMenuItem.Click += new System.EventHandler(this.pendingReservationToolStripMenuItem_Click);
            // 
            // cancelledReservationToolStripMenuItem
            // 
            this.cancelledReservationToolStripMenuItem.Name = "cancelledReservationToolStripMenuItem";
            this.cancelledReservationToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.cancelledReservationToolStripMenuItem.Text = "Cancelled";
            this.cancelledReservationToolStripMenuItem.Click += new System.EventHandler(this.cancelledReservationToolStripMenuItem_Click);
            // 
            // manageFacilitiesToolStripMenuItem
            // 
            this.manageFacilitiesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("manageFacilitiesToolStripMenuItem.Image")));
            this.manageFacilitiesToolStripMenuItem.Name = "manageFacilitiesToolStripMenuItem";
            this.manageFacilitiesToolStripMenuItem.Size = new System.Drawing.Size(126, 37);
            this.manageFacilitiesToolStripMenuItem.Text = "Manage Facilities";
            this.manageFacilitiesToolStripMenuItem.Click += new System.EventHandler(this.manageFacilitiesToolStripMenuItem_Click);
            // 
            // panel_Display
            // 
            this.panel_Display.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Display.Location = new System.Drawing.Point(0, 41);
            this.panel_Display.Name = "panel_Display";
            this.panel_Display.Size = new System.Drawing.Size(1280, 679);
            this.panel_Display.TabIndex = 1;
            this.panel_Display.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Display_Paint);
            // 
            // frm_Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.panel_Display);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimizeBox = false;
            this.Name = "frm_Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_dashboard_admin";
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
        private ToolStripMenuItem approvedReservationToolStripMenuItem;
        private ToolStripMenuItem pendingReservationToolStripMenuItem;
        private ToolStripMenuItem cancelledReservationToolStripMenuItem;
        private ToolStripMenuItem calendarToolStripMenuItem;
    }
}
