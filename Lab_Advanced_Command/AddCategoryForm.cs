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
    public partial class AddCategoryForm : Form
    {
        private string connectionString = "Data Source=.;Initial Catalog=Restaurant Management;Integrated Security=True";

        // Sau khi insert thành công sẽ set giá trị này (SCOPE_IDENTITY)
        public int NewCategoryId { get; private set; } = -1;

        public AddCategoryForm()
        {
            InitializeComponent();

            cbbType.Items.Clear();
            cbbType.Items.Add("Food");   // index 0 -> giá trị 1
            cbbType.Items.Add("Drink");  // index 1 -> giá trị 0
            cbbType.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtCategoryName.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Vui lòng nhập tên nhóm món ăn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy type theo lựa chọn (nếu bạn muốn khác thì chỉnh)
            int typeValue;
            if (cbbType.SelectedIndex == 0) typeValue = 1; // Food
            else typeValue = 0; // Drink

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                // Insert + trả về ID mới bằng SCOPE_IDENTITY()
                cmd.CommandText = "INSERT INTO Category([Name],[Type]) VALUES (@name, @type); SELECT CAST(SCOPE_IDENTITY() AS INT);";
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add(new SqlParameter("@name", SqlDbType.NVarChar, 1000) { Value = name });
                cmd.Parameters.Add(new SqlParameter("@type", SqlDbType.Int) { Value = typeValue });

                try
                {
                    conn.Open();
                    object scalar = cmd.ExecuteScalar();
                    conn.Close();

                    if (scalar != null && int.TryParse(scalar.ToString(), out int newId))
                    {
                        NewCategoryId = newId;
                        MessageBox.Show("Thêm nhóm món ăn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Không thể lấy ID sau khi thêm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi truy vấn cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
