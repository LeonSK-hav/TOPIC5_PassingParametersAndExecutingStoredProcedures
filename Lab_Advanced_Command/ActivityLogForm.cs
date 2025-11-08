using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_Advanced_Command
{
    public partial class ActivityLogForm : Form
    {
        private string connectionString = "Data Source=.;Initial Catalog=Restaurant Management;Integrated Security=True";
        private string accountName;
        public ActivityLogForm(string account)
        {
            InitializeComponent();
            accountName = account;
        }

        private void ActivityLogForm_Load(object sender, EventArgs e)
        {
            lblTitle.Text = $"Nhật ký hoạt động của tài khoản: {accountName}";
            LoadBills();
        }
        private void LoadBills()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_GetBillsByAccount", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AccountName", accountName);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                lstInvoices.DisplayMember = "CheckoutDate";
                lstInvoices.ValueMember = "BillID";
                lstInvoices.DataSource = dt;

                lblTotalInvoices.Text = $"Tổng số hóa đơn: {dt.Rows.Count}";
                decimal total = 0;
                foreach (DataRow r in dt.Rows)
                    total += Convert.ToDecimal(r["TotalAmount"]);
                lblTotalAmount.Text = $"Tổng tiền: {total:N0} VNĐ";
            }
        }

        private void lstInvoices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstInvoices.SelectedValue == null) return;
            int billId = Convert.ToInt32(lstInvoices.SelectedValue);
            LoadBillDetails(billId);
        }
        private void LoadBillDetails(int billId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_GetBillDetails", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BillID", billId);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvInvoiceDetails.DataSource = dt;
            }
        }
    }
}
