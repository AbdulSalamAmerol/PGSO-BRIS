using pgso.Billing.Models;
using pgso.Billing.Repositories;
using System;
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
    public partial class frm_Edit_Reservation_Info : Form
    {

        private Model_Billing billingInfo;
        private int _reservationID;
        private Repo_Billing _repo = new Repo_Billing();

        public frm_Edit_Reservation_Info(Model_Billing billing)
        {
            InitializeComponent();
            billingInfo = billing;
            LoadReservationDetails();
            LoadVenueDropdown();
        }

        private void LoadReservationDetails()
        {
            LoadVenueDropdown();
        }

        private void LoadVenueDropdown()
        {
            var equipmentList = _repo.GetAllEquipments(); // Get a list of { pk_EquipmentID, fld_Equipment_Name }
            //cmb_Equipment.DisplayMember = "fld_Equipment_Name";
            //cmb_Equipment.ValueMember = "pk_EquipmentID";
            //cmb_Equipment.DataSource = equipmentList;
        }

    }
}
