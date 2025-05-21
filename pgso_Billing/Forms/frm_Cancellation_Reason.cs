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
    public partial class frm_Cancellation_Reason : Form
    {
        private readonly int _reservationId;
        private Model_Billing _billingDetail; // changed to a single object
        private readonly Repo_Billing _repoBilling = new Repo_Billing();
        public event Action<int, string> OnRequestVenueExtension;// Check if extension is applicable

        public event Action<int?> RequestBillingRefresh;
        public frm_Cancellation_Reason(int reservationID)
        {
            InitializeComponent();
            _reservationId = reservationID;

            // You can load billing record here or elsewhere
            var billingRecords = _repoBilling.GetBillingRecordsByReservationId(_reservationId);
            _billingDetail = billingRecords?.FirstOrDefault();
        }

        private async void btn_Save_Click(object sender, EventArgs e)
        {
            if (_billingDetail == null)
            {
                MessageBox.Show("Billing record not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string currentStatus = _billingDetail.fld_Reservation_Status;
            string cancellationReason = rtb_Cancellation_Reason.Text.Trim();

            if (string.IsNullOrWhiteSpace(cancellationReason))
            {
                MessageBox.Show("Please provide a reason for cancellation.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (currentStatus != "Pending" && currentStatus != "Confirmed")
            {
                MessageBox.Show("Only 'Pending' or 'Confirmed' reservations can be cancelled.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_billingDetail.fld_OT_Hours > 0)
            {
                MessageBox.Show("This reservation has overtime hours. Cancellation is not allowed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to cancel this reservation?",
                                "Confirm Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                bool success = await _repoBilling.UpdateReservationStatusAsync(_reservationId, "Cancelled");



                if (success)
                {
                    // Save the cancellation reason to the database
                    bool saved = _repoBilling.SaveCancellationReason(_reservationId, cancellationReason);

                    if (!saved)
                    {
                        MessageBox.Show("Failed to save cancellation reason.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    bool deductionSuccess = await Task.Run(() => _repoBilling.ApplyCancellationDeduction(_reservationId));

                    if (deductionSuccess)
                    {
                        MessageBox.Show("Reservation cancelled and deduction applied.");
                        RequestBillingRefresh?.Invoke(_billingDetail.pk_ReservationID); // 🔁 Notify parent to refresh billing
                        this.Close();
                    }

                    else
                    {
                        MessageBox.Show("Cancellation applied, but deduction failed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        RequestBillingRefresh?.Invoke(_billingDetail.pk_ReservationID); // 🔁 Notify parent to refresh billing
                        this.Close();
                    }

                }



            }

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
