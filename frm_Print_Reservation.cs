using pgso_connect;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pgso
{
    public partial class frm_Print_Reservation : Form
    {
        private PrintDocument printDocument;
        private string controlNumber;
        private DataTable reservationData;

        public frm_Print_Reservation()
        {
            InitializeComponent();
            printDocument = new PrintDocument();
            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
        }

        private void frm_Print_Reservation_Load(object sender, EventArgs e)
        {

        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            controlNumber = txt_Search.Text.Trim();
            if (!string.IsNullOrEmpty(controlNumber))
            {
                // Retrieve reservation data based on control number
                reservationData = GetReservationData(controlNumber);
                if (reservationData.Rows.Count > 0)
                {
                    PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog
                    {
                        Document = printDocument,
                        Width = 800,
                        Height = 600
                    };
                    printPreviewDialog.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Control number not found!", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please enter a control number!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private DataTable GetReservationData(string controlNumber)
        {
            DataTable dt = new DataTable();
            try
            {
                Connection db = new Connection();
                db.strCon.Open();

                string query = @"
                SELECT 
                    r.fld_Control_Number,
                    r.fld_Start_Date,
                    r.fld_End_Date,
                    r.fld_Start_Time,
                    r.fld_End_Time,
                    r.fld_Activity_Name,
                    r.fld_Total_Amount,
                    rp.fld_First_Name,
                    rp.fld_Surname,
                    rp.fld_Contact_Number
                FROM 
                    tbl_Reservation r
                LEFT JOIN 
                    tbl_Requesting_Person rp ON r.fk_Requesting_PersonID = rp.pk_Requesting_PersonID
                WHERE 
                    r.fld_Control_Number = @ControlNumber";

                using (SqlCommand cmd = new SqlCommand(query, db.strCon))
                {
                    cmd.Parameters.AddWithValue("@ControlNumber", controlNumber);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (reservationData.Rows.Count > 0)
            {
                DataRow row = reservationData.Rows[0];
                float yPos = e.MarginBounds.Top;
                int leftMargin = e.MarginBounds.Left;
                int rightMargin = e.MarginBounds.Right;

                using (Font printFont = new Font("Arial", 12))
                {
                    e.Graphics.DrawString("Reservation Details", new Font("Arial", 16, FontStyle.Bold), Brushes.Black, leftMargin, yPos);
                    yPos += 40;

                    e.Graphics.DrawString($"Control Number: {row["fld_Control_Number"]}", printFont, Brushes.Black, leftMargin, yPos);
                    yPos += 30;
                    e.Graphics.DrawString($"Activity Name: {row["fld_Activity_Name"]}", printFont, Brushes.Black, leftMargin, yPos);
                    yPos += 30;
                    e.Graphics.DrawString($"Start Date: {row["fld_Start_Date"]:d}", printFont, Brushes.Black, leftMargin, yPos);
                    yPos += 30;
                    e.Graphics.DrawString($"End Date: {row["fld_End_Date"]:d}", printFont, Brushes.Black, leftMargin, yPos);
                    yPos += 30;
                    e.Graphics.DrawString($"Start Time: {row["fld_Start_Time"]}", printFont, Brushes.Black, leftMargin, yPos);
                    yPos += 30;
                    e.Graphics.DrawString($"End Time: {row["fld_End_Time"]}", printFont, Brushes.Black, leftMargin, yPos);
                    yPos += 30;
                    e.Graphics.DrawString($"Total Amount: {row["fld_Total_Amount"]:C}", printFont, Brushes.Black, leftMargin, yPos);
                    yPos += 30;
                    e.Graphics.DrawString($"First Name: {row["fld_First_Name"]}", printFont, Brushes.Black, leftMargin, yPos);
                    yPos += 30;
                    e.Graphics.DrawString($"Surname: {row["fld_Surname"]}", printFont, Brushes.Black, leftMargin, yPos);
                    yPos += 30;
                    e.Graphics.DrawString($"Contact Number: {row["fld_Contact_Number"]}", printFont, Brushes.Black, leftMargin, yPos);
                }
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}

