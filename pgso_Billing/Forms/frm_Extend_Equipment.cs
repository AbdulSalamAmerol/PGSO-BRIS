﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pgso.pgso_Billing.Forms
{
    public partial class frm_Extend_Equipment : Form
    {
        private int reservationID;

        public frm_Extend_Equipment(int reservationID)
        {
            InitializeComponent();
            this.reservationID = reservationID;

        }
    }
}
