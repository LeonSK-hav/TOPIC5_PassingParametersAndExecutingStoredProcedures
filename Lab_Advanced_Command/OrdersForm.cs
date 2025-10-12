using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_Advanced_Command
{
    public partial class OrdersForm : Form
    {
        private string connectionString = "Data Source=.;Initial Catalog=Restaurant Management;Integrated Security=True";
        public OrdersForm()
        {
            InitializeComponent();
        }

        private void OrdersForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetBillsByDateRange", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = dtpFrom.Value;
                cmd.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = dtpTo.Value;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                try
                {
                    conn.Open();
                    adapter.Fill(dt);
                    dgvOrders.DataSource = dt;

                    decimal totalBefore = 0;
                    decimal totalDiscount = 0;
                    decimal totalAfter = 0;

                    foreach (DataRow row in dt.Rows)
                    {
                        decimal amount = Convert.ToDecimal(row["Amount"]);
                        decimal discount = Convert.ToDecimal(row["Disscount"]);
                        decimal afterDiscount = amount * (1 - discount);

                        totalBefore += amount;
                        totalDiscount += amount * discount;
                        totalAfter += afterDiscount;
                    }

                    txtTotal.Text = totalBefore.ToString("N0");
                    txtDiscount.Text = totalDiscount.ToString("N0");
                    txtRevenue.Text = totalAfter.ToString("N0");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi truy vấn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int billID = Convert.ToInt32(dgvOrders.Rows[e.RowIndex].Cells["ID"].Value);
                OrderDetailsForm detailForm = new OrderDetailsForm(billID);
                detailForm.ShowDialog();
            }
        }
    }
}
