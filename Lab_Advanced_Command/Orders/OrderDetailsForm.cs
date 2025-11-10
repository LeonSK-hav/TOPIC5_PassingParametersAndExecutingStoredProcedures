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
    public partial class OrderDetailsForm : Form
    {
        private int billID;
        private string connectionString = "Data Source=.;Initial Catalog=Restaurant Management;Integrated Security=True";
        public OrderDetailsForm(int billID)
        {
            InitializeComponent();
            this.billID = billID;
        }

        private void OrderDetailsForm_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetBillDetailsByBillID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@BillID", SqlDbType.Int).Value = billID;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                try
                {
                    conn.Open();
                    adapter.Fill(dt);
                    dgvOrderDetails.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi truy vấn chi tiết hóa đơn: " + ex.Message);
                }
            }
        }
       
    }
}
